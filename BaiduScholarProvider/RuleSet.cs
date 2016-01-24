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
        public static string _baiduScholarURL = "http://xueshu.baidu.com";
        public static string _baiduCiteURL = "http://xueshu.baidu.com/u/citation?url=";

        public static string _entryPath = "//div[@tpl='se_st_sc_default']";
        public static string _citePath = ".//a[@data-click=\"{\'button_tp\':\'cite\'}\"]";
        public static string _titlePath = ".//a[@data-click=\"{\'button_tp\':\'title\'}\"]";
        public static string _authorsPath = ".//a[@data-click=\"{\'button_tp\':\'author\'}\"]";
        public static string _publishPath = ".//a[@data-click=\"{\'button_tp\':\'publish\'}\"]";
        public static string _yearPath = ".//span[@data-year]";
        public static string _abstractPath = ".//div[@class='c_abstract']";

        public static string _citeLinkAttrName = "data-link";
        public static string _citeSignAttrName = "data-sign";

        #endregion
    }
}
