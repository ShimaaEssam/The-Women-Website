<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="AdminPages_Login" %>

<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

<link href="../CSS/loginStyle.css" rel="stylesheet" />

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">


    <title>Login-Admin</title>
</head>
<body class="login_body">



    <%--   <div class="panel-img">
        <img src="../WebImages/Panel.png" alt="panel" />

       </div>--%>

    <!-- User Login Panel Start Here -->
    <div>
        <div class="container">
            <div class="modal-body">
                <div class="row">
                    <div class="col-xs-6">
                        <div>


                            <form id="form1" runat="server">

                                <div class="form-group">
                                    <asp:Label runat="server" ID="lbl_username"
                                        AssociatedControlID="txt_username"
                                        CssClass="control-label">User Name</asp:Label>

                                    <asp:TextBox runat="server" ID="txt_username"
                                        CssClass="form-control" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_username" ErrorMessage="*" ForeColor="Red" ValidationGroup="CheckValidate"></asp:RequiredFieldValidator>

                                    <span class="help-block"></span>

                                    <asp:Label runat="server" ID="lbl_password"
                                        AssociatedControlID="txt_password"
                                        CssClass="control-label">Password</asp:Label>

                                    <asp:TextBox runat="server" ID="txt_password"
                                        CssClass="form-control" TextMode="Password" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_password" ErrorMessage="*" ForeColor="Red" ValidationGroup="CheckValidate"></asp:RequiredFieldValidator>

                                    <span class="help-block"></span>

                                    <asp:Button runat="server" ID="btn_Login" Text="Login" CssClass="btn btn-success" ValidationGroup="CheckValidate" OnClick="btn_Login_Click"></asp:Button>
                                </div>

                                <asp:Label class="status" ID="Lbl_status" runat="server" Text="" ForeColor="Red"></asp:Label>



                            </form>
                        </div>
                    </div>




                </div>
            </div>
        </div>
    </div>




</body>
</html>
