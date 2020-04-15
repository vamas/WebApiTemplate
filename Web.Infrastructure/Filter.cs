using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Infrastructure
{
    public class Filter : ICloneable
    {
        public int PageSize { get; set; }

        private int page;
        private string searchPattern;
        private string sort;

        public Filter()
        {
            Page = 1;
            PageSize = 25;
        }

        public int Page
        {
            get { return page; }
            set { page = (value <= 0) ? 1 : value; }
        }

        public string SearchPattern
        {
            get { return searchPattern ?? ""; }
            set { searchPattern = value; }
        }


        public object Clone()
        {
            var jsonString = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject(jsonString, this.GetType());
        }

        public bool IsValid
        {
            get
            {
                return true;
            }
        }

        public string Sort
        {
            get { return sort ?? ""; }
            set { sort = value; }
        }

        public Tuple<string, bool> SortConfig()
        {
            if (Sort != "")
            {
                var chunks = Sort.Split(':');
                if (chunks.Length == 2)
                {
                    if (chunks[1].ToLower() == "desc")
                    {
                        return new Tuple<string, bool>(chunks[0], true);
                    }
                }
                return new Tuple<string, bool>(chunks[0], false);
            }
            return new Tuple<string, bool>("", false);
        }
    }
}
