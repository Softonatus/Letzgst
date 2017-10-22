using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SoftonautsService.CResponse.GST1
{
    [DataContract]
    public class CreditDebitUnRegisteredGst1
    {
        [DataMember]
        public string URTypeNoteRefundVoucherNumber
        { get; set; }

        [DataMember]
        public string NoteRefundVoucherdate
        { get; set; }

        [DataMember]
        public string DocumentType
        { get; set; }

        [DataMember]
        public string InvoiceAdvanceReceiptNumber
        { get; set; }

        [DataMember]
        public string InvoiceAdvanceReceiptdate
        { get; set; }

        [DataMember]
        public string ReasonForIssuingdocument
        { get; set; }

        [DataMember]
        public string PlaceOfSupplyNoteRefundVoucherValue
        { get; set; }

        [DataMember]
        public string Rate
        { get; set; }

        [DataMember]
        public string TaxableValue
        { get; set; }

        [DataMember]
        public string CessAmount
        { get; set; }

        [DataMember]
        public string PreGST
        { get; set; }

    }

    [DataContract]
    public class CreditDebitUnRegisteredGst1List
    {
        [DataMember]
        public List<CreditDebitUnRegisteredGst1> listCreditDebitUnRegisteredGst1
        { get; set; }
    }
}