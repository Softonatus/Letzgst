<%@ Page Title="" Language="C#" MasterPageFile="~/GSTSite.Master" AutoEventWireup="true" CodeBehind="Hsnsac.aspx.cs" Inherits="LetzGST.Dashboard.Hsnsac" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <%--  <div id="page-content-wrapper">--%>
                <div class="row">
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="box clearfix">
                            <div class="box-header with-border">
                                <h3 class="box-title">HSN / SAC Code</h3>
                            </div>
                            <div class="box-body">
                                <form id="sethsncode">
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
                                                    <button type="submit" id="search">
                                                        <span class="glyphicon glyphicon-search"></span>
                                                    </button>
                                                    </span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </form>
                                <form id="parentId" runat="server">
                                    <asp:HiddenField ClientIDMode="Static" ID="hdn_Main" runat="server" Value="0" />
                                    <asp:HiddenField ClientIDMode="Static" ID="hdn_uType" runat="server" Value="0" />            
                                    <asp:HiddenField ClientIDMode="Static" ID="hdn_LoginName" runat="server" Value="" />
                                    <asp:HiddenField ClientIDMode="Static" ID="hdn_LogoUrl" runat="server" Value="" />
                                </form>
                                <form id="savehsnCode">

                                    <div class="codes-container">
                                        <div class="codes" id="dvHSNCodes">
                                        </div>
                                    </div>


                                    <div class="box-footer">
                                        <button class="btn btn-primary letz-btn" type="submit" id="btnSubmit">Submit</button>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="box clearfix">
                            <div class="box-header with-border">
                                <h3 class="box-title">GST Codes</h3>
                            </div>
                            <div class="box-body">
                                <div class="table-responsive">
                                    <div id="dvHSN">
                                        <h4>HSN Codes</h4>
                                        <table id="hsncodes" class="table table-bordered table-striped">
                                            <thead>
                                                <tr>
                                                    <th>Sr.no</th>
                                                    <th>HSN Code</th>
                                                    <th>Description</th>
                                                    <th>Actions</th>
                                                </tr>
                                            </thead>
                                            <tbody id="hsnDetails">

                                            </tbody>
                                        </table>
                                    </div>
                                    <div class="saccodes-container" id="dvSAC">                                       
                                        <h4>SAC Codes</h4>
                                        <table id="saccodes" class="table table-bordered table-striped">
                                            <thead>
                                                <tr>
                                                    <th>Sr.no</th>
                                                    <th>SAC Code</th>
                                                    <th>Description</th>
                                                    <th>Actions</th>
                                                </tr>
                                            </thead>
                                            <tbody id="hscdetails">
                                            </tbody>
                                        </table>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            <%--</div>--%>
     <script type="text/javascript" src="../../js/jsrender.js"></script>
    <script type="text/javascript" src="../../plugins/datatables/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="../../plugins/datatables/dataTables.bootstrap.min.js"></script>
    <script type="text/javascript" src="../../js/hsnsac.js"></script>

    <script id="dvChkbox" type="text/x-jsrender">
        <div class="checkbox" id="chk_{{:HsnCodeId}}">
            <label><input type="checkbox" id="{{:HsnCodeId}}"><span>{{:HsnCode}}</span></label>
            <label><span>{{:HsnDetail}}</span></label>
            <label style="display:none" class="rate">{{:HsnRate}}</label>
        </div>
    </script>
    <script id="hsndata" type="text/x-jsrender">
        <tr id="hsn_{{:HsnCodeId}}">
            <td></td>
            <td>{{:HsnCode}}</td>
            <td>{{:HsnDetail}}</td>
            <td>
                <span id="rate_hsn_{{:HsnCodeId}}" style="display:none">{{:HsnRate}}</span>
                <a class="actions-btn" id="delete-user_{{:HsnCodeId}}" title="Delete" hsnid="{{:HsnCodeId}}" type="hsn"><span class="icon ico-delete ico-2x"></span></a>
            </td>
        </tr>
    </script>
    <script id="hscdata" type="text/x-jsrender">
        <tr id="hsc_{{:HsnCodeId}}">
            <td></td>
            <td>{{:HsnCode}}</td>
            <td>{{:HsnDetail}}</td>
            <td>
                <span id="rate_hsc_{{:HsnCodeId}}" style="display:none">{{:HsnRate}}</span>
                <a class="actions-btn" id="user_{{:HsnCodeId}}" title="Delete" hsnid="{{:HsnCodeId}}"  type="hsc"><span class="icon ico-delete ico-2x"></span></a>
            </td>
        </tr>
    </script>
</asp:Content>
