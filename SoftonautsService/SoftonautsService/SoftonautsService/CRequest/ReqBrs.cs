using SoftonautsService.CResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SoftonautsService.CRequest
{
    [DataContract]
    public class ReqBrs
    {
        [DataMember]
        public int? UserId
        {
            get;
            set;
        }

        [DataMember]
        public string tableName
        {
            get;
            set;
        }

        [DataMember]
        public string Month
        {
            get;
            set;
        }

      
    }

    [DataContract]
    public class ReqGetBrsPayment
    {
        [DataMember]
        public int? Id
        {
            get;
            set;
        }

        [DataMember]
        public string Type
        {
            get;
            set;
        }

    }

    [DataContract]
    public class ReqBrsPayment : ResCommon
    {
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

        [DataMember]
        public string PaymentMode
        {
            get;
            set;
        }

        [DataMember]
        public string PaidDate
        {
            get;
            set;
        }

        [DataMember]
        public string ModeNo
        {
            get;
            set;
        }

        [DataMember]
        public string RealizationDate
        {
            get;
            set;
        }

        [DataMember]
        public string Type
        {
            get;
            set;
        }

        [DataMember]
        public int? Id
        {
            get;
            set;
        }
    }

    [DataContract]
    public class ReqBrsPaymentList : ResCommon
    {
        [DataMember]
        public List<ReqBrsPayment> reqBrsPaymentList
        {
            get;
            set;
        }
        [DataMember]
        public string Type
        {
            get;
            set;
        }
    }

    [DataContract]
    public class ReqUpdateBrsPaymentList : ResCommon
    {
        [DataMember]
        public int? Id
        {
            get;
            set;
        }

        [DataMember]
        public List<ReqBrsPayment> reqBrsUpdatePaymentList
        {
            get;
            set;
        }

        [DataMember]
        public string Type
        {
            get;
            set;
        }
    }
}