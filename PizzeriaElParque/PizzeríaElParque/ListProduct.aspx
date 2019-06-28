<%@ Page Title="" Language="C#" MasterPageFile="~/NestedAdmin.master" AutoEventWireup="true" CodeBehind="ListProduct.aspx.cs" Inherits="PizzeríaElParque.ListProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-body">
                    <center>
                    <div style="border: 2px solid #0000FF; text-align:center; width:90%; padding: 10px 10px; box-sizing: border-box;
                     background: rgba(0,0,0,.1);" class="form-inline" role="form">
                        <h1 style="font-family: 'Times New Roman'; font-weight: bold; color: #CC3300;">Lista de Productos Activos</h1>
                       
                        <hr style=" height: 2px; color:#0000FF; width: 90%;" noshade="noshade" />

                        
                        <br />
                        <Center>
                        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" RowHeaderColumn="Hola" Width="700px">
                            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                            <RowStyle BackColor="White" ForeColor="#330099" />
                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                            <SortedAscendingCellStyle BackColor="#FEFCEB" />
                            <SortedAscendingHeaderStyle BackColor="#AF0101" />
                            <SortedDescendingCellStyle BackColor="#F6F0C0" />
                            <SortedDescendingHeaderStyle BackColor="#7E0000" />
                        </asp:GridView>

                        </Center>
                    </div>
                </center>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
