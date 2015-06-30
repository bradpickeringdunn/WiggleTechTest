using Wiggle.Service.Models.ShoppingBasket;

namespace Wiggle.Service.Api.Contract
{
    public interface IOfferVoucherRules
    {
        ShoppingBasketDto Validate(ShoppingBasketDto basket);
    }
}
