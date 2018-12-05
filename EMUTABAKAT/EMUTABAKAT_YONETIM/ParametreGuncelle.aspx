<%@ Page Title="" Language="C#" MasterPageFile="~/eMutabakat_MASTER.Master" AutoEventWireup="true" CodeBehind="ParametreGuncelle.aspx.cs" Inherits="eMutabakats_yonetim.ParametreGuncelle" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 59.6253%; margin-left: auto; margin-right: auto;">
        <caption>
            <h3><b>PARAMETRE GÜNCELLEME EKRANI</b></h3>
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
                <td style="width: 41.4729%;">Parametre İsmi</td>
                <td style="width: 2%; text-align: center">:</td>
                <td style="width: 93%;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="PARAMNAME" ErrorMessage="*" InitialValue="-- Seçin --" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:DropDownList ID="PARAMNAME" runat="server" AutoPostBack="True" Enabled="False" OnSelectedIndexChanged="PARAMNAME_SelectedIndexChanged">
                        <asp:ListItem Text="-- Seçin --" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:CheckBox ID="SADECE_ACTIVE_PARAM" Text="Sadece Aktif Parametreler" runat="server" AutoPostBack="True" Enabled="False" OnCheckedChanged="SADECE_ACTIVE_PARAM_CheckedChanged" Checked="True" />

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
                    <asp:Button class="btn btn-primary btn-block btn-fla" ID="paramGuncelle_btn" runat="server" Text="GÜNCELLE" OnClick="paramGuncelle_btn_Click" />
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
