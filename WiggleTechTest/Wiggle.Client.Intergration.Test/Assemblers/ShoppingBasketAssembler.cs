using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientModels = Wiggle.Client.Intergration.Test.ShoppingBasketService;
using ServiceModels = Wiggle.Service.Models;

namespace Wiggle.Client.Intergration.Test.Assemblers
{
    public static class ShoppingBasketAssembler
    {
        public static ClientModels.ProductDto[] AsProductModels(this IList<ServiceModels.Products.ProductDto> products)
        {
            return new ClientModels.ProductDto[]{};
        }
    }
}
