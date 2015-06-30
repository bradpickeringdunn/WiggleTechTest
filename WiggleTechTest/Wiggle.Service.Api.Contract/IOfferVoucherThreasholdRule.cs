using Wiggle.Service.Models.ShoppingBasket;

namespace Wiggle.Service.Api.Contract
{
    public interface IOfferVoucherThreasholdRule
    {
        ShoppingBasketDto Validate(ShoppingBasketDto basket);
    }
}
