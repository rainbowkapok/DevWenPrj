using System;
using System.Collections.Generic;

namespace DevWenPrj.Models;

public partial class OrderStatus訂單狀態
{
    public int OrdStatusId訂單狀態編號 { get; set; }

    public string OrdName訂單狀態名稱 { get; set; } = null!;

    public virtual ICollection<Order訂單總表> Order訂單總表s { get; } = new List<Order訂單總表>();
}
