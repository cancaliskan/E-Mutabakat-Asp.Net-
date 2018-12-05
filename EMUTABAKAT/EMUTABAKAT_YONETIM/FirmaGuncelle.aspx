<%@ Page Title="" Language="C#" MasterPageFile="~/eMutabakat_MASTER.Master" AutoEventWireup="true" CodeBehind="FirmaGuncelle.aspx.cs" Inherits="eMutabakats_yonetim.FirmaGuncelle" EnableEventValidation="false" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" OnLoad="MakeVisibleOrNot" runat="server">
    <script type="text/javascript">
        function previewFile2() {
            var preview = document.querySelector('#<%=FIRM_IMAGE2_img.ClientID %>');
            var file = document.querySelector('#<%=FIRM_IMAGE2.ClientID %>').files[0];
            var reader = new FileReader();

            reader.onloadend = function () {
                preview.src = reader.result;
            }

            if (file) {
                reader.readAsDataURL(file);
            } else {
                preview.src = "";
            }
        }
    </script>
    <script type="text/javascript">
        function previewFile() {
            var preview = document.querySelector('#<%=FIRM_IMAGE_img.ClientID %>');
            var file = document.querySelector('#<%=FIRM_IMAGE.ClientID %>').files[0];
            var reader = new FileReader();

            reader.onloadend = function () {
                preview.src = reader.result;
            }

            if (file) {
                reader.readAsDataURL(file);
            } else {
                preview.src = "";
            }
        }
    </script>
    <script type="text/javascript">
        function previewFile3() {
            var preview = document.querySelector('#<%=FIRM_IMAGE_MUHUR_img.ClientID %>');
            var file = document.querySelector('#<%=FIRM_IMAGE_MUHUR.ClientID %>').files[0];
            var reader = new FileReader();

            reader.onloadend = function () {
                preview.src = reader.result;
            }

            if (file) {
                reader.readAsDataURL(file);
            } else {
                preview.src = "";
            }
        }
    </script>
    <table style="width: 59.6253%; margin-left: auto; margin-right: auto;">
        <caption>
            <h3><b>FİRMA GÜNCELLEME EKRANI</b></h3>
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
                    <asp:CheckBox ID="SADECE_ACTIVE" Text="Sadece Aktif Firmalar" runat="server" AutoPostBack="True" OnCheckedChanged="SADECE_ACTIVE_CheckedChanged" Checked="True" />
                </td>
            </tr>

            <tr style="border-bottom: groove">
                <td style="width: 41.4729%;">Firma İsmi</td>
                <td style="width: 5%; text-align: center">:</td>
                <td style="width: 93%;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="FIRM_NAME" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="FIRM_NAME" Width="97%" runat="server"></asp:TextBox>

                </td>
            </tr>

            <tr style="border-bottom: groove">
                <td style="width: 41.4729%;">Mutabakat Başlık</td>
                <td style="width: 2%; text-align: center">:</td>
                <td style="width: 93%; padding-left:6px">
                    <asp:Image ID="FIRM_IMAGE_img" Height="70px" Width="70px" runat="server" />
                    <%--<asp:FileUpload ID="FIRM_IMAGE" runat="server" />--%>
                    <input id="FIRM_IMAGE" type="file" name="file" onchange="previewFile()" runat="server" />
                </td>
            </tr>
            <tr style="border-bottom: groove">
                <td style="width: 41.4729%;">Logo</td>
                <td style="width: 2%; text-align: center">:</td>
                <td style="width: 93%; padding-left:6px">
                    <asp:Image ID="FIRM_IMAGE2_img" Height="70px" Width="70px" runat="server" />
                    <input id="FIRM_IMAGE2" type="file" name="file" onchange="previewFile2()" runat="server" />
                </td>
            </tr>
            <tr style="border-bottom: groove">
                <td style="width: 41.4729%;">Cari Rep Sayfası</td>
                <td style="width: 2%; text-align: center">:</td>
                <td style="width: 93%;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="CARI_REP_PAGE" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="CARI_REP_PAGE" Width="97%" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="border-bottom: groove">
                <td style="width: 41.4729%;">BA BS Rep Sayfası</td>
                <td style="width: 2%; text-align: center">:</td>
                <td style="width: 93%;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="BA_BS_REP_PAGE" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="BA_BS_REP_PAGE" Width="97%" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="border-bottom: groove">
                <td style="width: 41.4729%;">SMTP Sunucu</td>
                <td style="width: 2%; text-align: center">:</td>
                <td style="width: 93%;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="SMTP_SERVER" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="SMTP_SERVER" Width="97%" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="border-bottom: groove">
                <td style="width: 41.4729%;">SMTP E-Posta</td>
                <td style="width: 2%; text-align: center">:</td>
                <td style="width: 93%;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="SENDER_EMAIL" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="SENDER_EMAIL" Width="97%" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="regularEx_SENDER_EMAIL" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="SENDER_EMAIL" ErrorMessage="Geçersiz e-posta adresi !"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr style="border-bottom: groove">
                <td style="width: 41.4729%;">Gönderen</td>
                <td style="width: 2%; text-align: center">:</td>
                <td style="width: 93%;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="SENDER_EMAIL_TEXT" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="SENDER_EMAIL_TEXT" Width="97%" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="border-bottom: groove">
                <td style="width: 41.4729%;">Kullanıcı E-Posta Adresi</td>
                <td style="width: 2%; text-align: center">:</td>
                <td style="width: 93%;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="EMAIL_USER" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="EMAIL_USER" Width="97%" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="regularEx_EMAIL_USER" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="EMAIL_USER" ErrorMessage="Geçersiz e-posta adresi !"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr style="border-bottom: groove">
                <td style="width: 41.4729%;">E-Posta Parola</td>
                <td style="width: 2%; text-align: center">:</td>
                <td style="width: 93%; padding-left:6px">
                    
                    <asp:TextBox ID="EMAIL_PASSWORD" Width="99%" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr style="border-bottom: groove">
                <td style="width: 41.4729%;">E-Posta Port</td>
                <td style="width: 2%; text-align: center">:</td>
                <td style="width: 93%;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="EMAIL_PORT" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="EMAIL_PORT" Width="97%" runat="server" onKeyPress="return sedeceSayi(event)" placeholder="Yalnızca sayi girilebilir"></asp:TextBox>
                </td>
            </tr>
            <tr style="border-bottom: groove">
                <td style="width: 41.4729%;">Web-Link</td>
                <td style="width: 2%; text-align: center">:</td>
                <td style="width: 93%;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="WEB_LINK" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="WEB_LINK" Width="97%" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="border-bottom: groove">
                <td style="width: 41.4729%;">SSL</td>
                <td style="width: 2%; text-align: center">:</td>
                <td style="width: 93%; padding-left:6px">
                    <asp:CheckBox ID="SSL" runat="server" />
                </td>
            </tr>
            <tr style="border-bottom: groove">
                <td style="width: 41.4729%;">Vergi Dairesi</td>
                <td style="width: 2%; text-align: center">:</td>
                <td style="width: 93%;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="FIRMVD" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="FIRMVD" Width="97%" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="border-bottom: groove">
                <td style="width: 41.4729%;">Netsis Duyuru Kodu</td>
                <td style="width: 2%; text-align: center">:</td>
                <td style="width: 93%;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ANNOUNCEMENT_CODE" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="ANNOUNCEMENT_CODE" Width="97%" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="border-bottom: groove">
                <td style="width: 41.4729%;">Mühür</td>
                <td style="width: 2%; text-align: center">:</td>
                <td style="width: 93%; padding-left:6px">
                    <asp:Image ID="FIRM_IMAGE_MUHUR_img" Height="70px" Width="70px" runat="server" />
                    <%--<asp:FileUpload ID="FIRM_IMAGE_MUHUR" runat="server" />--%>
                    <input id="FIRM_IMAGE_MUHUR" type="file" name="file" onchange="previewFile3()" runat="server" />
                </td>
            </tr>
            <tr style="border-bottom: groove">
                <td style="width: 41.4729%;">Fax Numarası</td>
                <td style="width: 2%; text-align: center">:</td>
                <td style="width: 93%;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="FAX_NO" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="FAX_NO" Width="97%" runat="server"></asp:TextBox>
                </td>
            </tr>
                <tr style="border-bottom: groove">
                <td style="width: 41.4729%;">Mailler Arası Bekleme Süresi (saniye)</td>
                <td style="width: 2%; text-align: center">:</td>
                <td style="width: 93%;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="MAIL_WAIT_TIME" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="MAIL_WAIT_TIME" Width="97%" runat="server" onKeyPress="return sedeceSayi(event)" placeholder="Yalnızca sayi girilebilir"></asp:TextBox>
                </td>
            </tr>
            <tr runat="server" id="ACTCODE_row" style="border-bottom: groove">
                <td style="width: 41.4729%;">Aktivasyon Kodu</td>
                <td style="width: 2%; text-align: center">:</td>
                <td style="width: 93%;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="ACTCODE" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="ACTCODE" Width="97%" runat="server"></asp:TextBox>
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
                    <asp:Button class="btn btn-primary btn-block btn-fla" ID="firmaGuncelle_btn" runat="server" Text="Güncelle" OnClick="firmaGuncelle_btn_Click" />
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
