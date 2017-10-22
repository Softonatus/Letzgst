using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SoftonautsService.CRequest
{
    [DataContract]
    public class ReqListUserCACompany
    {
        [DataMember]
        public int? ParentId
        {
            get;
            set;
        }

        [DataMember]
        public int? UserType
        {
            get;
            set;
        }
    }
}
