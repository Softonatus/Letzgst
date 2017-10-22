using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SoftonautsService.CRequest
{
    [DataContract]
    public class ReqOtpValidate
    {
        [DataMember]
        public int? UserId
        {
            get;
            set;
        }

        [DataMember]
        public int? otpId
        {
            get;
            set;
        }

        [DataMember]
        public string otpNo
        {
            get;
            set;
        }
    }
}
