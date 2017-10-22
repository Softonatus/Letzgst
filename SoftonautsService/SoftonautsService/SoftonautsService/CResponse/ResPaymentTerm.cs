using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SoftonautsService.CResponse
{
    [DataContract]
    public class ResGetPaymentTerm
    {
       [DataMember]
        public int? Id
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

    [DataContract]
    public class ResGetPaymentTermList : ResCommon
    {
        [DataMember]
        public List<ResGetPaymentTerm> resGetPaymentTermList
        {
            get;
            set;
        }
    }
}
