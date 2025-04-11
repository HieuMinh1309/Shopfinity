using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SSE_Project.Areas.Admin.Interfaces;
using SSE_Project.Models;

namespace SSE_Project.Areas.Admin.Controllers;
[Area("Admin")]
[Route("Admin/Product")]
public class ProductController : Controller
{
    private readonly ICrudProduct _products;
    private readonly ICrudConversion _conversion;

    public ProductController(ICrudProduct products, ICrudConversion conversion)
    {
        _products = products;
        _conversion = conversion;
    }

    [HttpGet]
    [Route("GetListProduct")]
    public  IActionResult GetListProduct()
    {
        var products = _products.GetProducts();
        return Ok(products);
    }

    [HttpGet("GetProductById/{id}")]
    public IActionResult GetProductById(int id)
    {
        var product = _products.GetProductById(id);

        if (product == null)
        {
            return NotFound();
        }

        return Ok(new
        {
            product.Id,
            product.ProductName,
            product.UnitId,
            Unit = product.Unit != null ? new { product.Unit.Id, product.Unit.Name } : null
        });
    }



    [Route("~/")]
    [HttpGet]
    [Route("ShowListProduct")]
    public IActionResult ShowListProduct()
    {
        return View();
    }

    [HttpGet]
    [Route("ShowAddProduct")]
    public IActionResult ShowAddProuct()
    {
        ViewBag.Categories = _products.GetCategories();
        ViewBag.Brands = _products.GetBrands();
        ViewBag.Units = _products.GetUnits();
        return View();
    }

    [HttpPost]
    [Route("AddProduct")]
    public async Task<IActionResult> AddProduct([FromForm] Product product,
                                           [FromForm] IFormFile MainImage,
                                           [FromForm] List<IFormFile> AdditionalImages,
                                           [FromForm] List<ProductPriceChange> PriceChanges,
                                           [FromForm] List<ProductSpecification> Specifications)
    {
        try
        {
            bool isSuccess = await _products.AddProductWithDetails(product, PriceChanges, AdditionalImages, Specifications, MainImage);

            if (isSuccess)
            {               
                return RedirectToAction("ShowListProduct");
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to add product.";
                return RedirectToAction("ShowAddProduct");
            }
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = "Error adding product: " + ex.Message;
            return RedirectToAction("ShowAddProduct");
        }
    }


    [HttpPost]
    [Route("DeleteProduct")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        bool isDelete = await _products.DeleteProduct(id);
        if (isDelete)
        {
            return Json(new { success = true, message = "delete successfully" });
        }
        return Json(new { success = false, message = "delete failed" });
    }

    [HttpGet]
    [Route("ShowUpdateProduct/{id}")]
    public IActionResult ShowUpdateProduct(int id)
    {
        Console.WriteLine($"Loading product with ID: {id}");

        var product = _products.GetProductById(id);
        if (product == null)
        {
            TempData["ErrorMessage"] = "Product not found.";
            return RedirectToAction("ShowListProduct");
        }

        ViewBag.Categories = _products.GetCategories();
        ViewBag.Brands = _products.GetBrands();
        ViewBag.Units = _products.GetUnits();

        // Get a list of additional product images

        ViewBag.AdditionalImages = _products.GetProductImages(id);

        //Get price change list

        ViewBag.PriceChanges = _products.GetPriceChanges(id);

        // Get the digital list
        ViewBag.Specifications = _products.GetProductSpecifications(id);

        return View(product);
    }


    [HttpPost]
    [Route("UpdateProduct")]
    public async Task<IActionResult> UpdateProduct([FromForm] Product product,
                                                  [FromForm] IFormFile? MainImage,
                                                  [FromForm] List<IFormFile>? AdditionalImages,
                                                  [FromForm] List<ProductPriceChange>? PriceChanges,
                                                  [FromForm] List<ProductSpecification>? Specifications)
    {
        try
        {
            bool isSuccess = await _products.UpdateProduct(product, PriceChanges, AdditionalImages, Specifications, MainImage);

            if (isSuccess)
            {
                return RedirectToAction("ShowListProduct");
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to update product.";
                return RedirectToAction("ShowUpdateProduct", new { id = product.Id });
            }
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = "Error updating product: " + ex.Message;
            return RedirectToAction("ShowUpdateProduct", new { id = product.Id });
        }
    }


    [HttpGet]
    [Route("GetProductDetail/{id}")]
    public IActionResult GetProductDetail(int id)
    {
        var product = _products.GetProductDetailId(id);
        if (product == null)
        {
            return NotFound(new { message = "Product not found!" });
        }

        ViewBag.ProductId = id;
        ViewBag.ProductImages = _products.GetProductImages(id);

        return View(product);
    }



}
