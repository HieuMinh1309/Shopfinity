using SSE_Project.Models;

namespace SSE_Project.Areas.Admin.Interfaces;

public interface ICrudProduct
{
    IEnumerable<object> GetProducts();
    Task<bool> AddProductWithDetails(Product product,
                                                  List<ProductPriceChange> priceChanges,
                                                  List<IFormFile> additionalImages,
                                                  List<ProductSpecification> specifications,
                                                  IFormFile mainImage);
    //get categories
    IEnumerable<ProductCategory> GetCategories();
    //get units
    IEnumerable<Unit> GetUnits();
    // get brands
    IEnumerable<Brand> GetBrands();
    //delete product
    Task<bool> DeleteProduct(int productId);
    //Update Product
    Task<bool> UpdateProduct(Product product,
                                      List<ProductPriceChange> priceChanges,
                                      List<IFormFile> additionalImages,
                                      List<ProductSpecification> specifications,
                                      IFormFile mainImage);
    //Get Product by Id
    Product GetProductById(int id);
    //Get Product Detail by Id
    ProductDetail GetProductDetailId(int id);
    // Get List Images
    IEnumerable<ProductImg> GetProductImages(int productId);
    // Get List Specification
    IEnumerable<ProductPriceChange> GetPriceChanges(int productId);
    //Get List Specifications
    IEnumerable<ProductSpecification> GetProductSpecifications(int productId);

}
