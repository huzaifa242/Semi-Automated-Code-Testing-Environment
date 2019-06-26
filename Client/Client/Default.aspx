<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Client._Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:RadioButtonList id="radiobuttons" runat="server">
    <asp:ListItem>File</asp:ListItem>
    <asp:ListItem>Text</asp:ListItem>
    </asp:RadioButtonList>
    <div>
        <asp:Label runat="server" Text="Language:"></asp:Label>
        <asp:DropDownList runat="server" ID="languages">
            <asp:ListItem Value="cpp">cpp</asp:ListItem>
            <asp:ListItem Value="c">c</asp:ListItem>
            <asp:ListItem Value="python2">python2</asp:ListItem>
            <asp:ListItem Value="python3">python3</asp:ListItem>
            <asp:ListItem Value="java">java</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div>
        <section id="fileselection" class="file">
            <div class="">
                <div class="col-lg-4">
                    <label>Testing Files</label>
                    <asp:FileUpload ID="fileupload1" runat="server" AllowMultiple="true" />
                </div>
                <div class="col-lg-4">
                    <label>Tester File</label>
                    <asp:FileUpload ID="fileupload2" runat="server" />
                </div>
                <div class="col-lg-4">
                    <label>Testcases File</label>
                    <asp:FileUpload ID="fileupload3" runat="server" />
                </div>
            </div>
        </section>
    </div>
    <section id="textsection" class="text">
        <div>
            <div class="col-lg-4">
                <label>Testing Code</label>
                <br/>
                <textarea name="testing"></textarea>
            </div>
            <div class="col-lg-4">
                <label>Tester code</label>
                <br/>
                <textarea name="tester"></textarea>
            </div>
            <div class="col-lg-4">
                <label>Testcases</label>
                <br/>
                <textarea name="testcase"></textarea>
            </div>
        </div>
    </section>
    <div class="text-center">
        <asp:Button ID="Button1" runat="server" Text="Test" OnClick="ButtonClick"/>
    </div>
    <ul runat="server" id ="list1">
    </ul>
</asp:Content>