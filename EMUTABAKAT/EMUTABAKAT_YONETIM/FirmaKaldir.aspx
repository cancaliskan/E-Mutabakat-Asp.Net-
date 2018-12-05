<%@ Page Title="" Language="C#" MasterPageFile="~/eMutabakat_MASTER.Master" AutoEventWireup="true" CodeBehind="FirmaKaldir.aspx.cs" Inherits="eMutabakats_yonetim.FirmaKaldir" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 59.6253%; margin-left: auto; margin-right: auto;">
        <caption>
            <h3><b>FİRMA KAPATMA EKRANI</b></h3>
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
                    <asp:DropDownList ID="FIRM_CODE" Width="50%" runat="server" AutoPostBack="True" OnSelectedIndexChanged="FIRM_CODE_SelectedIndexChanged">
                        <asp:ListItem Value="-- Seçin --" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 41.4729%;"></td>
                <td style="width: 2%; text-align: center"></td>
                <td style="width: 93%; text-align: center">
                    <br />
                    <asp:Button class="btn btn-primary btn-block btn-fla" Width="50%" ID="firmaKapat_btn" runat="server" Text="Kapat" OnClick="firmaKapat_btn_Click" />
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
