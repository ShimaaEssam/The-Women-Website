<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.master" AutoEventWireup="true" CodeFile="Update.aspx.cs" Inherits="AdminPages_Update" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../CSS/adminStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="row">

        <div class="jumbotron">
            <h1>Woman Fashion</h1>
            <p> Admin </p>
            <h2>Item Edit</h2>
        
        </div>


        <div class="col-sm-12">

            <asp:Panel ID="Panel_StatusSuccess" runat="server" CssClass="alert alert-success fade in" Visible="false">
                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                <strong>
                    <asp:Label ID="lblStatusSuccess" runat="server" Text=""></asp:Label></strong>
            </asp:Panel>

            <asp:Panel ID="Panel_StatusError" runat="server" CssClass="alert alert-danger fade in" Visible="false">
                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                <strong>
                    <asp:Label ID="lblStatusError" runat="server" Text=""></asp:Label></strong>
            </asp:Panel>

        </div>

        <%--===========================================================--%>

        <div class="col-sm-12">
            <asp:GridView ID="GridView_FashionItems" DataKeyNames="Fashion_item_Id" SelectedRowStyle-CssClass="table-Selected"
                EmptyDataText="No Data Found !" CssClass="table table-bordered table-hover" AutoGenerateColumns="false"
                runat="server" OnSelectedIndexChanged="GridView_FashionItems_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField HeaderText="Fashion Type Name" DataField="Fashion_Type_Name" />
                    <asp:BoundField HeaderText="Brand Name" DataField="BrandName" />
                    <asp:BoundField HeaderText="Price" DataField="Price" />
                    <asp:CommandField SelectText="Select To Edit" ShowSelectButton="true"  />
                </Columns>
            </asp:GridView>

        </div>

        <%--===========================================================--%>
        <asp:Panel runat="server" ID="Panel_FashionitemData" Visible="false">

            <div class="col-sm-12">
                <div class="col-sm-2 control-label">
                    Fashion Types :
                </div>
                <div class="col-sm-4">
                    <asp:DropDownList ID="ddl_FashionType" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddl_FashionType_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="col-sm-1">
                    <asp:CompareValidator ErrorMessage="*" ControlToValidate="ddl_FashionType" runat="server" Operator="NotEqual" ValueToCompare="0" ForeColor="Red" ValidationGroup="CheckValidate" />
                </div>

            </div>

            <div class="col-sm-12">
                <br />
            </div>

            <%--===========================================================--%>

            <div class="col-sm-12">
                <div class="col-sm-2 control-label">
                    Brands :
                </div>
                <div class="col-sm-4">
                    <asp:DropDownList ID="ddl_Brand" runat="server" CssClass="form-control"></asp:DropDownList>

                </div>

                <div class="col-sm-1">
                    <asp:CompareValidator ErrorMessage="*" ControlToValidate="ddl_Brand" runat="server" Operator="NotEqual" ValueToCompare="0" ForeColor="Red" ValidationGroup="CheckValidate" />
                </div>
            </div>

            <div class="col-sm-12">
                <br />
            </div>

            <%--===========================================================--%>

            <div class="col-sm-12">
                <div class="col-sm-2 control-label">
                    Color :
                </div>
                <div class="col-sm-4">
                    <asp:DropDownList ID="ddl_Color" runat="server" CssClass="form-control"></asp:DropDownList>

                </div>
                <div class="col-sm-1">
                    <asp:CompareValidator ErrorMessage="*" ControlToValidate="ddl_Color" runat="server" Operator="NotEqual" ValueToCompare="0" ForeColor="Red" ValidationGroup="CheckValidate" />
                </div>

            </div>

            <div class="col-sm-12">
                <br />
            </div>

            <%--===========================================================--%>

            <div class="col-sm-12">
                <div class="col-sm-2 control-label">
                    Rate :
                </div>
                <div class="col-sm-4">
                    <asp:DropDownList ID="ddl_Rating" runat="server" CssClass="form-control"></asp:DropDownList>

                </div>
                <div class="col-sm-1">
                    <asp:CompareValidator ErrorMessage="*" ControlToValidate="ddl_Rating" runat="server" Operator="NotEqual" ValueToCompare="0" ForeColor="Red" ValidationGroup="CheckValidate" />
                </div>

            </div>

            <div class="col-sm-12">
                <br />
            </div>

            <%--===========================================================--%>


            <div class="col-sm-12">
                <div class="col-sm-2 control-label">
                    Price :
                </div>
                <div class="col-sm-4">
                    <asp:TextBox runat="server" ID="txtbox_Price" CssClass="form-control" />
                </div>
                <div class="col-sm-1">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbox_Price" ErrorMessage="*" ForeColor="Red" ValidationGroup="CheckValidate"></asp:RequiredFieldValidator>
                </div>
                <div class="col-sm-2">
                    <asp:CompareValidator ErrorMessage="Numbers Only" ControlToValidate="txtbox_Price" runat="server" ForeColor="Red" Operator="DataTypeCheck" Type="Double" ValidationGroup="CheckValidate" />
                </div>

            </div>

            <div class="col-sm-12">
                <br />
            </div>

            <%--===========================================================--%>

            <div class="col-sm-12">
                <div class="col-sm-2 control-label">
                    Description :
                </div>
                <div class="col-sm-8">
                    <asp:TextBox runat="server" ID="txtbox_Description" TextMode="MultiLine" CssClass="form-control" />

                </div>
                <div class="col-sm-1">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtbox_Description" ErrorMessage="*" ForeColor="Red" ValidationGroup="CheckValidate"></asp:RequiredFieldValidator>

                </div>
            </div>

            <div class="col-sm-12">
                <br />
            </div>

            <%--===========================================================--%>

            <div class="col-sm-12">
                <div class="col-sm-2 control-label">
                    Image :
                </div>
                <div class="col-sm-4">
                    <asp:FileUpload ID="FileUpload_images" runat="server" CssClass="form-control" />
                </div>

                <div class="col-sm-4">
                    <asp:Image ID="ImgShow" CssClass="ImageUpdate" Visible="false" runat="server" />
                </div>

            </div>

            <div class="col-sm-12">
                <br />
            </div>

            <%--===========================================================--%>

            <div class="col-sm-12">
                <div class="col-sm-4">
                    <asp:Button ID="btn_Edit" runat="server" ValidationGroup="CheckValidate"
                        CssClass="btn btn-info btn-default" Text="Edit" OnClick="btn_Edit_Click" />
                </div>

                <div class="col-sm-2">
                </div>
                <div class="col-sm-4">
                    <asp:Button ID="btn_Delete" runat="server" CausesValidation="false"
                        CssClass="btn btn-info btn-danger" Text="Delete" OnClick="btn_Delete_Click" />
                </div>
            </div>

            <%--===========================================================--%>

        </asp:Panel>

    </div>


</asp:Content>

