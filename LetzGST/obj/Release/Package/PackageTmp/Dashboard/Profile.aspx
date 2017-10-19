<%@ Page Title="" Language="C#" MasterPageFile="~/GSTSite.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="LetzGST.Dashboard.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <!--common button start-->
    <div class="common-btns">
        <button class="btn btn-primary letz-btn" type="submit" id="btnCancel">Cancel</button>
        <button class="btn btn-primary letz-btn" type="submit" id="btnUpdate">Update</button>
    </div>
    <!--common button end-->
    <div class="box clearfix">
        <div class="col-md-12 col-xs-12">
            <div class="box-header with-border">
                <h3 class="box-title">Profile Settings</h3>
            </div>
            <div class="box-body">
                <form action="" id="profileform" onsubmit="return false" runat="server">
                    <div class="row">
                        <div class="col-md-6 col-sm-6 col-xs-12">
                            <div class="form-group ">
                                <label class="control-label">I am </label>
                                <select id="selectprofile" name="selectprofile" class="form-control" required="required">                                                
                                    <option value="0">--Select--</option>
                                    <option value="2"> Company </option>
                                    <option value="1"> Chartered Accountant </option>
                                    <option value="4"> CA Company </option>
                                    <%--<option value="consultant"> Consultant</option>
                                    <option value="individual">Individual</option>--%>
                                </select>
                            </div>
                            <div class="form-group">
                                <label class="control-label">Company Name</label>
                                <input type="text" class="form-control" id="companyname" name="companyname" placeholder="Company Name">
                            </div>
                            <div class="form-group">
                                <label class="control-label required">Contact Number</label>
                                <input type="text" class="form-control" id="contactno" name="contactno" placeholder="Contact Numbar" required="required">
                            </div>
                            <div class="form-group">
                                <label class="control-label required">Email</label>
                                <input type="email" class="form-control" id="profileemail" name="profileemail" placeholder="Email" required="required">
                            </div>
                            <div class="form-group">
                                <label class="control-label">Website</label>
                                <input type="text" class="form-control" id="website" name="website" placeholder="Website">
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                            <div class="form-group">
                                <label class="control-label">Company Logo</label>
                                <input type="file" class="filestyle" data-icon="false" id="companylogo" name="companylogo">
                            </div>
                            <div class="form-group address-group">
                                <label class="control-label">Address</label>
                                <input type="text" class="form-control" id="address1" name="address1" placeholder="Address line 1">
                                <input type="text" class="form-control" id="address2" name="address2" placeholder="Address line 2">
                                <input type="text" class="form-control" id="address3" name="address3" placeholder="Address line 3">
                            </div>
                            <div class="row">
                                <div class="form-group col-md-6 col-sm-12 col-xs-12">
                                    <label class="control-label">City</label>
                                    <input type="text" class="form-control" id="city" name="city" placeholder="City">
                                </div>
                                <div class="form-group col-md-6 col-sm-12 col-xs-12">
                                    <label class="control-label">State</label>
                                    <select id="state" name="state"  class="form-control chosen-select-deselect">                                                
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
                            <div class="row">
                                <div class="form-group col-md-6 col-sm-12 col-xs-12">
                                    <label class="control-label required">Pin</label>
                                    <input type="text" class="form-control" id="pin" name="pin" placeholder="Pin" required="required">
                                </div>
                                <div class="form-group col-md-6 col-sm-12 col-xs-12">
                                    <label class="control-label">Country</label>
                                    <input type="text" class="form-control" id="country" name="country" placeholder="Country">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <div class="form-group">
                                <label class="control-label required">PAN Number</label>
                                <input type="text" class="form-control" id="panno" name="panno" placeholder="Pan Number" required="required">
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
                        </div>

                        <div class="col-md-6 col-sm-12 col-xs-12">

                            <div class="form-group">
                                <label class="control-label required">GSTN</label>
                                <input type="text" class="form-control" id="gstnno" name="gstnno" placeholder="Gst Number" required="required">
                            </div>
                            <div class="form-group hideadhaar">
                                <label class="control-label required" >Adhaar Number</label>
                                <input type="text" class="form-control" id="adhaar" name="adhaar" placeholder="Adhaar Number" required="required">
                            </div>
                            <div class="form-group hideme">
                                <label class="control-label">CIN</label>
                                <input type="text" class="form-control" id="cin" name="cin" placeholder="Cin Number">
                            </div>
                            <div class="form-group hideme">
                                <label class="control-label">VAT / TIN </label>
                                <input type="text" class="form-control" id="vattin" name="vattin" placeholder="Vat / Tin Number">
                            </div>
                        </div>
                    </div>
                    <div class="box-footer">
                        <button class="btn btn-primary letz-btn" type="submit">Submit</button>
                    </div>
                        <asp:HiddenField ClientIDMode="Static" ID="hdn_FirstTime" runat="server" Value="0" />
                        <asp:HiddenField ClientIDMode="Static" ID="hdn_uType" runat="server" Value="0" />                    
                        <asp:HiddenField ClientIDMode="Static" ID="hdn_LoginName" runat="server" Value="" />
                        <asp:HiddenField ClientIDMode="Static" ID="hdn_LogoUrl" runat="server" Value="" />
                        <asp:HiddenField ClientIDMode="Static" ID="hdn_Expiry" runat="server" Value="" />
                        <input type="hidden" id="fileUrl" />
                </form>
            </div>

        </div>
    </div>    
    <script src="../js/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../js/profile.js"></script>
</asp:Content>
