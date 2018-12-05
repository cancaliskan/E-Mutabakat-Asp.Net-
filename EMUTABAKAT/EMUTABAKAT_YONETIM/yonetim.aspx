<%@ Page Title="" Language="C#" MasterPageFile="~/eMutabakat_MASTER.Master" AutoEventWireup="true" CodeBehind="yonetim.aspx.cs" Inherits="eMutabakats_yonetim.yonetim" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="content">
        <div class="row">
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Yonetim Paneli</h3>
                    </div>

                    <div class="box-body">

                    </div>
                </div>
            </div>


            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:drkEmutabakat %>" DeleteCommand="DELETE FROM [TBL_FIRMS] WHERE [ID] = @ID" InsertCommand="INSERT INTO [TBL_FIRMS] ([FIRM_NAME], [FIRM_CODE], [FIRM_IMAGE], [TEXT1], [TEXT2], [TEXT3], [TEXT4], [FIRM_IMAGE2], [CARI_REP_PAGE], [BA_BS_REP_PAGE], [SMTP_SERVER], [SENDER_EMAIL], [SENDER_EMAIL_TEXT], [EMAIL_USER], [EMAIL_PASSWORD], [EMAIL_PORT], [WEB_LINK], [SSL], [FIRMVD], [ANNOUNCEMENT_CODE], [FIRM_IMAGE_MUHUR], [FAX_NO]) VALUES (@FIRM_NAME, @FIRM_CODE, @FIRM_IMAGE, @TEXT1, @TEXT2, @TEXT3, @TEXT4, @FIRM_IMAGE2, @CARI_REP_PAGE, @BA_BS_REP_PAGE, @SMTP_SERVER, @SENDER_EMAIL, @SENDER_EMAIL_TEXT, @EMAIL_USER, @EMAIL_PASSWORD, @EMAIL_PORT, @WEB_LINK, @SSL, @FIRMVD, @ANNOUNCEMENT_CODE, @FIRM_IMAGE_MUHUR, @FAX_NO)" SelectCommand="SELECT * FROM [TBL_FIRMS]" UpdateCommand="UPDATE [TBL_FIRMS] SET [FIRM_NAME] = @FIRM_NAME, [FIRM_CODE] = @FIRM_CODE, [FIRM_IMAGE] = @FIRM_IMAGE, [TEXT1] = @TEXT1, [TEXT2] = @TEXT2, [TEXT3] = @TEXT3, [TEXT4] = @TEXT4, [FIRM_IMAGE2] = @FIRM_IMAGE2, [CARI_REP_PAGE] = @CARI_REP_PAGE, [BA_BS_REP_PAGE] = @BA_BS_REP_PAGE, [SMTP_SERVER] = @SMTP_SERVER, [SENDER_EMAIL] = @SENDER_EMAIL, [SENDER_EMAIL_TEXT] = @SENDER_EMAIL_TEXT, [EMAIL_USER] = @EMAIL_USER, [EMAIL_PASSWORD] = @EMAIL_PASSWORD, [EMAIL_PORT] = @EMAIL_PORT, [WEB_LINK] = @WEB_LINK, [SSL] = @SSL, [FIRMVD] = @FIRMVD, [ANNOUNCEMENT_CODE] = @ANNOUNCEMENT_CODE, [FIRM_IMAGE_MUHUR] = @FIRM_IMAGE_MUHUR, [FAX_NO] = @FAX_NO WHERE [ID] = @ID">
                <DeleteParameters>
                    <asp:Parameter Name="ID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="FIRM_NAME" Type="String" />
                    <asp:Parameter Name="FIRM_CODE" Type="String" />
                    <asp:Parameter Name="FIRM_IMAGE" Type="Object" />
                    <asp:Parameter Name="TEXT1" Type="String" />
                    <asp:Parameter Name="TEXT2" Type="String" />
                    <asp:Parameter Name="TEXT3" Type="String" />
                    <asp:Parameter Name="TEXT4" Type="String" />
                    <asp:Parameter Name="FIRM_IMAGE2" Type="Object" />
                    <asp:Parameter Name="CARI_REP_PAGE" Type="String" />
                    <asp:Parameter Name="BA_BS_REP_PAGE" Type="String" />
                    <asp:Parameter Name="SMTP_SERVER" Type="String" />
                    <asp:Parameter Name="SENDER_EMAIL" Type="String" />
                    <asp:Parameter Name="SENDER_EMAIL_TEXT" Type="String" />
                    <asp:Parameter Name="EMAIL_USER" Type="String" />
                    <asp:Parameter Name="EMAIL_PASSWORD" Type="String" />
                    <asp:Parameter Name="EMAIL_PORT" Type="Int32" />
                    <asp:Parameter Name="WEB_LINK" Type="String" />
                    <asp:Parameter Name="SSL" Type="Boolean" />
                    <asp:Parameter Name="FIRMVD" Type="String" />
                    <asp:Parameter Name="ANNOUNCEMENT_CODE" Type="String" />
                    <asp:Parameter Name="FIRM_IMAGE_MUHUR" Type="Object" />
                    <asp:Parameter Name="FAX_NO" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="FIRM_NAME" Type="String" />
                    <asp:Parameter Name="FIRM_CODE" Type="String" />
                    <asp:Parameter Name="FIRM_IMAGE" Type="Object" />
                    <asp:Parameter Name="TEXT1" Type="String" />
                    <asp:Parameter Name="TEXT2" Type="String" />
                    <asp:Parameter Name="TEXT3" Type="String" />
                    <asp:Parameter Name="TEXT4" Type="String" />
                    <asp:Parameter Name="FIRM_IMAGE2" Type="Object" />
                    <asp:Parameter Name="CARI_REP_PAGE" Type="String" />
                    <asp:Parameter Name="BA_BS_REP_PAGE" Type="String" />
                    <asp:Parameter Name="SMTP_SERVER" Type="String" />
                    <asp:Parameter Name="SENDER_EMAIL" Type="String" />
                    <asp:Parameter Name="SENDER_EMAIL_TEXT" Type="String" />
                    <asp:Parameter Name="EMAIL_USER" Type="String" />
                    <asp:Parameter Name="EMAIL_PASSWORD" Type="String" />
                    <asp:Parameter Name="EMAIL_PORT" Type="Int32" />
                    <asp:Parameter Name="WEB_LINK" Type="String" />
                    <asp:Parameter Name="SSL" Type="Boolean" />
                    <asp:Parameter Name="FIRMVD" Type="String" />
                    <asp:Parameter Name="ANNOUNCEMENT_CODE" Type="String" />
                    <asp:Parameter Name="FIRM_IMAGE_MUHUR" Type="Object" />
                    <asp:Parameter Name="FAX_NO" Type="String" />
                    <asp:Parameter Name="ID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>


    </section>


</asp:Content>
