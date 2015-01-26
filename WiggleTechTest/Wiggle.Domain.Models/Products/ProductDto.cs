using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiggle.Domain.Models.Common;

namespace Wiggle.Domain.Models.Products
{
    public class ProductDto : BaseDto
    {
        public ProductDto()
        {
        }

        public ProductDto(OfferVoucherDto offerVoucher)
        {
            this.OfferVoucher = offerVoucher;
        }

        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public ProductCategoryEnum Category { get; set; }
        public OfferVoucherDto OfferVoucher { get; private set; }
    }
}
