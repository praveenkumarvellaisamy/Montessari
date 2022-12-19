<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Sparkles</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="css/bootstrap-landing.css" rel="stylesheet" />
    <link href="css/animate.css" rel="stylesheet" />
    <link href="css/style-landing.css" rel="stylesheet" />
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.js"></script>
    <script src="js/jquery.localScroll.min.js"></script>
    <script src="js/waypoints.min.js"></script>
    <script src="js/jquery.touchSwipe.min.js"></script>
    <link href="css/fontawesome.css" rel="stylesheet" />
    <link href="css/Googleapis1.css" rel="stylesheet" />
    <link href="css/Googleapis2.css" rel="stylesheet" />
    <link href="css/Googleapis3.css" rel="stylesheet" />
    <!-- Custom JS -->
    <script src="js/custom.js"></script>
    <script>
        $(document).ready(function () {
            $("#loginwrap").show();

            $("#main-login").click(function () {
                $("#loginwrap").fadeIn();
                $("#ForgotPasswordwrap").hide();
                $("#signupwrap").hide();
            });

            $("#btn-signup").click(function () {
                $("#signupwrap").fadeIn();
                $("#loginwrap").hide();
                $("#ForgotPasswordwrap").hide();
            });

            $("#btn-login").click(function () {
                $("#signupwrap").hide();
                $("#loginwrap").fadeIn();
                $("#ForgotPasswordwrap").hide();
            });
            $("#btn-login1").click(function () {
                $("#signupwrap").hide();
                $("#loginwrap").fadeIn();
                $("#ForgotPasswordwrap").hide();
            });
            $("#btnFP").click(function () {
                $("#signupwrap").hide();
                $("#loginwrap").hide();
                $("#ForgotPasswordwrap").fadeIn();
            });
        });
    </script>
    <style>
        .login-input {
            margin: 10px !important;
        }
    </style>
</head>
<body>
    <form id="frm" runat="server">
        <nav class="navbar navbar-fixed-top" role="navigation">
            <div class="container-fluid">
                <div class="navbar-header">
                    <a class="navbar-brand logo" href="#">
                        <img src="images/logo.png" style="margin-top: 5px; margin-left: 20px;" /></a>
                </div>
            </div>
        </nav>

        <!-- header - homepage -->
        <header id="homepage" class="nav-link">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-6">
                        <div class="animate fadeInLeftBig animated admin-bannertext">
                            <img src="images/banner-text.png" /><br>
                            <img src="images/book-btn.png" class="fadeInLeftBig animated" id="main-login" style="margin-top: 10px; cursor: pointer" />
                        </div>
                    </div>


                    <div class="col-lg-6">
                        <div class="main-wrap" style="display:none;" id="loginwrap" runat="server">
                            <div class="login-title">Login</div>
                            <%-- <input type="text" class="login-input" placeholder="User ID"/>
        <input type="password" class="login-input" placeholder="Password"/>--%>
                            <asp:TextBox ID="txtUserNameInput" runat="server" placeholder="Name" CssClass="login-input"></asp:TextBox>
                            <asp:TextBox ID="txtPasswordInput" runat="server" TextMode="Password" placeholder="Password" CssClass="login-input"></asp:TextBox>
                            <div class="mt-3 w-100" id="divError" runat="server" visible="false">
                                <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
                            </div>
                            <div class="mt-3 w-100">
                                <%--<button type="button" class="btn login-btn" onclick="location.href='Login/Profile.aspx'">Login</button>--%>
                                <asp:Button ID="btnLogin" runat="server" class="btn login-btn" OnClick="btnLogin_Click" Text="Login" />
                                <span class="forgot-pass"><a href="#" id="btnFP">Forgot Password?</a></span>
                            </div>
                            <div class="signup-text">New to Sparkles, <a href="#" id="btn-signup">Sign Up</a> to explore</div>
                        </div>
                        <div class="main-wrap" style="display: none;" runat="server" id="signupwrap">
                            <div class="login-title">Register</div>
                            <%--<input type="text" class="login-input" placeholder="Name"/>--%>
                            <%--<input type="text" class="login-input" placeholder="Email"/>--%>
                            <%--<input type="password" class="login-input" placeholder="Password"/>--%>
                            <asp:TextBox ID="txtUserName" runat="server" placeholder="Name" CssClass="login-input"></asp:TextBox>
                            <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" CssClass="login-input"></asp:TextBox>
                            <asp:TextBox ID="txtMobileNumber" MaxLength="10" runat="server" placeholder="Mobile Number" CssClass="login-input"></asp:TextBox>
                            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" placeholder="Password" CssClass="login-input"></asp:TextBox>
                             <div class="mt-3 w-100" id="divErrorMessage" runat="server" visible="false">
                                <asp:Label ID="lblErrorMessageRegiter" runat="server"></asp:Label>
                            </div>
                            <div class="mt-3 w-100">
                                <%--<button type="button" class="btn login-btn" onclick="location.href='#'">Register</button>--%>
                                <asp:Button ID="btnRegister" runat="server" class="btn login-btn" OnClick="btnRegister_Click" Text="Register" />
                            </div>
                            <div class="signup-text">Already have an account? <a href="#" id="btn-login">Login Now</a></div>
                        </div>
                        <div class="main-wrap" runat="server" style="display: none;" id="ForgotPasswordwrap">
                            <div class="login-title">Forgot Password</div>
                            <%--<input type="text" class="login-input" placeholder="Name"/>--%>
                            <%--<input type="text" class="login-input" placeholder="Email"/>--%>
                            <%--<input type="password" class="login-input" placeholder="Password"/>--%>
                            <asp:TextBox ID="txtUserNameFP" runat="server" placeholder="User Name" CssClass="login-input"></asp:TextBox>
                            <asp:TextBox ID="txtEmailFP" runat="server" placeholder="Email" CssClass="login-input"></asp:TextBox>
                            <div class="mt-3 w-100">
                                <%--<button type="button" class="btn login-btn" onclick="location.href='#'">Register</button>--%>
                                <asp:Button ID="btnSendOTP" runat="server" class="btn login-btn" OnClick="btnSendOTP_Click" Text="Send OTP" />
                            </div>
                            <div class="signup-text"><a href="#" id="btn-login1">Login Now</a></div>
                        </div>
                    </div>
                </div>
            </div>
        </header>
    </form>
</body>
</html>
