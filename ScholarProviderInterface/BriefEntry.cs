using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScholarProviderInterface
{
    public abstract class BriefEntry
    {
        #region Private Field
        private string _title;
        private string _source;
        private string _abstract;
        private string _profile;
        private string _bibTeX;
        #endregion

        #region Constructor
        public BriefEntry(string title, string source, string abstrct, string profile)
        {
            Title = title;
            Source = source;
            Abstract = abstrct;
            Profile = profile;
        }
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
        public string Source
        {
            get { return _source; }
            set
            {
                _source = value ?? string.Empty;
            }
        }
        public string Abstract
        {
            get { return _abstract; }
            set
            {
                _abstract = value ?? string.Empty;
            }
        }
        public string Profile
        {
            get { return _profile; }
            set
            {
                _profile = value ?? string.Empty;
            }
        }

        /// <summary>
        /// It will excute abstract method GetBibTeX(), 
        /// and might take uncertain time when invoked this getter in the first time.
        /// </summary>
        public string BibTeX
        {
            get
            {
                _bibTeX = _bibTeX ?? GetBibTeX();
                return _bibTeX;
            }

        }

        #endregion

        #region Public Abstract Method
        /// <summary>
        /// Get BibTeX from customed data source.
        /// </summary>
        /// <returns></returns>
        protected abstract string GetBibTeX();
        #endregion
    }
}
