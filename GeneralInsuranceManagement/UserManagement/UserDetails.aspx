<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultUIS.Master" AutoEventWireup="true" CodeBehind="UserDetails.aspx.cs" Inherits="GeneralInsuranceManagement.UserManagement.UserDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!--breadcrumb-->
 <div class="page-breadcrumb d-none d-sm-flex align-items-center mb-3">
     <div class="breadcrumb-title pe-3">User Management</div>
     <div class="ps-3">
         <nav aria-label="breadcrumb">
             <ol class="breadcrumb mb-0 p-0">
                 <li class="breadcrumb-item"><a href="~/Default"><i class="bx bx-home-alt"></i></a>
                 </li>
                 <li class="breadcrumb-item active" aria-current="page">Register</li>
             </ol>
         </nav>
     </div>
     <div class="ms-auto">
         <div class="btn-group">
             <button type="button" class="btn btn-primary">Options</button>
             <button type="button" class="btn btn-primary split-bg-primary dropdown-toggle dropdown-toggle-split" data-bs-toggle="dropdown">
                 <span class="visually-hidden">Toggle Dropdown</span>
             </button>
             <div class="dropdown-menu dropdown-menu-right dropdown-menu-lg-end">
                 <p><asp:button class="dropdown-item" runat="server" text="Logs" OnClick="Unnamed_Click" ID="btnLogs"></asp:button></p>
                 <%--<a class="dropdown-item" runat="server" data-userId="<%Context.Session["UserID"]%>" href="~/UserManagement/UserLogs?userID=">Logs</a>--%>
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
                             <asp:TextBox runat="server" ID="FirstName" CssClass="form-control" placeholder="Enter firstname" disabled="true"/>
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
                             <asp:TextBox runat="server" ID="Lastname" CssClass="form-control" placeholder="Enter Lastname" disabled="true"/>
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
                             <asp:TextBox runat="server" ID="Username" CssClass="form-control" placeholder="Enter Username" disabled="true"/>
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
                             <asp:TextBox runat="server" ID="Email" CssClass="form-control" placeholder="Enter Email" disabled="true"/>
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
                             <asp:TextBox runat="server" ID="PhoneNumber" CssClass="form-control" placeholder="Enter Phone Number" disabled="true"/>
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
                             <asp:TextBox runat="server" ID="PasswordLifeSpan" CssClass="form-control" placeholder="Enter Password LifeSpan" disabled="true"/>
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
                             <asp:DropDownList ID="UserRoleID" runat="server" CssClass="form-select" disabled="true">
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
                             <asp:DropDownList ID="DepartmentId" runat="server" CssClass="form-select" disabled="true">
                             </asp:DropDownList>
                         </div>
                         <asp:RequiredFieldValidator runat="server" ControlToValidate="DepartmentId"
                             CssClass="text-danger" ErrorMessage="The Department field is required." />
                     </div>
                 </div>
                 <!-- row -->
                 <div class="row">
                     <asp:Label runat="server" AssociatedControlID="AllowPasswordReuse" class="col-sm-3 col-form-label">Allow Password Reuse? </asp:Label>
                     <div class="col-sm-9">
                         <div class="form-check">
                             <asp:CheckBox ID="AllowPasswordReuse" CssClass="form-check" runat="server" disabled="true"/>
                         </div>
                     </div>
                 </div>
                 <!-- row -->
                 <div class="row">
                     <asp:Label runat="server" AssociatedControlID="PasswordExpires" class="col-sm-3 col-form-label">Password Expires? </asp:Label>
                     <div class="col-sm-9">
                         <div class="form-check">
                             <asp:CheckBox ID="PasswordExpires" CssClass="form-check" runat="server" disabled="true"/>
                         </div>
                     </div>
                 </div>
                 <!-- row -->


                 <!-- form-layout-footer -->
             </div>
             <!-- card -->
         </div>
     </div>
 </div>
</asp:Content>
