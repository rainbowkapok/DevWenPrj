using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevWenPrj
{
    public class Utility
    {
        public static void MyLog(string message)
        {
            var logger = LogManager.GetCurrentClassLogger();
            logger.Debug(message);
        }
    }
}
