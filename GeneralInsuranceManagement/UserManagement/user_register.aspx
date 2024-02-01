<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userlogin.aspx.cs" Inherits="GeneralInsuranceManagement.UserManagement.userlogin" %>

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
    <script src="../assets/js/pace.min.js"></script>
    <!-- Bootstrap CSS -->
    <link href="../assets/css/bootstrap.min.css" rel="stylesheet">
    <link href="../assets/css/bootstrap-extended.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;500&amp;display=swap" rel="stylesheet">
    <link href="../assets/css/app.css" rel="stylesheet">
    <link href="../assets/css/icons.css" rel="stylesheet">
    <title>Register</title>
</head>
<body>
    <!--wrapper-->
    <div class="wrapper">
        <div class="section-authentication-cover">
            <div class="">
                <div class="row g-0">

                    <div class="col-12 col-xl-7 col-xxl-8 auth-cover-left align-items-center justify-content-center d-none d-xl-flex" id="register_background">
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
                                        <h5 class="">Active Insurance Admin</h5>
                                        <p class="mb-0">Please fill the below details to create your account</p>
                                    </div>
                                    <div class="form-body">
                                        <form class="row g-3" runat="server">
                                            <div class="col-12">
                                                <asp:Label runat="server" for="inputUsername" CssClass="form-label">Username</asp:Label>
                                                <asp:TextBox runat="server" ID="inputUsername" CssClass="form-control" TextMode="SingleLine" />
                                                <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="inputUsername"--%>
                                                <%--CssClass="text-danger " ErrorMessage="The Username field is required." />--%>
                                            </div>
                                            <div class="col-12">
                                                <asp:Label runat="server" for="inputEmailAddress" CssClass="form-label">Email Address</asp:Label>
                                                <asp:TextBox runat="server" ID="EmailAddress" CssClass="form-control" TextMode="email" placeholder="admin@user.com" />
                                                <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="inputUsername"--%>
                                                <%--CssClass="text-danger " ErrorMessage="The Username field is required." />--%>
                                            </div>
                                            <div class="col-12">
                                                <asp:Label runat="server" for="Password" CssClass="form-label border-end-0">Password</asp:Label>
                                                <div class="input-group" id="show_hide_password">
                                                    <asp:TextBox runat="server" ID="TextBox1" CssClass="form-control" TextMode="SingleLine" />
                                                    <a href="javascript:;" class="input-group-text bg-transparent"><i class='bx bx-hide'></i></a>
                                                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="inputUsername"--%>
                                                    <%--CssClass="text-danger " ErrorMessage="The Username field is required." />--%>
                                                </div>
                                            </div>
                                            <div class="col-12">
                                                <asp:Label runat="server" for="inputSelectCountry" CssClass="form-label">Country</asp:Label>
                                                <asp:DropDownList runat="server" ID="inputSelectCountry" CssClass="form-select"
                                                    aria-label="Default select example">
                                                    <asp:ListItem Text="" Value="" />
                                                    <asp:ListItem Text="Botswana" Value="1" />
                                                    <asp:ListItem Text="Zimbabwe" Value="2" />
                                                    <asp:ListItem Text="Zambia" Value="3" />
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-12">
                                                <div class="form-check form-switch">
                                                    <asp:CheckBox runat="server" ID="flexSwitchCheckChecked" />
                                                    <asp:Label runat="server" for="flexSwitchCheckChecked" CssClass="form-check-label">I read and agree to Terms & Conditions</asp:Label>
                                                </div>
                                            </div>
                                            <div class="col-12">
                                                <div class="d-grid">
                                                    <button type="submit" class="btn btn-primary" style="background-color: #00416a;">Sign up</button>
                                                </div>
                                            </div>
                                            <div class="col-12">
                                                <div class="text-center ">
                                                    <p class="mb-0">
                                                        Already have an account? 
                                                        <asp:HyperLink runat="server" ID="signInLink" NavigateUrl="auth-cover-signin.html"
                                                            CssClass="signin-link" Text="Sign in here" Style="color: #00416a;" />
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
    <!--app JS-->
    <script src="assets/js/app.js"></script>
</body>
</html>
