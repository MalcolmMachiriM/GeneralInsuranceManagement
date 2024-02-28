<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultUIS.Master" AutoEventWireup="true" CodeBehind="IdentificationTypesCreate.aspx.cs" Inherits="GeneralInsuranceManagement.GlobalParameters.IdentificationTypes.IdentificationTypesCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--breadcrumb-->
    <div class="page-breadcrumb d-none d-sm-flex align-items-center mb-3">
        <div class="breadcrumb-title pe-3">Identification Types Management</div>
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

    <asp:HiddenField ID="IdentificationTypesId" runat="server" />

    <div class="row">
        <div class="col-xl-8 mx-auto">
            <div class="card ">
                <div class="card-body p-4">
                    <h5 class="mb-4">
                        <span><i class='bx bx-id-card' style="font-size: x-large"></i></span>
                        Identification Types
                    </h5>
                    <p class="text-danger">
                        <asp:Literal runat="server" ID="ErrorMessage" />
                    </p>
                    <asp:ValidationSummary runat="server" CssClass="text-danger" />

                    <div class="row">
                        <asp:Label runat="server" AssociatedControlID="IdentificationType" class="col-sm-3 col-form-label">Identification Type </asp:Label>
                        <div class="col-sm-6">
                            <div class="input-group">
                                <span class="input-group-text"><i class="bx bx-id-card" style="color: blue"></i></span>
                                <asp:TextBox runat="server" ID="IdentificationType" CssClass="form-control" placeholder="Enter Identification Type" />
                            </div>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="IdentificationType"
                                CssClass="text-danger" ErrorMessage="The Identification Type field is required." />
                        </div>
                    </div>
                    <!-- row -->
                    <div class="row">
                        <asp:Label runat="server" class="col-sm-3 col-form-label">Format </asp:Label>
                        <div class="col-sm-6">
                            <div class="input-group">
                                <span class="input-group-text"><i class='bx bx-rename' style="color: blue"></i></span>
                                <asp:TextBox runat="server" ID="IdentificationTypesFormat" CssClass="form-control" placeholder="Enter Identification Type Format" />
                            </div>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="IdentificationTypesFormat"
                                CssClass="text-danger" ErrorMessage="The Format field is required." />
                        </div>
                    </div>

                    <div class="row">
                        <asp:Label runat="server" class="col-sm-3 col-form-label">Minimum Length Required</asp:Label>
                        <div class="col-sm-6">
                            <div class="input-group">
                                <span class="input-group-text"><i class='bx bx-list-minus' style="color: blue"></i></span>
                                <asp:TextBox runat="server" ID="MinimumLength" CssClass="form-control" placeholder="Enter Min Length Required" />
                            </div>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="MinimumLength"
                                CssClass="text-danger" ErrorMessage="The Minimum Length field is required." />
                        </div>
                    </div>

                    <div class="row">
                        <asp:Label runat="server" class="col-sm-3 col-form-label">Maximum Length Required </asp:Label>
                        <div class="col-sm-6">
                            <div class="input-group">
                                <span class="input-group-text"><i class="bx bx-list-plus" style="color: blue"></i></span>
                                <asp:TextBox runat="server" ID="MaximumLength" CssClass="form-control" placeholder="Enter Max Length Required" />
                            </div>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="MaximumLength"
                                CssClass="text-danger" ErrorMessage="The Maximum Length field is required." />
                        </div>
                    </div>
                    <asp:Panel ID="pnlSave" runat="server">
                        <div class="row">
                            <label class="col-sm-3 col-form-label"></label>
                            <div class="col-sm-9">
                                <asp:Button runat="server" ID="btnCreate" OnClick="btnCreate_Click" CssClass="btn btn-primary px-4 " />
                            </div>
                        </div>
                    </asp:Panel>
                    <!-- row -->
                </div>
                <!-- form-layout-footer -->

            </div>
            <!-- card -->
        </div>
    </div>
    </div>
</asp:Content>
