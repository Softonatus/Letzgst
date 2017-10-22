using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SoftonautsService.CResponse
{
    [DataContract]
    public class ResPoCount : ResCommon
    {
        [DataMember]
        public int? PoIdCount
        {
            get;
            set;
        }
    }

    [DataContract]
    public class ResBillCount : ResCommon
    {
        [DataMember]
        public int? BillNoCount
        {
            get;
            set;
        }
    }
}
