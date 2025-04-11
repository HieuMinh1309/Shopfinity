using System;
using System.Collections.Generic;

namespace SSE_Project.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? ProductName { get; set; }

    public int CateId { get; set; }

    public int BrandId { get; set; }

    public decimal? Price { get; set; }

    public int? UnitId { get; set; }

    public string? Img { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }

    public int? Weight { get; set; }

    public int? Height { get; set; }

    public int? Width { get; set; }

    public int? Length { get; set; }

    public int? WarrantyPeriod { get; set; }

    public virtual Brand Brand { get; set; } = null!;

    public virtual ProductCategory Cate { get; set; } = null!;
    public virtual Unit? Unit { get; set; }


    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Conversion> Conversions { get; set; } = new List<Conversion>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<ProductImg> ProductImgs { get; set; } = new List<ProductImg>();

    public virtual ICollection<ProductPriceChange> ProductPriceChanges { get; set; } = new List<ProductPriceChange>();

    public virtual ICollection<ProductSpecification> ProductSpecifications { get; set; } = new List<ProductSpecification>();

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();

}
