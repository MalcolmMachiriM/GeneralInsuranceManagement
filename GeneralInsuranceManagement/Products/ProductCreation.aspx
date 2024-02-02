<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultUIS.Master" AutoEventWireup="true" CodeBehind="ProductCreation.aspx.cs" Inherits="GeneralInsuranceManagement.Products.ProductCreation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--breadcrumb-->
    <div class="page-breadcrumb d-none d-sm-flex align-items-center mb-3">
        <div class="breadcrumb-title pe-3">Scheme Management</div>
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

    <asp:HiddenField ID="SchemeId" runat="server" />

    <div class="row">
        <div class="col-xl-8 mx-auto">
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
                            <asp:Label runat="server" AssociatedControlID="RegNo" class="form-label">Reg Number</asp:Label>
                            <asp:TextBox runat="server" ID="RegNo" CssClass="form-control" placeholder="Enter Reg Number" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="RegNo"
                                CssClass="text-danger" ErrorMessage="The Reg Number field is required." />
                        </div>
                        <!-- row -->
                        <div class="col-md-6">
                            <asp:Label runat="server" AssociatedControlID="TaxNo" class="form-label">Tax Number</asp:Label>
                            <asp:TextBox runat="server" ID="TaxNo" CssClass="form-control" placeholder="Enter Tax Number" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="TaxNo"
                                CssClass="text-danger" ErrorMessage="The Tax Number field is required." />
                        </div>
                        <!-- row -->
                        <div class="col-md-6">
                            <asp:Label runat="server" AssociatedControlID="ReassuranceNo" class="form-label">Reassurance Number</asp:Label>
                            <asp:TextBox runat="server" ID="ReassuranceNo" CssClass="form-control" placeholder="Enter Reassurance Number" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ReassuranceNo"
                                CssClass="text-danger" ErrorMessage="The Reassurance Number field is required." />
                        </div>
                        <!-- row -->
                        <div class="col-md-6">
                            <asp:Label runat="server" AssociatedControlID="CommencementDate" class="form-label">Commencement Date</asp:Label>
                            <asp:TextBox runat="server" ID="CommencementDate" CssClass="form-control" TextMode="Date" placeholder="Enter Commencement Date" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="CommencementDate"
                                CssClass="text-danger" ErrorMessage="The Commencement Date field is required." />
                        </div>
                        <!-- row -->
                        <div class="col-md-6">
                            <asp:Label runat="server" AssociatedControlID="ConversionDate" class="form-label">Conversion Date</asp:Label>
                            <asp:TextBox runat="server" ID="ConversionDate" CssClass="form-control" TextMode="Date" placeholder="Enter Conversion Date" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ConversionDate"
                                CssClass="text-danger" ErrorMessage="The Reg Name field is required." />
                        </div>
                        <!-- row -->
                        <div class="col-md-6">
                            <asp:Label runat="server" AssociatedControlID="RulesAmmendment" class="form-label">Rules Ammendment</asp:Label>
                            <asp:TextBox runat="server" ID="RulesAmmendment" CssClass="form-control" placeholder="Enter Rules Ammendment" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="RulesAmmendment"
                                CssClass="text-danger" ErrorMessage="The Rules Ammendment field is required." />
                        </div>
                        <!-- row -->
                        <div class="col-md-6">
                            <asp:Label runat="server" AssociatedControlID="RetentionLimit" class="form-label">Retention Limit</asp:Label>
                            <asp:TextBox runat="server" ID="RetentionLimit" CssClass="form-control" placeholder="Enter Retention Limit" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="RetentionLimit"
                                CssClass="text-danger" ErrorMessage="The Retention Limit field is required." />
                        </div>
                        <!-- row -->
                        <div class="col-md-6">
                            <asp:Label runat="server" AssociatedControlID="InstitutionalClientId" class="form-label">Institutional Client's Name </asp:Label>
                            <asp:DropDownList ID="InstitutionalClientId" runat="server" CssClass="form-select">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="InstitutionalClientId"
                                CssClass="text-danger" ErrorMessage="The Institutional Client's Name field is required." />
                        </div>
                        <!-- row -->
                        <asp:Panel ID="pnlSave" runat="server">
                            <div class="row">
                                <label class="col-sm-3 col-form-label"></label>
                                <div class="col-sm-9">
                                    <asp:Button runat="server" ID="btnRegister" Text="Register" CssClass="btn btn-primary px-4 " />
                                    <asp:Button runat="server" ID="btnReset" Text="Reset" CssClass="btn btn-light px-4 " />
                                </div>
                            </div>
                        </asp:Panel>
                        <!-- row -->
                        <asp:Panel ID="pnlApprove" runat="server">
                            <div class="row">
                                <label class="col-sm-3 col-form-label"></label>
                                <div class="col-sm-9">
                                    <asp:Button runat="server" ID="btnApprove" Text="Approve" CssClass="btn btn-success px-4 " />
                                    <asp:Button runat="server" ID="btnReject" Text="Reject" CssClass="btn btn-danger px-4 " />
                                </div>
                            </div>
                        </asp:Panel>

                    </div>
                    <!-- form-layout-footer -->

                </div>
                <!-- card -->
            </div>
        </div>
    </div>

</asp:Content>
