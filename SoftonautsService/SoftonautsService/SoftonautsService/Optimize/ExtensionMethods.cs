using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftonautsService.Optimize
{
    public static class ExtensionMethods
    {
        public static string CheckDBNull(this string readerValue)
        {
            if (readerValue == null)
                return readerValue;
            return string.Empty;
        }

        public static string GetStoreProcHsnOrHsv(string HsnOrHsc, string hsnStoreProc, string hscStoreProc)
        {
            string storeProc = String.Empty;
            if (HsnOrHsc.ToLower() == "hsn") storeProc = hsnStoreProc;
            else storeProc = hscStoreProc;
            return storeProc;
        }
    }
}
