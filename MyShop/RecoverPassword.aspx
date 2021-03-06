<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecoverPassword.aspx.cs" Inherits="MyShop.RecoverPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reset Your Password or Password Recovery</title>

    
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, Initial=Scale-1" />
    <meta http-equiv="X-UA-Compatible" content="IE-edge" />
    <link href="css/Custome.css" rel="stylesheet" />
      <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>

            
            <div class="navbar navbar-default navbar-fixed-top" role="navigation">
                <div class="container">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="sr-only">Toggle Navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>

                        </button>
                        <a class="navbar-brand" href="Default.aspx"><span> <img src="Icon/Royal Court BD.png" alt="MyShop" height="30"/></span>MyShop</a>
                        
                    </div>
                    <div class="navbar-collapse collapse">
                        <ul class="nav navbar-nav navbar-right">
                            <li ><a href="Default.aspx">Home</a></li>
                            <li><a href="#">About</a></li>
                            <li><a href="#">Contact</a></li>
                            <li><a href="#">Blog</a></li>
                            <li class="dropdown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown">Products<b class="caret"></b></a>
                                <ul class="dropdown-menu">
                                     <li class="dropdown-header">Men</li>
                                    <li role="separator" class="divider"></li>
                                    <li><a href="#">Shirt</a></li>
                                    <li><a href="#">Pants</a></li>
                                    <li><a href="#">Denims</a></li>

                                    <li role="separator" class="divider"></li>
                                    <li class="dropdown-header">Women</li>
                                    <li role="separator" class="divider"></li>
                                    <li><a href="#">TOp</a></li>
                                    <li><a href="#">Laggies</a></li>
                                    <li><a href="#">Denims</a></li>
                                </ul>
                            </li>
                           
                            <li><a href="SignIn.aspx">SignIn</a></li>
                        </ul>
                    </div>
                </div>
            </div>

        </div>

         <div class="container">
            <div class="form-horizontal">
                <br />
                <br />
                <br />

                <h2>Rest Password</h2>
                <hr />
                <h3></h3>
                <div class="form-group">
                     <asp:Label ID="lblmsg" CssClass="col-md-2 control-label" runat="server" Visible="False" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                </div>

                <div class="form-group">
                    <asp:Label ID="lblNewPass" CssClass="col-md-2 control-label" runat="server" Text="Your New Password" Visible="False"></asp:Label>
                
                <div class="col-md-3">
                    <asp:TextBox ID="textNewPass" CssClass="form-control" TextMode="Password" runat="server" Visible="False"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorNewPass" runat="server" CssClass="text-danger" ErrorMessage="Enter Your New Password" ControlToValidate="textNewPass" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>


                
                <div class="form-group">
                    <asp:Label ID="lblConfirmPass" CssClass="col-md-2 control-label" runat="server" Text="Confirm New Password" Visible="False"></asp:Label>
                
                <div class="col-md-3">
                    <asp:TextBox ID="textConfirmPass" CssClass="form-control" TextMode="Password" runat="server" Visible="False"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorConfirmPass" runat="server" CssClass="text-danger" ErrorMessage="Enter Your New Confirm Password" ControlToValidate="textConfirmPass" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidatorPass" runat="server" ErrorMessage="Confirm Password not match... try again" ControlToCompare="textNewPass" ControlToValidate="textConfirmPass" ForeColor="Red"></asp:CompareValidator>
                </div>
            </div>

                <div class="form-group">
                    <div class="col-md-2"> </div>

                    <div class="col-md-6">
                        <asp:Button ID="btnResetPass" CssClass="btn btn-default" runat="server" Text="Reset" Visible="False" OnClick="btnResetPass_Click" />
                        <asp:Label ID="lblResetPassMsg" CssClass="text-success" runat="server"></asp:Label>
                    </div>

                   
                </div>
          </div>
        </div>
    </form>

    
         <%--footer Contents Start--%>
        <hr />
        <footer>
             <div class="container">
            <p class="pull-right"><a href="#">Back To List</a></p>
            <p>&copy;2021 MyShop &middot;<a href="Default.aspx">Home</a>&middot;<a href="#">About</a> &middot;<a href="#">Contact</a> &middot;<a href="#">Products</a></p>
        </div>
        </footer>    
         <%--footer Contents End--%>
</body>
</html>
