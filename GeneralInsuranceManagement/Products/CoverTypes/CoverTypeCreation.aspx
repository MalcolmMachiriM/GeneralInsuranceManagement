<%@ Page Title="Cover Packages" Language="C#" MasterPageFile="~/DefaultUIS.Master" AutoEventWireup="true" CodeBehind="CoverTypeCreation.aspx.cs" Inherits="GeneralInsuranceManagement.Products.CoverTypes.CoverTypeCreation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--breadcrumb-->
    <div class="page-breadcrumb d-none d-sm-flex align-items-center mb-3">
        <div class="breadcrumb-title pe-3">Cover Types </div>
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

    <asp:HiddenField ID="CoverTypeId" runat="server" />

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
                            <asp:Label runat="server" AssociatedControlID="drpProduct" class="form-label">Product</asp:Label>
                            <asp:DropDownList ID="drpProduct" runat="server" CssClass="form-select">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="drpProduct"
                                CssClass="text-danger" ErrorMessage="The Product field is required." />
                        </div>
                        <!-- row -->
                        <div class="col-md-6">
                            <asp:Label runat="server" AssociatedControlID="Package" class="form-label">Package</asp:Label>
                            <asp:TextBox runat="server" ID="Package" CssClass="form-control" placeholder="Enter Package here" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Package"
                                CssClass="text-danger" ErrorMessage="The Package field is required." />
                        </div>
                        <!-- row -->
                        <div class="col-md-6">
                            <asp:Label runat="server" AssociatedControlID="ProcessTime" class="form-label">Process Time </asp:Label>
                            <asp:TextBox runat="server" ID="ProcessTime" CssClass="form-control" placeholder="Enter Process Time " />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ProcessTime"
                                CssClass="text-danger" ErrorMessage="The Process Time field is required." />
                        </div>
                        <!-- row -->
                        <div class="col-md-6">
                            <asp:Label runat="server" AssociatedControlID="Retention" class="form-label">Retention </asp:Label>
                            <asp:TextBox runat="server" ID="Retention" CssClass="form-control" placeholder="Enter Retention " />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Retention"
                                CssClass="text-danger" ErrorMessage="The Retention field is required." />
                        </div>
                        <!-- row -->
                        <div class="col-md-6">
                            <asp:Label runat="server" AssociatedControlID="drpSumAssureBasis" class="form-label">Sum Assured Basis</asp:Label>
                            <asp:DropDownList ID="drpSumAssureBasis" runat="server" CssClass="form-select"></asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="drpSumAssureBasis"
                                CssClass="text-danger" ErrorMessage="The Sum Assured Basis field is required." />
                        </div>
                        <!-- row -->
                        <div class="col-md-6">
                            <asp:Label runat="server" AssociatedControlID="EffectiveDate" class="form-label">Effective Date</asp:Label>
                            <asp:TextBox runat="server" ID="EffectiveDate" CssClass="form-control" TextMode="Date" placeholder="Enter Effective Date" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="EffectiveDate"
                                CssClass="text-danger" ErrorMessage="The Effective Date field is required." />
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
                                    <asp:Button runat="server" ID="btnCreate" OnClick="btnCreate_Click" Text="Create" CssClass="btn btn-primary px-4 " />&nbsp
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
