<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="MyShop.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SignUp</title>

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
                            <li><a href="Default.aspx">Home</a></li>
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
                            
                              <li class="active"><a href="SignUp.aspx">SignUp</a></li>
                            <li><a href="SignIn.aspx">SignIn</a></li>
                        </ul>
                    </div>
                </div>
            </div>

        </div>
       </div>

        <!---SignUp Page--->
       
        <div class="center-page">
            <label class="col-xs-11"> UserName:</label>
            <div class="col-xs-11">
                <asp:TextBox ID="textUname" runat="server" CssClass="form-control" placeholder="Enter Your UserName"></asp:TextBox>
            </div>


            <label class="col-xs-11"> Password:</label>
            <div class="col-xs-11">
                <asp:TextBox ID="textPass" runat="server" TextMode="Password" CssClass="form-control" placeholder="Enter Your Password"></asp:TextBox>
            </div>


            <label class="col-xs-11"> Confirm Password:</label>
            <div class="col-xs-11">
                <asp:TextBox ID="textCPass" runat="server" TextMode="Password" CssClass="form-control" placeholder="Enter Your Confirm Password"></asp:TextBox>
            </div>


            <label class="col-xs-11"> Your Full Name:</label>
            <div class="col-xs-11">
                <asp:TextBox ID="textName" runat="server" CssClass="form-control" placeholder="Enter Your Full Name"></asp:TextBox>
            </div>


            <label class="col-xs-11"> Email:</label>
            <div class="col-xs-11">
                <asp:TextBox ID="textEmail" runat="server" CssClass="form-control" placeholder="Enter Your Email"></asp:TextBox>
            </div>

            <label class="col-xs-11"></label>
            <div class="col-xs-11">
                <asp:Button ID="textsignup" CssClass="btn btn-success" runat="server" Text="SignUp" OnClick="textsignup_Click" />
                <asp:Label ID="lblMsg" runat="server" Text="Label"></asp:Label>
            </div>
        </div>

        <!---SignUp Page End--->

         <%--footer Contents Start--%>
        <hr />
        <footer class="footer-pos">
            <div class="container">
            <p class="pull-right"><a href="#">Back To List</a></p>
            <p>&copy;2021 MyShop &middot;<a href="Default.aspx">Home</a>&middot;<a href="#">About</a> &middot;<a href="#">Contact</a> &middot;<a href="#">Products</a></p>
        </div>
        </footer>
        
         <%--footer Contents End--%>
    </form>
</body>
</html>
