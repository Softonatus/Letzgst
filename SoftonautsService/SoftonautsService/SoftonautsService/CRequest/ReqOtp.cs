using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SoftonautsService.CRequest
{
    [DataContract]
    public class ReqOtp
    {
        [DataMember]
        public string mobileNo
        {
            get;
            set;
        }
    }
}
