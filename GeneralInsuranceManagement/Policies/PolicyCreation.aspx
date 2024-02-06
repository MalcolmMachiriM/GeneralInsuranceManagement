<%@ Page Title="Policy Creation" Language="C#" MasterPageFile="~/DefaultUIS.Master" AutoEventWireup="true" CodeBehind="PolicyCreation.aspx.cs" Inherits="GeneralInsuranceManagement.Policies.PolicyCreation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!--breadcrumb-->
 <div class="page-breadcrumb d-none d-sm-flex align-items-center mb-3">
     <div class="breadcrumb-title pe-3">Policies </div>
     <div class="ps-3">
         <nav aria-label="breadcrumb">
             <ol class="breadcrumb mb-0 p-0">
                 <li class="breadcrumb-item"><a href="~/Default"><i class="bx bx-home-alt"></i></a>
                 </li>
                 <li class="breadcrumb-item active" aria-current="page">Creation</li>
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

 <asp:HiddenField ID="PolicyId" runat="server" />

 <div class="row">
     <div class="col-xl-10 mx-auto">
         <div class="card ">
             <div class="card-body p-4">
                 <h5 runat="server" class="mb-4">
                     <asp:Literal runat="server" ID="pagetitle" />

                 </h5>
                 <p class="text-danger">
                     <asp:Literal runat="server" ID="ErrorMessage" />
                 </p>
                 <asp:ValidationSummary runat="server" CssClass="text-danger" />

                 <div class="row g-3">
                     <div class="col-md-6">
                         <asp:Label runat="server" AssociatedControlID="ApplicationDate" class="form-label">Application Date</asp:Label>
                         <asp:TextBox runat="server" ID="ApplicationDate" CssClass="form-control" placeholder="Enter Application Date here" />
                         <asp:RequiredFieldValidator runat="server" ControlToValidate="ApplicationDate"
                             CssClass="text-danger" ErrorMessage="The Application Date field is required." />
                     </div>
                     <!-- row -->
                     <div class="col-md-6">
                         <asp:Label runat="server" AssociatedControlID="ProductId" class="form-label">Product</asp:Label>
                         <asp:DropDownList ID="ProductId" runat="server" CssClass="form-select">
                         </asp:DropDownList>
                         <asp:RequiredFieldValidator runat="server" ControlToValidate="ProductId"
                             CssClass="text-danger" ErrorMessage="The Product field is required." />
                     </div>
                     <!-- row -->
                     <div class="col-md-6">
                         <asp:Label runat="server" AssociatedControlID="CoverTypeId" class="form-label">Cover Type</asp:Label>
                         <asp:DropDownList ID="CoverTypeId" runat="server" CssClass="form-select">
                         </asp:DropDownList>
                         <asp:RequiredFieldValidator runat="server" ControlToValidate="CoverTypeId"
                             CssClass="text-danger" ErrorMessage="The Cover Type field is required." />
                     </div>
                     <!-- row -->
                     <div class="col-md-6">
                         <asp:Label runat="server" AssociatedControlID="ClientId" class="form-label">Client</asp:Label>
                         <asp:DropDownList ID="ClientId" runat="server" CssClass="form-select">
                         </asp:DropDownList>
                         <asp:RequiredFieldValidator runat="server" ControlToValidate="ClientId"
                             CssClass="text-danger" ErrorMessage="The Client field is required." />
                     </div>
                     <!-- row -->
                     <div class="col-md-6">
                         <asp:Label runat="server" AssociatedControlID="SumAssured" class="form-label">Sum Assured</asp:Label>
                         <asp:TextBox runat="server" ID="SumAssured" CssClass="form-control" placeholder="Enter Sum Assured " />
                         <asp:RequiredFieldValidator runat="server" ControlToValidate="SumAssured"
                             CssClass="text-danger" ErrorMessage="The Sum Assured field is required." />
                     </div>
                     <!-- row -->
                     <div class="col-md-6">
                         <asp:Label runat="server" AssociatedControlID="Premium" class="form-label">Premium </asp:Label>
                         <asp:TextBox runat="server" ID="Premium" CssClass="form-control" placeholder="Enter Premium " />
                         <asp:RequiredFieldValidator runat="server" ControlToValidate="Premium"
                             CssClass="text-danger" ErrorMessage="The Premium is required." />
                     </div>
                     <!-- row -->
                     <div class="col-md-6">
                         <asp:Label runat="server" AssociatedControlID="PremiumPaymentMethod" class="form-label">Premium Payment Method</asp:Label>
                         <asp:DropDownList ID="PremiumPaymentMethod" runat="server" CssClass="form-select"></asp:DropDownList>
                         <asp:RequiredFieldValidator runat="server" ControlToValidate="PremiumPaymentMethod"
                             CssClass="text-danger" ErrorMessage="The Premium Payment Method field is required." />
                     </div>
                     <!-- row -->
                     <div class="col-md-6">
                         <asp:Label runat="server" AssociatedControlID="PremiumPaymentFrequency" class="form-label">Premium Payment Frequency</asp:Label>
                         <asp:DropDownList ID="PremiumPaymentFrequency" runat="server" CssClass="form-select"></asp:DropDownList>
                         <asp:RequiredFieldValidator runat="server" ControlToValidate="PremiumPaymentFrequency"
                             CssClass="text-danger" ErrorMessage="The Premium Payment Frequency field is required." />
                     </div>
                     <!-- row -->
                     <div class="col-md-6">
                         <asp:Label runat="server" AssociatedControlID="BenefitTerm" class="form-label">Benefit Term(In Months)</asp:Label>
                         <asp:TextBox runat="server" ID="BenefitTerm" CssClass="form-control" TextMode="Date" placeholder="Enter Benefit Term" />
                         <asp:RequiredFieldValidator runat="server" ControlToValidate="BenefitTerm"
                             CssClass="text-danger" ErrorMessage="The Benefit zTerm field is required." />
                     </div>
                     <!-- row -->
                     <div class="col-md-6">
                         <asp:Label runat="server" AssociatedControlID="MaxPremiumTerm" class="form-label">Max Premium Term</asp:Label>
                         <asp:TextBox runat="server" ID="MaxPremiumTerm" CssClass="form-control" placeholder="Enter Max Premium Term " />
                         <asp:RequiredFieldValidator runat="server" ControlToValidate="MaxPremiumTerm"
                             CssClass="text-danger" ErrorMessage="The Max Premium Term field is required." />
                     </div>
                     <!-- row -->
                     <div class="col-md-6">
                         <asp:Label runat="server" AssociatedControlID="MinimumSumAssured" class="form-label">Minimum Sum Assured</asp:Label>
                         <asp:TextBox runat="server" ID="MinimumSumAssured" CssClass="form-control" placeholder="Enter Minimum Sum Assured " />
                         <asp:RequiredFieldValidator runat="server" ControlToValidate="MinimumSumAssured"
                             CssClass="text-danger" ErrorMessage="The Minimum Sum Assured field is required." />
                     </div>
                     <!-- row -->
                     <div class="col-md-6">
                         <asp:Label runat="server" AssociatedControlID="MaximumSumAssured" class="form-label">Maximum Sum Assured</asp:Label>
                         <asp:TextBox runat="server" ID="MaximumSumAssured" CssClass="form-control" placeholder="Enter Maximum Sum Assured " />
                         <asp:RequiredFieldValidator runat="server" ControlToValidate="MaximumSumAssured"
                             CssClass="text-danger" ErrorMessage="The Minimum Sum Assured field is required." />
                     </div>
                     <!-- row -->
                     <div class="col-md-6">
                         <asp:Label runat="server" AssociatedControlID="Description" class="form-label">Description</asp:Label>
                         <asp:TextBox runat="server" ID="Description" CssClass="form-control"  placeholder="Enter Description " />
                         <asp:RequiredFieldValidator runat="server" ControlToValidate="Description"
                             CssClass="text-danger" ErrorMessage="The Description field is required." />
                     </div>
                     <!-- row -->
                     <div class="col-md-6">
                         <div class="row">
                             <asp:Label runat="server" AssociatedControlID="CanItBeCeded" class="col-sm-4 col-form-label">Can It Be Ceded? </asp:Label>
                             <div class="col-sm-8">
                                 <div class="form-check mt-2">
                                     <asp:CheckBox ID="CanItBeCeded" CssClass="form-check" runat="server" />
                                 </div>
                             </div>
                         </div>

                     </div>
                     <!-- row -->
                     <asp:Panel ID="pnlSave" runat="server">
                         <div class="row">
                             <label class="col-sm-3 col-form-label"></label>
                             <div class="col-sm-9">
                                 <asp:Button runat="server" ID="btnCreate" Text="Create" CssClass="btn btn-primary px-4 " />&nbsp
                                 <asp:Button runat="server" ID="btnReset" Text="Reset" CssClass="btn btn-light px-4 " />
                             </div>
                         </div>
                     </asp:Panel>
                     <!-- row -->
                     <%--<asp:Panel ID="pnlApprove" runat="server">
                         <div class="row">
                             <label class="col-sm-3 col-form-label"></label>
                             <div class="col-sm-9">
                                 <asp:Button runat="server" ID="btnApprove" Text="Approve" CssClass="btn btn-success px-4 " />
                                 <asp:Button runat="server" ID="btnReject" Text="Reject" CssClass="btn btn-danger px-4 " />
                             </div>
                         </div>
                     </asp:Panel>--%>
                 </div>
                 <!-- form-layout-footer -->

             </div>
             <!-- card -->
         </div>
     </div>
 </div>
</asp:Content>
