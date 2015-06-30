using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiggle.Service.Api.Contract;

namespace Wiggle.Service.Adapter
{
    public class ShoppingBasketProducts : IShoppingBasketProducts
    {
        public Models.ShoppingBasket.ShoppingBasketDto AddProduct(Models.ShoppingBasket.ShoppingBasketDto basket, Models.Products.ProductDto product)
        {
            throw new NotImplementedException();
        }
    }
}
