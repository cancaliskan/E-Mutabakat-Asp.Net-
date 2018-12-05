<%@ Page Title="" Language="C#" MasterPageFile="~/eMutabakat_MASTER.Master" AutoEventWireup="true" CodeBehind="KullaniciGuncelle.aspx.cs" Inherits="eMutabakats_yonetim.KullaniciGuncelle" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 59.6253%; margin-left: auto; margin-right: auto;">
        <caption>
            <h3><b>KULLANICI GÜNCELLEME EKRANI</b></h3>
        </caption>
        <tbody>
            <tr>
                <td style="width: 41.4729%;">
                    <asp:Label ID="uyari_Lbl" runat="server" Text="" Font-Size="Large" Font-Bold="true"></asp:Label></td>

            </tr>
            <tr style="border-bottom: groove">
                <td style="width: 41.4729%;">Vergi Kimlik No</td>
                <td style="width: 2%; text-align: center">:</td>
                <td style="width: 93%;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FIRM_CODE" ErrorMessage="*" InitialValue="-- Seçin --" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:DropDownList ID="FIRM_CODE" runat="server" AutoPostBack="True" OnSelectedIndexChanged="FIRM_CODE_SelectedIndexChanged">
                        <asp:ListItem Value="-- Seçin --" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:CheckBox ID="SADECE_ACTIVE_FIRM" Text="Sadece Aktif Firmalar" runat="server" AutoPostBack="True" OnCheckedChanged="SADECE_ACTIVE_FIRM_CheckedChanged" Checked="True" />
                </td>
            </tr>
            <tr style="border-bottom: groove">
                <td style="width: 41.4729%;">Kullanıcı Adı</td>
                <td style="width: 2%; text-align: center">:</td>
                <td style="width: 93%;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="USERNAME" ErrorMessage="*" InitialValue="-- Seçin --" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:DropDownList ID="USERNAME" runat="server" AutoPostBack="True" Enabled="False" OnSelectedIndexChanged="USERNAME_SelectedIndexChanged">
                        <asp:ListItem Text="-- Seçin --" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:CheckBox ID="SADECE_ACTIVE_USER" Text="Sadece Aktif Kullanıcılar" runat="server" AutoPostBack="True" Enabled="False" OnCheckedChanged="SADECE_ACTIVE_USER_CheckedChanged" Checked="True" />
                </td>
            </tr>
            <tr style="border-bottom: groove">
                <td style="width: 41.4729%;">Ünvan</td>
                <td style="width: 2%; text-align: center">:</td>
                <td style="width: 93%;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ADMINID" ErrorMessage="*" InitialValue="-- Seçin --" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:DropDownList ID="ADMINID" runat="server" AutoPostBack="True" Enabled="False">
                        <asp:ListItem Value="-- Seçin --" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="1" Text="Yönetici"> </asp:ListItem>
                        <asp:ListItem Value="0" Text="Kullanıcı"> </asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="border-bottom: groove">
                <td style="width: 41.4729%;">İsim</td>
                <td style="width: 2%; text-align: center">:</td>
                <td style="width: 93%;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="NAME" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>                
                    <asp:TextBox ID="NAME" Width="97%" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="border-bottom: groove">
                <td style="width: 41.4729%;">Soyisim</td>
                <td style="width: 2%; text-align: center">:</td>
                <td style="width: 93%;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="SURNAME" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>                
                    <asp:TextBox ID="SURNAME" Width="97%" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr style="border-bottom: groove">
                <td style="width: 41.4729%;">E-Posta Adresi</td>
                <td style="width: 2%; text-align: center">:</td>
                <td style="width: 93%;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="CONTACTEMAIL" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>                
                    <asp:TextBox ID="CONTACTEMAIL" Width="97%" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="regularEx_CONTACTEMAIL" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="CONTACTEMAIL" ErrorMessage="Geçersiz e-posta adresi !"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr style="border-bottom: groove">
                <td style="width: 41.4729%;">Parola</td>
                <td style="width: 2%; text-align: center">:</td>
                <td style="width: 93%; padding-left:6px">                    
                    <asp:TextBox ID="PASSWORD" Width="99%" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr runat="server" id="ACTIVE_row" visible="true" style="border-bottom: groove;">
                <td style="width: 41.4729%;">Aktif</td>
                <td style="width: 2%; text-align: center">:</td>
                <td style="width: 93%; padding-left:6px">
                    <asp:CheckBox ID="ACTIVE" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 41.4729%;">
                    <%--<asp:Button class="btn btn-primary btn-block btn-fla" ID="temizle_btn" runat="server" Text="Temizle" OnClick="temizle_btn_Click" />--%>
                </td>
                <td style="width: 5%;">&nbsp</td>
                <td style="width: 93%;">
                    <asp:Button class="btn btn-primary btn-block btn-fla" ID="kullaniciGuncelle_btn" runat="server" Text="GÜNCELLE" OnClick="kullaniciGuncelle_btn_Click" />
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
