<%@ Page Title="" Language="C#" MasterPageFile="~/GSTSite.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="LetzGST.Dashboard.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-8 col-md-offset-2 col-xs-12">
            <div class="block-head">
                <h3 class="margin-muted">Profile Settings</h3>
                <span></span>
            </div>
            <form action="" id="profileform">

                <div class="row">
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="form-group ">
                            <label class="control-label">I am </label>
                            <select id="selectprofile" name="selectprofile" class="form-control" required="required">                                                
                                <option value="0">--Select--</option>
                                <option value="2"> Company </option>
                                <option value="1"> Chartered Accountant </option>
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
                                <select id="state" name="state" class="form-control">                                                
                                <option selected> Select ...</option>
                                <option value="MH"> Maharashtra </option>
                                <option value="GJ"> Gujrat </option>
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
                <hr>
                <div class="block-head">
                    <h3 class="margin-muted">Compliance &amp; Tax Details</h3>
                    <span></span>
                </div>


                <div class="row">
                    <div class="col-md-6 col-sm-12 col-xs-12">
                        <div class="form-group">
                            <label class="control-label required">PAN</label>
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
                <button class="btn btn-primary letz-btn" type="submit">Submit</button>
                <!--<input type="button" class="btn btn-primary letz-btn" value="Submit">-->
            </form>

        </div>
    </div>
    <script type="text/javascript" src="../../js/profile.js"></script>
</asp:Content>
