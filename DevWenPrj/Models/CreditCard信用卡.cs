using System;
using System.Collections.Generic;

namespace DevWenPrj.Models;

public partial class CreditCard信用卡
{
    public int Cid信用卡流水號 { get; set; }

    public string Cname信用卡公司名 { get; set; } = null!;

    public string Cnum信用卡號 { get; set; } = null!;

    public bool? Cuse使用狀態 { get; set; }

    public virtual ICollection<Member會員> Member會員s { get; } = new List<Member會員>();
}
