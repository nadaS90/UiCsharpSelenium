using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCESymp.Data
{
    public static class DataLogger
    {

        private static log4net.ILog log = log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void Info(string text)
        {
            log.Info(text);
        }

        public static void Error(string text)
        {
            log.Error(text);
        }


    }
}
