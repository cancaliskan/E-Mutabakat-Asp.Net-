<%@ Page Title="" Language="C#" MasterPageFile="~/eMutabakat_MASTER.Master" AutoEventWireup="true" CodeBehind="ParametreEkle.aspx.cs" Inherits="eMutabakats_yonetim.ParametreEkle" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 59.6253%; margin-left: auto; margin-right: auto;">
        <caption>
            <h3><b>PARAMETRE EKLEME EKRANI</b></h3>
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
                    <asp:DropDownList ID="FIRM_CODE" runat="server" AutoPostBack="True">
                    <asp:ListItem Value="-- Seçin --" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:CheckBox ID="SADECE_ACTIVE_FIRM" Text="Sadece Aktif Firmalar" runat="server" AutoPostBack="True" OnCheckedChanged="SADECE_ACTIVE_FIRM_CheckedChanged" Checked="True" />
                </td>
            </tr>
            <tr style="border-bottom: groove">
                <td style="width: 41.4729%;">Parametre İsmi</td>
                <td style="width: 2%; text-align: center">:</td>
                <td style="width: 93%;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="PARAMNAME" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="PARAMNAME" Width="97%" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="border-bottom: groove">
                <td style="width: 41.4729%;">Parametre Değeri</td>
                <td style="width: 2%; text-align: center">:</td>
                <td style="width: 93%;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="PARAMVAL" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="PARAMVAL" Width="97%" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td style="width: 41.4729%;">
                    <%--<asp:Button class="btn btn-primary btn-block btn-fla" ID="temizle_btn" runat="server" Text="Temizle" OnClick="temizle_btn_Click" />--%>
                </td>
                <td style="width: 5%;">&nbsp</td>
                <td style="width: 93%;">
                    <asp:Button class="btn btn-primary btn-block btn-fla" ID="paramEkle_btn" runat="server" Text="EKLE" OnClick="paramEkle_btn_Click" />
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
