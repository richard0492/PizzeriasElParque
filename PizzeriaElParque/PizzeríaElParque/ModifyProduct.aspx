<%@ Page Title="" Language="C#" MasterPageFile="~/NestedAdmin.master" AutoEventWireup="true" CodeBehind="ModifyProduct.aspx.cs" Inherits="PizzeríaElParque.ModifyProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
    <div class="col-md-12">
        <div class="panel panel-default" style="border-radius: 20px 20px 20px 20px;">
                <div class="panel-body">
                    <center>
                    <div style="border: 2px solid #0000FF; text-align:center; width:90%; padding: 10px 10px; box-sizing: border-box; border-radius: 20px 20px 20px 20px;" class="form-inline" role="form">
                       <h1 style="font-family: 'Times New Roman'; font-weight: bold; color: #CC3300;">Moficar Producto</h1>
                        <hr style=" height: 2px; color:#0000FF; width: 90%;" noshade="noshade" />

                        <br /><br />
                        <div class="form-group">
                            <label for="cogigo" style="font-family: Verdana, Geneva, Tahoma, sans-serif; font-size: medium; color: #000000">Código del producto a modificar:</label>
                            <asp:TextBox type="number" CssClass="form-control" ID="Identification" runat="server" placeholder="Ejemplo:001" title="Digite el número de código del producto" BorderColor="Blue" Font-Bold="True" Font-Names="Lucida Sans"></asp:TextBox>
                        <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-default btn-lg, btn btn-primary" Height="32px" Width="156px" OnClick="LinkButton1_Click"><i class="fa fa-search"></i> Buscar producto</asp:LinkButton>
                        
                        </div>

                        <hr style=" color: #0000FF; line-height: 10px; height: 2px; width: 80%;" noshade="noshade">
                        <br>
                        <br>
                        
                        <div class="form-group">
                            <label for="name" style="font-size: medium; font-family: Verdana, Geneva, Tahoma, sans-serif; color: #000000;">Nombre del producto:</label>
                            <asp:TextBox type="text" CssClass="form-control" ID="txtName" runat="server" BorderColor="Blue" Font-Bold="True" Font-Names="Lucida Sans"></asp:TextBox>
                            &nbsp;</div>
                        <br>
                        <br>
                        <div class="form-group">
                            <label for="Type" style="font-family: Verdana, Geneva, Tahoma, sans-serif; font-size: medium; color: #000000">Tiempo de preparación en minutos:</label>
                           
                            <br />
                            <asp:DropDownList CssClass="form-control" ID="DropDownListPreparationTime" runat="server" Font-Bold="True" Font-Names="Lucida Sans" >
                                <asp:ListItem>Selccione un tiempo</asp:ListItem>
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
                            <br /><br /><br /><br />
                             <div class="form-group">
                            <label for="name" style="font-size: medium; font-family: Verdana, Geneva, Tahoma, sans-serif; color: #000000;">Precio:</label>
                            <asp:TextBox type="number" CssClass="form-control" ID="txtPrice" runat="server" BorderColor="Blue" Font-Bold="True" Font-Names="Lucida Sans"></asp:TextBox>
                            &nbsp;<label for="name" style="font-size: medium; font-family: Verdana, Geneva, Tahoma, sans-serif; color: #000000;">colones.</label></div>
                        </div>
                        <br />
            <br />
            <asp:LinkButton ID="btnModify" runat="server" class="btn btn-default btn-lg, btn btn-primary" Height="49px" Width="117px" OnClick="btnModify_Click"><i class="fa fa-plus"></i> Modificar</asp:LinkButton>
            <br />
            <br />
            <br />
                    </div>
                </center>

            </div>
            

        </div>

    </div>

</div>

</asp:Content>
