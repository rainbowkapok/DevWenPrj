using DevWenPrj.Models;
using Microsoft.AspNetCore.Mvc;
using NLog;
using NLog.Fluent;
using PrjWen.ViewModel;
using System.Diagnostics;
using System.Text.Json;

namespace DevWenPrj.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WenDbContext _dbcontext;

        public HomeController(ILogger<HomeController> logger, WenDbContext db)
        {
            _logger = logger;
            _dbcontext = db;
        }

        public IActionResult Index()
        {
            if (!HttpContext.Session.Keys.Contains(CSectionClass.LoginUser))
            {
                _logger.LogDebug("Debug用，還沒登入");
                Utility.MyLog("Debug用，測試UtilityMyLog");
                return RedirectToAction("Login");
            }
         
            return View();
        }
              
        #region
        // Trace = 0, Debug = 1, Information = 2, Warning = 3, Error = 4, Critical = 5, and None = 6.
        //Trace - 最常見的記錄資訊，一般用於普通輸出
        //Debug - 同樣是記錄資訊，不過出現的頻率要比Trace少一些，一般用來除錯程式
        //Info - 資訊型別的訊息
        //Warn - 警告資訊，一般用於比較重要的場合
        //Error - 錯誤資訊e
        //Fatal - 致命異常資訊。一般來講，發生致命異常之後程式將無法繼續執行。
        #endregion
        public IActionResult Login()
        {

            return View();
        }

        public string name;
        [HttpPost]
        public IActionResult Login(CMemberViewModel cmv)
        {
            //Member會員 Member = (new WenDBContext()).Member會員s.FirstOrDefault(m => m.Email信箱.Equals(cmv.txtEmail));
            Member會員 Member = _dbcontext.Member會員s.FirstOrDefault(m => m.Email信箱.Equals(cmv.txtEmail));
            if (Member != null)
            {
                if (Member.Password密碼 == cmv.txtPassword)
                {
                    string JoinUser = JsonSerializer.Serialize(Member);
                    HttpContext.Session.SetString(CSectionClass.LoginUser, JoinUser);

                    name = Member.Name會員名稱;
                    LogManager.Configuration.Variables["MyValue"] = name;
                    _logger.LogInformation("success" + "登入時間:" + DateTime.Now.ToString() + Member.Name會員名稱);
                    _logger.LogWarning("這是溫馨小提醒(Warning)," + "Hi" + Member.Name會員名稱 + "已登入囉!");

                    return RedirectToAction("Index");
                }
            }
            return View();           
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}