using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Infrastructure.BusinessLogic.Interface;
using Web.Infrastructure.BusinessLogic.Model;
using Web.ProductManager.Interface;
using Web.ProductManager.Model;

namespace Web.ProductManager.Action
{
    class DeleteProductAction : ProductManagerActionBase
    {
        private readonly IProductManagerData _data;

        public DeleteProductAction(IProductManagerData data)
        {
            _data = data;
        }

        public override async Task<BusinessLogicEntity> Action(BusinessLogicEntity dto)
        {
            var entity = dto as Product;
            if ((await _data.GetProduct(entity.id)) == null)
            {
                AddError(string.Format("Product with Id={0} doesn't exist", entity.id));
                return null;
            }
            await _data.DeleteProduct(entity);
            return entity;
        }
    }
}

