using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SoftonautsService.CResponse
{
    [DataContract]
    public class ResBillPayment :ResCommon
    {
        [DataMember]
        public int? BillId
        {
            get;
            set;
        }

        [DataMember]
        public string PaymentDate
        {
            get;
            set;
        }

        [DataMember]
        public string PaymentMode
        {
            get;
            set;
        }

        [DataMember]
        public string Amount
        {
            get;
            set;
        }

        [DataMember]
        public string Memo
        {
            get;
            set;
        }
    }

    public class ResBillPaymentList :ResCommon
    {
        public List<ResBillPayment> resBillPaymentList
        {
            get;
            set;
        }
    }
}
