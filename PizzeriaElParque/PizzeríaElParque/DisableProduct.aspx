<%@ Page Title="" Language="C#" MasterPageFile="~/NestedAdmin.master" AutoEventWireup="true" CodeBehind="DisableProduct.aspx.cs" Inherits="PizzeríaElParque.DisableProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-body">
                <center>
                    <div style="border: 2px solid #0000FF; text-align:center; width:90%; padding: 10px 10px; box-sizing: border-box;
                     background: rgba(0,0,0,.1);" class="form-inline" role="form">
                        <h1 style="font-family: 'Times New Roman'; font-weight: bold; color: #CC3300;">Ingrese datos del Producto</h1>
                        <hr style=" height: 2px; color:#0000FF; width: 90%;" noshade="noshade" />

                        <div class="form-group">
                            <label for="name" style="font-size: medium; font-family: Verdana, Geneva, Tahoma, sans-serif; color: #000000;">Nombre del producto:</label>
                            <asp:TextBox type="text" CssClass="form-control" ID="txtName" runat="server" BorderColor="Blue" Font-Bold="True" Font-Names="Lucida Sans"></asp:TextBox>
                            &nbsp;</div>
                        <br /><br />
                        <div class="form-group">
                            <label for="cedula" style="font-family: Verdana, Geneva, Tahoma, sans-serif; font-size: medium; color: #000000">Código del producto:</label>
                            <asp:TextBox type="number" CssClass="form-control" ID="Identification" runat="server" placeholder="Ejemplo:101110011" title="Digite el número de cédula con números seguidos y con división de ceros ejemplo:101110111" BorderColor="Blue" Font-Bold="True" Font-Names="Lucida Sans"></asp:TextBox>
                        </div>

                        <hr style=" color: #0000FF; line-height: 10px; height: 2px; width: 80%;" noshade="noshade">
                        <br>
                        <br>

                        <div class="form-group">
                            <label for="Type" style="font-family: Verdana, Geneva, Tahoma, sans-serif; font-size: medium; color: #000000">Tiempo de preparación en minutos:</label>
                           
                            <br />
                            
                            <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server" Font-Bold="True" Font-Names="Lucida Sans" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                <asp:ListItem Value="0 ">0 minutos</asp:ListItem>
                                <asp:ListItem Value="5  ">5  minutos</asp:ListItem>
                                <asp:ListItem Value="10  ">10  minutos</asp:ListItem>
                                <asp:ListItem Value="15 ">15  minutos</asp:ListItem>
                                <asp:ListItem Value="20 ">20  minutos</asp:ListItem>
                                <asp:ListItem Value="25">25 minutos</asp:ListItem>
                                <asp:ListItem Value="30">30  minutos</asp:ListItem>
                                <asp:ListItem Value="35">35 minutos</asp:ListItem>
                                <asp:ListItem Value="40">40 minutos</asp:ListItem>
                                <asp:ListItem Value="45">45 minutos</asp:ListItem>
                                <asp:ListItem Value="50">50 minutos</asp:ListItem>
                                <asp:ListItem Value="55">55 minutos</asp:ListItem>
                                <asp:ListItem Value="60">60 minutos</asp:ListItem>
                            </asp:DropDownList>
                            <br /><br />
                             <div class="form-group">
                            <label for="name" style="font-size: medium; font-family: Verdana, Geneva, Tahoma, sans-serif; color: #000000;">Precio:</label>
                            <asp:TextBox type="number" CssClass="form-control" ID="TextBox1" runat="server" BorderColor="Blue" Font-Bold="True" Font-Names="Lucida Sans"></asp:TextBox>
                            &nbsp;<label for="name" style="font-size: medium; font-family: Verdana, Geneva, Tahoma, sans-serif; color: #000000;">colones</label></div>
                        </div>
                        <br />
           
                    </div>
                </center>

            </div>
            

        </div>

    </div>

</div>
</asp:Content>
