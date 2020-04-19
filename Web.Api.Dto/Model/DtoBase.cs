using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Api.Dto
{
    public abstract class DtoBase
    {
        public DtoBase()
        {
            Links = new List<Link>();
        }

        public List<Link> Links { get; set; }
    }
}
