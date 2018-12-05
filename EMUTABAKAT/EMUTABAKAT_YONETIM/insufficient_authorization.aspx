<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="insufficient_authorization.aspx.cs" Inherits="eMutabakat.WebForm1" %>

<!DOCTYPE html>

           <!-- Bootstrap CSS -->    
 <%--   <link href="styles/bootstrap.min.css" rel="stylesheet">--%>
    <!-- bootstrap theme -->
    <link href="styles/bootstrap-theme.css" rel="stylesheet">
    <!--external css-->
    <!-- font icon -->
    <link href="styles/elegant-icons-style.css" rel="stylesheet" />
    <link href="styles/font-awesome.min.css" rel="stylesheet" />
    <!-- Custom styles -->
    <link href="styles/style.css" rel="stylesheet">
    <link href="styles/style-responsive.css" rel="stylesheet" />
    <link href="styles/style_1.css" rel="stylesheet" type="text/css"  />
    <link href="styles/navigator.css" rel="stylesheet" type="text/css"  />
    <link href="styles/line-icons.css" rel="stylesheet" type="text/css" />
    <link href="styles/elegant-icons-style.css" rel="stylesheet"  type="text/css" />
    <link href="styles/PieStyle.css" rel="stylesheet" type="text/css"  />


<html xmlns="http://www.w3.org/1999/xhtml">

  <body>

  <!-- container section start -->
  <section id="container" class="">
      <!--header start-->
      

 <header class="header dark-bg">


          <div class="toggle-nav">
              <div class="icon-reorder tooltips" data-original-title="Toggle Navigation" data-placement="bottom"></div>
          </div>

          <!--logo start-->
          <a href="DashBoard.aspx" class="logo">dORUK <span class="lite">e-MUTABAKAT</span></a>
          <!--logo end-->

           <div class="top-nav notification-row">                
                <!-- notificatoin dropdown start-->
                <ul class="nav pull-right top-menu">

                     <!-- user login dropdown start-->
                    <li class="dropdown">
                        <a data-toggle="dropdown" class="dropdown-toggle" href="#">
                            <span >
                                <img alt="" src="" class="icon-dashboard-l">
                            </span>
                            <span class="username">REPORTS</span>
                            <b class="caret"></b>
                        </a>
                        <ul runat="server" class="dropdown-menu extended logout" id ="drpDownMenu">
                            <div class="log-arrow-up"></div>
                          <%--  <li class="eborder-top">
                                <a href="ExportAndRegionSales.aspx"><i class="icon_mail_alt icon-reagion-l"></i>Export And Region</a>
                            </li>
                            <li class="eborder-top">
                                <a href="CustomerBaseSales.aspx"><i class="icon_mail_alt icon-customersales-l"></i>Customer&Sales</a>
                            </li>
                            <li class="eborder-top">
                                <a href="ProductSales.aspx"><i class="icon_mail_alt icon-export-l"></i>Product Sales</a>
                            </li>
                            <li class="eborder-top">
                                <a href="PivotData.aspx"><i class="icon_mail_alt icon-PivotTable-l"></i>PivotTable</a>
                            </li>
                            <li>
                                <a href="KeyAccountSales.aspx"><i class="icon_mail_alt icon-keyAccount-l"></i> Key Account</a>
                            </li>--%>

        <%--                            <li>
                                <a href="documentation.html"><i class="icon_key_alt"></i> Documentation</a>
                            </li>--%>
                        </ul>
                    </li>
                    <!-- user login dropdown end -->
            

                </ul>

           </div>

         

      </header>      
      <!--header end-->

      <!--sidebar start-->
   <%--   <aside>
          <div id="sidebar"  class="nav-collapse ">
              <!-- sidebar menu start-->
              <ul class="sidebar-menu">                
                  <li class="">
                      <a class="" href="Sales.aspx">
                          <i class="icon_house_alt"></i>
                          <span>Sales</span>
                      </a>
                  </li>
				  <li class="sub-menu">
                      <a href="javascript:;" class="">
                          <i class="icon_document_alt"></i>
                          <span>Sales</span>
                          <span class="menu-arrow arrow_carrot-right"></span>
                      </a>
                      <ul class="sub">
                          <li><a class="" href="salesExportAndProduct.aspx">Export-Domestic</a></li>                          
                          <li><a class="" href="form_validation.html">Customer Base</a></li>
                      </ul>
                  </li>       
                  <li class="sub-menu">
                      <a href="javascript:;" class="">
                          <i class="icon_desktop"></i>
                          <span>UI Fitures</span>
                          <span class="menu-arrow arrow_carrot-right"></span>
                      </a>
                      <ul class="sub">
                          <li><a class="" href="general.html">Components</a></li>
                          <li><a class="" href="buttons.html">Buttons</a></li>
                          <li><a class="" href="grids.html">Grids</a></li>
                      </ul>
                  </li>
                  <li>
                      <a class="" href="widgets.html">
                          <i class="icon_genius"></i>
                          <span>Widgets</span>
                      </a>
                  </li>
                  <li>                     
                      <a class="" href="chart-chartjs.html">
                          <i class="icon_piechart"></i>
                          <span>Charts</span>
                          
                      </a>
                                         
                  </li>
                             
                  <li class="sub-menu">
                      <a href="javascript:;" class="">
                          <i class="icon_table"></i>
                          <span>Tables</span>
                          <span class="menu-arrow arrow_carrot-right"></span>
                      </a>
                      <ul class="sub">
                          <li><a class="" href="basic_table.html">Basic Table</a></li>
                      </ul>
                  </li>
                  
                  <li class="sub-menu ">
                      <a href="javascript:;" class="">
                          <i class="icon_documents_alt"></i>
                          <span>Pages</span>
                          <span class="menu-arrow arrow_carrot-right"></span>
                      </a>
                      <ul class="sub">                          
                          <li><a class="" href="profile.html">Profile</a></li>
                          <li><a class="" href="login.html"><span>Login Page</span></a></li>
                          <li><a class="active" href="blank.html">Blank Page</a></li>
                          <li><a class="" href="404.html">404 Error</a></li>
                      </ul>
                  </li>
                  
              </ul>
              <!-- sidebar menu end-->
          </div>
      </aside>--%>
      <!--sidebar end-->

      <!--main content start-->
   <%--   <section id="main-content">--%>
          <section id="">
          <section class="wrapper">
              <!-- page start-->
              <form id="form1" runat="server" loginUrl="logon.aspx" protection="All" timeout="30" path="/" 
                   >
<%--                  requireSSL="false" slidingExpiration="true"
                   cookieless="UseDeviceProfile" domain="" 
                   enableCrossAppRedirects="false"--%>

<%--              <credentials passwordFormat="SHA1"/>--%>

                  <asp:LoginView runat="server" ViewStateMode="Disabled" ID="LoginVw">
<%--                      <AnonymousTemplate>
                          <ul>
                              <li><a id="registerLink" runat="server" href="~/Account/Register">Register</a></li>
                              <li><a id="loginLink" runat="server" href="~/Account/Login">Log in</a></li>
                          </ul>
                      </AnonymousTemplate>--%>
                      <LoggedInTemplate>
                          <p>
                              Hello,  <asp:LoginName runat="server" CssClass="username" />!
                            <asp:LoginStatus runat="server" LogoutAction="Redirect" LogoutText="Log off" LogoutPageUrl="logon.aspx" />
                          </p>
                      </LoggedInTemplate>
                  </asp:LoginView>
                  
                  <div class="row">
                      <div class="col-sm-6">
                          <section class="panel">

                              <div class="alert alert-block alert-danger fade in">
                                  <button data-dismiss="alert" class="close close-sm" type="button">
                                      <i class="icon-remove"></i>
                                  </button>
                                  <strong>Insufficient authorization!</strong>  to open this page please select page from menu 
                             
                              </div>

                          </section>
                      </div>
                  </div>



            </form>
              <!-- page end-->
          </section>
      </section>
      <!--main content end-->
  </section>
  <!-- container section end -->
    <!-- javascripts -->
    <script src="js/jquery.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <!-- nice scroll -->
    <script src="js/jquery.scrollTo.min.js"></script>
    <script src="js/jquery.nicescroll.js" type="text/javascript"></script><!--custome script for all page-->
    <script src="js/scripts.js"></script>


  </body>
</html>
