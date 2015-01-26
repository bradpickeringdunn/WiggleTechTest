using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiggle.Domain.Models.Products;
using Wiggle.Domain.Models.ShoppingBasket;

namespace Wiggle.Domain.ShoppingBasket
{
    public interface IShoppingBasketProducts
    {
        ShoppingBasketDto AddProduct(ShoppingBasketDto basket, ProductDto product);
    }
}
