using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleScholarProvider
{
    public static class RuleSet
    {
        #region Public Static Field
        public static string GoogleScholarURL       = "https://scholar.google.com";
        public static string GoogleScholarSearchURL = "https://scholar.google.com/scholar?q=";
        public static string GoogleCiteURL          = "https://scholar.google.com/scholar.bib?q=info:";
        public static string GoogleCiteURLSuffix    = ":scholar.google.com/&output=cite&scirp=0&hl=zh-CN";

        public static string EntryPath              = "//div[@class='gs_ri']";
        public static string CiteUrlPath            = "//a[@class='gs_citi']";
        public static string TitlePath              = ".//h3[@class='gs_rt']";
        public static string SourcePath             = ".//h3[@class='gs_rt']/a";
        public static string AbstractPath           = ".//div[@class='gs_rs']";
        public static string ProfilePath            = ".//div[@class='gs_a']";
        public static string CitePath               = ".//a[@onclick]";
        public static string CiteIdAttrName         = "onclick";
        #endregion
    }
}
