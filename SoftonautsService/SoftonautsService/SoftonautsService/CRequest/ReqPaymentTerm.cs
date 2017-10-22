using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SoftonautsService.CRequest
{
    [DataContract]
    public class ReqPaymentTerm
    {

        [DataMember]
        public int? UserId
        {
            get;
            set;
        }

        [DataMember]
        public string Term
        {
            get;
            set;
        }
    }
}
