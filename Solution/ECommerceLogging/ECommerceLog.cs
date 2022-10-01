using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceLogging.Logging
{
    public class ECommerceLog
    {
        private List<String> CustomerLogs { get; set; }
        public  ECommerceLog()
        {
            CustomerLogs = new List<string>();
        }

        public void Log(string log)
        {
            CustomerLogs.Add(log);
        }

        public void ClearLogs(string customerId)
        {
            CustomerLogs.Clear();
        }

        public string GetMessage()
        {
            string s = string.Empty;
            CustomerLogs.ForEach(t => s = s + t + System.Environment.NewLine);
            s = s.TrimEnd();
            return s;
        }
    }
}
