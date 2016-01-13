using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibCrawler
{
    public class BriefEntry
    {
        #region Private Field
        private string _title;
        private string _abstract;
        private string _profile;
        private string _citeUrl;
        #endregion

        #region Public Property
        public string Title
        {
            get { return _title; }
            set
            {
                if (value != null)
                    _title = value;
                else
                {
                    throw new NullReferenceException("Title is required.");
                }
            }
        }
        public string Abstract
        {
            get { return _abstract; }
            set
            {
                _abstract = value == null ? string.Empty : value;
            }
        }
        public string Profile
        {
            get { return _profile; }
            set
            {
                _profile = value == null ? string.Empty : value;
            }
        }
        public string CiteUrl
        {
            get { return _citeUrl; }
            set
            {
                if (value != null)
                    _citeUrl = value;
                else
                {
                    throw new NullReferenceException("CiteUrl is required.");
                }
            }
        }
        #endregion
    }
}
