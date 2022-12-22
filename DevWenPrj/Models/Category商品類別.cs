using System;
using System.Collections.Generic;

namespace DevWenPrj.Models;

public partial class Category商品類別
{
    public int Id類別編號 { get; set; }

    public string CategoryName類別名稱 { get; set; } = null!;

    public virtual ICollection<Product商品> Product商品s { get; } = new List<Product商品>();
}
