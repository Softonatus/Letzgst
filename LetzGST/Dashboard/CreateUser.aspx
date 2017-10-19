<%@ Page Title="" Language="C#" MasterPageFile="~/GSTSite.Master" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="LetzGST.Dashboard.CreateUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- <div id="page-content-wrapper">--%>
                <div class="row">
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="box clearfix">
                            <div class="box-header with-border">
                                <h3 class="box-title">Create User &amp; Roles</h3>
                            </div>
                            <div class="box-body">
                                <form id="createusers">
                                    <div class="form-group">
                                        <label class="control-label">Name</label>
                                        <input type="text" class="form-control" id="crname" name="crname" placeholder="Name">
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label">Email</label>
                                        <input type="email" class="form-control" id="cremail" name="cremail" placeholder="Email">
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label">Mobile</label>
                                        <input type="text" class="form-control" id="crmobile" name="crmobile" placeholder="Mobile">
                                    </div>
                                    <div class="form-group ">
                                        <label class="control-label">Role </label>
                                        <select id="crrole" name="crrole" class="form-control" required="required"> 
                                                <option value="1" selected="selected"> Admin </option>
                                                <%--<option value="ca"> Chartered Accountant </option>
                                                <option value="consultant"> Consultant</option>
                                                <option value="individual">Staff</option>--%>
                                            </select>
                                    </div>
                                    <div class="box-footer">
                                        <button class="btn btn-primary letz-btn" type="submit">Submit</button>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="box clearfix">
                            <div class="box-header with-border">
                                <h3 class="box-title">User &amp; Roles</h3>
                            </div>
                            <div class="box-body">
                                <table id="usersroles" class="table table-bordered table-striped">
                                    <thead>
                                        <tr>
                                            <th style="display:none"></th>
                                            <th>Name</th>
                                            <th>Email</th>
                                            <th>Mobile</th>
                                            <th>Role</th>
                                            <th>Actions</th>
                                        </tr>
                                    </thead>
                                   <tbody id="bodyContent">
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <form id="userTypeid" runat="server">
                    <asp:HiddenField ClientIDMode="Static" ID="hdn_uType" runat="server" Value="0" />               
                    <asp:HiddenField ClientIDMode="Static" ID="hdn_LoginName" runat="server" Value="" />
                    <asp:HiddenField ClientIDMode="Static" ID="hdn_LogoUrl" runat="server" Value="" />
                </form>

       <%--     </div>  --%>  
    <script type="text/javascript" src="../../js/jsrender.js"></script>
    <script type="text/javascript" src="../../plugins/datatables/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="../../plugins/datatables/dataTables.bootstrap.min.js"></script>
    <script type="text/javascript" src="../../js/userRoles.js"></script>
    <script id="tbltemplate" type="text/x-jsrender">
        <tr id="{{:UserId}}">
            <td style="display:none">{{:UserId}}</td>
            <td>{{:Name}}</td>
            <td>{{:EmailId}}</td>
            <td>{{:ContactNo}}</td>
            <td>Admin</td>
            <td>
                <a class="actions-btn" id="view_user_{{:UserId}}" title="View" UID="{{:UserId}}"><span class="icon ico-view ico-2x"></span></a>
                <a class="actions-btn" id="edit_user_{{:UserId}}" title="Edit" UID="{{:UserId}}"><span class="icon ico-edit ico-2x"></span></a>
                <a class="actions-btn" id="delete_user_{{:UserId}}" title="Delete" UID="{{:UserId}}"><span class="icon ico-delete ico-2x"></span></a>
            </td>
        </tr>
    </script>
</asp:Content>
