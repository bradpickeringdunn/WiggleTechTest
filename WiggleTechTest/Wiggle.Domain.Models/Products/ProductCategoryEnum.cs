using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Wiggle.Service.Models.Products
{
    [DataContract]
    public enum ProductCategoryEnum
    {
        HeadGear,
        Clothing,
        GiftVoucher
    }
}
