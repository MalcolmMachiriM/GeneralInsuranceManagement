
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userlogin.aspx.cs" Inherits="GeneralInsuranceManagement.UserManagement.userlogin" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!--favicon-->
    <link rel="icon" href="../assets/images/favicon-32x32.png" type="image/png" />
    <!--plugins-->
    <link href="../assets/plugins/simplebar/css/simplebar.css" rel="stylesheet" />
    <link href="../assets/plugins/perfect-scrollbar/css/perfect-scrollbar.css" rel="stylesheet" />
    <link href="../assets/plugins/metismenu/css/metisMenu.min.css" rel="stylesheet" />
    <!-- loader-->
    <link href="../assets/css/pace.min.css" rel="stylesheet" />
    <%--<script src="../assets/js/pace.min.js"></script>--%>
    <!-- Bootstrap CSS -->
    <link href="../assets/css/bootstrap.min.css" rel="stylesheet">
    <link href="../assets/css/bootstrap-extended.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;500&amp;display=swap" rel="stylesheet">
    <link href="../assets/css/app.css" rel="stylesheet">
    <link href="../assets/css/icons.css" rel="stylesheet">
    <title>Login - General Insurance Management</title>

     <%-- swal --%>
 <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/sweetalert2@11.0.19/dist/sweetalert2.min.css">
 <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11.0.19/dist/sweetalert2.all.min.js"></script>
 <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

 <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/2.0.1/js/toastr.js"></script>
 <%-- Alerts --%>
 <script type="text/javascript">

     function success(msg) {

         toastr.option = {

             "debug": false,

             "positionClass": "toast-top-center",

             "Onclick": null

         }

         toastr.success(msg, "Success");

         return false;

     }


     function error(msg) {

         toastr.option = {

             "debug": false,

             "positionClass": "toast-top-center",

             "Onclick": null

         }

         toastr.error(msg, "Error");

         return false;

     }

     function warning(msg) {

         toastr.option = {

             "debug": false,

             "positionClass": "toast-top-center",

             "Onclick": null

         }

         toastr.warning(msg, "Warning");

         return false;

     }


 </script>
 <%-- Alerts --%>

 <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/2.0.1/js/toastr.js"></script>

 <script type="text/javascript" src="//cdn.jsdelivr.net/jquery/1/jquery.min.js"></script>

 <link media="screen" rel="stylesheet" type="text/css" href="//cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/css/toastr.css" />


 <%-- end swal --%>
</head>
<body>
    <!--wrapper-->
    <div class="wrapper">
        <div class="section-authentication-cover">
            <div class="">
                <div class="row g-0">

                    <div class="col-12 col-xl-7 col-xxl-8 auth-cover-left align-items-center justify-content-center d-none d-xl-flex" id="background">


                        <div class="card shadow-none bg-transparent shadow-none rounded-0 mb-0">
                            <div class="card-body">
                            </div>
                        </div>

                    </div>

                    <div class="col-12 col-xl-5 col-xxl-4 auth-cover-right align-items-center justify-content-center">
                        <div class="card rounded-0 m-3 shadow-none bg-transparent mb-0">
                            <div class="card-body p-sm-5">
                                <div class="">
                                    <div class="mb-3 text-center">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/assets/images/logo-icon.png" CssClass="logo-icon" AlternateText="logo icon"
                                            Style="width: 20%;" />
                                    </div>
                                    <div class="text-center mb-4">
                                        <h5 class="">General Insurance Management</h5>
                                        <p class="mb-0">Please log in to your account</p>
                                    </div>
                                    <div class="form-body">
                                        <form class="row g-3" runat="server">
                                            <div class="col-12">
                                                <asp:Label runat="server" for="inputEmailAddress" AssociatedControlID="Email" CssClass="form-label">Email</asp:Label>
                                                <asp:TextBox runat="server" ID="Email" CssClass="form-control"  placeholder="admin@user.com" />
                                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                                CssClass="text-danger " ErrorMessage="The Username field is required." />
                                            </div>
                                            <div class="col-12">
                                                <asp:Label runat="server" for="Password" CssClass="form-label border-end-0">Password</asp:Label>
                                                <div class="input-group" id="show_hide_password">
                                                    <asp:TextBox runat="server" ID="Password" CssClass="form-control" TextMode="Password" />
                                                    <a href="javascript:;" class="input-group-text bg-transparent"><i class='bx bx-hide'></i></a>
                                                </div>
                                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                                                    CssClass="text-danger " ErrorMessage="The Password field is required." />
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-check form-switch">
                                                    <asp:CheckBox runat="server" ID="RememberMe" />
                                                    <asp:Label runat="server" for="flexSwitchCheckChecked" AssociatedControlID="RememberMe" CssClass="form-check-label">Remember Me</asp:Label>
                                                </div>
                                            </div>
                                            <div class="col-md-6 text-end">
                                                <a href="auth-cover-forgot-password.html" style="color: #00416a;">Forgot Password ?</a>
                                            </div>
                                            <div class="col-12">
                                                <div class="d-grid">
                                                    <%--<button type="submit" class="btn btn-primary" style="background-color: #00416a;">Sign in</button>--%>
                                                    <asp:Button runat="server" OnClick="LogIn" Text="Sign in" CssClass="btn btn-primary" />
                                                </div>
                                            </div>
                                            <div class="col-12">
                                                <div class="text-center ">
                                                    <p class="mb-0">
                                                        Don't have an account yet? <a runat="server" href="~/Account/Register" style="color: #00416a;">Register here</a>
                                                    </p>
                                                </div>
                                            </div>
                                        </form>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
                <!--end row-->
            </div>
        </div>
    </div>
    <!--end wrapper-->
    <!-- Bootstrap JS -->
    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/assets/js/bootstrap.bundle.min.js") %>
        <%: Scripts.Render("~/assets/plugins/simplebar/js/simplebar.min.js") %>
        <%: Scripts.Render("~/assets/plugins/metismenu/js/metisMenu.min.js") %>
        <%: Scripts.Render("~/assets/plugins/perfect-scrollbar/js/perfect-scrollbar.js") %>
        <%: Scripts.Render("~/assets/js/jquery.min.js") %>

        <%: Scripts.Render("https://unpkg.com/feather-icons") %>
        <%: Scripts.Render("~/assets/js/app.js") %>

    </asp:PlaceHolder>

    <%--<script src="assets/js/bootstrap.bundle.min.js"></script>
    <!--plugins-->
    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/plugins/simplebar/js/simplebar.min.js"></script>
    <script src="assets/plugins/metismenu/js/metisMenu.min.js"></script>
    <script src="assets/plugins/perfect-scrollbar/js/perfect-scrollbar.js"></script>--%>
    <!--Password show & hide js -->
    <script>
        $(document).ready(function () {
            $("#show_hide_password a").on('click', function (event) {
                event.preventDefault();
                if ($('#show_hide_password input').attr("type") == "text") {
                    $('#show_hide_password input').attr('type', 'password');
                    $('#show_hide_password i').addClass("bx-hide");
                    $('#show_hide_password i').removeClass("bx-show");
                } else if ($('#show_hide_password input').attr("type") == "password") {
                    $('#show_hide_password input').attr('type', 'text');
                    $('#show_hide_password i').removeClass("bx-hide");
                    $('#show_hide_password i').addClass("bx-show");
                }
            });
        });
    </script>
</body>
</html>