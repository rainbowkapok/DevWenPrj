using System;
using System.Collections.Generic;

namespace DevWenPrj.Models;

public partial class Product商品
{
    public int Id產品編號 { get; set; }

    public string? Name產品名稱 { get; set; }

    public decimal? Price價格 { get; set; }

    public string? Path圖片路徑 { get; set; }

    public int? Id類別編號 { get; set; }

    public bool? Shelf上架 { get; set; }

    public virtual Category商品類別? Id類別編號Navigation { get; set; }

    public virtual ICollection<Receipt購買商品明細> Receipt購買商品明細s { get; } = new List<Receipt購買商品明細>();
}
