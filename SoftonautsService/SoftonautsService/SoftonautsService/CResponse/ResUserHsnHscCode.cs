using SoftonautsService.CResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SoftonautsService.CResponse
{
    [DataContract]
    public class ResUserHsnHscCode : ResCommon
    {
        [DataMember]
        public List<ResHsnCodeGoods> reqUserHsnList
        {
            get;
            set;
        }

        [DataMember]
        public List<ResHsnCodeGoods> reqUserHscList
        {
            get;
            set;
        }

    }
}
