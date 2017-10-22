using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SoftonautsService.CResponse
{
    [DataContract]
    public class ResOtp : ResCommon
    {
        [DataMember]
        public int? UserId
        {
            get;
            set;
        }

        [DataMember]
        public int? OtpId
        {
            get;
            set;
        }
    }
}
