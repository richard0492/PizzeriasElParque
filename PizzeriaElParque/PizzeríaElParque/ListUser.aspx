<%@ Page Title="" Language="C#" MasterPageFile="~/NestedAdmin.master" AutoEventWireup="true" CodeBehind="ListUser.aspx.cs" Inherits="PizzeríaElParque.ListUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="row">
    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-body">
                <center>
                    <div style="border: 2px solid #0000FF; text-align:center; width:90%; padding: 10px 10px; box-sizing: border-box;
                     background: rgba(0,0,0,.1);" class="form-inline" role="form">
                        <h1 style="font-family: 'Times New Roman'; font-weight: bold; color: #CC3300;">Lista de Usuarios Activos</h1>
                       
                        <hr style=" height: 2px; color:#0000FF; width: 90%;" noshade="noshade" />

                        
                        <br />
                        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
                            <AlternatingRowStyle BackColor="#DCDCDC" />
                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#0000A9" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#000065" />
                        </asp:GridView>

                        
                    </div>
                </center>

            </div>
            

        </div>

    </div>

</div>

</asp:Content>
