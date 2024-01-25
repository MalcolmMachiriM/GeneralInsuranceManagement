<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="GeneralInsuranceManagement.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="row row-sm mg-t-20">
          <div class="col-xl-6">
            <div class="card pd-20 pd-sm-40 form-layout form-layout-4">
              <h6 class="card-body-title">Create a new account</h6>
              <p class="text-danger">
                <asp:Literal runat="server" ID="ErrorMessage" />
              </p>
                 <asp:ValidationSummary runat="server" CssClass="text-danger" />
              <div class="row">
                <asp:Label runat="server" AssociatedControlID="FirstName" class="col-sm-4 form-control-label">Firstname: <span class="tx-danger">*</span></asp:Label>
                <div class="col-sm-8 mg-t-10 mg-sm-t-0">
                    <asp:TextBox runat="server" ID="FirstName" CssClass="form-control" placeholder="Enter firstname" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstName"
                    CssClass="text-danger" ErrorMessage="The First Name field is required." />
                </div>
              </div><!-- row -->
              <div class="row mg-t-20">
                <asp:Label runat="server" AssociatedControlID="Lastname" class="col-sm-4 form-control-label">Lastname: <span class="tx-danger">*</span></asp:Label>
                <div class="col-sm-8 mg-t-10 mg-sm-t-0">
                    <asp:TextBox runat="server" ID="Lastname" CssClass="form-control" TextMode="Email" placeholder="Enter lastname"/>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Lastname"
                    CssClass="text-danger" ErrorMessage="The Lastname field is required." />
                </div>
              </div>
              <div class="row mg-t-20">
                <asp:Label runat="server" AssociatedControlID="Email" class="col-sm-4 form-control-label">Email: <span class="tx-danger">*</span></asp:Label>
                <div class="col-sm-8 mg-t-10 mg-sm-t-0">
                    <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" placeholder="Enter your email"/>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="The email field is required." />
                </div>
              </div>
              <div class="row mg-t-20">
                <asp:Label runat="server" AssociatedControlID="Password" class="col-sm-4 form-control-label">Password: <span class="tx-danger">*</span></asp:Label>
                <div class="col-sm-8 mg-t-10 mg-sm-t-0">
                    <asp:TextBox runat="server" ID="Password" CssClass="form-control" TextMode="Password" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="The Password field is required." />
                </div>
              </div>
              <div class="row mg-t-20">
                    <asp:Label runat="server" AssociatedControlID="ConfirmPassword" class="col-sm-4 form-control-label">ConfirmPassword: <span class="tx-danger">*</span></asp:Label>
                <div class="col-sm-8 mg-t-10 mg-sm-t-0">
                    <asp:TextBox runat="server" ID="ConfirmPassword" CssClass="form-control" TextMode="Password" placeholdder="Confirm password"/>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                    <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                </div>
              </div>
              <div class="form-layout-footer mg-t-30">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-info mg-r-5" />
                <button class="btn btn-secondary">Cancel</button>
              </div><!-- form-layout-footer -->
            </div><!-- card -->
          </div><!-- col-6 -->
          </div><!-- col-6 -->

</asp:Content>
