<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="LetzGST.Index" %>

<!DOCTYPE html>
<%--adding comment--%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta http-equiv="x-ua-compatible" content="ie=edge" />
    <title>Login</title>
    <link href="css/master.css" rel="stylesheet" />
</head>
<body>
    <div class="preloader" id="preloader" style="display:none;">
        <img src="../../images/Ripple.svg" />
    </div>
    <div class="bg-gradient">
        <div class="texture">

            <div class="row no-gutters">

                <div class="login-body">
                    <div class="login-header">
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <img src="images/letzgst.png" class="img-responsive logo">
                        </div>

                    </div>
                    <div class="login-body">
                        <div class="login-container">
                            <div class="login-container-text">
                                <h3>Welcome to LetzGST</h3>
                                <p>Introducing LETZGST Comprehensive Software for GST Compliance to manage your business activity on single platform.</p>
                                <ul>
                                    <li>Experience Digital Invoicing auto followup,Reminders</li>
                                    <li>Track your Payments (Reconcile) </li>
                                    <li>Simply Manage HSN / SAC Codes</li>
                                    <li>Access your account from anywhere</li>
                                    <li>Add your users with appropriate permission</li>
                                    <li>Informative Dashboard will help you to see growth of your business</li>
                                    <li>User Friendy GST Trasition to Upload your Monthly / Quartarly Returns</li>
                                    <li>Automated Tax calculation of CGST/SGST/IGST/UTGST</li>
                                    <li>Monthly, quartarly, annual consolidate reports</li>
                                </ul>
                            </div>
                        </div>
                        <div class="login-box right-align">
                            <div class="loginbox-overflow-container">
                                <div class="translate-container">
                                    <div class="login-translate-container" style="transform: translateX(0px);">
                                        <div class="login-steps">
                                            <div class="heading">
                                                Login to Dashboard
                                            </div>
                                            <div class="login-details-container">
                                                <div class="login-text">
                                                    Enter your Credentials
                                                </div>
                                                <div>
                                                    <label id="lblErrorMsg" class="error" ></label>
                                                </div>
                                                <form class="login-form" id="loginform">
                                                    <div class="form-group">
                                                        <label>Email</label>
                                                        <input type="email" class="form-control" name="loginemail" id="loginemail" required="required" />
                                                    </div>
                                                    <div class="form-group">
                                                        <label>Password</label>
                                                        <input type="password" class="form-control" name="loginpwd" id="loginpwd" required="required" />
                                                    </div>
                                                    <div class="forgot-password-text highlight-text sign">
                                                        New to Letzgst? SignUp
                                                    </div>

                                                    <div class="forgot-password-text highlight-text fp">
                                                        Forgot Password?
                                                    </div>
                                                    <button class="btn btn-primary form-control" type="submit">Login</button>
                                                </form>
                                            </div>
                                        </div>
                                        <div class="login-steps">
                                            <div class="heading">
                                                Forgot Password
                                            </div>
                                            <div class="login-details-container">
                                                <div class="login-text">
                                                    Enter your entered mobile number to reset your password
                                                </div>                                              
                                                <div>
                                                    <label id="lblErrorMsgMobVAL" class="error" ></label>
                                                </div>
                                                <form class="login-form" id="forgotform">
                                                    <div class="form-group">
                                                        <label>Mobile Number</label>
                                                        <input type="text" class="form-control" name="forgotmob" id="forgotmob" required="required" />
                                                    </div>

                                                    <div class="forgot-password-text highlight-text bl">
                                                        Back to Login
                                                    </div>
                                                    <button class="btn btn-primary form-control" type="submit">Submit</button>
                                                </form>
                                            </div>
                                        </div>
                                        <div class="login-steps">
                                            <div class="heading">
                                                Signing Up...
                                            </div>
                                            <div class="login-details-container">
                                                <div class="login-text">
                                                    Create your to continue
                                                </div>
                                                <div>
                                                    <label id="lblErrorMsgCrt" class="error" ></label>
                                                </div>
                                                <form class="login-form" id="signupform">
                                                     <div class="form-group">
                                                        <label>Name</label>
                                                        <input type="text" class="form-control" name="username" id="username" required="required">
                                                    </div>
                                                    <div class="form-group">
                                                        <label>Email</label>
                                                        <input type="email" class="form-control" name="signupemail" id="signupemail" required="required" />
                                                    </div>
                                                    <div class="form-group">
                                                        <label>Mobile Number</label>
                                                        <input type="text" class="form-control" name="signupmob" id="signupmob" required="required" />
                                                    </div>
                                                    <div class="form-group">
                                                        <label>Password</label>
                                                        <input type="password" class="form-control" name="signuppwd" id="signuppwd" required="required" />
                                                    </div>
                                                    <div class="form-group">
                                                        <label>Confirm Password</label>
                                                        <input type="password" class="form-control" name="signupcpwd" id="signupcpwd" required="required" />
                                                    </div>

                                                    <div class="forgot-password-text highlight-text bl">
                                                        Already have an account? Back to Login
                                                    </div>
                                                    <button class="btn btn-primary form-control createac" type="button " id="signupbtn">Sign Up</button>
                                                </form>
                                            </div>
                                        </div>
                                        <div class="login-steps">
                                            <div class="heading">
                                                Enter OTP
                                            </div>
                                            <div class="login-details-container">
                                                <div class="login-text">
                                                    Enter OTP to confirm your account
                                                </div>
                                                <form class="login-form" id="confirmotpform">
                                                    <div class="form-group">
                                                        <label>Enter OTP</label>
                                                        <input type="text" class="form-control" name="confirmotp" id="confirmotp" required="required" />
                                                    </div>
                                                    <button class="btn btn-primary form-control" type="submit">Submit</button>
                                                </form>
                                            </div>
                                        </div>
                                        <div class="login-steps">
                                            <div class="heading">
                                                Enter OTP
                                            </div>
                                            <div class="login-details-container">
                                                <div class="login-text">
                                                    Enter OTP to reset your password
                                                </div>
                                                <div>
                                                    <label id="LBLErrorMsgOTP" class="error" ></label>
                                                </div>
                                                <form class="login-form" id="forgototp">
                                                    <div class="form-group">
                                                        <label>Enter OTP</label>
                                                        <input type="text" class="form-control" name="forgototp" id="txtforgototp" required="required" />
                                                    </div>
                                                    <button class="btn btn-primary form-control" type="submit">Submit</button>
                                                </form>
                                            </div>
                                        </div>
                                        <div class="login-steps">
                                            <div class="heading">
                                                Reset Password
                                            </div>
                                            <div class="login-details-container">
                                                <div class="login-text">
                                                    Enter New password
                                                </div>
                                                <form class="login-form" id="newpwdform">
                                                    <div class="form-group">
                                                        <label>New Password</label>
                                                        <input type="password" class="form-control" name="newpwd" id="newpwd" required="required" />
                                                    </div>
                                                    <div class="form-group">
                                                        <label>Confirm New Password</label>
                                                        <input type="password" class="form-control" name="newcpwd" id="newcpwd" required="required" />
                                                    </div>
                                                    <button class="btn btn-primary form-control" type="submit">Submit</button>
                                                </form>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>


        </div>
    </div>
</body>
    <!-- SCRIPTS -->
<!-- JQuery -->
<script type="text/javascript" src="js/jquery-3.1.1.min.js"></script>
<script src="https://npmcdn.com/tether@1.2.4/dist/js/tether.min.js"></script>
<script type="text/javascript" src="js/bootstrap.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.16.0/jquery.validate.min.js"></script>
<script type="text/javascript" src="js/custom.js"></script>
    <script type="text/javascript" src="js/common.js"></script>
</html>
