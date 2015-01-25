using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiggle.Domain.Models.Products
{
    public class ProductBasket : BaseDto
    {
        public IEnumerable<ProductDto> Products { get; set; }

        public double Total { get; }
    }
}
