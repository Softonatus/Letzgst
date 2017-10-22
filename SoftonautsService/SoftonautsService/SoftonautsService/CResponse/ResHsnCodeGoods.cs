using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SoftonautsService.CResponse
{
    [DataContract]
    public class ResHsnCodeGoods
    {
        [DataMember]
        public string HsnCodeId
        {
            get;
            set;
        }

        [DataMember]
        public string HsnCode
        {
            get;
            set;
        }

        [DataMember]
        public string HsnDetail
        {
            get;
            set;
        }

        [DataMember]
        public string HsnRate
        {
            get;
            set;
        }
    }

    [DataContract]
    public class ResListHsnCodeGoods : ResCommon
    {
        [DataMember]
        public List<ResHsnCodeGoods> resHsnCodeGoods
        {
            get;
            set;
        }
    }
    }
