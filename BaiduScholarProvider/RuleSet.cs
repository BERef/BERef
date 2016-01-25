using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiduScholarProvider
{
    public static class RuleSet
    {
        #region Public Static Field
        public static string BaiduScholarUrl = "http://xueshu.baidu.com";
        public static string BaiduCiteUrl = "http://xueshu.baidu.com/u/citation?url=";

        public static string EntryPath = "//div[@tpl='se_st_sc_default']";
        public static string CitePath = ".//a[@data-click=\"{\'button_tp\':\'cite\'}\"]";
        public static string TitlePath = ".//a[@data-click=\"{\'button_tp\':\'title\'}\"]";
        public static string AuthorsPath = ".//a[@data-click=\"{\'button_tp\':\'author\'}\"]";
        public static string PublishPath = ".//a[@data-click=\"{\'button_tp\':\'publish\'}\"]";
        public static string YearPath = ".//span[@data-year]";
        public static string AbstractPath = ".//div[@class='c_abstract']";

        public static string CiteLinkAttrName = "data-link";
        public static string CiteSignAttrName = "data-sign";

        #endregion
    }
}
