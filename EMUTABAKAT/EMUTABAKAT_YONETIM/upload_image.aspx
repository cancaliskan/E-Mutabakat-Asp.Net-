<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="upload_image.aspx.cs" Inherits="eMutabakats.upload_image" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
        <div>

            <asp:FileUpload ID="imgUpload" runat="server" />



            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
&nbsp;IMAGE<br />
            <br />

            <asp:FileUpload ID="imgUpload2" runat="server" />



            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />
            IMAGE2<br />
            <br />

            <asp:FileUpload ID="imgUpload3" runat="server" />



            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Button" />
            MUHUR</div>
    </form>
</body>
</html>
