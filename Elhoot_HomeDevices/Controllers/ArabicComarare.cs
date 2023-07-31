using System.Globalization;
using System.Collections.Generic;
namespace Elhoot_HomeDevices.Controllers
{  public class ArabicComparer : IComparer<string>
    {
        private readonly CompareInfo compareInfo;

        public ArabicComparer()
        {
            this.compareInfo = CultureInfo.GetCultureInfo("ar").CompareInfo;
        }

        public int Compare(string x, string y)
        {
            return compareInfo.Compare(x, y);
        }
    }
}