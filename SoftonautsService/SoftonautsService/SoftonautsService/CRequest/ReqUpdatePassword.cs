using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SoftonautsService.CRequest
{
    [DataContract]
    public  class ReqUpdatePassword
    {
        [DataMember]
        public int? UserId
        {
            get;
            set;
        }

        [DataMember]
        public string Password
        {
            get;
            set;
        }

    }
}
