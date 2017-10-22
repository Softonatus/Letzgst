using SoftonautsService.CRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SoftonautsService.CResponse
{
    [DataContract]
    public class ResBill_BillItem
    {
      [DataMember]
        public ReqBill reqBill
        {
            get;
            set;
        }

        [DataMember]
        public ReqBillItem reqBillItem
        {
            get;
            set;
        }
    }
}
