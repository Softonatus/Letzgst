using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftonautsService.Optimize
{
    public class StaticConst
    {
       // public static string connectionString = "Data Source =SHANKAR; Initial Catalog = BragoDB ;Trusted_Connection=True";
        //public static string connectionString = "Data Source =SHANKAR; Initial Catalog = SoftonautsDB ;Trusted_Connection=True";
        public static string connectionString = "Server=tcp:210.16.103.188;Database=SoftonautsDB;User Id =Shiv;Password=June123!@#;MultipleActiveResultSets=True";
        public const char ATTHERATE = '@';
        public const string System = "System";
        public const string SYSTEMLISTTYPE = "System.Collections.Generic.List";

        #region SMS & Email
        //https://control.msg91.com/api/sendotp.php?authkey=YourAuthKey&mobile=919999999990&message=Your%20otp%20is%202786&sender=senderid&otp=2786
        public const string SMSURL = "https://control.msg91.com/api/sendhttp.php?";
        public const string SENDERID = "LTZGST";
        public const string AUTHKEY = "162806Al0fmplkeo595153d9";
        public const string EMAILID = "gsthelp@letzgst.com";
        public const string EMAILPASSWORD = "ktGm28^5";

        public const string SERVERNAME = "letzgst.com";
        #endregion

        #region Random Generation
        public const string Caps = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string  Small = "abcdefghijklmnopqrstuvwxyz";
        public const string  Num = "0123456789";
        public const string  Special = "!@#$%^&*?";
        #endregion

        #region Stored Procedure Name



        public const string SPUPDATELOGO = "sp_UpdateLogo";

        #region Login/Registration/Profile
        public const string SP_USERREGISTRATION = "sp_UserRegistration";
        public const string SP_USERLOGIN = "sp_UserLogin";
        public const string SP_UPDATEPASSWORD = "sp_Update_UserPassword";
        public const string SP_INSERTOTP = "sp_InsertOtp";
        public const string SP_VALIDATEOTP = "sp_ValidateOtp";

        public const string SP_INSERTPROFILE = "sp_ProfileInsert";
        public const string SP_GETPROFILE = "sp_GetProfile";
        public const string SP_UPDATEPROFILE = "sp_UpdateProfile";
        #endregion

        #region Get CA/Company List
        public const string SPGETUSERLIST_CA_COMPANY = "sp_GetUserList_CA_Company";
        public const string SPGETLIST_CA_COMPANY = "sp_GetCompanyList_CA";

        public const string SPDELETEUSER = "sp_DeleteUser";
        public const string SPUPDATEUSER = "sp_UpdateUser";
        #endregion

        #region Hsn/Hsc
        public const string SPSEARCHHSNCODE = "sp_SearchHsnCode";
        public const string SPGETUSERHSNCODE = "sp_GetUserHsnCode";
        public const string SPDELETEUSERHSNCODE = "sp_DeleteHsnUserCode";
        public const string SPINSERTUSERHSNCODE = "sp_InsertHsnUserCode";

     
        public const string SPSEARCHHSCCODE = "sp_SearchHscCode";
        public const string SPGETUSERHSCCODE = "sp_GetUserHsnCodeService";
        public const string SPDELETEUSERHSCCODE = "sp_DeleteHsnServiceUserCode";
        public const string SPINSERTUSERHSCCODE = "sp_InsertHsnUserService";
        public const string SPGETUSERHSNHSCCODE = "sp_GetUserHsn_HscCode";
        #endregion

        #region
        public const string SPINSERTVENDOR = "sp_InsertVendor";
        public const string SPDELETEVENDOR = "sp_DeleteVendor";
        public const string SPGETUSERVENDORLIST = "sp_GetUserVendorList";
        public const string SPGETVENDORDETAIL = "sp_GetVendorDetail";
        public const string SPUPDATEVENDOR = "sp_UpdateVendor";
        #endregion

        public const string SPINSERTEXPENSETYPE = "sp_InsertExpenseType";
        public const string SPGETEXPENSETYPE = "sp_GetExpenseType";

        #region Purchase
        public const string SPINSERTPURCHASE = "sp_InsertPurchase";
        public const string SPUPDATEPURCHASE = "sp_UpdatePurchase";
        public const string SPGETPURCHASELIST = "sp_GetUserPurchase";
        public const string SPGETPURCHASEDETAIL = "sp_GetUserPurchaseDetail";
        public const string SPBULKINSERTPURCHASE = "sp_BulkInsertPurchase";
        #endregion

        public const string SPGETLASTINSERTEDPOID = "sp_GetLastInsertedPoId";

        #region  Bill
        public const string SPBULKINSERTBILL = "sp_BulkInsertBill";
        public const string SPDELETEBILL = "sp_DeleteBill";
        public const string SPGETBILLPAYMENTDETAIL = "sp_GetBillPaymentDetail";
        public const string SPGETBILLPAYMENTLIST = "sp_GetBillPaymentList";
        public const string SPGETLASTINSERTEDBILLNO = "sp_GetLastInsertedBillNo";
        public const string SPGETUSERBILL = "sp_GetUserBill";
        public const string SPGETUSERBILLDETAIL = "sp_GetUserBillDetail";
        public const string SPGETUSERBILLOVERDUE = "sp_GetUserBillOverDue";
        public const string SPINSERTBILL = "sp_InsertBill";
        public const string SPINSERTBILLPAYMENT = "sp_InsertBillPayment";
        public const string SPUPDATEBILL = "sp_UpdateBill";
        public const string SPUPDATEBILLPAYMENT = "sp_UpdateBillPayment";
        public const string SPGETUSERFUTUREBILL = "sp_GetUserFutureBill";
        #endregion

        public const string SPGETUSERITEM = "sp_GetUserItem";
        public const string SPINSERTUSERITEM = "sp_InsertUserItem";
        public const string SPGetTds = "sp_GetTds";
        public const string SPBULKINSERTVENDOR = "sp_BulkInsertVendor";
        public const string SPGETPAYMENTTERM = "sp_GetPaymentTerm";
        public const string SPINSERTUSERPAYMENTTERM =  "sp_InsertUserPaymentTerm";
        public const string SPGETDASHBOARDCONTENT = "sp_GetDashBoardContent";
        public const string SPDELETEPURCHASE = "sp_DeletePurchase";

        #region Invoice/Debit/Credit
        public const string SPINSERTADVANCE = "sp_InsertAdvance";
        public const string SPUPDATEADVANCE = "sp_UpdateAdvance";
        public const string SPDELETEADVANCE = "sp_DeleteAdvance";
        public const string SPGETADVANCEDETAIL = "sp_GetAdvanceDetail";
        public const string SPGETCREDITDETAIL = "sp_GetCreditDetail";
        public const string SPGETDEBITDETAIL = "sp_GetDebitDetail";
        public const string SPGETESTIMATEDETAIL = "sp_GetEstimateDetail";
        public const string SPGETINVOICEDETAIL = "sp_GetInvoiceDetail";
        public const string SPDELETECREDIT = "sp_DeleteCredit";
        public const string SPDELETEDEBIT = "sp_DeleteDebit";
        public const string SPDELETEESTIMATE = "sp_DeleteEstimate";
        public const string SPDELETEINVOICE = "sp_DeleteInvoice";
        public const string SPGETADVANCE = "sp_GetAdvance";
        public const string SPGETCREDIT = "sp_GetCredit";
        public const string SPGETDEBIT = "sp_GetDebit";
        public const string SPGETESTIMATE = "sp_GetEstimate";
        public const string SPGETINVOICE = "sp_GetInvoice";
        public const string SPINSERTCREDIT = "sp_InsertCredit";
        public const string SPINSERTDEBIT = "sp_InsertDebit";
        public const string SPINSERTESTIMATE = "sp_InsertEstimate";
        public const string SPINSERTINVOICE = "sp_InsertInvoice";
        public const string SPUPDATECREDIT = "sp_UpdateCredit";
        public const string SPUPDATEDEBIT = "sp_UpdateDebit";
        public const string SPUPDATEESTIMATE = "sp_UpdateEstimate";
        public const string SPUPDATEINVOICE = "sp_UpdateInvoice";
        public const string SPGETLASTINSERTEDADVANCENO = "sp_GetLastInsertedAdvanceNo";
        public const string SPGETLASTINSERTEDCREDITNO = "sp_GetLastInsertedCreditNo";
        public const string SPGETLASTINSERTEDDEBITNO = "sp_GetLastInsertedDebitNo";
        public const string SPGETLASTINSERTEDESTIMATENO = "sp_GetLastInsertedEstimateNo";
        public const string SPGETLASTINSERTEDINVOICENO = "sp_GetLastInsertedInvoiceNo";

        #endregion

        public const string SPGETINVOICEREF = "sp_GetInvoiceRef";
        public const string SPGETBILLREF = "sp_GetBillRef";
        public const string SPGETINVOICETAX = "sp_GetInvoiceTax";
        public const string SPGETEXPENSETAX = "sp_GetExpenseTax";

        #region
        public const string SPGETBRSLIST = "sp_GetBrsList";
        public const string SPINSERTBRSPAYMENT = "sp_InsertBrsPayment";
        public const string SPGETBRSPAYMENT = "sp_GetBrsPayment";
        #endregion

        public const string SPGETREPORTLIST = "sp_GetReportList";

        #region Customer
        public const string SPINSERTCUSTOMER = "sp_InsertCustomer";
        public const string SPUPDATECUSTOMER = "sp_UpdateCustomer";
        public const string SPDELETECUSTOMER = "sp_DeleteCustomer";
        public const string SPGETCUSTOMERDETAIL = "sp_GetCustomerDetail";
        public const string SPGETUSERCUSTOMERLIST = "sp_GetUserCustomerList";
        #endregion

        public const string SPUPDATEBRSPAYMENT = "sp_UpdateBrsPayment";

        #region Gst1 Fetch 
        public const string SPGST1B2B = "sp_GST1_B2B";
        public const string SPGST1B2CL = "sp_GST1_B2CL";
        public const string SPGST1B2CS = "sp_GST1_B2CS";
        public const string SPGST1CREDITDEBITREGISTERED = "sp_GST1_CreditDebitRegistered";
        public const string SPGST1CREDITDEBITUNREGISTERED = "sp_GST1_CreditDebitUnRegistered";
        public const string SPGST1EXPORT = "sp_GST1_Export";
        public const string SPGST1ADVANCE = "sp_GST1_Advance";
        public const string SPGST1ADVANCEADJ = "sp_GST1_AdvanceAdj";

        public const string SPGSTR1GET = "sp_GSTR1_Get"; 
        #endregion

        #endregion

        #region Email Content



        #endregion
    }
}
