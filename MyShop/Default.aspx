<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyShop.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Shop</title>

    <script src="https://code.jquery.com/jquery-3.6.0.js" integrity="sha256-H+K7U5CnXl1h5ywQfKtSj8PCmoN9aaq30gDh27Xc0jk=" crossorigin="anonymous">

    </script>

    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, Initial=Scale-1" />
    <meta http-equiv="X-UA-Compatible" content="IE-edge" />
    <link href="css/Custome.css" rel="stylesheet" />
      <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

    <script>

        $(document).ready(function myfunction() {

            $("#btnCart").click(function myfuncation() {
                window.location.href = "/Cart.aspx";
            });
        });

    </script>

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
                            <li class="active"><a href="Default.aspx">Home</a></li>
                            <li><a href="#">About</a></li>
                            <li><a href="#">Contact</a></li>
                            <li><a href="#">Blog</a></li>
                            <li class="dropdown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown">Products<b class="caret"></b></a>
                                <ul class="dropdown-menu">
                                     <li><a href="Products.aspx">All Products</a></li>
                                     <li role="separator" class="divider"></li>
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
                            <li><button id="btnCart" class="btn btn-primary navbar-btn" type="button">
                                Cart<span class="badge" id="pCount" runat="server"></span>

                                </button>


                            </li>
                            <li id="btnSignUp" runat="server"><a href="SignUp.aspx">SignUp</a></li>
                            <li id="btnSignIn" runat="server"><a href="SignIn.aspx">SignIn</a></li>

                            <li>
                                <asp:Button ID="btnLogout" CssClass="btn btn-default navbar-btn" runat="server" Text="Sign Out" OnClick="btnLogout_Click" />
                            </li>
                        </ul>
                    </div>
                </div>
            </div>

           <%--Image Slider Start--%>
            <div class="container">
  <h2>Carousel Example</h2>  
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
        <img src="Image Slider/New Arrival.png" alt="Los Angeles" style="width:100%; height:287px"/>
         <div class="carousel-caption">
        <h3>Men Shopping</h3>
        <p>50% off</p>
             <p><a class="btn btn-lg btn-primary" href="#" role="button">Buy Now</a></p>
        </div>
      </div>

      <div class="item">
        <img src="Image Slider/plaza.jpg" alt="Chicago" style="width:100%;  height:287px"/>
           <div class="carousel-caption">
        <h3>Women Shopping</h3>
        <p>20% off</p>
        </div>
      </div>
    
      <div class="item">
        <img src="Image Slider/fashion-slider-final-min.png" alt="New york" style="width:100%; height:287px"/>
           <div class="carousel-caption">
        <h3>Women Shopping</h3>
        <p>30% off</p>
        </div>
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

           <%--Image Slider End--%>

        </div>

        <%--Middle Contents Start--%>
        <hr />
        <div class="container center">
            <div class="row">
                <div class="col-lg-4">
                    <img class="img-circle" src="Images/Mobile/iphone-12-red.jpg" alt="thumb" width="140" height="140"/>
                    <h2>Mobile</h2>
                    <p>The iPhone 12 and iPhone 12 Mini are smartphones designed, developed, 
                        and marketed by Apple Inc. They are the fourteenth-generation, lower-priced iPhones,
                        succeeding the iPhone 11. They were unveiled at an 
                        The iPhone 12 and iPhone 12 Mini are smartphones designed, developed, and marketed 
                       ...</p>
                    <p><a class="btn btn-default" href="#" role="button">View More &raquo;</a></p>
                </div>

                <div class="col-lg-4">
                    <img class="img-circle" src="Images/Casual for men/Casuals for Men Sneakers For Men.jpeg" alt="thumb" width="140" height="140"/>
                    <h2>Footwear</h2>
                    <p>The iPhone 12 and iPhone 12 Mini are smartphones designed, developed, 
                        and marketed by Apple Inc. They are the fourteenth-generation, lower-priced iPhones,
                        succeeding the iPhone 11. They were unveiled at an 
                        The iPhone 12 and iPhone 12 Mini are smartphones designed, developed, and marketed 
                        ....</p>
                    <p><a class="btn btn-default" href="#" role="button">View More &raquo;</a></p>
                </div>

                <div class="col-lg-4">
                    <img class="img-circle" src="Images/Clothing/Clothing.jpeg" alt="thumb" width="140" height="140"/>
                    <h2>Footwear</h2>
                    <p>The iPhone 12 and iPhone 12 Mini are smartphones designed, developed, 
                        and marketed by Apple Inc. They are the fourteenth-generation, lower-priced iPhones,
                        succeeding the iPhone 11. They were unveiled at an 
                        The iPhone 12 and iPhone 12 Mini are smartphones designed, developed, and market....</p>
                    <p><a class="btn btn-default" href="#" role="button">View More &raquo;</a></p>
                </div>
            </div>
        </div>
        <%--Middle Contents END--%>


         <%--footer Contents Start--%>
        <footer>
            <hr />

             <div class="container">
            <p class="pull-right"><a href="#">Back To List</a></p>
            <p>&copy;2021 MyShop &middot;<a href="Default.aspx">Home</a>&middot;<a href="#">About</a> &middot;<a href="#">Contact</a> &middot;<a href="#">Products</a></p>
        </div>
        </footer>    
         <%--footer Contents End--%>

    </form>
    
</body>
</html>
