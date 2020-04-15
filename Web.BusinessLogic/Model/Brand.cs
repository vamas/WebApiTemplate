using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Infrastructure.BusinessLogic.Model;

namespace Web.ProductManager.Model
{
    public class Brand : BusinessLogicEntity
    {
        public string id { get; set; }
        public string name { get; set; }
        public ICollection<Product> products { get; set; }
    }
}
