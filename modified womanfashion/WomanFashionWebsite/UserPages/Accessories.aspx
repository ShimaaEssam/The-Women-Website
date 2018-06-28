<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Home.master" AutoEventWireup="true" CodeFile="Accessories.aspx.cs" Inherits="UserPages_Accessories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link href="../CSS/custom.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class=" container-fluid">

            <div class="col-md-12">
                <div class="row ">
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
                                            <h4>
                                                <%# Eval("Item_Description") %>
                                           </h4>
                                             
                                        </div>
                                        <div class="rating hidden-sm col-md-4">
                                           <%# Eval("categoryhtml") %>
                                        </div>
                                        <div class="rating hidden-sm col-md-4">
                                           <%# Eval("Price") %> LE 
                                            
                        
                                        </div>
                                    </div>
                                      <div class="separator clear-left">
                                        <p class="btn-add">
                                                   
                                          <%--  <i class="fa fa-shopping-cart"></i><a href="http://www.jquery2dotnet.com" class="hidden-sm">Add to cart</a></p>--%>
                                  <%--=======================================================--%>
                                            <asp:Label ID="lbl_Fashion_item_Id" Text='<%# Eval("Fashion_item_Id")%>' runat="server" Visible="false" />
                                            
                                           <asp:LinkButton ID="lnkbtn_AddToCart" runat="server" CssClass="fa fa-shopping-cart" Text=" Add To Cart" OnClick="lnkbtn_AddToCart_Click"></asp:LinkButton>
                                        <%--==========================================================--%>
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

