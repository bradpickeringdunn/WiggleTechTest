
using Wiggle.Service.Models.Products;
using Wiggle.Service.Models.ShoppingBasket;
namespace Wiggle.Service.Api.Contract
{
    public interface IShoppingBasketProducts
    {
        ShoppingBasketDto AddProduct(ShoppingBasketDto basket, ProductDto product);
    }
}
