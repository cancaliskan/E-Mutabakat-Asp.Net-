<%@ Page Title="" Language="C#" MasterPageFile="~/eMutabakat_MASTER.Master" AutoEventWireup="true" CodeBehind="ParametreKaldir.aspx.cs" Inherits="eMutabakats_yonetim.ParametreKaldir" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <table style="width: 59.6253%; margin-left: auto; margin-right: auto;">
        <caption>
            <h3><b>PARAMETRE KAPATMA EKRANI</b></h3>
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
                <td style="width: 41.4729%;">Parametre Adı</td>
                <td style="width: 2%; text-align: center">:</td>
                <td style="width: 93%;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="PARAMNAME" ErrorMessage="*" InitialValue="-- Seçin --" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:DropDownList ID="PARAMNAME" runat="server" AutoPostBack="True" Enabled="False">
                        <asp:ListItem Text="-- Seçin --" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 41.4729%;"></td>
                <td style="width: 2%; text-align: center"></td>
                <td style="width: 93%; text-align: center">
                    <br />
                    <asp:Button class="btn btn-primary btn-block btn-fla" Width="50%" ID="kullaniciKapat_btn" runat="server" Text="Kapat" OnClick="kullaniciKapat_btn_Click" />
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
