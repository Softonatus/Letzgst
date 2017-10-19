<%@ Page Title="" Language="C#" MasterPageFile="~/GSTSite.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="LetzGST.Dashboard.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- <div id="page-content-wrapper">--%>
                <div class="row">
                    <div class="col-md-4 col-md-offset-4 col-sm-6 col-xs-12">
                        <div class="box clearfix">
                            <div class="box-header with-border">
                                <h3 class="box-title">Change Password</h3>
                            </div>
                            <div class="box-body">
                                <form id="pwdvalid">

                                    <div class="form-group">
                                        <label class="control-label">New Password </label>
                                        <input type="password" class="form-control" id="newpwd" name="newpwd">
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label">Confirm New Password </label>
                                        <input type="password" class="form-control" id="newcpwd" name="newcpwd">
                                    </div>

                                    <div class="box-footer">
                                        <button class="btn btn-primary letz-btn" type="submit" id="submitbtn">Submit</button>
                                    </div>
                                </form>
                                <form id="parentId" runat="server">
                                    <asp:HiddenField ClientIDMode="Static" ID="hdn_Main" runat="server" Value="0" />
                                    <asp:HiddenField ClientIDMode="Static" ID="hdn_uType" runat="server" Value="0" />                    
                                    <asp:HiddenField ClientIDMode="Static" ID="hdn_LoginName" runat="server" Value="" />
                                    <asp:HiddenField ClientIDMode="Static" ID="hdn_LogoUrl" runat="server" Value="" />
                                </form>
                            </div>
                        </div>
                    </div>

                </div>
        <%--    </div>--%>
            <script type="text/javascript" src="../../js/changePassword.js"></script>
</asp:Content>
