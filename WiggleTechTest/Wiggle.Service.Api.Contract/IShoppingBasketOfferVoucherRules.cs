
using Wiggle.Service.Models.ShoppingBasket;
namespace Wiggle.Service.Api.Contract
{
    public interface IShoppingBasketOfferVoucherRules
    {
        ShoppingBasketDto ApplyOfferVoucher(ShoppingBasketDto basket);
    }
}
