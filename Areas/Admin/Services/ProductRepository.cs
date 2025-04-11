using Microsoft.EntityFrameworkCore;
using SSE_Project.Areas.Admin.Interfaces;
using SSE_Project.Models;

namespace SSE_Project.Areas.Admin.Services;

public class ProductRepository : ICrudProduct
{
    private readonly SseContext _context;
    public ProductRepository(SseContext context)
    {
        _context = context;
    }

    public IEnumerable<object> GetProducts()
    {
        var products = from p in _context.Products
                       join u in _context.Units on p.UnitId equals u.Id into unitGroup
                       from u in unitGroup.DefaultIfEmpty()  
                       select new
                       {
                           id = p.Id,
                           productName = p.ProductName,
                           categoryName = p.Cate != null ? p.Cate.CateName : "N/A",
                           brandName = p.Brand != null ? p.Brand.Name : "N/A",
                           price = p.Price,
                           unitName = u != null ? u.Name : "N/A", 
                           img = p.Img,
                           status = p.Status,
                           warrantyPeriod = p.WarrantyPeriod
                       };

        return products.ToList();
    }


    public IEnumerable<ProductCategory> GetCategories()
    {
        return _context.ProductCategories.ToList();
    }

    public IEnumerable<Unit> GetUnits()
    {
        return _context.Units.ToList();
    }

    public IEnumerable<Brand> GetBrands()
    {
        return _context.Brands.ToList();
    }

    public async Task<bool> DeleteProduct(int productId)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return false; 
            }

            // delete price changes
            var priceChanges = _context.ProductPriceChanges.Where(pc => pc.ProductId == productId);
            _context.ProductPriceChanges.RemoveRange(priceChanges);

            // delete Img
            var productImages = _context.ProductImgs.Where(img => img.ProductId == productId);
            _context.ProductImgs.RemoveRange(productImages);

            // delete specifications
            var specifications = _context.ProductSpecifications.Where(spec => spec.ProductId == productId);
            _context.ProductSpecifications.RemoveRange(specifications);

            // delete main image
            if (!string.IsNullOrEmpty(product.Img))
            {
                string mainImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", product.Img.TrimStart('/'));
                if (System.IO.File.Exists(mainImagePath))
                {
                    System.IO.File.Delete(mainImagePath);
                }
            }

            // delete product
            _context.Products.Remove(product);

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return true;
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            return false;
        }
    }


    public async Task<bool> UpdateProduct(Product product,
                                      List<ProductPriceChange> priceChanges,
                                      List<IFormFile> additionalImages,
                                      List<ProductSpecification> specifications,
                                      IFormFile mainImage)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            if (product == null)
            {
                Console.WriteLine("Product is null");
                return false;
            }

            var existingProduct = await _context.Products
                                                .FirstOrDefaultAsync(p => p.Id == product.Id);
            if (existingProduct == null)
            {
                Console.WriteLine("Product not found in database");
                return false;
            }

            string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            // **Cập nhật ảnh chính nếu có**
            if (mainImage != null && mainImage.Length > 0)
            {
                string mainImageFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(mainImage.FileName);
                string mainImageFilePath = Path.Combine(uploadsFolder, mainImageFileName);

                using (var fileStream = new FileStream(mainImageFilePath, FileMode.Create))
                {
                    await mainImage.CopyToAsync(fileStream);
                }

                // Xóa ảnh cũ nếu tồn tại
                if (!string.IsNullOrEmpty(existingProduct.Img))
                {
                    string oldImagePath = Path.Combine(uploadsFolder, existingProduct.Img.TrimStart('/'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                existingProduct.Img = "/images/" + mainImageFileName;
            }

            // **Cập nhật thông tin sản phẩm**
            existingProduct.ProductName = product.ProductName;
            existingProduct.CateId = product.CateId;
            existingProduct.BrandId = product.BrandId;
            existingProduct.Price = product.Price;
            existingProduct.UnitId = product.UnitId;
            existingProduct.Status = product.Status;
            existingProduct.Description = product.Description;

            // **Cập nhật giá sản phẩm**
            if (priceChanges != null && priceChanges.Any())
            {
                foreach (var priceChange in priceChanges)
                {
                    priceChange.ProductId = product.Id;
                    _context.ProductPriceChanges.Add(priceChange);
                }
            }

            // **Cập nhật hình ảnh bổ sung**
            if (additionalImages != null && additionalImages.Any())
            {
                var existingImages = _context.ProductImgs.Where(img => img.ProductId == product.Id).ToList();

                // Xóa ảnh cũ
                foreach (var oldImage in existingImages)
                {
                    string oldImagePath = Path.Combine(uploadsFolder, oldImage.ImgUrl.TrimStart('/'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                    _context.ProductImgs.Remove(oldImage);
                }

                // Thêm ảnh mới
                foreach (var image in additionalImages)
                {
                    if (image.Length > 0)
                    {
                        string additionalImageFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(image.FileName);
                        string additionalImageFilePath = Path.Combine(uploadsFolder, additionalImageFileName);

                        using (var fileStream = new FileStream(additionalImageFilePath, FileMode.Create))
                        {
                            await image.CopyToAsync(fileStream);
                        }

                        var newProductImg = new ProductImg
                        {
                            ProductId = product.Id,
                            ImgUrl = "/images/" + additionalImageFileName
                        };

                        _context.ProductImgs.Add(newProductImg);
                    }
                }
            }

            // **Cập nhật thông số kỹ thuật**
            if (specifications != null && specifications.Any())
            {
                var existingSpecs = _context.ProductSpecifications.Where(s => s.ProductId == product.Id).ToList();
                _context.ProductSpecifications.RemoveRange(existingSpecs); // Xóa thông số cũ

                foreach (var spec in specifications)
                {
                    spec.ProductId = product.Id;
                    _context.ProductSpecifications.Add(spec);
                }
            }

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return true;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            Console.WriteLine($"Error! Update Product {ex.Message}");
            return false;
        }
    }


    public Product? GetProductById(int id)
    {
        try
        {
            return _context.Products
                .Include(p => p.Unit) 
                .FirstOrDefault(p => p.Id == id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while fetching Product with ID: {id}, {ex.Message}");
            return null;
        }
    }


    public ProductDetail GetProductDetailId(int id)
    {
        var product = (from p in _context.Products
                       join c in _context.ProductCategories on p.CateId equals c.Id
                       join b in _context.Brands on p.BrandId equals b.Id
                       join u in _context.Units on p.UnitId equals u.Id into unitJoin
                       from u in unitJoin.DefaultIfEmpty()
                       where p.Id == id
                       select new ProductDetail
                       {
                           Id = p.Id,
                           ProductName = p.ProductName,
                           CategoryName = c.CateName,
                           BrandName = b.Name,
                           Price = (decimal)p.Price,
                           UnitName = u != null ? u.Name : "N/A",
                           Description = p.Description,
                           Img = p.Img,
                           Status = p.Status
                       }).FirstOrDefault();

        return product;
    }

    public async Task<bool> AddProductWithDetails(Product product,
                                              List<ProductPriceChange> priceChanges,
                                              List<IFormFile> additionalImages,
                                              List<ProductSpecification> specifications,
                                              IFormFile mainImage)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            // Image main
            if (mainImage != null && mainImage.Length > 0)
            {
                string mainImageFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(mainImage.FileName);
                string mainImageFilePath = Path.Combine(uploadsFolder, mainImageFileName);

                using (var fileStream = new FileStream(mainImageFilePath, FileMode.Create))
                {
                    await mainImage.CopyToAsync(fileStream);
                }

                product.Img = "/images/" + mainImageFileName;
            }
            else
            {
                throw new Exception("Main image is required.");
            }

            // Save product
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            // Save price changes
            ProductPriceChange newPriceChange = new ProductPriceChange
            {
                ProductId = product.Id,
                Price = product.Price, 
                DateStart = DateTime.UtcNow, 
                DateEnd = null 
            };
            _context.ProductPriceChanges.Add(newPriceChange);

            // Save additionalImages
            if (additionalImages != null && additionalImages.Any())
            {
                foreach (var image in additionalImages)
                {
                    if (image.Length > 0)
                    {
                        string additionalImageFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(image.FileName);
                        string additionalImageFilePath = Path.Combine(uploadsFolder, additionalImageFileName);

                        using (var fileStream = new FileStream(additionalImageFilePath, FileMode.Create))
                        {
                            await image.CopyToAsync(fileStream);
                        }

                        var productImage = new ProductImg
                        {
                            ProductId = product.Id,
                            ImgUrl = "/images/" + additionalImageFileName
                        };

                        _context.ProductImgs.Add(productImage);
                    }
                }
            }

            // Save specifications
            if (specifications != null && specifications.Any())
            {
                foreach (var spec in specifications)
                {
                    spec.ProductId = product.Id;
                    _context.ProductSpecifications.Add(spec);
                }
            }

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return true;
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            return false;
        }
    }

    public IEnumerable<ProductImg> GetProductImages(int productId)
    {
        return _context.ProductImgs
                       .Where(img => img.ProductId == productId)
                       .ToList();
    }

    public IEnumerable<ProductPriceChange> GetPriceChanges(int productId)
    {
        return _context.ProductPriceChanges
                       .Where(pc => pc.ProductId == productId)
                       .ToList();
    }

    public IEnumerable<ProductSpecification> GetProductSpecifications(int productId)
    {
        return _context.ProductSpecifications
                       .Where(spec => spec.ProductId == productId)
                       .ToList();
    }
}
