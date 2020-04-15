using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Infrastructure.BusinessLogic.Model;

namespace Web.ProductManager.Model
{
    public class Product : BusinessLogicEntity
    {
        public string id { get; set; }
        public string name { get; set; }
        [ForeignKey("brand")]
        public string brandId { get; set; }
        public Brand brand { get; set; }
    }
}
