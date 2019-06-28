<%@ Page Title="" Language="C#" MasterPageFile="~/NestedAdmin.master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="PizzeríaElParque.AgregarAdmin" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
    <div class="col-md-12">
        <div class="panel panel-default" style="border-radius: 20px 20px 20px 20px;">
                <div class="panel-body">
                    <center>
                    <div style="border: 2px solid #0000FF; text-align:center; width:90%; padding: 10px 10px; box-sizing: border-box; border-radius: 20px 20px 20px 20px;" class="form-inline" role="form">
                       <h1 style="font-family: 'Times New Roman'; font-weight: bold; color: #CC3300;">Ingrese datos del Usuario</h1>
                        <hr style=" height: 2px; color:#0000FF; width: 90%;" noshade="noshade" />

                        <div class="form-group">
                            <label for="name" style="font-size: medium; font-family: Verdana, Geneva, Tahoma, sans-serif; color: #000000;">Primer nombre:</label>
                            <asp:TextBox type="text" CssClass="form-control" ID="txtName" runat="server" BorderColor="Blue" Font-Bold="True" Font-Names="Lucida Sans"></asp:TextBox>
                            <label for="secondName" style="font-size: medium; font-family: Verdana, Geneva, Tahoma, sans-serif; color: #000000;">Segundo nombre:</label>
                            <asp:TextBox type="text" CssClass="form-control" ID="txtSecondName" runat="server" aria-placeholder="opcional" BorderColor="Blue" Font-Bold="True" Font-Names="Lucida Sans"></asp:TextBox>
                        </div>

                        <br />

                        <br/>

                        <div class="form-group">
                            <label for="lastName" style="font-family: Verdana, Geneva, Tahoma, sans-serif; font-size: medium; color: #000000">Primer apellido:</label>
                            <asp:TextBox type="text" CssClass="form-control" ID="txtLastName" runat="server" BorderColor="Blue" Font-Bold="True" Font-Names="Lucida Sans"></asp:TextBox>
                            <label for="SecondLastName" style="font-family: Verdana, Geneva, Tahoma, sans-serif; font-size: medium; color: #000000">Segundo apellido:</label>
                            <asp:TextBox type="text" CssClass="form-control" ID="txtSecondLastName" runat="server" BorderColor="Blue" Font-Bold="True" Font-Names="Lucida Sans"></asp:TextBox>
                        </div>

                        <br>
                        <hr style=" height: 2px; color:#0000FF; width: 90%;" noshade="noshade">
                        <br>
                        <br>

                        <div class="form-group">
                            <label for="cedula" style="font-family: Verdana, Geneva, Tahoma, sans-serif; font-size: medium; color: #000000">Número de Cédula:</label>
                            <asp:TextBox type="number" CssClass="form-control" ID="Identification" runat="server" placeholder="Ejemplo:101110011" title="Digite el número de cédula con números seguidos y con división de ceros ejemplo:101110111" BorderColor="Blue" Font-Bold="True" Font-Names="Lucida Sans" TextMode="SingleLine"></asp:TextBox>
                        </div>

                        <hr style=" color: #0000FF; line-height: 10px; height: 2px; width: 80%;" noshade="noshade">
                        <br>
                        <br>

                        <div class="form-group">
                            <label for="Type" style="font-family: Verdana, Geneva, Tahoma, sans-serif; font-size: medium; color: #000000">Tipo de usuario:</label>
                            <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server" Font-Bold="True" readonly Font-Names="Lucida Sans">
                                <asp:ListItem Value="1">Administrador</asp:ListItem>
                                <asp:ListItem Value="2">Cajero</asp:ListItem>
                                <asp:ListItem Value="3">Cocina</asp:ListItem>
                            </asp:DropDownList>
                            <br>
                            <br>
                        </div>
                        <br />
            <br />
            <asp:LinkButton ID="btnAgregar" runat="server" class="btn btn-default btn-lg, btn btn-primary" OnClick="btbAgregar_Click" Height="30px" Width="117px"><i class="fa fa-plus"></i> Agregar</asp:LinkButton>
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
