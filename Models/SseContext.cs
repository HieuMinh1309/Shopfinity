using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SSE_Project.Models;

public partial class SseContext : DbContext
{
    public SseContext()
    {
    }

    public SseContext(DbContextOptions<SseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BannedKeyword> BannedKeywords { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<ChatMessage> ChatMessages { get; set; }

    public virtual DbSet<ChatRoom> ChatRooms { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Conversion> Conversions { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeSalaryHistory> EmployeeSalaryHistories { get; set; }

    public virtual DbSet<EmployeeWarehouse> EmployeeWarehouses { get; set; }

    public virtual DbSet<ExpenseHistory> ExpenseHistories { get; set; }

    public virtual DbSet<ExpenseType> ExpenseTypes { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductImg> ProductImgs { get; set; }

    public virtual DbSet<ProductPriceChange> ProductPriceChanges { get; set; }

    public virtual DbSet<ProductSpecification> ProductSpecifications { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<RequestDetail> RequestDetails { get; set; }

    public virtual DbSet<ReturnOrder> ReturnOrders { get; set; }

    public virtual DbSet<ReturnOrderDetail> ReturnOrderDetails { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SalaryType> SalaryTypes { get; set; }

    public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<TaxHistory> TaxHistories { get; set; }

    public virtual DbSet<TblDiscount> TblDiscounts { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    public virtual DbSet<WarehouseReceipt> WarehouseReceipts { get; set; }

    public virtual DbSet<WarehouseReceiptDetail> WarehouseReceiptDetails { get; set; }

    public virtual DbSet<WarehouseReleasenote> WarehouseReleasenotes { get; set; }

    public virtual DbSet<WarehouseRnDetail> WarehouseRnDetails { get; set; }

    public virtual DbSet<WarehouseType> WarehouseTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-BSKTEGQ;Initial Catalog=SSE;Persist Security Info=True;User ID=sa;Password=123456;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BannedKeyword>(entity =>
        {
            entity.ToTable("banned_keywords");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IsActive)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("is_active");
            entity.Property(e => e.Keyword)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("keyword");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.ToTable("Brand");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ChatMessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Chat_Mes__3213E83FE1CF2755");

            entity.ToTable("Chat_Message");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ChatroomId).HasColumnName("chatroom_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.IsRead).HasColumnName("is_read");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.SenderType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sender_type");
            entity.Property(e => e.Timestamp)
                .HasColumnType("datetime")
                .HasColumnName("timestamp");

            entity.HasOne(d => d.Chatroom).WithMany(p => p.ChatMessages)
                .HasForeignKey(d => d.ChatroomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Chat_Message_Chat_Room");
        });

        modelBuilder.Entity<ChatRoom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ChatRoom__465962293B9217F1");

            entity.ToTable("Chat_Room");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.LastActivity)
                .HasColumnType("datetime")
                .HasColumnName("last_activity");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("WAITING")
                .HasColumnName("status");

            entity.HasOne(d => d.Order).WithMany(p => p.ChatRooms)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Chat_Room_Order");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.ToTable("comments");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content)
                .HasColumnType("text")
                .HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK_comments_comments");

            entity.HasOne(d => d.Product).WithMany(p => p.Comments)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_comments_Product");
        });

        modelBuilder.Entity<Conversion>(entity =>
        {
            entity.ToTable("Conversion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ConversionRate).HasColumnName("Conversion_rate");
            entity.Property(e => e.FromUnitId).HasColumnName("From_unit_id");
            entity.Property(e => e.ProductId).HasColumnName("Product_Id");
            entity.Property(e => e.ToUnitId).HasColumnName("To_unit_id");

            entity.HasOne(d => d.FromUnit).WithMany(p => p.ConversionFromUnits)
                .HasForeignKey(d => d.FromUnitId)
                .HasConstraintName("FK_Conversion_Unit");

            entity.HasOne(d => d.Product).WithMany(p => p.Conversions)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Conversion_Product");

            entity.HasOne(d => d.ToUnit).WithMany(p => p.ConversionToUnits)
                .HasForeignKey(d => d.ToUnitId)
                .HasConstraintName("FK_Conversion_Unit1");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.CreationTime)
                .HasColumnType("datetime")
                .HasColumnName("Creation_time");
            entity.Property(e => e.Dob).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("First_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("Last_name");
            entity.Property(e => e.Password).HasColumnType("text");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_name");
            entity.Property(e => e.Password).IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RoleId).HasColumnName("Role_Id");

            entity.HasOne(d => d.Role).WithMany(p => p.Employees)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_Employee_Role");
        });

        modelBuilder.Entity<EmployeeSalaryHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC075CB79263");

            entity.ToTable("Employee_Salary_History");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");
            entity.Property(e => e.EndDate).HasColumnName("End_Date");
            entity.Property(e => e.SalaryTypeId).HasColumnName("Salary_Type_Id");
            entity.Property(e => e.StartDate).HasColumnName("Start_Date");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeSalaryHistories)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__Employee___Emplo__0F624AF8");

            entity.HasOne(d => d.SalaryType).WithMany(p => p.EmployeeSalaryHistories)
                .HasForeignKey(d => d.SalaryTypeId)
                .HasConstraintName("FK__Employee___Salar__10566F31");
        });

        modelBuilder.Entity<EmployeeWarehouse>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("employee_warehouse");

            entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.WarehouseId).HasColumnName("Warehouse_Id");

            entity.HasOne(d => d.Warehouse).WithMany()
                .HasForeignKey(d => d.WarehouseId)
                .HasConstraintName("FK_employee_warehouse_Warehouse");
        });

        modelBuilder.Entity<ExpenseHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Expense___3214EC0707747A40");

            entity.ToTable("Expense_History");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.EndDate).HasColumnName("End_Date");
            entity.Property(e => e.ExpenseTypeId).HasColumnName("Expense_Type_Id");
            entity.Property(e => e.StartDate).HasColumnName("Start_Date");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("Updated_At");

            entity.HasOne(d => d.ExpenseType).WithMany(p => p.ExpenseHistories)
                .HasForeignKey(d => d.ExpenseTypeId)
                .HasConstraintName("FK__Expense_H__Expen__123EB7A3");
        });

        modelBuilder.Entity<ExpenseType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Expense___3214EC07C45C458E");

            entity.ToTable("Expense_Types");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.IsActive)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Yes")
                .HasColumnName("Is_Active");
            entity.Property(e => e.IsFixed)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("No")
                .HasColumnName("Is_Fixed");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("Updated_At");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.ToTable("Feedback");

            entity.Property(e => e.Comment).IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetail_Id");
            entity.Property(e => e.ProductId).HasColumnName("Product_Id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Product).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Feedback_Product");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.Address).IsUnicode(false);
            entity.Property(e => e.CouponId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("coupon_id");
            entity.Property(e => e.CusName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Cus_Name");
            entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Discount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("discount");
            entity.Property(e => e.DistrictId).HasColumnName("District_Id");
            entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");
            entity.Property(e => e.ExpectedDeliveryTime).HasColumnName("expected_delivery_time");
            entity.Property(e => e.GhnOrderCode).HasColumnName("ghn_order_code");
            entity.Property(e => e.Notes)
                .IsUnicode(false)
                .HasColumnName("notes");
            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("OrderID");
            entity.Property(e => e.PayStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Pay_status");
            entity.Property(e => e.PaymentId).HasColumnName("Payment_Id");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ProvinceId).HasColumnName("Province_Id");
            entity.Property(e => e.ShippingFee)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("shippingFee");
            entity.Property(e => e.ShippingStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("shipping_status");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("totalAmount");
            entity.Property(e => e.TrackingCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tracking_code");
            entity.Property(e => e.TransactionId)
                .IsUnicode(false)
                .HasColumnName("Transaction_id");
            entity.Property(e => e.WardId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Ward_Id");
            entity.Property(e => e.WarehouseId).HasColumnName("Warehouse_Id");

            entity.HasOne(d => d.Coupon).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CouponId)
                .HasConstraintName("FK_Order_tbl_coupon");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Order_Customer");

            entity.HasOne(d => d.Employee).WithMany(p => p.Orders)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_Order_Employee");

            entity.HasOne(d => d.Payment).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PaymentId)
                .HasConstraintName("FK_Order_Payment");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.ToTable("Order_detail");

            entity.Property(e => e.OrderId).HasColumnName("Order_Id");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductId).HasColumnName("Product_Id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StockId).HasColumnName("Stock_Id");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_Order_detail_Order");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.ToTable("Payment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.BrandId).HasColumnName("Brand_Id");
            entity.Property(e => e.CateId).HasColumnName("Cate_Id");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Img).IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Product_name");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UnitId).HasColumnName("Unit_id");
            entity.Property(e => e.WarrantyPeriod).HasColumnName("Warranty_period");

            entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Brand");

            entity.HasOne(d => d.Cate).WithMany(p => p.Products)
                .HasForeignKey(d => d.CateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Product_category");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.ToTable("Product_category");

            entity.Property(e => e.CateName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Cate_name");
        });

        modelBuilder.Entity<ProductImg>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_produc_img");

            entity.ToTable("product_img");

            entity.Property(e => e.ImgUrl)
                .IsUnicode(false)
                .HasColumnName("Img_url");
            entity.Property(e => e.ProductId).HasColumnName("Product_Id");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductImgs)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_produc_img_Product");
        });

        modelBuilder.Entity<ProductPriceChange>(entity =>
        {
            entity.ToTable("Product_price_change");

            entity.Property(e => e.DateEnd)
                .HasColumnType("datetime")
                .HasColumnName("Date_end");
            entity.Property(e => e.DateStart)
                .HasColumnType("datetime")
                .HasColumnName("Date_start");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductId).HasColumnName("Product_Id");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductPriceChanges)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_price_change_Product1");
        });

        modelBuilder.Entity<ProductSpecification>(entity =>
        {
            entity.ToTable("product_specifications");

            entity.Property(e => e.DesSpe)
                .IsUnicode(false)
                .HasColumnName("Des_spe");
            entity.Property(e => e.NameSpe)
                .IsUnicode(false)
                .HasColumnName("Name_spe");
            entity.Property(e => e.ProductId).HasColumnName("Product_Id");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductSpecifications)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_product_specifications_Product");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.ToTable("Request");

            entity.Property(e => e.EmployeeId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Employee_Id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OrderId).HasColumnName("Order_Id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WarehouseId).HasColumnName("Warehouse_Id");
        });

        modelBuilder.Entity<RequestDetail>(entity =>
        {
            entity.ToTable("Request_detail");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdProduct).HasColumnName("Id_product");
            entity.Property(e => e.QuantityExported).HasColumnName("Quantity_exported");
            entity.Property(e => e.QuantityRequested).HasColumnName("Quantity_requested");
            entity.Property(e => e.RequestId).HasColumnName("Request_Id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Request).WithMany(p => p.RequestDetails)
                .HasForeignKey(d => d.RequestId)
                .HasConstraintName("FK_Request_detail_Request");
        });

        modelBuilder.Entity<ReturnOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Return_O__3214EC075C522C8A");

            entity.ToTable("Return_Order");

            entity.Property(e => e.DiscountAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Discount_Amount");
            entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");
            entity.Property(e => e.FinalAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Final_Amount");
            entity.Property(e => e.Message).IsUnicode(false);
            entity.Property(e => e.Note).IsUnicode(false);
            entity.Property(e => e.OrderId).HasColumnName("Order_Id");
            entity.Property(e => e.ReturnDate)
                .HasColumnType("datetime")
                .HasColumnName("Return_Date");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Total_Amount");

            entity.HasOne(d => d.Order).WithMany(p => p.ReturnOrders)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_Return_Order_Order");
        });

        modelBuilder.Entity<ReturnOrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Return_O__3214EC074D5A1665");

            entity.ToTable("Return_Order_Detail");

            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.OrderDetailId).HasColumnName("Order_Detail_Id");
            entity.Property(e => e.Reason).HasColumnType("text");
            entity.Property(e => e.ReturnOrderId).HasColumnName("Return_Order_Id");

            entity.HasOne(d => d.ReturnOrder).WithMany(p => p.ReturnOrderDetails)
                .HasForeignKey(d => d.ReturnOrderId)
                .HasConstraintName("FK_Return_Order_Detail_Return_Order");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SalaryType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Salary_T__3214EC071A307410");

            entity.ToTable("Salary_Types");

            entity.Property(e => e.IsActive)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Yes")
                .HasColumnName("Is_Active");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<ShoppingCart>(entity =>
        {
            entity.ToTable("shopping_cart");

            entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");
            entity.Property(e => e.ProductId).HasColumnName("Product_Id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Customer).WithMany(p => p.ShoppingCarts)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_shopping_cart_Customer");
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.ToTable("Stock");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdProduct).HasColumnName("Id_product");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WhRcDtId).HasColumnName("Wh_rc_dt_Id");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Stocks)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("FK_Stock_Product");

            entity.HasOne(d => d.WhRcDt).WithMany(p => p.Stocks)
                .HasForeignKey(d => d.WhRcDtId)
                .HasConstraintName("FK_Stock_Warehouse_receipt_detail");
        });

        modelBuilder.Entity<TaxHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tax_Hist__3214EC07A07F9EFB");

            entity.ToTable("Tax_History");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.PaymentDate).HasColumnName("Payment_Date");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Payment_Status");
            entity.Property(e => e.PeriodEnd).HasColumnName("Period_End");
            entity.Property(e => e.PeriodStart).HasColumnName("Period_Start");
            entity.Property(e => e.TaxAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Tax_Amount");
            entity.Property(e => e.TaxRate)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Tax_Rate");
            entity.Property(e => e.TaxType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Tax_Type");
        });

        modelBuilder.Entity<TblDiscount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_coup__3213E83F49AA6758");

            entity.ToTable("tbl_discount");

            entity.HasIndex(e => e.Code, "UQ__tbl_coup__357D4CF93A305A74").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.DiscountAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("discount_amount");
            entity.Property(e => e.DiscountPercentage)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("discount_percentage");
            entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");
            entity.Property(e => e.ExpiryDate).HasColumnName("expiry_date");
            entity.Property(e => e.MaxDiscountAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("max_discount_amount");
            entity.Property(e => e.MinOrderValue)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("min_order_value");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.ToTable("Unit");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.ToTable("Warehouse");

            entity.Property(e => e.Address).IsUnicode(false);
            entity.Property(e => e.DistrictId).HasColumnName("District_Id");
            entity.Property(e => e.GhnStoreId).HasColumnName("ghn_store_id");
            entity.Property(e => e.Lat)
                .HasColumnType("decimal(12, 8)")
                .HasColumnName("lat");
            entity.Property(e => e.Lng)
                .HasColumnType("decimal(12, 8)")
                .HasColumnName("lng");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProvinceId).HasColumnName("Province_Id");
            entity.Property(e => e.WardId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Ward_Id");
            entity.Property(e => e.WhTypeId).HasColumnName("Wh_type_Id");

            entity.HasOne(d => d.WhType).WithMany(p => p.Warehouses)
                .HasForeignKey(d => d.WhTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Warehouse_Warehouse_type");
        });

        modelBuilder.Entity<WarehouseReceipt>(entity =>
        {
            entity.ToTable("Warehouse_receipt");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Employee_Id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OtherFee)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Other_fee");
            entity.Property(e => e.ShippingFee)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Shipping_fee");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TotalFee)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Total_fee");
            entity.Property(e => e.WhId).HasColumnName("Wh_Id");

            entity.HasOne(d => d.Wh).WithMany(p => p.WarehouseReceipts)
                .HasForeignKey(d => d.WhId)
                .HasConstraintName("FK_Warehouse_receipt_Warehouse");
        });

        modelBuilder.Entity<WarehouseReceiptDetail>(entity =>
        {
            entity.ToTable("Warehouse_receipt_detail");

            entity.Property(e => e.ConversionId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Conversion_Id");
            entity.Property(e => e.ProductId).HasColumnName("Product_Id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WhPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Wh_price");
            entity.Property(e => e.WhReceiptId).HasColumnName("Wh_receiptId");

            entity.HasOne(d => d.WhReceipt).WithMany(p => p.WarehouseReceiptDetails)
                .HasForeignKey(d => d.WhReceiptId)
                .HasConstraintName("FK_Warehouse_receipt_detail_Warehouse_receipt");
        });

        modelBuilder.Entity<WarehouseReleasenote>(entity =>
        {
            entity.ToTable("Warehouse_releasenote");

            entity.Property(e => e.EmployeeId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Employee_Id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OrderId).HasColumnName("Order_Id");
            entity.Property(e => e.RequestId).HasColumnName("Request_Id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WarehouseId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Warehouse_Id");

            entity.HasOne(d => d.Order).WithMany(p => p.WarehouseReleasenotes)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_Warehouse_releasenote_Order");

            entity.HasOne(d => d.Request).WithMany(p => p.WarehouseReleasenotes)
                .HasForeignKey(d => d.RequestId)
                .HasConstraintName("FK_Warehouse_releasenote_Request");
        });

        modelBuilder.Entity<WarehouseRnDetail>(entity =>
        {
            entity.ToTable("Warehouse_rn_detail");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdProduct).HasColumnName("Id_product");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StockId).HasColumnName("Stock_Id");
            entity.Property(e => e.WgrnId).HasColumnName("Wgrn_Id");

            entity.HasOne(d => d.Stock).WithMany(p => p.WarehouseRnDetails)
                .HasForeignKey(d => d.StockId)
                .HasConstraintName("FK_Warehouse_rn_detail_Stock1");

            entity.HasOne(d => d.Wgrn).WithMany(p => p.WarehouseRnDetails)
                .HasForeignKey(d => d.WgrnId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Warehouse_rn_detail_Warehouse_releasenote");
        });

        modelBuilder.Entity<WarehouseType>(entity =>
        {
            entity.ToTable("Warehouse_type");

            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
