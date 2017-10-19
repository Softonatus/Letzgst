<%@ Page Title="" Language="C#" MasterPageFile="~/GSTSite.Master" AutoEventWireup="true" CodeBehind="CreditNote.aspx.cs" Inherits="LetzGST.Manage.CreditNote" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <!-- main Content starts here-->
           
                <div class="box clearfix">

                    <div class="box-header with-border">
                        <h3 class="box-title">Invoice Management : Credit Note</h3>
                    </div>
                    <div class="box-body">
                        <div id="horizontalTab">
                            <div id="creditnotetable">
                                <div class="row">
                              <div class="col-md-6 col-sm-12 col-xs-12"></div>
                                    <div class="col-md-6 col-sm-12 col-xs-12">
                                        <a class="btn btn-ltz m-t-30 pull-right" id="addcreditnote"><span class="icon ico-add ico-2x"></span> Add Credit Note</a>
                                    </div>
                                </div>
                                <br />
                                <div class="table-container">
                                    <div class="col-md-12 col-sm-12 col-xs-12">
                                        <table id="creditlisttbl" class="table table-striped table-bordered dt-responsive dataTable no-footer dtr-inline ltz-table" width="100%" cellspacing="0">
                                            <thead>
                                                <tr>
                                                    <th>Sr.no</th>
                                                    <th>Customer Name</th>
                                                    <th>Credit Date</th>
                                                    <th>Amount</th>
                                                    <%--<th>Status</th>--%>
                                                    <th>Actions</th>
                                                </tr>
                                            </thead>
                                            <tbody id="creditDetails">
                                                <%--<tr>
                                                    <td>1</td>
                                                    <td>Softonauts</td>
                                                    <td>17/08/2017</td>
                                                    <td><span class="icon ico-rupees ico-3x"></span> 10,000</td>
                                                    <td>Pending</td>
                                                    <td>
                                                        <a class="actions-btn" id="view-user" title="View"><span class="icon ico-view ico-2x"></span></a>
                                                        <a class="actions-btn" id="edit-user" title="Edit"><span class="icon ico-edit ico-2x"></span></a>
                                                        <a class="actions-btn" id="converttobill" title="Covert to invoice"><span class="icon icon ico-invoice ico-2x"></span></a>
                                                        <a class="actions-btn" id="delete-user" title="Delete"><span class="icon ico-delete ico-2x"></span></a>

                                                    </td>
                                                </tr>--%>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>

                            </div>
                            <div id="creditnote" style="display: none;">
                                <form id="frmCreditNote" runat="server">
                                    <div class="row">
                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                            <div class="btns-container">
                                                <div class="pull-left">

                                                    <a class="btn letz-btn btn-ltz" id="backtocredit"><span class="icon ico-back ico-2x"></span> Back</a>
                                                </div>

                                                <div class="pull-right">
                                                    <a class="btn letz-btn btn-ltz" onClick="printdiv('my-container');" id="PrintPdf"><span class="icon ico-printer ico-2x"></span> Print</a>
                                                    <a class="btn letz-btn btn-ltz" id="btn_saveCredit"><span class="icon ico-save ico-2x"></span> Save</a>
                                                     <a href="#" id="btnSendQuote" class="btn btn-ltz btn-outline" data-toggle="modal" data-target="#sendquote"><span class="icon ico-sendbtn ico-2x"></span> Send</a>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3 col-sm-12 col-xs-12">
                                            <div class="form-group ">
                                                <label class="control-label">Credit Note To</label>&nbsp; <span id="err_creditnoteto"></span>
                                                <select id="creditnoteto" name="creditnoteto" data-placeholder="Select " class="form-control chosen-select-deselect" required="required">
                                                    <option></option>
                                                   <%-- <option value="addnewpoto" class="addnewtxt">Add new Customer</option>--%>
                                                   
                                                </select>

                                            </div>
                                        </div>
                                        <div class="col-md-3 col-sm-12 col-xs-12">
                                            <div class="form-group">
                                                <label class="control-label">credit Note No</label>
                                                <input type="text" id="billno" class="form-control">
                                               <%-- <div class="overwrite"><input type="checkbox">Overwrite</div>--%>
                                            </div>
                                        </div>
                                        <div class="col-md-3 col-sm-12 col-xs-12">
                                            <div class="form-group">
                                                <label class="control-label">credit Note Date</label>&nbsp; <span id="err_podate"></span>
                                                <div class="input-group date">
                                                    <div class="input-group-addon">
                                                        <i class="icon ico-calendar"></i>
                                                    </div>
                                                    <input type="text" class="form-control pull-right" id="podate" name="podate" required="required">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3 col-sm-12 col-xs-12">
                                            <label class="control-label">Invoice Ref No</label>  &nbsp;<span id="err_invrefno"></span>
                                            <select id="invrefno" name="invrefno" data-placeholder="Select " class="form-control chosen-select-deselect" required="required">
                                                    <option></option>
                                                    <%--<option value="1"> 1</option>
                                                    <option value="2"> 2 </option>
                                                    <option value="3"> 3</option>--%>
                                                </select>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3 col-sm-12 col-xs-12">
                                            <div class="form-group ">
                                                <label class="control-label">Shipping Address</label>
                                                <input type="text" class="form-control" placeholder="Address Line 1" id="shipaddress1">
                                                <input type="text" class="form-control" placeholder="Address Line 2" id="shipaddress2">
                                                <!-- <textarea class="form-control" cols="2" rows="5"></textarea>-->
                                            </div>
                                        </div>
                                        <div class="col-md-3 col-sm-12 col-xs-12">
                                            <div class="form-group">
                                                <label class="control-label">City</label>
                                                <input type="text" id="shipcity" class="form-control">
                                            </div>
                                        </div>
                                        <div class="col-md-3 col-sm-12 col-xs-12">
                                            <div class="form-group ">
                                                <label class="control-label">State</label>
                                                <select id="shippingState" name="state" data-placeholder="Select State" class="form-control chosen-select-deselect">
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
                                        <div class="col-md-3 col-sm-12 col-xs-12">
                                            <div class="form-group">
                                                <label class="control-label">Pin Code</label>
                                                <input type="text" id="pincode" class="form-control">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3 col-sm-12 col-xs-12">
                                            <label class="control-label">Ref No</label>&nbsp; <span id="err_refno"></span>
                                            <input type="text" id="refno" class="form-control" name="refno" required="required">
                                        </div>

                                        <%--<div class="col-md-3 col-sm-12 col-xs-12">
                                            <label class="control-label">Prices are inclusive / exclusive of taxes</label>
                                            <div>
                                                <div class="radio radio-primary radio-inline">
                                                    <input type="radio" id="Exclusive" value="option1" name="radioInline">
                                                    <label for="Exclusive"> Exclusive </label>
                                                </div>
                                                <div class="radio radio-primary radio-inline">
                                                    <input type="radio" id="Inclusive" value="option1" name="radioInline">
                                                    <label for="Inclusive"> Inclusive </label>
                                                </div>
                                            </div>
                                        </div>--%>

                                        <div class="col-md-3 col-sm-12 col-xs-12">
                                            <div class="form-group ">
                                                <label class="control-label">Reson For Issuing Document</label> &nbsp; <span id="err_issueReason"></span>
                                                <select id="issueReason" name="issueReason" data-placeholder="Select reason" class="form-control chosen-select-deselect" required="required">
                                                    <option></option>
                                                    <option value="SalesReturn"> Sales Return</option>
                                                    <option value="PostSaleDiscount"> Post Sale Discount </option>
                                                    <option value="Deficiencyinservices"> Deficiency in services</option>
                                                    <option value="ChangeinPOS">Change in POS</option>
                                                    <option value="CorrectioninInvoice">Correction in Invoice</option>
                                                    <option value="FinalizationofProvisionalassessment">Finalization of Provisional assessment</option>
                                                    <option value="Others">Others</option>
                                                </select>
                                            </div>
                                        </div>
                                        <div class="col-md-3 col-sm-12 col-xs-12">
                                            <div class="form-group ">
                                                <label class="control-label"> Document Type</label> &nbsp; <span id="err_docstype"></span>
                                                <select id="docstype" name="docstype" data-placeholder="Select Document Type" class="form-control chosen-select-deselect" required="required">
                                                    <option></option>
                                                    <option value="C">Credit</option>
                                                    <option value="D">Debit</option>
                                                    <option value="R"> Refundable</option>
                                                    </select>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="p-t-20">
                                        <table id="creditdetailstbl" class="table table-bordered dt-responsive dataTable no-footer dtr-inline ltz-table" width="100%" cellspacing="0">
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
                                                    <th class="w-4">CESS (%)</th>
                                                    <th class="w-1"></th>
                                                </tr>
                                            </thead>
                                            <tbody id="tblItemDetails">
                                                <tr class="data-wrapper">
                                                    <td id="tr_1">1</td>
                                                    <td>
                                                        <select id="additems_1" name="additems_1" data-placeholder="Select Items" class="form-control additems chosen-select-deselect userItemDetails" required="required">                                                
                                                                <option></option>
                                                                <%--<option value="addnewitem"  class="addnewtxt">Add new item</option>--%>
                                                            </select>
                                                    </td>
                                                    <td><textarea class="form-control" id="desc_1" name="desc_1" ></textarea></td>
                                                    <td><input type="text" class="form-control calculate" id="price_1" data-rule-required="true" name="price_1" onkeypress="return isNumberKey(event)"></td>
                                                    <td><input type="text" class="form-control product-qty calculate" id="unt_1"  data-rule-required="true" name="unt_1" onkeypress="return isNumberKey(event)"><span id="unit_1"></span></td>
                                                   
                                                    <td><input type="text" class="form-control amtdetails" disabled id="Amount_1"></td>
                                                    <td>
                                                        <select id="tax_1" name="tax_1" data-placeholder="Select Tax" class="form-control chosen-select-deselect calculate" required="required" data-rule-required="true">                                                
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
                                                    <td>
                                                        <input type="text" class="form-control product-qty calculate" id="cess_1"><span class="icon ico-rupees ico-3x"></span><span class="cessAmt">0</span>
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
                                                    <label class="control-label">Invoice Payment Details</label>
                                                    <textarea class="form-control" id="INVPayDet"></textarea>
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
                                                        <p class="control-label p-t-5">CESS :</p>
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
                                                        <p>&nbsp;&nbsp;&nbsp; <input type="text" id="cess" value="" class="discount-txt"></p>
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
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <asp:HiddenField ClientIDMode="Static" ID="hdn_uCountry" runat="server" Value="0" />         
                                    <asp:HiddenField ClientIDMode="Static" ID="hdn_LoginName" runat="server" Value="" />
                                    <asp:HiddenField ClientIDMode="Static" ID="hdn_Main" runat="server" Value="0" />
                                    <asp:HiddenField ClientIDMode="Static" ID="hdn_uType" runat="server" Value="0" />
                                    <asp:HiddenField ClientIDMode="Static" ID="hdn_LogoUrl" runat="server" Value="" />
                                    <input type="hidden" id="hdnRowId" value="1" />
                                    <input type="hidden" id="hdnPurchaseId" value="" />
                                    <input type="hidden" id="hdnCustomerId" value="" />
                                </form>
                            </div>

                        </div>
                    </div>
                </div>

          
            <!-- main content ends here -->
    <!-- /#wrapper -->
    
    <!-------------all modals starts here-------------->
   <div class="modal fade " id="poorderto" tabindex="-1" role="dialog" style="display: none;">
        <div class="modal-dialog custom-modal" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title" id="myModalLabel">Add Customer</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-4 col-sm-6 col-xs-12">

                            <div class="form-group">
                                <label class="control-label">Customer Name</label>
                                <input type="text" class="form-control" id="companyname" name="companyname" placeholder="Customer / Company Name">
                            </div>
                            <div class="form-group">
                                <label class="control-label required">Contact Number</label>
                                <input type="text" class="form-control" id="contactno" name="contactno" placeholder="Contact Numbar" required="required">
                            </div>
                            <div class="form-group">
                                <label class="control-label required">PAN Number</label>
                                <input type="text" class="form-control" id="panno" name="panno" placeholder="Pan Number" required="required">
                            </div>
                            <div class="form-group address-group">
                                <label class="control-label">Billing Address</label>
                                <input type="text" class="form-control" id="address1" name="address1" placeholder="Address line 1">
                                <input type="text" class="form-control" id="address2" name="address2" placeholder="Address line 2">
                                <input type="text" class="form-control" id="address3" name="address3" placeholder="Address line 3">
                                <div class="row">
                                    <div class="form-group col-md-6 col-sm-12 col-xs-12">
                                        <input type="text" class="form-control" id="city" name="city" placeholder="City">
                                        <input type="text" class="form-control" id="pin" name="pin" placeholder="Pin" required="required">
                                    </div>
                                    <div class="form-group col-md-6 col-sm-12 col-xs-12">
                                        <select id="state" name="state" data-placeholder="Select State" class="form-control chosen-select-deselect">
                                            <option> </option>
                                            <option value="MH"> Maharashtra </option>
                                            <option value="GJ"> Gujrat </option>
                                        </select>
                                        <select id="state" name="state" data-placeholder="Select Country" class="form-control chosen-select-deselect">
                                            <option> </option>
                                            <option value="Ind"> India </option>
                                            <option value="USa"> USA </option>
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <label class="control-label">Notes</label>
                                    <textarea class="form-control"></textarea>
                                </div>
                              <%--  <div class="col-md-6 col-sm-6 col-xs-12">
                                    <label class="control-label">Currency</label>
                                    <select id="state" name="state" data-placeholder="Select Currency" class="form-control chosen-select-deselect">
                                            <option> </option>
                                            <option value="AUD">Australian Dollar&nbsp;($)</option>
                                            <option value="BGN">Bulgarian Lev&nbsp;(лв)</option>
                                            <option value="BRL">Brazilian Real&nbsp;(R$)</option>
                                            <option value="CAD">Canadian Dollar&nbsp;($)</option>
                                            <option value="CHF">Swiss Franc&nbsp;(CHF)</option>
                                            <option value="CNY">Chinese Yuan&nbsp;(¥)</option>
                                            <option value="CZK">Czech Republic Koruna&nbsp;(Kč)</option>
                                            <option value="DKK">Danish Krone&nbsp;(kr)</option>
                                            <option value="EUR">Euro&nbsp;(€)</option>
                                            <option value="GBP">British Pound Sterling&nbsp;(£)</option>
                                            <option value="HKD">Hong Kong Dollar&nbsp;($)</option>
                                            <option value="HRK">Croatian Kuna&nbsp;(kn)</option>
                                            <option value="HUF">Hungarian Forint&nbsp;(Ft)</option>
                                            <option value="IDR">Indonesian Rupiah&nbsp;(Rp)</option>
                                            <option value="ILS">Israeli New Sheqel&nbsp;(₪)</option>
                                            <option value="INR" selected>Indian Rupee&nbsp;(₹)</option>
                                            <option value="JPY">Japanese Yen&nbsp;(¥)</option>
                                            <option value="KRW">South Korean Won&nbsp;(₩)</option>
                                            <option value="MXN">Mexican Peso&nbsp;($)</option>
                                            <option value="MYR">Malaysian Ringgit&nbsp;(RM)</option>
                                            <option value="NOK">Norwegian Krone&nbsp;(kr)</option>
                                            <option value="NZD">New Zealand Dollar&nbsp;($)</option>
                                            <option value="PHP">Philippine Peso&nbsp;(₱)</option>
                                            <option value="PLN">Polish Zloty&nbsp;(zł)</option>
                                            <option value="RON">Romanian Leu&nbsp;(lei)</option>
                                            <option value="RUB">Russian Ruble&nbsp;(₽)</option>
                                            <option value="SEK">Swedish Krona&nbsp;(kr)</option>
                                            <option value="SGD">Singapore Dollar&nbsp;($)</option>
                                            <option value="THB">Thai Baht&nbsp;(฿)</option>
                                            <option value="TRY">Turkish Lira&nbsp;(TL)</option>
                                            <option value="USD">US Dollar&nbsp;($)</option>
                                            <option value="ZAR">South African Rand&nbsp;(R)</option>
                                        </select>
                                </div>--%>

                            </div>


                        </div>
                        <div class="col-md-4 col-sm-6 col-xs-12">
                            <div class="form-group">
                                <label class="control-label">Contact Person</label>
                                <input type="text" class="form-control" id="ContactPerson" name="ContactPerson" placeholder="Contact Person">
                            </div>
                            <div class="form-group">
                                <label class="control-label required">Email</label>
                                <input type="email" class="form-control" id="profileemail" name="profileemail" placeholder="Email" required="required">
                            </div>
                            <div class="form-group hideadhaar">
                                <label class="control-label required">Adhaar Number</label>
                                <input type="text" class="form-control" id="adhaar" name="adhaar" placeholder="Adhaar Number" required="required">
                            </div>
                            <div class="form-group address-group">
                                <label class="control-label">Shipping Address</label> <span class="pull-right"><input type="checkbox"> Same as Billing Address</span>
                                <input type="text" class="form-control" id="address1" name="address1" placeholder="Address line 1">
                                <input type="text" class="form-control" id="address2" name="address2" placeholder="Address line 2">
                                <input type="text" class="form-control" id="address3" name="address3" placeholder="Address line 3">
                                <div class="row">
                                    <div class="form-group col-md-6 col-sm-12 col-xs-12">
                                        <input type="text" class="form-control" id="city" name="city" placeholder="City">
                                        <input type="text" class="form-control" id="pin" name="pin" placeholder="Pin" required="required">
                                    </div>
                                    <div class="form-group col-md-6 col-sm-12 col-xs-12">
                                        <select id="state" name="state" data-placeholder="Select State" class="form-control chosen-select-deselect">
                                        <option> </option>
                                        <option value="MH"> Maharashtra </option>
                                        <option value="GJ"> Gujrat </option>
                                    </select>
                                        <select id="state" name="state" data-placeholder="Select Country" class="form-control chosen-select-deselect">
                                        <option> </option>
                                        <option value="Ind"> India </option>
                                        <option value="USa"> USA </option>
                                    </select>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">TDS Applicable</label>
                                        <input type="text" class="form-control">
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <div><input type="checkbox"> Show TDS in Invoice</div>
                                        <div><input type="checkbox"> Supplies made to SEZ unit or SEZ Developer</div>
                                    </div>
                                </div>

                            </div>

                        </div>
                        <div class="col-md-4 col-sm-12 col-xs-12">

                            <div class="form-group">
                                <label class="control-label required">GSTN</label>
                                <input type="text" class="form-control" id="gstnno" name="gstnno" placeholder="Gst Number" required="required">
                            </div>
                            <div class="form-group ">
                                <label class="control-label">TAN</label>
                                <input type="text" class="form-control" id="tan" name="tan" placeholder="Tan Number">
                            </div>
                            <div class="form-group ">
                                <label class="control-label">Service Tax</label>
                                <input type="text" class="form-control" id="servicetax" name="servicetax" placeholder="Service Number">
                            </div>
                            <div class="form-group ">
                                <label class="control-label">VAT / TIN </label>
                                <input type="text" class="form-control" id="vattin" name="vattin" placeholder="Vat / Tin Number">
                            </div>
                            <div class="form-group ">
                                <label class="control-label">Bank Account Number </label>
                                <input type="text" class="form-control" id="servicetax" name="bankacno" placeholder="Bank Account Number">
                            </div>
                            <div class="form-group ">
                                <label class="control-label">Bank Account Name </label>
                                <input type="text" class="form-control" id="bankacname" name="bankacname" placeholder="Bank  Account Name">
                            </div>
                            <div class="form-group">
                                <div class="form-group ">
                                    <label class="control-label">IFSC</label>
                                    <input type="text" class="form-control" id="ifsc" name="ifsc" placeholder="IFSC">
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary">Save changes</button>
                </div>
            </div>
        </div>
    </div>
    <!-----add new items start -->
    <div class="modal fade itemsadd" id="" tabindex="-1" role="dialog" style="display: none;">
        <div class="modal-dialog bs-example-modal-md" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title" id="myModalLabel">Add Item</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">Item Name</label>
                                <input type="text" class="form-control" id="" name="" placeholder="Item Name">
                            </div>
                            <div class="form-group">
                                <label class="control-label">HSN / SAC Code</label>
                                <input type="text" class="form-control" id="" name="" placeholder="HSN / SAC Code">

                                <button class="btn link-btn" data-toggle="modal" href="#codesmodal">Find HSN / SAC Codes</button>
                            </div>
                            <div class="form-group">
                                <label class="control-label">Price</label>
                                <input type="text" class="form-control" id="" name="" placeholder="Price">
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">Tax</label>
                                <select id="tax" name="tax" data-placeholder="Select Tax" class="form-control chosen-select-deselect" required="required">
                                    <option></option>
                                    <option>NA</option>
                                    <option value="0"> 0 </option>
                                    <option value="3"> 3% </option>
                                    <option value="5">5%</option>
                                    <option value="12">12%</option>
                                    <option value="18">18%</option>
                                    <option value="28">28%</option>
                                </select>
                            </div>

                            <div class="form-group">
                                <label class="control-label">Measure units</label>
                                <select id="tax" name="tax" data-placeholder="Select Unit" class="form-control chosen-select-deselect" required="required">
                                    <option></option>
                                    <option>NA</option>
                                    <option value="0"> KG </option>
                                    <option value="3"> Box</option>
                                    <option value="5">Bundle</option>
                                </select>
                            </div>
                            <div class="form-group">
                                <label class="control-label">Description</label>
                                <textarea class="form-control"></textarea>
                            </div>
                        </div>
                    </div>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary">Save changes</button>
                </div>
            </div>
        </div>
    </div>
    <!-----add new itesm end-->
    <!-----add hsnsac start -->
    <!--<div class="modal fade itemsadd" id="codesmodal" tabindex="-1" role="dialog" style="display: none;">-->
    <div id="codesmodal" class="modal fade" tabindex="-1" data-focus-on="input:first" style="display: none;">
        <div class="modal-dialog bs-example-modal-md" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title" id="myModalLabel">Find HSN / SAC Codes</h4>
                </div>
                <div class="modal-body">
                    <form id="sethsncode">
                        <div class="row">
                            <div class=" col-md-4 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label class="control-label">Select </label>
                                    <select id="crrole" name="crrole" class="form-control" required="required">
                                        <option></option>
                                        <option value="goods"> Goods </option>
                                        <option value="services"> Services</option>
                                    </select>
                                </div>
                            </div>
                            <div class="col-md-8 col-sm-12 col-xs-12">
                                <label>Search HSN / SAC code</label>
                                <div id="imaginary_container">
                                    <div class="input-group stylish-input-group">
                                        <input type="text" class="form-control" placeholder="HSN Code (e.g. 1011090) or keywords (e.g. Manufactures )">
                                        <span class="input-group-addon">
                                                    <button type="submit">
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
                                    <div class="codes">
                                        <div class="checkbox">
                                            <label>
                                                <input type="checkbox"><span>63071030</span></label>
                                            <label><span>Floor Clothes, Dish Clothes, Dusters And Similar Cleaning Clothes - Of Cotton,handloom</span></label>
                                        </div>
                                        <div class="checkbox">
                                            <label>
                                                <input type="checkbox"><span>63071030</span></label>
                                            <label><span>Floor Clothes, Dish Clothes, Dusters And Similar Cleaning Clothes - Of Cotton,handloom</span></label>
                                        </div>
                                        <div class="checkbox">
                                            <label>
                                                <input type="checkbox"><span>63071030</span></label>
                                            <label><span>Floor Clothes, Dish Clothes, Dusters And Similar Cleaning Clothes - Of Cotton,handloom</span></label>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>

                    </form>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary">Save changes</button>
                </div>
            </div>
        </div>
    </div>
    <!-----add hsnsac end
<!-----send quotation start -->
    <div class="modal fade " id="sendquote" tabindex="-1" role="dialog" style="display: none;">
        <div class="modal-dialog custom-modal" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title" id="lblCVreditNote">Send Credit Note</h4>
                </div>
                <div class="modal-body">
                    <div class="row">

                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Email Id(s) </label>
                                <input type="text" class="form-control" id="senderEmailId" name="senderEmailId" placeholder="Email ID(s)">
                            </div>
                            <div class="form-group">
                                <label class="control-label">Email Subject </label>
                                <input type="text" class="form-control" id="EmailSubject" name="EmailSubject" placeholder="Email Subject">
                            </div>
                            <div class="form-group">
                                <textarea class="textarea" id="EmailBody" placeholder="Enter text ..." style="width: 100%; height: 200px"></textarea>
                            </div>
                        </div>
                        <div class="col-md-9">
                            <div class="form-group">
                                <div class="col-md-12">
                                    <div id="my-container" class="pdfobject-container" style="overflow-y:auto;">
                                        <section style="padding:6mm">   
                                            <table style="border: solid 1px #666; font-family: monospace; font-size: 13px; line-height:18px;" width="100%" cellpadding='0' cellspacing='0' border='0' id="mytbl">
                                                <tr>
                                                    <td colspan="3" style="text-align: center;border-bottom: solid 1px #666;background-color: #dadada;height: 30px;font-size: 16px;"><strong>Tax Invoice</strong></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="0" style="border-right: solid 1px #666; border-bottom: solid 1px #666; padding: 4px; ">
                                                        <span id="P_Add1">Gat No. 55, Indrayani Industrial Estate, </span>
                                                        <br><span id="P_Add2">behind Ravi Ranjan weigh bridge,<br> near Kolosus green city, Chikhali Moshi<br> road</span><br />
                                                         <span id="P_city">Pune</span>&nbsp; <span id="P_pin">412114</span>&nbsp;<span id="P_State">Maharashtra</span>&nbsp;<span id="P_Country">India</span>   
                                                         <br /> Contact: +91- <span id="P_contact">9960999506</span>
                                                    </td>
                                                    <td colspan="2" style="padding: 4px; border-bottom: solid 1px #666;">
                                                        <p style="margin:4px 0; padding: 0; border-bottom: solid 1px #666;"><strong>GSTIN:</strong> <span id="P_Gstn"></span></p>
                                                        <p style="margin: 4px 0; padding: 0; border-bottom: solid 1px #666;"><strong>PAN:</strong> <span id="P_Pan"></span></p>
                                                        <p style="margin: 4px 0; padding: 0;border-bottom: solid 1px #666;"><strong>Contact Name & No:</strong> <span id="P_contactDet"></span></p>
                                                        <p style="margin: 4px 0; padding: 0;border-bottom: solid 1px #666;"><strong>Email:</strong> <span id="P_Email"></span></p>
                                                        <p style="margin: 4px 0; padding: 0;"><strong>Website:</strong> <span id="P_website"></span></p>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="0" style="border-right: solid 1px #666; border-bottom: solid 1px #666; padding: 4px;">
                                                        <p><strong>Consignee Address,</strong></p>
                                                         <span id="P_C_Add1">Gat No. 55, Indrayani Industrial Estate, </span>
                                                        <br><span id="P_C_Add2">behind Ravi Ranjan weigh bridge,<br> near Kolosus green city, Chikhali Moshi<br> road</span><br />
                                                         <span id="P_C_city">Pune</span>&nbsp; <span id="P_C_pin">412114</span>&nbsp;<span id="P_C_State">Maharashtra</span>&nbsp;<span id="P_C_Country">India</span>   
                                                         <br /> Contact: +91- <span id="P_C_contact">9960999506</span>
                                                        <p><strong>GSTN:</strong> <span id="P_C_Gstn"></span></p>
                                                    </td>
                                                    <td colspan="0" style="border-right: solid 1px #666; border-bottom: solid 1px #666; padding: 4px;">
                                                        <p><strong>Shipping Address,</strong></p>
                                                         <span id="P_S_Add1">Gat No. 55, Indrayani Industrial Estate, </span>
                                                        <br><span id="P_S_Add2">behind Ravi Ranjan weigh bridge,<br> near Kolosus green city, Chikhali Moshi<br> road</span><br />
                                                         <span id="P_S_city">Pune</span>&nbsp; <span id="P_S_pin">412114</span>&nbsp;<span id="P_S_State">Maharashtra</span>&nbsp;<span id="P_S_Country">India</span>   
                                                         <br /> Contact: +91- <span id="P_S_contact">9960999506</span>
                                                        <p><strong>GSTN:</strong> <span id="P_S_Gstn"></span></p>
                                                    </td>
                                                    <td style="padding: 4px; border-bottom: solid 1px #666;">
                                                        <p style="margin:4px 0; padding: 0; border-bottom: solid 1px #666;"><strong>Invoice No:</strong> <span id="P_billno"></span></p>
                                                        <p style="margin: 4px 0; padding: 0; border-bottom: solid 1px #666;"><strong>Date:</strong> <span id="P_podate"></span></p>
                                                        <p style="margin: 4px 0; padding: 0;border-bottom: solid 1px #666;"><strong>Order No:</strong> <span></span></p>
                                                        <p style="margin: 4px 0; padding: 0;border-bottom: solid 1px #666;"><strong>Vendor / Suplier Code:</strong> <span></span></p>
                                                        <p style="margin: 4px 0; padding: 0; border-bottom: solid 1px #666;"><strong>Payment Terms:</strong> <span></span></p>
                                                        <p style="margin: 4px 0; padding: 0;"><strong>Payment Due Date:</strong> <span id="P_duedate"></span></p>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td colspan="3" style="padding:  4px;">
                                                        <table width="100%" cellpadding='0' cellspacing='0' border='0' class='pdftbl'>
                                                            <thead>
                                                                <tr>
                                                                    <th colspan="1" rowspan="2">#</th>
                                                                    <th colspan="1" rowspan="2" class="text-left">Items (HSN /SAC) </th>
                                                                    <th colspan="1" rowspan="2" class="text-left">Qty</th>
                                                                    <th colspan="1" rowspan="2">Unit</th>
                                                                    <th colspan="1" rowspan="2">Rate</th>
                                                                    <th colspan="1" rowspan="2">Discount</th>
                                                                    <th colspan="2" rowspan="1">CGST</th>
                                                                    <th colspan="2" rowspan="1">SGST</th>
                                                                    <th colspan="2" rowspan="1">IGST</th>
                                                                    <th colspan="2" rowspan="1">UTGST</th>
                                                                    <th colspan="2" rowspan="1">CESS</th>
                                                                    <th colspan="1" rowspan="2">Amout</th>
                                                                </tr>
                                                                <tr>
                                                                    <th colspan="1" rowspan="1">Rate (%)</th>
                                                                    <th colspan="1" rowspan="1">Amt (Rs)</th>
                                                                    <th colspan="1" rowspan="1">Rate (%)</th>
                                                                    <th colspan="1" rowspan="1">Amt (Rs)</th>
                                                                    <th colspan="1" rowspan="1">Rate (%)</th>
                                                                    <th colspan="1" rowspan="1">Amt (Rs)</th>
                                                                    <th colspan="1" rowspan="1">Rate (%)</th>
                                                                    <th colspan="1" rowspan="1">Amt (Rs)</th>
                                                                    <th colspan="1" rowspan="1">Rate (%)</th>
                                                                    <th colspan="1" rowspan="1">Amt (Rs)</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody id="P_ItemDetails">
                                                                <tr class="itemdetailsPDF">
                                                                    <td id="trpdf_1"> 1</td>
                                                                    <td> <span id="P_hsnId_1">Live Fish (10256)</span></td>
                                                                    <td><span id="P_Qty_1">0</span></td>
                                                                    <td><span id="P_Unit_1">0</span></td>
                                                                    <td><span id="P_Price_1">0</span></td>
                                                                    <td><span id="P_Discount_1">0</span> %</td>
                                                                    <td><span id="P_CGSTRate_1">0</span>%</td>
                                                                    <td><span id="P_CGSTAmount_1">0</span></td>
                                                                    <td><span id="P_SGSTRate_1">0</span>%</td>
                                                                    <td><span id="P_SGSTAmount_1">0</span></td>
                                                                    <td><span id="P_IGSTRate_1">0</span>%</td>
                                                                    <td><span id="P_IGSTAmount_1">0</span></td>
                                                                    <td><span id="P_UTGSTRate_1">0</span>%</td>
                                                                    <td><span id="P_UTGSTAmount_1">0</span></td>
                                                                    <td><span id="P_CESS_1">0</span></td>
                                                                    <td><span id="P_CESS_AMT_1" class="cessAmtFull">0</span></td>
                                                                    <td><span id="P_TotalAmount_1">0</span> <span style="display:none" id="P_tax_1"></span></td>
                                                                    </tr>
                                                            </tbody>
                                                            <tfoot>
                                                                <tr class="footer">
                                                                    <td colspan="5"></td>
                                                                    <td>Total</td>
                                                                    <td></td>
                                                                    <td id="P_CGSTAMT"></td>
                                                                    <td></td>
                                                                    <td id="P_SGSTAMT"></td>
                                                                    <td></td>
                                                                    <td id="P_IGSTAMT"></td>
                                                                    <td></td>
                                                                    <td id="P_UTGSTAMT"></td>
                                                                    <td></td>
                                                                    <td id="P_TotCess"></td>
                                                                    <td id="P_TotalAMT"></td>
                                                                </tr>
                                                            </tfoot>
                                                            

                                                        </table>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td style="padding:4px; border-bottom: solid 1px #666; border-left: solid 1px #666;" colspan="2"> <strong>Freight & Packaging:</strong> Rs <span id="P_freight"></span></td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td style="padding:4px; border-bottom: solid 1px #666; border-left: solid 1px #666;" colspan="2"> <strong>Labour Charges:</strong> Rs <span id="P_labourCharge"></span></td>
                                                </tr>


                                                <tr>
                                                    <td></td>
                                                    <td style="padding:4px; border-bottom: solid 1px #666; border-left: solid 1px #666;" colspan="2"> <strong>Net Total:</strong> Rs <span id="P_nettotal"></span></td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td style="padding:4px; border-bottom: solid 1px #666; border-left: solid 1px #666;" colspan="2"> <strong>Insurance Amt:</strong> Rs <span id="P_InsuranceAmt"></span></td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td style="padding:4px; border-bottom: solid 1px #666; border-left: solid 1px #666;" colspan="2"> <strong>Other Charges:</strong> Rs <span id="P_otherCharges"></span></td>
                                                </tr>
                                                <tr>
                                                    <td style="border-bottom: solid 1px #666;"></td>
                                                    <td style="padding:4px; border-bottom: solid 1px #666; border-left: solid 1px #666;" colspan="2"> <strong>Discount :</strong> Rs <span id="P_disount"></span></td>
                                                </tr>
                                                <tr>
                                                    <td style="padding:4px; border-right:solid 1px #666; border-bottom:solid 1px #666; height: 100px; vertical-align: top;">
                                                        <p><strong>Notes:</strong> &nbsp; <span id="P_TA_Notes"></span> </p>
                                                    </td>
                                                    <td style="padding:4px; border-right: solid 1px #666; border-bottom:solid 1px #666; vertical-align: top;"><strong>Bank Details</strong> &nbsp <span id="P_INVPayDet"></span></td>
                                                    <td style="padding:4px; border-bottom:solid 1px #666; vertical-align: top;"> <strong>Terms & Conditions:</strong>&nbsp; <span id="P_TandC"></span> </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 4px; height: 150px; vertical-align: top;">Receiver's Sign</td>
                                                    <td></td>
                                                    <td style="padding: 4px; height: 150px; vertical-align: top;">
                                                        Authorised Signatory

                                                    </td>
                                                </tr>
                                            </table>
                                         </section>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%--<script>
                        $('.textarea').wysihtml5();
                        PDFObject.embed("../docs/sample-3pp.pdf", "#my-container");

                    </script>--%>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-ltz btn-outline" id="btn_Sendmail"><span class="icon ico-sendbtn ico-2x"></span> Send</button>
                </div>
            </div>
        </div>
    </div>
    <!-----send quotation end------->

    <!-- JQuery -->
 <%--       <script src="https://npmcdn.com/tether@1.2.4/dist/js/tether.min.js"></script>
    <script type="text/javascript" src="../../js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../../js/bootstrap-filestyle.min.js"></script>
    <script type="text/javascript" src="../../js/common.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.16.0/jquery.validate.min.js"></script>--%>

   <%-- <script type="text/javascript" src="../../js/jquery-3.1.1.min.js"></script>--%>
    
    <script type="text/javascript" src="../js/jsrender.js"></script>
    <!-- DataTables -->
    <script src="../plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="../plugins/datatables/dataTables.bootstrap.min.js"></script>
    <script src="../plugins/datatables/extensions/Responsive/js/dataTables.responsive.min.js"></script>
    <script src="../plugins/datatables/dataTables.bootstrap.min.js"></script>
    <!----plugins----->
    <script src="../js/chosen.jquery.js"></script>

    <script type="text/javascript" src="../js/charts.js"></script>
    <script src="../plugins/datepicker/bootstrap-datepicker.js"></script>
    <script type="text/javascript" src="../js/wysihtml5-0.3.0.min.js"></script>
    <script type="text/javascript" src="../js/bootstrap-wysihtml5.js"></script>   
    <script type="text/javascript" src="../js/custom.js"></script>
    <script type="text/javascript" src="../js/creditnote.js"></script>
 <%--   <script>
        $sidebarMenu($('.sidebar-menu'))

    </script>--%>


    <script>
        $(function() {

            $(".chosen-select").chosen({
                width: "100%"
            });
            $('.chosen-select-deselect').chosen({
                width: "100%",
                allow_single_deselect: true,
                include_group_label_in_selected: true
            });

        });

    </script>

    <script type="text/javascript">
        $('#creditnoteto').change(function(event) {
            $modal = $('#poorderto');
            if ($("#creditnoteto option:selected").val() == "addnewpoto") {
                $('#creditnoteto').prop('selectedIndex', 0);

                $modal.modal('show');
            }
            if ($("#creditnoteto option:selected").val() !== "addnewpoto") {
                $('.edits').show();
            }
        });

        
        $(".additems").on("change", function() {
            $modal = $('.itemsadd');
            if ($(this).val() === 'addnewitem') {
                $modal.modal('show');
            }
        });

    </script>

    <script id="tblCreditNoteDetails" type="text/x-jsrender">
        <tr id="{{:CreditId}}">
            <td></td>
            <td>{{:CustomerName}}</td>
            <td>{{:CreditDate}}</td>
            <td><span class="icon ico-rupees ico-3x"></span>{{:TotalAmount}}</td>
            <%--<td>{{:Status}}</td>--%>
            <td>
              <%--  <a class="actions-btn" id="viewuser_{{:CreditId}}" title="View"><span class="icon ico-view ico-2x"></span></a>--%>
                <a class="actions-btn edit" id="edituser_{{:CreditId}}" title="Edit"><span class="icon ico-edit ico-2x"></span></a>
                <a class="actions-btn delete" id="deleteuser_{{:CreditId}}" title="Delete"><span class="icon ico-delete ico-2x"></span></a>


            </td>
        </tr>
    </script>
     <script id="tblCustomerDropdown" type="text/x-jsrender">
        <option value="{{:Id}}" state="{{:State}}"> {{:CustomerName}} </option>
    </script>
    <script id="tblItemsDropdown" type="text/x-jsrender">
        <option value="{{:Id}}" HsnCodeId="{{:HsnCodeId}}" ItemDescription="{{:ItemDescription}}" Price="{{:Price}}" Tax="{{:Tax}}" UnitOfMeasures="{{:UnitOfMeasures}}"> {{:ItemName}} </option>
    </script>

    <script id="BillIDDetails" type="text/x-jsrender">
        <option value="{{:RefId}}"> {{:RefNo}} </option>
    </script>
</asp:Content>
