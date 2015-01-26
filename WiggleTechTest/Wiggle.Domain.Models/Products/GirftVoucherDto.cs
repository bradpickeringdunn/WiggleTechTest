using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiggle.Domain.Models.Common;

namespace Wiggle.Domain.Models.Products
{
    public class GiftVoucherDto : BaseDto
    {
        public string code { get; private set; }
        public double Value {get;private set;}
        
        public GiftVoucherDto(string existingVoucherCode, double value)
        {
            this.code = existingVoucherCode;
            this.Value = value;
        }
    }
}
