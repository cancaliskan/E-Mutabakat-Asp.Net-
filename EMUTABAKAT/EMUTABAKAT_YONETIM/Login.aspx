<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="eMutabakats_yonetim.Login" %>

<!DOCTYPE html>
   

  <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
  <!-- Bootstrap 3.3.6 -->
  <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css">
  <!-- Font Awesome -->
  <link rel="stylesheet" href="css/font-awesome.min.css">
  <!-- Ionicons -->
  <link rel="stylesheet" href="css/ionicons.min.css">
  <!-- Theme style -->
  <link rel="stylesheet" href="dist/css/AdminLTE.min.css">
  <!-- iCheck -->
  <link rel="stylesheet" href="plugins/iCheck/square/blue.css">


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

   
</head>
<body class="hold-transition login-page">

<script src="plugins/jQuery/jquery-2.2.3.min.js"></script>
    <!-- Bootstrap 3.3.6 -->
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <!-- iCheck -->
    <script src="plugins/iCheck/icheck.min.js"></script>
    <script>
    $(function () {
        $('input').iCheck({
            checkboxClass: 'icheckbox_square-blue',
            radioClass: 'iradio_square-blue',
            increaseArea: '20%' // optional
        });
    });
</script>


        <div class="login-box">
              <div class="login-logo">
                    <img src="img/drk_yazilim.png" height="70" width="227" />
                    <%--<a href="#"><b>Admin</b>LTE</a>--%>
              </div>
              <!-- /.login-logo -->
          <div class="login-box-body">
            <p class="login-box-msg">Sign in to start your session</p>


        <form id="form1" runat="server">
            <div class="form-group has-feedback">
 
              <%--  <asp:Login ID="Login1"  CssClass="logo" runat="server" FailureText="Your login attempt was not successful. Please try again." TitleText="Log In">
                --%>
                    <LayoutTemplate>
                         <p class="">
                            <asp:Literal runat="server" ID="FailureText" ></asp:Literal>
                        </p>
                        <div class="login-wrap">

                            <div class="form-group has-feedback">
                                <asp:TextBox runat="server" class="form-control" ID="UserName" />
                                <span class="glyphicon glyphicon-envelope form-control-feedback">
                                    <%--<i class="icon_profile"></i>--%>

                                </span>
                                
                                

                            </div>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" CssClass="field-validation-error" ErrorMessage="The user name field is required." />
                            <div class="form-group has-feedback">
                                <asp:TextBox runat="server" class="form-control" ID="Password" TextMode="Password" />
                                <span class="glyphicon glyphicon-lock form-control-feedback">
                                    <%--<i class="icon_key_alt"></i>--%>

                                </span>
                                
                            </div>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="field-validation-error" ErrorMessage="The password field is required." />
                            <label class="checkbox">
                                <asp:CheckBox runat="server" ID="RememberMe" />
                                <asp:Label runat="server" AssociatedControlID="RememberMe" CssClass="checkbox">Remember me?</asp:Label>
                            </label>
                            <asp:Button class="btn btn-primary btn-block btn-fla" runat="server"  CommandName="Login" Text="Log in" ID="BtnLogin" OnClick="BtnLogin_Click"  />
                        </div>
                    </LayoutTemplate>
                <%--</asp:Login>--%>

            </div>
        </form>
            </div>
        </div>
</body>
</html>
