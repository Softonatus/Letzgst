using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SoftonautsService.CResponse
{
    [DataContract]
    public class ResReports
    {
        [DataMember]
        public int? PId
        {
            get;
            set;
        }

        [DataMember]
        public int? TId
        {
            get;
            set;
        }

        [DataMember]
        public string RefNo
        {
            get;
            set;
        }

        [DataMember]
        public string Date
        {
            get;
            set;
        }

        [DataMember]
        public string Name
        {
            get;
            set;
        }


        [DataMember]
        public string GstinNo
        {
            get;
            set;
        }


        [DataMember]
        public string PanNo
        {
            get;
            set;
        }


        [DataMember]
        public string ContactName
        {
            get;
            set;
        }


        [DataMember]
        public string Cgst
        {
            get;
            set;
        }


        [DataMember]
        public string Sgst
        {
            get;
            set;
        }

        [DataMember]
        public string Igst
        {
            get;
            set;
        }

        [DataMember]
        public string Utgst
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
        public string Status
        {
            get;
            set;
        }

     
    }

    [DataContract]
    public class ResReportsList : ResCommon
    {
        [DataMember]
        public List<ResReports> resReportsList
        {
            get;set;
        }
    }
}

