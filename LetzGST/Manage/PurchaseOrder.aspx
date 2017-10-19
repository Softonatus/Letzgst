<%@ Page Title="" Language="C#" MasterPageFile="~/GSTSite.Master" AutoEventWireup="true" CodeBehind="PurchaseOrder.aspx.cs" Inherits="LetzGST.Manage.PurchaseOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- main Content starts here-->
  <%--  <div id="page-content-wrapper">--%>

                <div class="box clearfix">

                    <div class="box-header with-border">
                        <h3 class="box-title">Expenditure Management : Expenditure Proforma</h3>
                    </div>
                    <div class="box-body">
                        <div id="horizontalTab">
                            <div id="expensetable" style="display: block;">
                                <div class="row">
                                    <div class="col-md-6 col-sm-12 col-xs-12">
                                        <%--Future Bills--%>
                                        <table class="table">
                                           <%-- <tr>
                                                <th>Bill</th>
                                                <th>Amount</th>
                                                <th>Date</th>
                                            </tr>
                                            <tr>
                                                <td>Tes</td>
                                                <td><span class="icon ico-rupees ico-3x"></span> 10,000</td>
                                                <td>13/09/2017</td>
                                            </tr>--%>
                                        </table>
                                    </div>
                                    
                                     <div class="col-md-6 col-sm-12 col-xs-12">
                                        <a class="btn btn-ltz m-t-30 pull-right" id="addpobtn"><span class="icon ico-add ico-2x"></span> Add  Expenditure Proforma</a>
                                    </div>
                                </div>
                                <br />
                                <div class="table-container">
                                    <div class="col-md-12 col-sm-12 col-xs-12">
                                        <table id="exptable" class="table table-striped table-bordered dt-responsive dataTable no-footer dtr-inline" width="100%" cellspacing="0">
                                            <thead>
                                                <tr>
                                                    <th>Sr.no</th>
                                                    <th>Vendor Name</th>
                                                    <th>Due Date</th>
                                                    <th>Amount</th>
                                                    <th>Status</th>
                                                    <th>Actions</th>
                                                </tr>
                                            </thead>
                                            <tbody id="tblPOdetails">
                                                <tr>
                                                    <td colspan="6">
                                                        Loading...
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>

                                </div>

                            </div>
                            <div id="addexpense" style="display: none;">
                                <form id="addExpenseDetails" runat="server">
                                    <div class="row">
                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                            <div class="btns-container">
                                                <div class="pull-left">
                                                    <a class="btn letz-btn btn-ltz" id="backtopo"><span class="icon ico-back ico-2x"></span> Back</a>
                                                </div>

                                                <div class="pull-right">
                                                    <a class="btn letz-btn btn-ltz" onClick="printdiv('my-container');" id="PrintPdf"><span class="icon ico-printer ico-2x"></span> Print</a>
                                                    <a class="btn letz-btn btn-ltz" type="submit" id="btn_SubmitPO"><span class="icon ico-save ico-2x"></span> Save</a>
                                                    <%--<a href="" class="btn btn-ltz btn-outline" data-toggle="modal" data-target="#sendquote"><span class="icon ico-sendbtn ico-2x"></span> Send</a>--%>
                                                </div>
                                            </div>

                                            <%--<div class="btns-container">
                                                <div class="pull-left">
                                                    <a class="btn btn-danger letz-btn" id="backtopo"><span class="glyphicon glyphicon-remove"></span></a>
                                                </div>
                                                
                                                <div class="pull-right">
                                                    <a class="btn btn-warning letz-btn">View</a>
                                                    <button class="btn btn-primary letz-btn" type="submit" id="btn_SubmitPO">Submit</button>
                                                </div>
                                            </div>--%>

                                        </div>
                                    </div>
                                    <div class="row">
                                    <div class="col-md-3 col-sm-12 col-xs-12">
                                        <div class="form-group ">
                                            <label class="control-label">Purchase Type</label>
                                            <select id="purchaseType" name="purchaseType" data-placeholder="Select Purchase Type" class="form-control chosen-select-deselect">  
                                                <option></option>
                                                <option value="1">Taxable</option>
                                                    <option value="2"> Exempt </option>
                                                    <option value="3"> Nill Rated</option>
                                                    <option value="4">Special Economic Zone(SEZ)</option>
                                                    <option value="5">Non GST</option>
                                                    <option value="6">From Composition Dealer</option>
                                                    <option value="7">Import</option>
                                                    <option value="8">Import of Service(RCM)</option>
                                            </select>
                                        </div>
                                    </div>
                                    <div class="col-md-3 col-sm-12 col-xs-12">
                                        <div class="form-group ">
                                            <label class="control-label">Purchase Code</label>
                                            <select id="purchaseCode" name="purchaseCode" data-placeholder="Select Purchase Code" class="form-control chosen-select-deselect" >  
                                                <option></option>
                                                <option value="1"> Inter State</option>
                                                <option value="2"> Intra State </option>                                                    
                                                <option value="import">Import</option>
                                                <option>Special Economic Zone (SEZ)</option>
                                            </select>
                                        </div>
                                    </div>
                                    <div class="col-md-3 col-sm-12 col-xs-12">
                                        <div class="form-group ">
                                            <label class="control-label">Type of Credit</label>
                                            <select id="purchasecreditType" name="purchasecreditType" data-placeholder="Select Type of Credit" class="form-control chosen-select-deselect" >  
                                                <option></option>
                                                <option value="1"> Not Applicable </option>
                                                <option value="2"> Input </option>
                                                <option value="3"> Input Service</option>
                                                <option value="4"> Capital Goods</option>
                                            </select>
                                        </div>
                                    </div>
                                </div>
                                    <div class="row">
                                        <div class="col-md-3 col-sm-12 col-xs-12">
                                            <div class="form-group ">
                                                <label class="control-label">Select Vendor</label> &nbsp; <span id="err_purchaseorderto"></span>
                                                <select id="purchaseorderto" name="purchaseorderto" data-placeholder="Select vendor" class="form-control chosen-select-deselect" required="required">  
                                                    <option></option>
                                                    <option value="addnewpoto"  class="addnewtxt">Add new vendor</option>
                                                </select>
                                                <div class="edits" style="display: none;"><a href="javascript:void(0);"><span class="icon ico-edit ico-2x"></span></a></div>
                                            </div>
                                        </div>
                                        <div class="col-md-3 col-sm-12 col-xs-12">
                                            <div class="form-group">
                                                <label class="control-label">PO No</label>
                                                <input type="text" id="billno" class="form-control">
                                            </div>
                                        </div>
                                        <div class="col-md-3 col-sm-12 col-xs-12">
                                            <div class="form-group">
                                                <label class="control-label">PO Date</label>  &nbsp;<span id="err_podate"></span>
                                                <div class="input-group date">
                                                    <div class="input-group-addon">
                                                        <i class="icon ico-calendar"></i>
                                                    </div>
                                                    <input type="text" class="form-control pull-right" id="podate" name="podate" required="required">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3 col-sm-12 col-xs-12">
                                            <div class="form-group">
                                                <label class="control-label">PO Due Date</label>  &nbsp;<span id="err_duedate"></span>
                                                <div class="input-group date">
                                                    <div class="input-group-addon">
                                                        <i class="icon ico-calendar"></i>
                                                    </div>
                                                    <input type="text" class="form-control pull-right" id="duedate" name="duedate" required="required">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3 col-sm-12 col-xs-12">
                                            <div class="form-group ">
                                                <label class="control-label">Expense Type</label> &nbsp;<span id="err_addnewexp"></span>
                                                <select id="addnewexp" name="addnewexp" data-placeholder="Select expense type" class="form-control chosen-select-deselect" required="required">  
                                                    <option></option>
                                                    <option value="newexpense"  class="addnewtxt"> Add new expense</option>
                                                </select>
                                            </div>
                                        </div>
                                        <div class="col-md-3 col-sm-12 col-xs-12">
                                            <div class="form-group">
                                                <label class="control-label">Ref No</label>
                                                <input type="text" id="refno" class="form-control">
                                            </div>
                                        </div>
                                        <div class="col-md-3 col-sm-12 col-xs-12">
                                            <div class="form-group ">
                                                <label class="control-label">Payment Terms</label> &nbsp;<span id="err_paymentterms"></span>
                                                <select id="paymentterms" name="paymentterms" data-placeholder="Select payment term" class="form-control chosen-select-deselect" required="required"> 
                                                    <option></option>
                                                    <option value="addpaymentterms"  class="addnewtxt">Add new payment term</option>
                                                </select>
                                            </div>
                                        </div>
                                        <div class="col-md-3 col-sm-12 col-xs-12"></div>
                                    </div>

                                    <div class="p-t-20">
                                        <table id="potable" class="table table-bordered dt-responsive nowrap dataTable no-footer dtr-inline ltz-table" width="100%" cellspacing="0">
                                            <thead>
                                                <tr>
                                                    <th class="w-1">Sr.no</th>
                                                    <th class="w-2">Items</th>
                                                    <th class="w-2">Description</th>
                                                    <th class="w-3">Price</th>
                                                    <th class="w-4">Qty / Unit</th>
                                                    <th class="w-4">Amount</th>
                                                    <th class="w-4">Tax</th>
                                                    <th class="w-4">GST</th>
                                                    <th class="w-1"></th>
                                                </tr>
                                            </thead>
                                            <tbody id="tblItemDetails">
                                                <tr class="data-wrapper">
                                                    <td id="tr_1">1</td>
                                                    <td>
                                                        <select id="additems_1" name="additems_1" data-placeholder="Select Items" class="form-control additems chosen-select-deselect userItemDetails" required="required">                                                
                                                                <option></option>
                                                                <option value="addnewitem"  class="addnewtxt">Add new item</option>
                                                            </select>
                                                    </td>
                                                    <td><textarea class="form-control" id="desc_1" name="desc_1" ></textarea></td>
                                                    <td><input type="text" class="form-control calculate ignore" id="price_1" data-rule-required="true" name="price_1" onkeypress="return isNumberKey(event)"></td>
                                                    <td><input type="text" class="form-control product-qty calculate ignore" id="unt_1"  data-rule-required="true" name="unt_1" onkeypress="return isNumberKey(event)"><span id="unit_1"></span></td>
                                                   
                                                    <td><input type="text" class="form-control amtdetails" disabled id="Amount_1"></td>
                                                    <td>
                                                        <select id="tax_1" name="tax_1" data-placeholder="Select Tax" class="form-control chosen-select-deselect calculate ignore" required="required" data-rule-required="true">                                                
                                                                <option></option>
                                                                <option>NA</option>
                                                                <option value="0"> 0 </option>
                                                                <option value="3"> 3% </option>
                                                                <option value="5">5%</option>
                                                                <option value="12">12%</option>
                                                                <option value="18">18%</option>
                                                                <option value="28">28%</option>
                                                            </select>
                                                    </td>
                                                    <td>
                                                        <div id="taxseperation_1">                                                            
                                                            <div class="gsttax-txt cgst-sep" style="display:none;"><span>CGST@</span><span class="cgst">0</span>%<span> : <i>&#8377;</i><span class="cgstAmt"> 0</span></span></div>
                                                            <div class="gsttax-txt sgst-sep"  style="display:none;"><span>SGST@</span><span class="sgst">0</span>%<span> : <i>&#8377;</i><span class="sgstAmt"> 0</span></span></div>
                                                            <div class="gsttax-txt igst-sep"  style="display:none;"><span>IGST@</span><span class="igst">0</span>%<span> : <i>&#8377;</i><span class="igstAmt"> 0</span></span></div>
                                                            <div class="gsttax-txt utgst-sep"  style="display:none;"><span>UTGST@</span><span class="utgst">0</span>%<span> : <i>&#8377;</i><span class="utgstAmt"> 0</span></span></div>
                                                        </div>

                                                    </td>
                                                    <td width="2%">
                                                        <input type='button' class='add tbl-btn' value='' id="add_1" />
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>


                                    <div class="p-t15">
                                        <div class="row">
                                            <div class="col-md-4 col-sm-12 col-xs-12">
                                                <div class="fomr-group">
                                                    <label class="control-label">Notes</label>
                                                    <textarea class="form-control" id="TA_notes"></textarea>
                                                </div>
                                                <div class="fomr-group p-t-20">
                                                    <label class="control-label">Terms &amp; Conditions</label>
                                                    <textarea class="form-control" id="TandC"></textarea>
                                                </div>
                                            </div>
                                            <div class="col-md-4 col-sm-12 col-xs-12">
                                                <div class="fomr-group">
                                                    <label class="control-label">Purchase Payment Details</label>
                                                    <textarea class="form-control" id="PayDet"></textarea>
                                                </div>
                                                <%--<div class="form-group p-t-20">
                                                    <label class="control-label">Attachment</label>
                                                    <input type="file" class="filestyle" data-icon="false" id="companylogo" name="companylogo" multiple>
                                                </div>--%>

                                            </div>
                                            <div class="col-md-4 col-sm-12 col-xs-12">
                                                <div class="total-container">
                                                    <div class="col-md-5 col-sm-4 col-xs-4 net-total">
                                                        <p class="control-label">Sub Total :</p>
                                                        <p class="control-label">Total CGST:</p>
                                                        <p class="control-label">Total SGST:</p>
                                                        <p class="control-label">Total IGST:</p>
                                                        <p class="control-label">Total UTGST:</p>
                                                        <p class="control-label p-t-5">Freight &amp; Packaging:</p>
                                                        <p class="control-label p-t-5">Labour Charge:</p>
                                                        <p class="control-label p-t-5"> Insurance Amt:</p>
                                                        <p class="control-label p-t-5"> Other Charges:</p>
                                                        <p class="control-label p-t-10">Discount :</p>
                                                        <%--<p class="control-label p-t-5">CESS :</p>--%>
                                                        <p class="control-label p-t-5">Round of &nbsp;
                                                            <input type="checkbox"> :</p>
                                                        <p class="control-label payable-text">Gross Total : </p>
                                                        <p class="control-label payable-text">Amount In Word : </p>
                                                    </div>
                                                    <div class="col-md-7 col-sm-4 col-xs-4 net-total no-gutter">
                                                        <p><span class="icon ico-rupees ico-3x"></span> <span id="totalamt">0</span></p>
                                                        <p><span class="icon ico-rupees ico-3x"></span> <span id="totalcgst">0</span></p>
                                                        <p><span class="icon ico-rupees ico-3x"></span> <span id="totalsgst">0</span></p>
                                                        <p><span class="icon ico-rupees ico-3x"></span> <span id="totaligst">0</span></p>
                                                        <p><span class="icon ico-rupees ico-3x"></span> <span id="totalugst">0</span></p>
                                                        <p><span class="icon ico-rupees ico-3x"></span> <input type="text" id="freight" value="0" class="discount-txt"></p>
                                                        <p><span class="icon ico-rupees ico-3x"></span> <input type="text" id="labourCharge" value="0" class="discount-txt"></p>
                                                        <p><span class="icon ico-rupees ico-3x"></span> <input type="text" id="InsuranceAmt" value="0" class="discount-txt"></p>
                                                        <p><span class="icon ico-rupees ico-3x"></span> <input type="text" id="otherCharges" value="0" class="discount-txt"></p>
                                                        <p>
                                                            &nbsp;&nbsp;&nbsp; <input type="text" id="disount" value="0" class="discount-txt"><label>%</label>
                                                        </p>
                                                       <%-- <p>&nbsp;&nbsp;&nbsp; <input type="text" id="cess" value="" class="discount-txt"></p>--%>
                                                        <%-- <p>
                                                            <select id="invoicetds" data-placeholder="Select TDS" name="invoicetds" class="chosen-select select-tds">
                                                                    <option></option>                                                               
                                                                </select>
                                                            <span id="tds-description" class="tdstxt">Interest other than Interest on Securities</span>
                                                        </p>--%>

                                                        <p>
                                                            <span class="icon ico-rupees ico-3x"></span> <span id="roundamt">0</span>
                                                        </p>
                                                        <p class="payable-text"><span class="icon ico-rupees ico-3x"></span> <span id="nettotal">0</span></p>
                                                        <p class="payable-text"><span ></span> <span id="AmtWords"></span></p>
                                                    </div>
                                                </div>
                                            </div>

                                            <%--<div class="col-md-4 col-sm-12 col-xs-12">
                                                <div class="row">
                                                    <div class="col-md-4 col-sm-4 col-xs-4 net-total">
                                                        <p class="control-label">Total :</p>


                                                        <p class="control-label">Round of &nbsp;<input type="checkbox"  id="chkRound"> :</p>
                                                        <p class="control-label payable-text">Net Total : </p>
                                                    </div>
                                                    <div class="col-md-8 col-sm-4 col-xs-4 net-total">
                                                        <p><span class="icon ico-rupees ico-3x"></span> <span id="totalamt"></span></p>

                                                       

                                                        <p>
                                                            <span class="icon ico-rupees ico-3x"></span> <span id="roundamt"></span>
                                                        </p>
                                                        <p class="payable-text"><span class="icon ico-rupees ico-3x"></span> <span id="nettotal"></span></p>
                                                    </div>
                                                </div>
                                            </div>--%>
                                        </div>
                                    </div>

                                    <asp:HiddenField ClientIDMode="Static" ID="hdn_uCountry" runat="server" Value="0" />          
                                    <asp:HiddenField ClientIDMode="Static" ID="hdn_LoginName" runat="server" Value="" /> 
                                    <asp:HiddenField ClientIDMode="Static" ID="hdn_Main" runat="server" Value="0" />
                                    <asp:HiddenField ClientIDMode="Static" ID="hdn_uType" runat="server" Value="0" /> 
                                    <asp:HiddenField ClientIDMode="Static" ID="hdn_LogoUrl" runat="server" Value="" />                                 
                                    <input type="hidden" id="hdnRowId" value="1" />
                                    <input type="hidden" id="hdnPurchaseId" value="" />
                                    <input type="hidden" id="hdnVendorId" value="" />

                                </form>
                            </div>

                        </div>
                    </div>


                </div>

           <%-- </div>--%>
    <!-- main content ends here -->
    <!-------------all modals starts here-------------->
    <!--add new vendor start-->
    <div class="modal fade " id="poorderto" tabindex="-1" role="dialog" style="display: none;">
        <form id="vendordetails">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="modal-title" id="myModalLabel">Add Vendor</h4>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-6 col-sm-6 col-xs-12">

                                <div class="form-group">
                                    <label class="control-label">Vendor / Company Name </label> &nbsp;  <span id="err_companyname"></span>
                                    <input type="text" class="form-control" id="companyname" name="companyname" placeholder="Vendor / Company Name" required="required">
                                </div>
                                <div class="form-group">
                                    <label class="control-label required">Contact Number </label> &nbsp;  <span id="err_contactno"></span>
                                    <input type="text" class="form-control" id="contactno" name="contactno" placeholder="Contact Number" required="required">
                                </div>
                                <div class="form-group">
                                    <label class="control-label required">Email </label> &nbsp;  <span id="err_profileemail"></span>
                                    <input type="email" class="form-control" id="profileemail" name="profileemail" placeholder="Email" required="required">
                                </div>
                                <div class="row">
                                    <div class  ="form-group col-md-6 col-sm-12 col-xs-12"> 
                                        <label class="control-label">City </label> &nbsp;  <span id="err_city"></span>
                                        <input type="text" class="form-control" id="city" name="city" placeholder="City" required="required">
                                    </div>
                                    <div class="form-group col-md-6 col-sm-12 col-xs-12">
                                        <label class="control-label">State </label> &nbsp;  <span id="stateErr"></span>
                                        <select id="state" name="state"  data-placeholder="Select State" class="form-control chosen-select-deselect" required="required">                                                
                                                    <option></option>
                                                    <option value="Andaman and Nicobar Islands">Andaman and Nicobar Islands</option>
                                                    <option value="Andhra Pradesh">Andhra Pradesh</option>
                                                    <option value="Arunachal Pradesh">Arunachal Pradesh</option>
                                                    <option value="Assam">Assam</option>
                                                    <option value="Bihar">Bihar</option>
                                                    <option value="Chandigarh">Chandigarh</option>
                                                    <option value="Chhattisgarh">Chhattisgarh</option>
                                                    <option value="Dadra and Nagar Haveli">Dadra and Nagar Haveli</option>
                                                    <option value="Daman and Diu">Daman and Diu</option>
                                                    <option value="Delhi">Delhi</option>
                                                    <option value="Goa">Goa</option>
                                                    <option value="Gujarat">Gujarat</option>
                                                    <option value="Haryana">Haryana</option>
                                                    <option value="Himachal Pradesh">Himachal Pradesh</option>
                                                    <option value="Jammu and Kashmir">Jammu and Kashmir</option>
                                                    <option value="Jharkhand">Jharkhand</option>
                                                    <option value="Karnataka">Karnataka</option>
                                                    <option value="Kerala">Kerala</option>
                                                    <option value="Lakshadweep">Lakshadweep</option>
                                                    <option value="Madhya Pradesh">Madhya Pradesh</option>
                                                    <option value="Maharashtra">Maharashtra</option>
                                                    <option value="Manipur">Manipur</option>
                                                    <option value="Meghalaya">Meghalaya</option>
                                                    <option value="Mizoram">Mizoram</option>
                                                    <option value="Nagaland">Nagaland</option>
                                                    <option value="Orissa">Orissa</option>
                                                    <option value="Puducherry">Puducherry</option>
                                                    <option value="Punjab">Punjab</option>
                                                    <option value="Rajasthan">Rajasthan</option>
                                                    <option value="Sikkim">Sikkim</option>
                                                    <option value="Tamil Nadu">Tamil Nadu</option>
                                                    <option value="Tripura">Tripura</option>
                                                    <option value="Uttaranchal">Uttaranchal</option>
                                                    <option value="Uttar Pradesh">Uttar Pradesh</option>
                                                    <option value="West Bengal">West Bengal</option>
                                                </select>
                                        
                                    </div>
                                </div>


                            </div>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <div class="form-group">
                                    <label class="control-label">Contact Person </label> &nbsp; <span id="err_ContactPerson"></span>
                                    <input type="text" class="form-control" id="ContactPerson" name="ContactPerson" placeholder="Contact Person" required="required">
                                </div>
                                <div class="form-group address-group">
                                    <label class="control-label">Address </label> &nbsp;  <span id="err_address1"></span>
                                    <input type="text" class="form-control" id="address1" name="address1" placeholder="Address line 1" required="required">
                                    <input type="text" class="form-control" id="address2" name="address2" placeholder="Address line 2">
                                    <input type="text" class="form-control" id="address3" name="address3" placeholder="Address line 3">
                                </div>
                                <div class="row">

                                </div>
                                <div class="row">
                                    <div class="form-group col-md-6 col-sm-12 col-xs-12">
                                        <label class="control-label required">Pin </label> &nbsp;  <span id="err_pin"></span>
                                        <input type="text" class="form-control" id="pin" name="pin" placeholder="Pin" required="required">
                                    </div>
                                    <div class="form-group col-md-6 col-sm-12 col-xs-12">
                                        <label class="control-label">Country</label>
                                        <input type="text" class="form-control" id="country" name="country" value="India" readonly="readonly"  />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label class="control-label">PAN Number</label>
                                    <input type="text" class="form-control" id="panno" name="panno" placeholder="Pan Number">
                                </div>
                                <div class="form-group hideme">
                                    <label class="control-label">TAN</label>
                                    <input type="text" class="form-control" id="tan" name="tan" placeholder="Tan Number">
                                </div>
                                <div class="form-group hidemember" style="display:none">
                                    <label class="control-label required">CA Membership ID</label>
                                    <input type="text" class="form-control" id="camembership" name="camembership" placeholder="CA Membership Number" required="required">
                                </div>
                                <div class="form-group hideme">
                                    <label class="control-label">Service Tax</label>
                                    <input type="text" class="form-control" id="servicetax" name="servicetax" placeholder="Service Number">
                                </div>
                            
                                <div class="form-group hideme">
                                    <label class="control-label">Bank  Account Number </label>
                                    <input type="text" class="form-control" id="bankacno" name="bankacno" placeholder="Bank Account Number">
                                </div>
                               <div class="form-group hideme">
                                    <label class="control-label">Bank  Account Name </label>
                                    <input type="text" class="form-control" id="bankacname" name="bankacname" placeholder="Bank  Account Name">
                                </div>
                            </div>

                            <div class="col-md-6 col-sm-12 col-xs-12">

                                <div class="form-group">
                                    <label class="control-label">GSTN</label>
                                    <input type="text" class="form-control" id="gstnno" name="gstnno" placeholder="Gst Number">
                                </div>
                                <div class="form-group hideadhaar" style="display:none">
                                    <label class="control-label">Adhaar Number</label>
                                    <input type="text" class="form-control" id="adhaar" name="adhaar" placeholder="Adhaar Number">
                                </div>
                                <div class="form-group hideme">
                                    <label class="control-label">CIN</label>
                                    <input type="text" class="form-control" id="cin" name="cin" placeholder="Cin Number">
                                </div>
                                <div class="form-group hideme">
                                    <label class="control-label">VAT / TIN </label>
                                    <input type="text" class="form-control" id="vattin" name="vattin" placeholder="Vat / Tin Number">
                                </div>
                                <div class="form-group hideme">
                                    <label class="control-label">IFSC</label>
                                    <input type="text" class="form-control" id="ifsc" name="ifsc" placeholder="IFSC">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal" >Close</button>
                        <button type="button" class="btn btn-primary" id ="saveVendor">Save changes</button>
                    </div>
                </div>
            </div>
        </form>
    </div>
    <!--add new vendor end -->
    <!-----add new expense type start -->
    <div class="modal fade " id="newexpenses" tabindex="-1" role="dialog" style="display: none;">
        <form id="expenseDetails">
            <div class="modal-dialog bs-example-modal-md" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="newExpenses">Add New Expense</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label class="control-label">Expense Name </label>&nbsp; <span id="err_newexpense"></span>
                                    <input type="text" class="form-control" id="newexpense" name="newexpense" placeholder="Expense Name" required="required" />
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                        <button type="button" class="btn btn-primary" id="saveExpense">Save changes</button>
                    </div>
                </div>
            </div>
        </form>
    </div>
    <!-----add new expense type end-->
    <!-----add new payment terms start -->
    <div class="modal fade " id="addpayments" tabindex="-1" role="dialog" style="display: none;">
        <div class="modal-dialog bs-example-modal-md" role="document">
            <form id="frm_addPayment">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="newPaymentTerm">Add New Payment Term</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label class="control-label">Payment Term</label> <span id="err_newpyterm"></span>
                                    <input type="text" class="form-control" id="newpyterm" name="newpyterm" placeholder="Payment Term">
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                        <button type="button" class="btn btn-primary" id="savePaymentTerm">Save changes</button>
                    </div>
                </div>
            </form>
        </div>
    </div>
    <!-----add new payment terms end-->
    <!-----add new payment terms start -->
    <div class="modal fade itemsadd" id="" tabindex="-1" role="dialog" style="display: none;">
        <div class="modal-dialog bs-example-modal-md" role="document">
            <form id="frm_additem">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="newItem">Add New Item</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label">Item Name &nbsp;</label>&nbsp; <span id="err_txtItemName"></span>
                                    <input type="text" class="form-control" id="txtItemName" name="txtItemName" placeholder="Item Name" required="required">
                                </div>
                                <div class="form-group">
                                    <label class="control-label">HSN / SAC Code</label> &nbsp;<span id="err_txt_hsnhsc"></span>
                                    <input type="text" class="form-control" id="txt_hsnhsc" name="txt_hsnhsc" placeholder="HSN / SAC Code"  required="required">

                                    <button class="btn link-btn" data-toggle="modal" href="#codesmodal">Find HSN / SAC Codes</button>
                                </div>
                                <div class="form-group">
                                    <label class="control-label">Price</label> &nbsp;<span id="err_txtprice"></span>
                                    <input type="text" class="form-control" id="txtprice" name="txtprice" placeholder="Price" required="required">
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="control-label">Tax</label>  &nbsp;<span id="err_taxdetails"></span>
                                    <select id="taxdetails" name="taxdetails" class="form-control" required="required">                                                
                                        <option value="-1">-- Select --</option>
                                        <option value="NA">NA</option>
                                        <option value="0"> 0 </option>
                                        <option value="3"> 3% </option>
                                        <option value="5"> 5% </option>
                                        <option value="12">12%</option>
                                        <option value="18">18%</option>
                                        <option value="28">28%</option>
                                    </select>
                                </div>

                                <div class="form-group">
                                    <label class="control-label">Measure units</label> &nbsp;<span id="err_dd_Unit"></span>
                                    <select id="dd_Unit" name="dd_Unit" class="form-control" required="required">                                                
                                        <option value="-1">-- Select --</option>
                                        <option value="NA">NA</option>
                                        <option value="0"> KG </option>
                                        <option value="3"> Box</option>
                                        <option value="5">Bundle</option>
                                    </select>
                                </div>
                                <div class="form-group">
                                    <label class="control-label">Description</label>
                                    <textarea class="form-control" id="TA_desc"></textarea>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                        <button type="button" class="btn btn-primary" id="btnSaveItem">Save changes</button>
                    </div>
                </div>
            </form>
        </div>
    </div>
    <!-----add new payment terms end-->
    <!-----add new payment terms start -->
    <!--<div class="modal fade itemsadd" id="codesmodal" tabindex="-1" role="dialog" style="display: none;">-->
    <div id="codesmodal" class="modal fade" tabindex="-1" data-focus-on="input:first" style="display: none;">
        <div class="modal-dialog bs-example-modal-md" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="HsnHsc">Find HSN / SAC Codes</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
        </button>
                </div>
                <div class="modal-body">
                    <form id="sethsncode" onsubmit="return false">
                        <div class="row">
                            <div class=" col-md-4 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label class="control-label">Select </label>
                                   <select id="crrole" name="crrole" class="form-control" required="required">                                                
                                        <option value="-1">--Select--</option>
                                        <option value="hsn"> Goods </option>
                                        <option value="hsc"> Services</option>
                                    </select>
                                </div>
                            </div>
                            <div class="col-md-8 col-sm-12 col-xs-12">
                                <label>Search HSN / SAC code</label>
                                <div id="imaginary_container">
                                    <div class="input-group stylish-input-group">
                                        <input type="text" class="form-control" placeholder="HSN Code (e.g. 1011090) or keywords (e.g. Manufactures )" id="txtSearch" />
                                        <span class="input-group-addon">
                                            <button type="button" id="search">
                                                <span class="glyphicon glyphicon-search"></span>
                                            </button>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="codes-container">
                                    <div class="codes" id="userCodes">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </form>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary" id="btnSaveHsnCode">Save changes</button>
                </div>
            </div>
        </div>
    </div>
    <!-----add new payment terms end-->    
    <script type="text/javascript" src="../../js/jsrender.js"></script>  
    <script src="../plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="../plugins/datatables/dataTables.bootstrap.min.js"></script>
    <script src="../plugins/datatables/extensions/Responsive/js/dataTables.responsive.min.js"></script>
    <script src="../plugins/datatables/dataTables.bootstrap.min.js"></script>
    <script type="text/javascript" src="../js/charts.js"></script>
    <script type="text/javascript" src="../plugins/datepicker/bootstrap-datepicker.js"></script>
    <script src="../js/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/expenses.js"></script>
    <script type="text/javascript" src="../js/custom.js"></script>

    <script type="text/javascript">

        $("#purchaseorderto").on("change", function() {
            $modal = $('#poorderto');
            if ($(this).val() === 'addnewpoto') {
                $modal.find("input,textarea,select").val('').end().find("input[type=checkbox], input[type=radio]").prop("checked", "").end();
                $modal.modal('show', { backdrop: 'static', keyboard: false });
                $(this).val("");
            }
            if ($("#purchaseorderto option:selected").val() !== "addnewpoto") {
                $('.edits').show();
            }
        });

        $("#addnewexp").on("change", function() {
            $modal = $('#newexpenses');
            if ($(this).val() === 'newexpense') {
                $modal.find("input,textarea,select").val('').end().find("input[type=checkbox], input[type=radio]").prop("checked", "").end();
                $modal.modal('show', { backdrop: 'static', keyboard: false });
                $(this).val("");
            }
        });
        $("#paymentterms").on("change", function() {
            $modal = $('#addpayments');
            if ($(this).val() === 'addpaymentterms') {
                $modal.find("input,textarea,select").val('').end().find("input[type=checkbox], input[type=radio]").prop("checked", "").end();
                $modal.modal('show', { backdrop: 'static', keyboard: false });
                $(this).val("");
            }
        });

        $(document).on({
            change: function () {
                $modal = $('.itemsadd');
                if ($(this).val() === 'addnewitem') {
                    $modal.find("input,textarea,select").val('').end().find("input[type=checkbox], input[type=radio]").prop("checked", "").end();
                    var dd_Id = $(this).parent().parent().find("select").attr("id").split("_")[1];
                    $("#hdnRowId").val(dd_Id);
                    $modal.modal('show', { backdrop: 'static', keyboard: false });
                    $(this).val("");
                }
            }
        }, '.data-wrapper select');

     
    </script>
    <script id="tblPOdetailsList" type="text/x-jsrender">
       <tr id="{{:PurchaseId}}">
            <td></td>
            <td>{{:VendorName}}</td>
            <td>{{:DueDate}}</td>
            <td><span class="icon ico-rupees ico-3x"></span> {{:TotalAmount}}</td>
            <td>Pending</td>
            <td>
                <a class="actions-btn view" id="view-user_{{:PurchaseId}}" title="View"><span class="icon ico-view ico-2x"></span></a>
                <a class="actions-btn edit"  id="edit-user_{{:PurchaseId}}" title="Edit"><span class="icon ico-edit ico-2x"></span></a>
                <a class="actions-btn bill" id="converttobill_{{:PurchaseId}}" title="Covert to invoice"><span class="icon icon ico-invoice ico-2x"></span></a>
                <a class="actions-btn delete" id="delete-user_{{:PurchaseId}}" title="Delete"><span class="icon ico-delete ico-2x"></span></a>

            </td>
        </tr>
    </script>
    <script id="tblVendorDropdown" type="text/x-jsrender">
        <option value="{{:Id}}" state="{{:State}}"> {{:VendorName}} </option>
    </script>
    <script id="tblexpenseDropdown" type="text/x-jsrender">
        <option value="{{:Id}}"> {{:ExpenseType}} </option>
    </script>
    <script id="tblpaymentTermsDropdown" type="text/x-jsrender">
        <option value="{{:Id}}"> {{:Term}} </option>
    </script>
    <script id="tblItemsDropdown" type="text/x-jsrender">
        <option value="{{:Id}}" HsnCodeId="{{:HsnCodeId}}" ItemDescription="{{:ItemDescription}}" Price="{{:Price}}" Tax="{{:Tax}}" UnitOfMeasures="{{:UnitOfMeasures}}"> {{:ItemName}} </option>
    </script>
    <script id="userHsn" type="text/x-jsrender">
        <div class="checkbox">
            <label><input type="radio" id="hsn_{{:HsnCodeId}}" rate="{{:HsnRate}}" name="rd_HSNHSC" code="{{:HsnCode}}"><span>{{:HsnCode}}</span></label>
            <label><span>{{:HsnDetail}}</span></label>
        </div>
    </script>
    <script id="userHsc" type="text/x-jsrender">
        <div class="checkbox">
            <label><input type="radio" id="hsc_{{:HsnCodeId}}" rate="{{:HsnRate}}" name="rd_HSNHSC" code="{{:HsnCode}}"><span>{{:HsnCode}}</span></label>
            <label><span>{{:HsnDetail}}</span></label>
        </div>
    </script>
</asp:Content>
