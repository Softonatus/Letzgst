using SoftonautsService.CRequest;
using SoftonautsService.CRequest.GST1;
using SoftonautsService.CResponse;
using SoftonautsService.CResponse.GST1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SoftonautsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISNService" in both code and config file together.
    [ServiceContract]
    public interface ISNService
    {

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Registration", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResRegistration Registration(ReqRegistration reqRegistration);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Login", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResLogin Login(ReqLogin reqLogin);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UpdatePassword", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCommon UpdatePassword(ReqUpdatePassword reqUpdatePassword);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "SendOtp", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResOtp SendOtp(ReqOtp reqOtp);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "ValidateOtp", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCommon ValidateOtp(ReqOtpValidate reqValidateOtp);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "InsertProfile", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCommon InsertProfile(ReqProfile reqProfile);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UpdateProfile", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCommon UpdateProfile(ReqProfile reqProfile);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetProfile", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResProfile GetProfile(ReqUserId reqUserId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetListUserCACompany", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResUserListCACompany GetListUserCACompany(ReqListUserCACompany reqListUserCACompany);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetListCACompany", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCompanyListCA GetListCACompany(ReqUserId reqParentId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "InsertUserHSNCode", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCommon InsertUserHSNCode(ReqInsertUserHsn reqInsertUserHsn);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "HsnDetailSearch", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResListHsnCodeGoods HsnDetailSearch(ReqHsnCode reqHsnCode);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UserHsnDetail", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResListHsnCodeGoods UserHsnDetail(ReqUserHsnDetail reqUserHsnDetail);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "DeleteUserHsn", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCommon DeleteUserHsn(ReqUserHsn reqUserHsn);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "DeleteUser", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCommon DeleteUser(ReqUserId reqUserId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UpdateUser", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCommon UpdateUser(ReqUpdateUser reqUpdateUser);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetUserHsnHscCode", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResUserHsnHscCode GetUserHsnHscCode(ReqUserId reqUserId);

        #region Vendor
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "InsertVendor", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResId InsertVendor(ReqVendor reqVendor);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UpdateVendor", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCommon UpdateVendor(ReqVendorUpdate reqVendorUpdate);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "DeleteVendor", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCommon DeleteVendor(ReqId reqVendorId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetVendorList", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResVendorList GetVendorList(ReqUserId reqUserId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetVendorDetail", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResVendorDetail GetVendorDetail(ReqId reqVendorId);

        #endregion

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetCustomerDetail", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCustomerDetail GetCustomerDetail(ReqId reqCustomerId);

        #region Expense
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "InsertExpense", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResId InsertExpense(ReqInsertExpense reqInsertExpense);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetExpense", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResGetExpenseList GetExpense(ReqUserId reqUserId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "InsertPurchase", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCommon InsertPurchase(ReqPurchase reqPurchase);
        #endregion


        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetLastInsertedPoId", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResPoCount GetLastInsertedPoId(ReqUserId reqUserId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UpdatePurchase", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCommon UpdatePurchase(ReqPurchase reqUpdatePurchase);


        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetPurchaseList", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ReqPurchaseList GetPurchaseList(ReqUserId reqUserId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetPurchaseDetail", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResPurchase_PurchaseItem GetPurchaseDetail(ReqId reqId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "BulkInsertPurchase", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCommon BulkInsertPurchase(ResPurchase_PurchaseItemList resPurchase_PurchaseItemList);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetAllUser", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResAllUserList GetAllUser();


        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "DeleteBill", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCommon DeleteBill(ReqId reqBillId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetBillPaymentDetail", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResBillPayment GetBillPaymentDetail(ReqId reqBillId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UpdateBillPayment", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ReqBillPayment UpdateBillPayment(ResBillPayment resBillPayment);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "InsertBill", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCommon InsertBill(ReqBill reqBill);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "BulkInsertBill", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCommon BulkInsertBill(ReqBill_BillItem reqBill);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "BulkInsertRecurringBill", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCommon BulkInsertRecurringBill(ReqBill_BillItem reqBill);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetLastInsertedBillNo", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResBillCount GetLastInsertedBillNo(ReqUserId reqUserId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetUserBillList", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResBillList GetUserBillList(ReqUserId reqUserId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetUserFutureBillList", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResBillList GetUserFutureBillList(ReqUserId reqUserId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UpdateBill", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCommon UpdateBill(ReqBill reqBill);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetBillDetail", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ReqBill GetBillDetail(ReqId reqId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetUserItemList", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResUserItemsList GetUserItemList(ReqUserId reqUserId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "InsertUserItem", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResId InsertUserItem(ReqInsertUserItems reqInsertUserItems);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetTdsList", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResTdsList GetTdsList(ReqUserId reqUserId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "BulkInsertVendor", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCommon BulkInsertVendor(ReqVendorList reqVendorList);


        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetPaymentTerm", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResGetPaymentTermList GetPaymentTerm(ReqUserId reqUserId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "InsertPaymentTerm", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResId InsertPaymentTerm(ReqPaymentTerm reqPaymentTerm);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetDashBoardContentInvoice", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        CResponse.ResDashBoard GetDashBoardContentInvoice(ReqDashBoardContentTax reqDashBoardContentTax);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetDashBoardContentExpense", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        CResponse.ResDashBoard GetDashBoardContentExpense(ReqDashBoardContentTax reqDashBoardContentTax);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetLastInsertedAdvance", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResLastInsertedCount GetLastInsertedAdvance(ReqUserId reqUserId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetLastInsertedCredit", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResLastInsertedCount GetLastInsertedCredit(ReqUserId reqUserId);





        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetLastInsertedInvoice", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResLastInsertedCount GetLastInsertedInvoice(ReqUserId reqUserId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "DeletePurchase", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCommon DeletePurchase(ReqId reqId);

        #region Insert Advance/Credit/Debit/Estimate/Invoice

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "InsertAdvance", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCommon InsertAdvance(ReqAdvance reqAdvance);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "InsertCredit", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCommon InsertCredit(ReqCreditNote reqCreditNote);


        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "InsertInvoice", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCommon InsertInvoice(ReqInvoice reqInvoice);

        #endregion

        #region Update Advance/Credit/Debit/Estimate/Invoice

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UpdateAdvance", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCommon UpdateAdvance(ReqAdvance reqAdvance);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UpdateCredit", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCommon UpdateCredit(ReqCreditNote reqCreditNote);



        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UpdateInvoice", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCommon UpdateInvoice(ReqInvoice reqInvoice);

        #endregion

        #region Delete dvance/Credit/Debit/Estimate/Invoice

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "DeleteAdvance", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCommon DeleteAdvance(ReqId reqId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "DeleteCredit", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCommon DeleteCredit(ReqId reqId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "DeleteInvoice", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCommon DeleteInvoice(ReqId reqId);
        #endregion



        #region Get Advance/Credit/Debit/Estimate/Invioce

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetAdvance", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResAdvanceGetList GetAdvance(ReqUserId reqUserId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetCredit", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCreditNoteGetList GetCredit(ReqUserId reqUserId);





        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetInvoice", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResInvoiceGetList GetInvoice(ReqUserId reqUserId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetAdvanceDetail", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResAdvanceGetList GetAdvanceDetail(ReqId reqId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetCreditDetail", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCreditNoteGetList GetCreditDetail(ReqId reqId);





        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetInvoiceDetail", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResInvoiceGetList GetInvoiceDetail(ReqId reqId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetBrsList", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResBrsList GetBrsList(ReqBrs reqBrs);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "InsertBrsPayment", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCommon InsertBrsPayment(ReqBrsPaymentList reqBrsPayment);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetBrsPayment", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ReqBrsPaymentList GetBrsPayment(ReqGetBrsPayment reqGetBrsPayment);

        #endregion

        #region Get InvoiceRef/BillRef

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetInvoiceRef", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResrefIdList GetInvoiceRef(ReqUserId reqUserId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetBillRef", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResrefIdList GetBillRef(ReqUserId reqUserId);


        #endregion

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetReportList", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResReportsList GetReportList(ReqReports reqReport);

        #region Estimate
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetLastInsertedEstimate", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResLastInsertedCount GetLastInsertedEstimate(ReqUserId reqUserId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "InsertEstimate", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCommon InsertEstimate(ReqEstimate reqEstimate);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UpdateEstimate", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCommon UpdateEstimate(ReqEstimate reqEstimate);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "DeleteEstimate", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCommon DeleteEstimate(ReqId reqId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetEstimate", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResEstimateGetList GetEstimate(ReqUserId reqUserId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetEstimateDetail", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResEstimateGetList GetEstimateDetail(ReqId reqId);

        #endregion

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "InsertCustomer", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResId InsertCustomer(ReqCustomer reqCustomer);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "DeleteCustomer", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCommon DeleteCustomer(ReqId reqCustomerId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetCustomerList", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCustomerList GetCustomerList(ReqUserId reqUserId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UpdateCustomer", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResId UpdateCustomer(ReqCustomerUpdate reqCustomerUpdate);


        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UpdateBrsPayment", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCommon UpdateBrsPayment(ReqBrsPaymentList reqUpdateBrsPayment);


        #region Debit Related Service

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UpdateDebit", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCommon UpdateDebit(ReqDebitNote reqDebitNote);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "DeleteDebit", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCommon DeleteDebit(ReqId reqId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetDebit", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResDebitNoteGetList GetDebit(ReqUserId reqUserId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetDebitDetail", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResDebitNoteGetList GetDebitDetail(ReqId reqId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetLastInsertedDebit", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResLastInsertedCount GetLastInsertedDebit(ReqUserId reqUserId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "InsertDebit", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCommon InsertDebit(ReqDebitNote reqDebitNote);

        #endregion

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UpdateLogo", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCommon UpdateLogo(ReqUpdateLogo reqUpdateLogo);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "SendMailCustom", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResCommon SendMailCustom(ReqEmail reqEmail);

        #region GST1

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetB2BGst1", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResGst1List GetB2BGst1(ReqGst1 reqGst1);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetB2CLGst1", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResGst1List GetB2CLGst1(ReqGst1 reqGst1);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetB2CSGst1", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ResGst1List GetB2CSGst1(ReqGst1 reqGst1);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetGstr1", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Gst1Save GetGstr1(ReqGst1 reqGst1);
        #endregion

    }

}
