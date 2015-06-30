
using Wiggle.Service.Models.ShoppingBasket;
namespace Wiggle.Service.Api.Contract
{
    public interface IProductPurchaeRules
    {
        ShoppingBasketDto ApplyOfferVoucher(ShoppingBasketDto basket);
    }
}
