<%@ Page Title="Manage Account" Language="C#" MasterPageFile="~/DefaultUIS.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="GeneralInsuranceManagement.Account.Manage" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>

        <div>
            <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
                <p class="text-success"><%: SuccessMessage %></p>
            </asp:PlaceHolder>
        </div>
        <asp:HiddenField ID="TxtUserId" runat="server" />
          <!--breadcrumb-->
  <div class="page-breadcrumb d-none d-sm-flex align-items-center mb-3">
      <div class="breadcrumb-title pe-3">User Management</div>
      <div class="ps-3">
          <nav aria-label="breadcrumb">
              <ol class="breadcrumb mb-0 p-0">
                  <li class="breadcrumb-item"><a href="~/Default"><i class="bx bx-home-alt"></i></a>
                  </li>
                  <li class="breadcrumb-item active" aria-current="page">Account Details</li>
              </ol>
          </nav>
      </div>
      <div class="ms-auto">
          <div class="btn-group">
              <button type="button" class="btn btn-primary">Settings</button>
              <button type="button" class="btn btn-primary split-bg-primary dropdown-toggle dropdown-toggle-split" data-bs-toggle="dropdown">
                  <span class="visually-hidden">Toggle Dropdown</span>
              </button>
              <div class="dropdown-menu dropdown-menu-right dropdown-menu-lg-end">
                  <a class="dropdown-item" href="javascript:;">Action</a>
                  <a class="dropdown-item" href="javascript:;">Another action</a>
                  <a class="dropdown-item" href="javascript:;">Something else here</a>
                  <div class="dropdown-divider"></div>
                  <a class="dropdown-item" href="javascript:;">Separated link</a>
              </div>
          </div>
      </div>
  </div>
  <!--end breadcrumb-->

        <asp:HiddenField ID="UserId" runat="server" />

<div class="row">
    <div class="col-lg-8 mx-auto">
        <div class="card ">
            <div class="card-body p-4">
                <h5 runat="server" class="mb-4">
                    <asp:Literal runat="server" ID="pagetitle" /></h5>
                <p class="text-danger">
                    <asp:Literal runat="server" ID="ErrorMessage" />
                </p>
                <asp:ValidationSummary runat="server" CssClass="text-danger" />


                <div class="row">
                    <asp:Label runat="server" AssociatedControlID="FirstName" class="col-sm-3 col-form-label">First Name </asp:Label>
                    <div class="col-sm-9">
                        <div class="input-group">
                            <span class="input-group-text"><i class="text-primary" data-feather="user"></i></span>
                            <asp:TextBox runat="server" ID="FirstName" CssClass="form-control" placeholder="Enter firstname" />
                        </div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstName"
                            CssClass="text-danger" ErrorMessage="The First Name field is required." />
                    </div>
                </div>
                <!-- row -->
                <div class="row">
                    <asp:Label runat="server" AssociatedControlID="Lastname" CssClass="col-sm-3 col-form-label">Last Name </asp:Label>
                    <div class="col-sm-9">
                        <div class="input-group">
                            <span class="input-group-text"><i class="text-primary" data-feather="users"></i></span>
                            <asp:TextBox runat="server" ID="Lastname" CssClass="form-control" placeholder="Enter Lastname" />
                        </div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Lastname"
                            CssClass="text-danger" ErrorMessage="The Last Name field is required." />
                    </div>
                </div>

                <!-- row -->
                <div class="row">
                    <asp:Label runat="server" AssociatedControlID="Username" class="col-sm-3 col-form-label">Username </asp:Label>
                    <div class="col-sm-9">
                        <div class="input-group">
                            <span class="input-group-text"><i class="text-primary" data-feather="user-plus"></i></span>
                            <asp:TextBox runat="server" ID="Username" CssClass="form-control" placeholder="Enter Username" />
                        </div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Username"
                            CssClass="text-danger" ErrorMessage="The Username field is required." />
                    </div>
                </div>
                <!-- row -->
                <div class="row">
                    <asp:Label runat="server" AssociatedControlID="Email" class="col-sm-3 col-form-label">Email </asp:Label>
                    <div class="col-sm-9">
                        <div class="input-group">
                            <span class="input-group-text"><i class="text-primary" data-feather="mail"></i></span>
                            <asp:TextBox runat="server" ID="Email" CssClass="form-control" placeholder="Enter Email" />
                        </div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                            CssClass="text-danger" ErrorMessage="The Email field is required." />
                    </div>
                </div>
                <!-- row -->
                <div class="row">
                    <asp:Label runat="server" AssociatedControlID="PhoneNumber" class="col-sm-3 col-form-label">Phone Number </asp:Label>
                    <div class="col-sm-9">
                        <div class="input-group">
                            <span class="input-group-text"><i class="text-primary" data-feather="phone"></i></span>
                            <asp:TextBox runat="server" ID="PhoneNumber" CssClass="form-control" placeholder="Enter Phone Number" />
                        </div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="PhoneNumber"
                            CssClass="text-danger" ErrorMessage="The Phone Number field is required." />
                    </div>
                </div>
                <!-- row -->
                <div class="row">
                    <asp:Label runat="server" AssociatedControlID="PasswordLifeSpan" class="col-sm-3 col-form-label">Password LifeSpan(In Days) </asp:Label>
                    <div class="col-sm-9">
                        <div class="input-group">
                            <span class="input-group-text"><i class="text-primary" data-feather="clock"></i></span>
                            <asp:TextBox runat="server" ID="PasswordLifeSpan" CssClass="form-control" placeholder="Enter Password LifeSpan" />
                        </div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="PasswordLifeSpan"
                            CssClass="text-danger" ErrorMessage="The Password LifeSpan field is required." />
                    </div>
                </div>
                <!-- row -->
                <div class="row">
                    <asp:Label runat="server" AssociatedControlID="UserRoleID" class="col-sm-3 col-form-label">User Role </asp:Label>
                    <div class="col-sm-9">
                        <div class="input-group">
                            <span class="input-group-text"><i class="text-primary" data-feather="user-check"></i></span>
                            <asp:DropDownList ID="UserRoleID" runat="server" CssClass="form-select">
                            </asp:DropDownList>
                        </div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="UserRoleID"
                            CssClass="text-danger" ErrorMessage="The User Role field is required." />
                    </div>
                </div>
                <!-- row -->
                <div class="row">
                    <asp:Label runat="server" AssociatedControlID="DepartmentId" class="col-sm-3 col-form-label">Department </asp:Label>
                    <div class="col-sm-9">
                        <div class="input-group">
                            <span class="input-group-text"><i class="text-primary" data-feather="archive"></i></span>
                            <asp:DropDownList ID="DepartmentId" runat="server" CssClass="form-select">
                            </asp:DropDownList>
                        </div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="DepartmentId"
                            CssClass="text-danger" ErrorMessage="The Department field is required." />
                    </div>
                </div>
                <!-- row -->
                <div class="row">
                    <asp:Label runat="server" AssociatedControlID="ChangePassword" class="col-sm-3 col-form-label">Password </asp:Label>
                    <div class="col-sm-9">
                        <div class="input-group">
                            <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Change]" Visible="false" ID="ChangePassword" runat="server" />
                        </div>
                    </div>
                </div>
                <!-- row -->
                <div class="row">
                    <asp:Label runat="server" AssociatedControlID="AllowPasswordReuse" class="col-sm-3 col-form-label">Allow Password Reuse? </asp:Label>
                    <div class="col-sm-9">
                        <div class="form-check">
                            <asp:CheckBox ID="AllowPasswordReuse" CssClass="form-check" runat="server" />
                        </div>
                    </div>
                </div>
                <!-- row -->
                <div class="row">
                    <asp:Label runat="server" AssociatedControlID="PasswordExpires" class="col-sm-3 col-form-label">Password Expires? </asp:Label>
                    <div class="col-sm-9">
                        <div class="form-check">
                            <asp:CheckBox ID="PasswordExpires" CssClass="form-check" runat="server" />
                        </div>
                    </div>
                </div>
                <!-- row -->
                <asp:Panel ID="pnlSave" runat="server">
                    <div class="row">
                        <label class="col-sm-3 col-form-label"></label>
                        <div class="col-sm-9">
                            <asp:Button runat="server" OnClick="btnUpdate_Click" ID="btnUpdate" Text="Update" CssClass="btn btn-primary px-4 " />&nbsp
                        </div>
                    </div>
                </asp:Panel>
                <!-- row -->

                <!-- form-layout-footer -->
            </div>
            <!-- card -->
        </div>
    </div>
</div>

        <div class="col-md-12">
            <div class="row">
                <hr />
                <dl class="dl-vertical">
                    <%--<dt>Password:</dt>--%>
                    <dd>
                        <%--<asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Change]" Visible="false" ID="ChangePassword" runat="server" />--%>
                        <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Create]" Visible="false" ID="CreatePassword" runat="server" />
                    </dd>
                    <dt>External Logins:</dt>
                    <dd><%: LoginsCount %>
                        <asp:HyperLink NavigateUrl="/Account/ManageLogins" Text="[Manage]" runat="server" />

                    </dd>
                    <%--
                        Phone Numbers can used as a second factor of verification in a two-factor authentication system.
                        See <a href="https://go.microsoft.com/fwlink/?LinkId=403804">this article</a>
                        for details on setting up this ASP.NET application to support two-factor authentication using SMS.
                        Uncomment the following blocks after you have set up two-factor authentication
                    --%>
                    <%--
                    <dt>Phone Number:</dt>
                    <% if (HasPhoneNumber)
                        { %>
                    <dd>
                        <asp:HyperLink NavigateUrl="/Account/AddPhoneNumber" runat="server" Text="[Add]" />
                    </dd>
                    <% }
                        else
                        { %>
                    <dd>
                        <asp:Label Text="" ID="PhoneNumber" runat="server" />
                        <asp:HyperLink NavigateUrl="/Account/AddPhoneNumber" runat="server" Text="[Change]" /> &nbsp;|&nbsp;
                        <asp:LinkButton Text="[Remove]" OnClick="RemovePhone_Click" runat="server" />
                    </dd>
                    <% } %>
                    --%>

                   <%-- <dt>Two-Factor Authentication:</dt>
                    <dd>
                        <p>
                            There are no two-factor authentication providers configured. See <a href="https://go.microsoft.com/fwlink/?LinkId=403804">this article</a>
                            for details on setting up this ASP.NET application to support two-factor authentication.
                        </p>--%>
                        <% if (TwoFactorEnabled)
                            { %> 
                        <%--
                        Enabled
                        <asp:LinkButton Text="[Disable]" runat="server" CommandArgument="false" OnClick="TwoFactorDisable_Click" />
                        --%>
                        <% }
                            else
                            { %> 
                        <%--
                        Disabled
                        <asp:LinkButton Text="[Enable]" CommandArgument="true" OnClick="TwoFactorEnable_Click" runat="server" />
                        --%>
                        <% } %>
                    <%--</dd>--%>
                </dl>
            </div>
        </div>
    </main>
</asp:Content>
