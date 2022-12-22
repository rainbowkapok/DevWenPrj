using System;
using System.Collections.Generic;

namespace DevWenPrj.Models;

public partial class Order訂單總表
{
    public int OrdId訂單編號 { get; set; }

    public int StoreId各店編號 { get; set; }

    public int OrdStatusId訂單狀態編號 { get; set; }

    public DateTime OrdDate訂單日期 { get; set; }

    public virtual OrderStatus訂單狀態 OrdStatusId訂單狀態編號Navigation { get; set; } = null!;

    public virtual ICollection<Receipt購買商品明細> Receipt購買商品明細s { get; } = new List<Receipt購買商品明細>();

    public virtual Store各分店 StoreId各店編號Navigation { get; set; } = null!;
}
