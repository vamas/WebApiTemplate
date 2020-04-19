using System;

namespace Web.Api.Dto
{
    public class Link
    {
        public string href { get; set; }
        public string rel { get; set; }
        public string method { get; set; }

        public Link()
        {
        }

        public Link(string href, string rel, string method)
        {
            this.href = href;
            this.rel = rel;
            this.method = method;
        }

        public Link(string href, string rel)
        {
            this.href = href;
            this.rel = rel;
            this.method = "GET";
        }

        public Link(Uri href, string rel)
        {
            this.href = href.ToString();
            this.rel = rel;
            this.method = "GET";
        }
    }
}