using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiggle.Domain.Models.Common;

namespace Wiggle.Domain.Models.Products
{
    public class OfferVoucherDto : BaseDto
    {
        public bool CanBeApplied { get; set; }

        public string Code{get;private set;}

        public double Value{get;private set;}

        public double Threashold { get; set; }

        public ProductCategoryEnum? ProductCatergoy { get; private set; }

        public OfferVoucherType IsApplicableTo { get; set; }

        public OfferVoucherDto(string code, double value, double threashold, ProductCategoryEnum productCategory, OfferVoucherType isApplicableTo)
        {
            this.CanBeApplied = false;
            this.Code = code;
            this.Value = value;
            this.ProductCatergoy = productCategory;
            this.Threashold = threashold;
            this.IsApplicableTo = isApplicableTo;
        }
    }
}
