<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultUIS.Master" AutoEventWireup="true" CodeBehind="BanksCreate.aspx.cs" Inherits="GeneralInsuranceManagement.GlobalParameters.Banks.BanksCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--breadcrumb-->
    <div class="page-breadcrumb d-none d-sm-flex align-items-center mb-3">
        <div class="breadcrumb-title pe-3">Banks Management</div>
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

    <asp:HiddenField ID="BankId" runat="server" />

    <div class="row">
        <div class="col-xl-8 mx-auto">
            <div class="card ">
                <div class="card-body p-4">
                    <h5 class="mb-4">
                        <span><i class='bx bx-buildings' style="font-size: x-large"></i></span>
                        Banks
                    </h5>
                    <p class="text-danger">
                        <asp:Literal runat="server" ID="ErrorMessage" />
                    </p>
                    <asp:ValidationSummary runat="server" CssClass="text-danger" />

                    <div class="row">
                        <asp:Label runat="server" AssociatedControlID="BankCode" class="col-sm-3 col-form-label">Code </asp:Label>
                        <div class="col-sm-6">
                            <div class="input-group">
                                <span class="input-group-text"><i class="bx bx-barcode" style="color: blue"></i></span>
                                <asp:TextBox runat="server" ID="BankCode" CssClass="form-control" placeholder="Enter Bank Code" />
                            </div>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="BankCode"
                                CssClass="text-danger" ErrorMessage="The Bank Code field is required." />
                        </div>
                    </div>
                    <div class="row">
                        <asp:Label runat="server" AssociatedControlID="BankName" class="col-sm-3 col-form-label">Bank Name </asp:Label>
                        <div class="col-sm-6">
                            <div class="input-group">
                                <span class="input-group-text"><i class="bx bx-buildings" style="color: blue"></i></span>
                                <asp:TextBox runat="server" ID="BankName" CssClass="form-control" placeholder="Enter Bank Name" />
                            </div>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="BankName"
                                CssClass="text-danger" ErrorMessage="The Bank Name field is required." />
                        </div>
                    </div>
                    <div class="row">
                        <asp:Label runat="server" AssociatedControlID="BranchNumbers" class="col-sm-3 col-form-label">Number of Branches </asp:Label>
                        <div class="col-sm-6">
                            <div class="input-group">
                                <span class="input-group-text"><i class="bx bx-credit-card" style="color: blue"></i></span>
                                <asp:TextBox runat="server" ID="BranchNumbers" CssClass="form-control" placeholder="Enter Number of Branches" />
                            </div>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="BranchNumbers"
                                CssClass="text-danger" ErrorMessage="The Number of Branches field is required." />
                        </div>
                    </div>
                    <div class="row">
                        <asp:Label runat="server" AssociatedControlID="NumberLength" class="col-sm-3 col-form-label">Account Number Length </asp:Label>
                        <div class="col-sm-6">
                            <div class="input-group">
                                <span class="input-group-text"><i class="bx bx-rename" style="color: blue"></i></span>
                                <asp:TextBox runat="server" ID="NumberLength" CssClass="form-control" placeholder="Enter Account Number Length" />
                            </div>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="NumberLength"
                                CssClass="text-danger" ErrorMessage="The Account Number Length field is required." />
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
                <!-- card -->
            </div>
        </div>
    </div>
</asp:Content>
