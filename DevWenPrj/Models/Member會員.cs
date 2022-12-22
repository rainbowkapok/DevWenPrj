using System;
using System.Collections.Generic;

namespace DevWenPrj.Models;

public partial class Member會員
{
    public int Id會員編號 { get; set; }

    public string Name會員名稱 { get; set; } = null!;

    public string Email信箱 { get; set; } = null!;

    public string Phone手機號碼 { get; set; } = null!;

    public int Cid信用卡流水號 { get; set; }

    public int Permission權限 { get; set; }

    public int? Bonus紅利 { get; set; }

    public DateTime CreatedTime建立時間 { get; set; }

    public string Password密碼 { get; set; } = null!;

    /// <summary>
    /// 以識別介接權限的GUID，APIKey需要提前申請
    /// </summary>
    public int? Apikey { get; set; }

    /// <summary>
    /// SessionId	字串GUID，由作業的發起方產生，以識別此次介接動作的一連串流程
    /// </summary>
    public int? SessionId { get; set; }

    /// <summary>
    /// 0:女，1:男
    /// </summary>
    public int? Gender性別 { get; set; }

    public virtual CreditCard信用卡 Cid信用卡流水號Navigation { get; set; } = null!;
}
