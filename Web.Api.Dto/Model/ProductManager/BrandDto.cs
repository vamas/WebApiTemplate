using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Api.Dto.Model.ProductManager
{
    public class BrandDto : DtoBase
    {
        public string id { get; set; }
        public string name { get; set; }
        public ICollection<ProductDto> products { get; set; }
    }
}
