<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Home.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="UserPages_Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
       <link href="../CSS/custom.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <div class=" container-fluid">

            <div class="col-md-12">
                <div class="row">
                    <asp:Repeater ID="Repeater_Product" runat="server">

                        <ItemTemplate>

                            <div class="col-md-4">
                            <div class="col-item">
                                <div class="photo">
                                    <img src='<%# Eval("ImageURL") %>' runat="server" class="img-responsive" alt="a" />
                                </div>
                                <div class="info">
                                    <div class="row">
                                        <div class="price col-md-8">
                                            <h5>
                                                <%# Eval("Item_Description") %>
                                            <h5 class="price-text-color">
                                             
                                        </div>
                                        <div class="rating hidden-sm col-md-4">
                                           <%# Eval("categoryhtml") %>
                                        </div>
                                        <div class="rating hidden-sm col-md-4">
                                           <%# Eval("Price") %> LE 
                                            
                        
                                        </div>
                                         <div class="rating hidden-sm col-md-4">
                                           <%# Eval("ColorName") %>
                                            
                        
                                        </div>
                                    </div>
                                   
                                    <div class="clearfix">
                                    </div>
                                </div>
                            </div>
                        </div>
                        </ItemTemplate>
                    </asp:Repeater>
     </div>
                

            </div>

        </div>
</asp:Content>

