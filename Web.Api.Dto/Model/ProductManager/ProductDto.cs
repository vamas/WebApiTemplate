using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Api.Dto.Model.ProductManager
{
    public class ProductDto : DtoBase
    {
        public string id { get; set; }
        public string name { get; set; }
        public BrandDto brand { get; set; }
    }
}
