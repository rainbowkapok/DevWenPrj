using System;
using System.Collections.Generic;

namespace DevWenPrj.Models;

public partial class Store各分店
{
    public int StoreId各店編號 { get; set; }

    public string StoreName店名 { get; set; } = null!;

    public string? Address地址 { get; set; }

    public string? Tel電話 { get; set; }

    public virtual ICollection<Order訂單總表> Order訂單總表s { get; } = new List<Order訂單總表>();
}
