﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Home.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="UserPages_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

<%--    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>--%>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div class="PageContent">
        <div class="row">
            <div class="container-fluid">
                <div id="myCarousel" class="carousel slide" data-ride="carousel">
                    <!-- Indicators -->
                    <ol class="carousel-indicators">
                        <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                        <li data-target="#myCarousel" data-slide-to="1"></li>
                        <li data-target="#myCarousel" data-slide-to="2"></li>
                    </ol>

                    <!-- Wrapper for slides -->
                    <div class="carousel-inner">
                        <div class="item active">
                            <img src="../WebImages/5.jpg" alt="Fashion" style="width: 100%;" />
                        </div>

                        <div class="item">
                            <img src="../WebImages/1.jpg" alt="Fashion" style="width: 100%;" />
                        </div>
                         <div class="item">
                            <img src="../WebImages/7.jpg" alt="Fashion" style="width: 100%;" />
                        </div>
                       
                          <div class="item">
                            <img src="../WebImages/4.jpg" alt="Fashion" style="width: 100%;" />
                        </div>
                        <div class="item">
                            <img src="../WebImages/2.jpg" alt="Fashion" style="width: 100%;" />
                        </div>
                        <div class="item">
                            <img src="../WebImages/11.jpg" alt="Fashion" style="width: 100%;" />
                        </div>
                        <div class="item">
                            <img src="../WebImages/12.jpg" alt="Fashion" style="width: 100%;" />
                        </div>
                    </div>

                    <!-- Left and right controls -->
                    <a class="left carousel-control" href="#myCarousel" data-slide="prev">
                        <span class="glyphicon glyphicon-chevron-left"></span>
                        <span class="sr-only">Previous</span>
                    </a>
                    <a class="right carousel-control" href="#myCarousel" data-slide="next">
                        <span class="glyphicon glyphicon-chevron-right"></span>
                        <span class="sr-only">Next</span>
                    </a>
                </div>
            </div>

        </div>
            
        </div>

    

</asp:Content>

