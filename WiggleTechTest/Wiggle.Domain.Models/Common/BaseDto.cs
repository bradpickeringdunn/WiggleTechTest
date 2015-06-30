using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Wiggle.Service.Models.Common
{
    [DataContract]
    public class BaseDto
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public bool IsActive { get; set; }
    }
}
