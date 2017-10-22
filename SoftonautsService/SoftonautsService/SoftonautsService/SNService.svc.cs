using SoftonautsService.CRequest;
using SoftonautsService.CRequest.GST1;
using SoftonautsService.CResponse;
using SoftonautsService.CResponse.GST1;
using SoftonautsService.Optimize;
using SoftonautsService.Optimize.Brs;
using SoftonautsService.Optimize.GST1;
using SoftonautsService.Optimize.Invoice;
using SoftonautsService.Optimize.Reports;
using System;
using System.Collections.Generic;

namespace SoftonautsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SNService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SNService.svc or SNService.svc.cs at the Solution Explorer and start debugging.
    public class SNService : ISNService
    {

        public SNService()
        { }
        public ResRegistration Registration(ReqRegistration reqRegistration)
        {

            if (String.IsNullOrEmpty(reqRegistration.Password))
            {
                Random rnd = new Random();
                var a = StaticConst.Caps[rnd.Next(StaticConst.Caps.Length)].ToString();
                var b = StaticConst.Special[rnd.Next(0, StaticConst.Special.Length)].ToString();
                var c = StaticConst.Small[rnd.Next(0, StaticConst.Small.Length)].ToString() + StaticConst.Special[rnd.Next(0, StaticConst.Special.Length)].ToString();
                var d = StaticConst.Num[rnd.Next(0, StaticConst.Num.Length)].ToString() + StaticConst.Small[rnd.Next(0, StaticConst.Small.Length)].ToString();

                reqRegistration.Password = a + b + c + d;
            }
            ResRegistration resRegistration = new ResRegistration();
            resRegistration = Common<ReqRegistration, ResRegistration>.Serialize_Deserialize(reqRegistration, resRegistration, StaticConst.SP_USERREGISTRATION);
            if (resRegistration.ResponseCode == 1 || resRegistration.ResponseCode == 2)
            {
                ReqEmail reqEmail = new ReqEmail();
                reqEmail.EmailId = reqRegistration.EmailId;
                reqEmail.UserName = reqRegistration.Name;
                CallThirdParty.SendMailCustom(reqEmail, reqRegistration.Password);
            }
            //CallThirdParty.SendDefaultPassword(reqRegistration.ContactNo, reqRegistration.Password);
            return resRegistration;
        }

        public ResLogin Login(ReqLogin reqLogin)
        {
            ResLogin resLogin = new ResLogin();
            Random rnd = new Random();
            var a = StaticConst.Caps[rnd.Next(StaticConst.Caps.Length)].ToString() + StaticConst.Special[rnd.Next(0, StaticConst.Special.Length)].ToString();
            var b = StaticConst.Special[rnd.Next(0, StaticConst.Special.Length)].ToString() + StaticConst.Special[rnd.Next(0, StaticConst.Special.Length)].ToString();
            var c = StaticConst.Small[rnd.Next(0, StaticConst.Small.Length)].ToString() + StaticConst.Special[rnd.Next(0, StaticConst.Special.Length)].ToString();
            var d = StaticConst.Num[rnd.Next(0, StaticConst.Num.Length)].ToString() + StaticConst.Small[rnd.Next(0, StaticConst.Small.Length)].ToString();
            var e = StaticConst.Num[rnd.Next(0, StaticConst.Num.Length)].ToString() + StaticConst.Small[rnd.Next(0, StaticConst.Small.Length)].ToString();

            reqLogin.authKey = a + b + c + d+e;
            return Common<ReqLogin, ResLogin>.Serialize_Deserialize(reqLogin, resLogin, StaticConst.SP_USERLOGIN);
        }

        public ResCommon UpdatePassword(ReqUpdatePassword reqUpdatePassword)
        {
            ResCommon resCommon = new ResCommon();

            return Common<ReqUpdatePassword, ResCommon>.Serialize_Deserialize(reqUpdatePassword, resCommon, StaticConst.SP_UPDATEPASSWORD);
        }

        public ResOtp SendOtp(ReqOtp reqOtp)
        {
            return CallThirdParty.SendMessage(reqOtp.mobileNo);
        }

        public ResCommon ValidateOtp(ReqOtpValidate reqValidateOtp)
        {
            ResCommon resCommon = new ResCommon();
            return Common<ReqOtpValidate, ResCommon>.Serialize_Deserialize(reqValidateOtp, resCommon, StaticConst.SP_VALIDATEOTP);
        }

        public ResCommon InsertProfile(ReqProfile reqProfile)
        {
            ResCommon resCommon = new ResCommon();
            return Common<ReqProfile, ResCommon>.Serialize_Deserialize(reqProfile, resCommon, StaticConst.SP_INSERTPROFILE);
        }

        public ResProfile GetProfile(ReqUserId reqUserId)
        {
            ResProfile resProfile = new ResProfile();
            return Common<ReqUserId, ResProfile>.Serialize_Deserialize(reqUserId, resProfile, StaticConst.SP_GETPROFILE);
        }

        public ResCommon UpdateProfile(ReqProfile reqProfile)
        {
            ResCommon resCommon = new ResCommon();
            return Common<ReqProfile, ResCommon>.Serialize_Deserialize(reqProfile, resCommon, StaticConst.SP_UPDATEPROFILE);
        }

        public ResUserListCACompany GetListUserCACompany(ReqListUserCACompany reqListUserCACompany)
        {
            return DBCall.GetUserListCompanyCA(reqListUserCACompany, StaticConst.SPGETUSERLIST_CA_COMPANY);
        }

        public ResCompanyListCA GetListCACompany(ReqUserId reqParentId)
        {
            return DBCall.GetListCompanyCA(reqParentId, StaticConst.SPGETLIST_CA_COMPANY);
        }

        public ResCommon DeleteUser(ReqUserId reqUserId)
        {
            ResCommon resCommon = new ResCommon();
            return Common<ReqUserId, ResCommon>.Serialize_Deserialize(reqUserId, resCommon, StaticConst.SPDELETEUSER);
        }

        public ResCommon UpdateUser(ReqUpdateUser reqUpdateUser)
        {
            ResCommon resCommon = new ResCommon();
            return Common<ReqUpdateUser, ResCommon>.Serialize_Deserialize(reqUpdateUser, resCommon, StaticConst.SPUPDATEUSER);
        }

        public ResUserHsnHscCode GetUserHsnHscCode(ReqUserId reqUserId)
        {
            return DBCall.GetUserHsn_HscCode(reqUserId, StaticConst.SPGETUSERHSNHSCCODE);
        }

        public ResCommon InsertUserHSNCode(ReqInsertUserHsn reqInsertUserHsn)
        {
            ResCommon resCommon = new ResCommon();
            return DBCall.InsertUserHSNCode(reqInsertUserHsn, ExtensionMethods.GetStoreProcHsnOrHsv(reqInsertUserHsn.HsnOrHsc, StaticConst.SPINSERTUSERHSNCODE, StaticConst.SPINSERTUSERHSCCODE));

        }

        public ResListHsnCodeGoods HsnDetailSearch(ReqHsnCode reqHsnCode)
        {
            return DBCall.GetListHsnCode(reqHsnCode, ExtensionMethods.GetStoreProcHsnOrHsv(reqHsnCode.HsnOrHsc, StaticConst.SPSEARCHHSNCODE, StaticConst.SPSEARCHHSCCODE));
        }

        public ResListHsnCodeGoods UserHsnDetail(ReqUserHsnDetail reqUserHsnDetail)
        {
            return DBCall.GetUserHsnDetail(reqUserHsnDetail.UserId, ExtensionMethods.GetStoreProcHsnOrHsv(reqUserHsnDetail.HsnOrHsc, StaticConst.SPGETUSERHSNCODE, StaticConst.SPGETUSERHSCCODE));
        }

        public ResCommon DeleteUserHsn(ReqUserHsn reqUserHsn)
        {
            ResCommon resCommon = new ResCommon();
            return DBCall.DeleteUserHsn(reqUserHsn, ExtensionMethods.GetStoreProcHsnOrHsv(reqUserHsn.HsnOrHsc, StaticConst.SPDELETEUSERHSNCODE, StaticConst.SPDELETEUSERHSCCODE));
            //return Common<ReqUserHsn, ResCommon>.Serialize_Deserialize(reqUserHsn, resCommon, ExtensionMethods.GetStoreProcHsnOrHsv(reqUserHsn.HsnOrHsc, StaticConst.SPDELETEUSERHSNCODE, StaticConst.SPDELETEUSERHSCCODE));
        }

        public ResId InsertVendor(ReqVendor reqVendor)
        {
            ResId resId = new ResId();
            return Common<ReqVendor, ResId>.Serialize_Deserialize(reqVendor, resId, StaticConst.SPINSERTVENDOR);
        }

        public ResCommon UpdateVendor(ReqVendorUpdate reqVendorUpdate)
        {
            ResCommon resCommon = new ResCommon();
            return Common<ReqVendorUpdate, ResCommon>.Serialize_Deserialize(reqVendorUpdate, resCommon, StaticConst.SPUPDATEVENDOR);
        }

        public ResCommon DeleteVendor(ReqId reqVendorId)
        {
            ResCommon resCommon = new ResCommon();
            return Common<ReqId, ResCommon>.Serialize_Deserialize(reqVendorId, resCommon, StaticConst.SPDELETEVENDOR);
        }

        public ResVendorList GetVendorList(ReqUserId reqUserId)
        {
            return DBCall.GetVendorList(reqUserId, StaticConst.SPGETUSERVENDORLIST);
        }

        public ResVendorDetail GetVendorDetail(ReqId reqVendorId)
        {
            ResVendorDetail resVendorDetail = new ResVendorDetail();
            return Common<ReqId, ResVendorDetail>.Serialize_Deserialize(reqVendorId, resVendorDetail, StaticConst.SPGETVENDORDETAIL);
        }

        public ResId InsertExpense(ReqInsertExpense reqInsertExpense)
        {
            ResId resId = new ResId();
            return Common<ReqInsertExpense, ResId>.Serialize_Deserialize(reqInsertExpense, resId, StaticConst.SPINSERTEXPENSETYPE);
        }

        public ResGetExpenseList GetExpense(ReqUserId reqUserId)
        {
            return DBCall.GetExpenseList(reqUserId, StaticConst.SPGETEXPENSETYPE);
        }

        public ResCommon InsertPurchase(ReqPurchase reqPurchase)
        {
            return DBCall.InsertPurchase(reqPurchase, StaticConst.SPINSERTPURCHASE);
        }

        public ResPoCount GetLastInsertedPoId(ReqUserId reqUserId)
        {
            ResPoCount respoCount = new ResPoCount();
            return Common<ReqUserId, ResPoCount>.Serialize_Deserialize(reqUserId, respoCount, StaticConst.SPGETLASTINSERTEDPOID);
        }

        

        public ResCommon UpdatePurchase(ReqPurchase reqUpdatePurchase)
        {
            return DBCall.UpdatePurchase(reqUpdatePurchase, StaticConst.SPUPDATEPURCHASE);
        }

        public ResCommon DeletePurchase(ReqId reqId)
        {
            ResCommon resCommon = new ResCommon();
            return Common<ReqId, ResCommon>.Serialize_Deserialize(reqId, resCommon, StaticConst.SPDELETEPURCHASE);
        }
        public ReqPurchaseList GetPurchaseList(ReqUserId reqUserId)
        {
            return DBCall.GetPurchaseList(reqUserId, StaticConst.SPGETPURCHASELIST);
        }

        public ResPurchase_PurchaseItem GetPurchaseDetail(ReqId reqId)
        {
            return DBCall.GetPurchaseDetail(reqId, StaticConst.SPGETPURCHASEDETAIL);
        }

        public ResCommon BulkInsertPurchase(ResPurchase_PurchaseItemList resPurchase_PurchaseItemList)
        {
            return DBCall.BulkInsertPurchase(resPurchase_PurchaseItemList, StaticConst.SPBULKINSERTPURCHASE);
        }

        public ResAllUserList GetAllUser()
        {
            return DBCall.GetAllUser("sp_GetAllUser");
        }

        public ResCommon DeleteBill(ReqId reqBillId)
        {
            ResCommon resCommon = new ResCommon();
            return Common<ReqId, ResCommon>.Serialize_Deserialize(reqBillId, resCommon, StaticConst.SPDELETEBILL);
        }

        public ResBillPayment GetBillPaymentDetail(ReqId reqBillId)
        {
            ResBillPayment resBillPayment = new ResBillPayment();
            return Common<ReqId, ResBillPayment>.Serialize_Deserialize(reqBillId, resBillPayment, StaticConst.SPGETBILLPAYMENTDETAIL);
        }

        public ReqBillPayment UpdateBillPayment(ResBillPayment resBillPayment)
        {
            ReqBillPayment reqBillPayment = new ReqBillPayment();
            return Common<ResBillPayment, ReqBillPayment>.Serialize_Deserialize(resBillPayment, reqBillPayment, StaticConst.SPUPDATEBILLPAYMENT);
        }

        public ResCommon InsertBillPayment(ReqBillPayment resBillPayment)
        {
            ResCommon resCommon = new ResCommon();
            return Common<ReqBillPayment, ResCommon>.Serialize_Deserialize(resBillPayment, resCommon, StaticConst.SPINSERTBILLPAYMENT);
        }

        public ResCommon InsertBill(ReqBill reqBill)
        {
            return DBCall.InsertBill(reqBill, StaticConst.SPINSERTBILL);
        }

        public ResCommon BulkInsertBill(ReqBill_BillItem reqBill)
        {
            return DBCall.BulkInsertBill(reqBill, StaticConst.SPBULKINSERTBILL);
        }

        public ResCommon BulkInsertRecurringBill(ReqBill_BillItem reqBill)
        {
            return DBCall.BulkInsertRecurringBill(reqBill, StaticConst.SPBULKINSERTBILL);
        }

        public ResBillCount GetLastInsertedBillNo(ReqUserId reqUserId)
        {
            ResBillCount resBillCount = new ResBillCount();
            return Common<ReqUserId, ResBillCount>.Serialize_Deserialize(reqUserId, resBillCount, StaticConst.SPGETLASTINSERTEDBILLNO);
        }

        public ResBillList GetUserBillList(ReqUserId reqUserId)
        {
            return DBCall.GetUserBillList(reqUserId, StaticConst.SPGETUSERBILL);
        }

        public ResBillList GetUserFutureBillList(ReqUserId reqUserId)
        {
            return DBCall.GetUserBillList(reqUserId, StaticConst.SPGETUSERFUTUREBILL);
        }

        public ResBillList GetUserOverDueList(ReqUserId reqUserId)
        {
            return DBCall.GetUserOverDueList(reqUserId, StaticConst.SPGETUSERBILLOVERDUE);
        }

        public ResCommon UpdateBill(ReqBill reqBill)
        {
            return DBCall.UpdateBill(reqBill, StaticConst.SPUPDATEBILL);
        }

        public ReqBill GetBillDetail(ReqId reqId)
        {
            return DBCall.GetBillDetail(reqId, StaticConst.SPGETUSERBILLDETAIL);
        }

        public ResUserItemsList GetUserItemList(ReqUserId reqUserId)
        {
            return DBCall.GetUserItemList(reqUserId, StaticConst.SPGETUSERITEM);
        }

        public ResId InsertUserItem(ReqInsertUserItems reqInsertUserItems)
        {
            ResId resId = new ResId();
            return Common<ReqInsertUserItems, ResId>.Serialize_Deserialize(reqInsertUserItems, resId, StaticConst.SPINSERTUSERITEM);
        }

        public ResTdsList GetTdsList(ReqUserId reqUserId)
        {
            return DBCall.GetTdsList(reqUserId, StaticConst.SPGetTds);
        }

        public ResCommon BulkInsertVendor(ReqVendorList reqVendorList)
        {
            return DBCall.BulkInsertVendor(reqVendorList, StaticConst.SPBULKINSERTVENDOR);
        }

        public ResGetPaymentTermList GetPaymentTerm(ReqUserId reqUserId)
        {
            return DBCall.GetPaymentTermList(reqUserId, StaticConst.SPGETPAYMENTTERM);
        }

        public ResId InsertPaymentTerm(ReqPaymentTerm reqPaymentTerm)
        {
            ResId resId = new ResId();
            return Common<ReqPaymentTerm, ResId>.Serialize_Deserialize(reqPaymentTerm, resId, StaticConst.SPINSERTUSERPAYMENTTERM);

        }

        //public ResDashBoard GetDashBoardContent(ReqUserId reqUserId)
        //{
        //    return DBCall.GetDashBoardContent(reqUserId, StaticConst.SPGETDASHBOARDCONTENT);
        //}
        public CResponse.ResDashBoard GetDashBoardContentInvoice(ReqDashBoardContentTax reqDashBoardContentTax)
        {
            return DBCall.GetDashBoardContentInvoice(reqDashBoardContentTax, StaticConst.SPGETINVOICETAX);
        }

        public CResponse.ResDashBoard GetDashBoardContentExpense(ReqDashBoardContentTax reqDashBoardContentTax)
        {
            return DBCall.GetDashBoardContentExpense(reqDashBoardContentTax, StaticConst.SPGETEXPENSETAX);
        }

        public ResLastInsertedCount GetLastInsertedAdvance(ReqUserId reqUserId)
        {
            ResLastInsertedCount resLastInsertedCount = new ResLastInsertedCount();
            return Common<ReqUserId, ResLastInsertedCount>.Serialize_Deserialize(reqUserId, resLastInsertedCount, StaticConst.SPGETLASTINSERTEDADVANCENO);
        }

        public ResLastInsertedCount GetLastInsertedEstimate(ReqUserId reqUserId)
        {
            ResLastInsertedCount resLastInsertedCount = new ResLastInsertedCount();
            return Common<ReqUserId, ResLastInsertedCount>.Serialize_Deserialize(reqUserId, resLastInsertedCount, StaticConst.SPGETLASTINSERTEDESTIMATENO);
        }

        public ResLastInsertedCount GetLastInsertedCredit(ReqUserId reqUserId)
        {
            ResLastInsertedCount resLastInsertedCount = new ResLastInsertedCount();
            return Common<ReqUserId, ResLastInsertedCount>.Serialize_Deserialize(reqUserId, resLastInsertedCount, StaticConst.SPGETLASTINSERTEDCREDITNO);
        }

        public ResLastInsertedCount GetLastInsertedDebit(ReqUserId reqUserId)
        {
            ResLastInsertedCount resLastInsertedCount = new ResLastInsertedCount();
            return Common<ReqUserId, ResLastInsertedCount>.Serialize_Deserialize(reqUserId, resLastInsertedCount, StaticConst.SPGETLASTINSERTEDDEBITNO);
        }

        public ResLastInsertedCount GetLastInsertedInvoice(ReqUserId reqUserId)
        {
            ResLastInsertedCount resLastInsertedCount = new ResLastInsertedCount();
            return Common<ReqUserId, ResLastInsertedCount>.Serialize_Deserialize(reqUserId, resLastInsertedCount, StaticConst.SPGETLASTINSERTEDINVOICENO);
        }

        #region INSERT of Advance/Credit/Debit/Estimate/Invoice
        public ResCommon InsertAdvance(ReqAdvance reqAdvance)
        {
            return InvoiceCall.InsertAdvance(reqAdvance, StaticConst.SPINSERTADVANCE);
        }

        public ResCommon InsertCredit(ReqCreditNote reqCreditNote)
        {
            return InvoiceCall.InsertCredit(reqCreditNote, StaticConst.SPINSERTCREDIT);
        }

        public ResCommon InsertDebit(ReqDebitNote reqDebitNote)
        {
            return InvoiceCall.InsertDebit(reqDebitNote, StaticConst.SPINSERTDEBIT);
        }

        public ResCommon InsertEstimate(ReqEstimate reqEstimate)
        {
            return InvoiceCall.InsertEstimate(reqEstimate, StaticConst.SPINSERTESTIMATE);
        }

        public ResCommon InsertInvoice(ReqInvoice reqInvoice)
        {
            return InvoiceCall.InsertInvoice(reqInvoice, StaticConst.SPINSERTINVOICE);
        }

        #endregion

        #region Update of Advance/Credit/Debit/Estimate/Invoice
        public ResCommon UpdateAdvance(ReqAdvance reqAdvance)
        {
            return InvoiceCall.UpdateAdvance(reqAdvance, StaticConst.SPUPDATEADVANCE);
        }

        public ResCommon UpdateCredit(ReqCreditNote reqCreditNote)
        {
            return InvoiceCall.UpdateCredit(reqCreditNote, StaticConst.SPUPDATECREDIT);
        }

        public ResCommon UpdateDebit(ReqDebitNote reqDebitNote)
        {
            return InvoiceCall.UpdateDebit(reqDebitNote, StaticConst.SPUPDATEDEBIT);
        }

        public ResCommon UpdateEstimate(ReqEstimate reqEstimate)
        {
            return InvoiceCall.UpdateEstimate(reqEstimate, StaticConst.SPUPDATEESTIMATE);
        }

        public ResCommon UpdateInvoice(ReqInvoice reqInvoice)
        {
            return InvoiceCall.UpdateInvoice(reqInvoice, StaticConst.SPUPDATEINVOICE);
        }

        #endregion

        #region Delete of Advance/Credit/Debit/Estimate/Invoice

        public ResCommon DeleteAdvance(ReqId reqId)
        {
            ResCommon resCommon = new ResCommon();
            return Common<ReqId, ResCommon>.Serialize_Deserialize(reqId, resCommon, StaticConst.SPDELETEADVANCE);
        }

        public ResCommon DeleteCredit(ReqId reqId)
        {
            ResCommon resCommon = new ResCommon();
            return Common<ReqId, ResCommon>.Serialize_Deserialize(reqId, resCommon, StaticConst.SPDELETECREDIT);
        }

        public ResCommon DeleteDebit(ReqId reqId)
        {
            ResCommon resCommon = new ResCommon();
            return Common<ReqId, ResCommon>.Serialize_Deserialize(reqId, resCommon, StaticConst.SPDELETEDEBIT);
        }

        public ResCommon DeleteEstimate(ReqId reqId)
        {
            ResCommon resCommon = new ResCommon();
            return Common<ReqId, ResCommon>.Serialize_Deserialize(reqId, resCommon, StaticConst.SPDELETEESTIMATE);
        }

        public ResCommon DeleteInvoice(ReqId reqId)
        {
            ResCommon resCommon = new ResCommon();
            return Common<ReqId, ResCommon>.Serialize_Deserialize(reqId, resCommon, StaticConst.SPDELETEINVOICE);
        }

        #endregion

        #region Get Advance/Credit/Debit/Estimate/Invoice

        public ResAdvanceGetList GetAdvance(ReqUserId reqUserId)
        {
            return InvoiceCall.GetAdvance(reqUserId, StaticConst.SPGETADVANCE);
        }

        public ResCreditNoteGetList GetCredit(ReqUserId reqUserId)
        {
            return InvoiceCall.GetCredit(reqUserId, StaticConst.SPGETCREDIT);
        }

        public ResDebitNoteGetList GetDebit(ReqUserId reqUserId)
        {
            return InvoiceCall.GetDebit(reqUserId, StaticConst.SPGETDEBIT);
        }

        public ResEstimateGetList GetEstimate(ReqUserId reqUserId)
        {
            return InvoiceCall.GetEstimate(reqUserId, StaticConst.SPGETESTIMATE);
        }

        public ResInvoiceGetList GetInvoice(ReqUserId reqUserId)
        {
            return InvoiceCall.GetInvoice(reqUserId, StaticConst.SPGETINVOICE);
        }


        public ResAdvanceGetList GetAdvanceDetail(ReqId reqId)
        {
            return InvoiceCall.GetAdvanceDetail(reqId, StaticConst.SPGETADVANCEDETAIL);
        }

        public ResCreditNoteGetList GetCreditDetail(ReqId reqId)
        {
            return InvoiceCall.GetCreditDetail(reqId, StaticConst.SPGETCREDITDETAIL);
        }

        public ResDebitNoteGetList GetDebitDetail(ReqId reqId)
        {
            return InvoiceCall.GetDebitDetail(reqId, StaticConst.SPGETDEBITDETAIL);
        }

        public ResEstimateGetList GetEstimateDetail(ReqId reqId)
        {
            return InvoiceCall.GetEstimateDetail(reqId, StaticConst.SPGETESTIMATEDETAIL);
        }

        public ResInvoiceGetList GetInvoiceDetail(ReqId reqId)
        {
            return InvoiceCall.GetInvoiceDetail(reqId, StaticConst.SPGETINVOICEDETAIL);
        }

        #endregion

        #region BRS

        public ResBrsList GetBrsList(ReqBrs reqBrs)
        {
            return BrsCall.GetBrsList(reqBrs,StaticConst.SPGETBRSLIST);
        }


        public ResCommon InsertBrsPayment(ReqBrsPaymentList reqBrsPayment)
        {
            return BrsCall.InsertBrsPayment(reqBrsPayment, StaticConst.SPINSERTBRSPAYMENT);
        }

        public ResCommon UpdateBrsPayment(ReqBrsPaymentList reqUpdateBrsPayment)
        {
            return BrsCall.UpdateBrsPayment(reqUpdateBrsPayment, StaticConst.SPUPDATEBRSPAYMENT);
        }

        public ReqBrsPaymentList GetBrsPayment(ReqGetBrsPayment reqGetBrsPayment)
        {
            return BrsCall.GetBrsPayment(reqGetBrsPayment,StaticConst.SPGETBRSPAYMENT);
        }
        #endregion


        public ResrefIdList GetInvoiceRef(ReqUserId reqUserId)
        {
            return DBCall.GetInvoiceRef(reqUserId, StaticConst.SPGETINVOICEREF);
        }

        public ResrefIdList GetBillRef(ReqUserId reqUserId)
        {
            return DBCall.GetBillRef(reqUserId, StaticConst.SPGETBILLREF);
        }

        public ResReportsList GetReportList(ReqReports reqReport)
        {
            return ReportCall.GetReportList(reqReport, StaticConst.SPGETREPORTLIST);
        }

        public ResId InsertCustomer(ReqCustomer reqCustomer)
        {
            ResId resId = new ResId();
            return Common<ReqCustomer, ResId>.Serialize_Deserialize(reqCustomer, resId, StaticConst.SPINSERTCUSTOMER);
        }

        public ResId UpdateCustomer(ReqCustomerUpdate reqCustomerUpdate)
        {
            ResId resId = new ResId();
            return Common<ReqCustomerUpdate, ResId>.Serialize_Deserialize(reqCustomerUpdate, resId, StaticConst.SPUPDATECUSTOMER);
        }

        public ResCommon DeleteCustomer(ReqId reqCustomerId)
        {
            ResCommon resCommon = new ResCommon();
            return Common<ReqId, ResCommon>.Serialize_Deserialize(reqCustomerId, resCommon, StaticConst.SPDELETECUSTOMER);
        }

        public ResCustomerList GetCustomerList(ReqUserId reqUserId)
        {
            return DBCall.GetCustomerList(reqUserId, StaticConst.SPGETUSERCUSTOMERLIST);
        }

        public ResCustomerDetail GetCustomerDetail(ReqId reqCustomerId)
        {
            ResCustomerDetail resCustomerDetail = new ResCustomerDetail();
            return Common<ReqId, ResCustomerDetail>.Serialize_Deserialize(reqCustomerId, resCustomerDetail, StaticConst.SPGETCUSTOMERDETAIL);
        }

        public ResCommon UpdateLogo(ReqUpdateLogo reqUpdateLogo)
        {
            ResCommon resCommon = new ResCommon();
            return Common<ReqUpdateLogo, ResCommon>.Serialize_Deserialize(reqUpdateLogo, resCommon, StaticConst.SPUPDATELOGO);
        }

        public ResCommon SendMailCustom(ReqEmail reqEmail)
        {
            return CallThirdParty.SendMailCustom(reqEmail);
        }


        #region GST1

        public ResGst1List GetB2BGst1(ReqGst1 reqGst1)
        {
            return GST1.GetB2BGst1(reqGst1,StaticConst.SPGST1B2B);
        }

        public ResGst1List GetB2CLGst1(ReqGst1 reqGst1)
        {
            return GST1.GetB2CLGst1(reqGst1, StaticConst.SPGST1B2CL);
        }

        public ResGst1List GetB2CSGst1(ReqGst1 reqGst1)
        {
            return GST1.GetB2CSGst1(reqGst1, StaticConst.SPGST1B2CS);
        }


        public Gst1Save GetGstr1(ReqGst1 reqGst1)
        {
            return GST1.GetGstr1(reqGst1, StaticConst.SPGSTR1GET);
        }
        #endregion
    }
}
