<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Home.master" AutoEventWireup="true" CodeFile="ShoppingCart.aspx.cs" Inherits="UserPages_ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link href="../CSS/custom.css" rel="stylesheet" />


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="row dirLTR">

        <div class="jumbotron">
            <h1>Woman Fashion</h1>
            <p>Your Cart</p>
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

       
        <div class="col-sm-12">
             <div class="col-sm-10">


            <asp:GridView ID="GridView_CartFashionItems" DataKeyNames="Fashion_item_Id" SelectedRowStyle-CssClass="table-Selected"
                EmptyDataText="No Fashion Item Added To Shopping Cart !" CssClass="table table-bordered table-hover" AutoGenerateColumns="false"
                runat="server" OnSelectedIndexChanged="GridView_CartFashionItems_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField HeaderText="Description" DataField="Item_Description" />
                    <asp:BoundField HeaderText="Fashion Type Name" DataField="Fashion_Type_Name" />
                    <asp:BoundField HeaderText="Brand Name" DataField="BrandName" />
                    <asp:BoundField HeaderText="Price" DataField="Price" />
                    <asp:CommandField SelectText="Remove From Cart" ShowSelectButton="true" />
                </Columns>
            </asp:GridView>

        </div>

        </div>


    </div>

</asp:Content>

