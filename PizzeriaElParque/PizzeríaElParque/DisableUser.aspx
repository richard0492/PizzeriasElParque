<%@ Page Title="" Language="C#" MasterPageFile="~/NestedAdmin.master" AutoEventWireup="true" CodeBehind="DisableUser.aspx.cs" Inherits="PizzeríaElParque.DisableUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
    <div class="col-md-12">
         <div class="panel panel-default" style="border-radius: 20px 20px 20px 20px;">
                <div class="panel-body">
                    <center>
                    <div style="border: 2px solid #0000FF; text-align:center; width:90%; padding: 10px 10px; box-sizing: border-box; border-radius: 20px 20px 20px 20px;" class="form-inline" role="form">
                       <h1 style="font-family: 'Times New Roman'; font-weight: bold; color: #CC3300;">Deshabilitar Usuario</h1>
                        <p style="font-family: 'Times New Roman'; font-weight: bold; color: #CC3300;">
                    <asp:Label ID="lbnEmployeesName" runat="server" Text="Seleccionar Usuario:" Font-Size="Large"></asp:Label>
                    <asp:DropDownList ID="dlEmployees" CssClass="custom-select" runat="server" Height="40px" Width="257px" Font-Size="Medium" AutoPostBack="True" OnSelectedIndexChanged="dlEmployees_SelectedIndexChanged">
                    </asp:DropDownList>
                        </p>
                        <hr style=" height: 2px; color:#0000FF; width: 90%;" noshade="noshade" />

                        <div class="form-group">
                            <label for="name" style="font-size: large; font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif; color: #000000; text-transform: none; font-variant: normal; font-weight: bold;">Primer nombre:</label>
                            <asp:TextBox type="text" CssClass="form-control" ID="txtName" runat="server" BorderColor="Blue" Font-Bold="True" Font-Names="Lucida Sans" Enabled="False"></asp:TextBox>
                            <label for="secondName" style="font-size: large; font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif; color: #000000; font-weight: bold;">Segundo nombre:</label>
                            <asp:TextBox type="text" CssClass="form-control" ID="txtSecondName" runat="server" aria-placeholder="opcional" BorderColor="Blue" Font-Bold="True" Font-Names="Lucida Sans" Enabled="False"></asp:TextBox>
                        </div>

                        <br />

                        <br/>

                        <div class="form-group">
                            <label for="lastName" style="font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif; font-size: large; color: #000000; font-weight: bold;">Primer apellido:</label>
                            <asp:TextBox type="text" CssClass="form-control" ID="txtLastName" runat="server" BorderColor="Blue" Font-Bold="True" Font-Names="Lucida Sans" Enabled="False"></asp:TextBox>
                            <label for="SecondLastName" style="font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif; font-size: large; color: #000000; font-weight: bold;">Segundo apellido:</label>
                            <asp:TextBox type="text" CssClass="form-control" ID="txtSecondLastName" runat="server" BorderColor="Blue" Font-Bold="True" Font-Names="Lucida Sans" Enabled="False"></asp:TextBox>
                        </div>

                        <br>
                        <hr style=" height: 2px; color:#0000FF; width: 90%;" noshade="noshade">
                        <br>
                        <br>

                        <div class="form-group">
                            <label for="cedula" style="font-family:'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif; font-size: large; color: #000000; font-weight: bold;">Número de Cédula:</label>
                       <asp:TextBox ID="tbIDCard" runat="server" CssClass="form-control" placeholder="Ejemplo:101110011" title="Digite el número de cédula con números seguidos y con división de ceros ejemplo:101110111" BorderColor="Blue" Font-Bold="True" Enabled="False"></asp:TextBox>
                            </div>

                        <hr style=" color: #0000FF; line-height: 10px; height: 2px; width: 80%;" noshade="noshade">
                        <br>
                        <br>

                        <div class="form-group">
                            <label for="Type" style="font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif; font-size: large; color: #000000">Tipo de usuario:</label>
                            <asp:TextBox ID="tbType" CssClass="form-control" runat="server"  title="Indica el tipo de usuario que se desa dehabilitar del sistema" BorderColor="Blue" Font-Bold="True" Font-Names="Lucida Sans" Enabled="False"></asp:TextBox>
                            <br>
                            <br>
                        </div>
                        <br />
            <br />
            <asp:LinkButton ID="btnDisable" runat="server" class="btn btn-default btn-lg, btn btn-primary" OnClick="btbDisable_Click" Height="36px" Width="162px"><i class="fa fa-plus"></i> Deshabilitar</asp:LinkButton>
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
