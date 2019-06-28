    <%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PizzeríaElParque.WebForm1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server">


        <div id="MyModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" style="display: none;" aria-hidden="true">
            <div class="modal-dialog modal-sm">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">×</button>
                        <h4 class="modal-title">Crear Contraseña</h4>
                    </div>
                    <div class="modal-body" style="text-align: center">
                        Digite su contraseña:
                        <br />
                        <asp:TextBox ID="tbNewPassword" runat="server" CssClass="form-control" TextMode="Password">Contraseña</asp:TextBox>
                        <br />
                        <br />
                        Vuelva a digitar su contraseña:
                        <br />
                        <asp:TextBox ID="tbConfirnPassword" runat="server" CssClass="form-control" TextMode="Password">Contraseña</asp:TextBox>
                    </div>
                    <div class="modal-footer">
                    <asp:LinkButton class="btn btn-default btn-lg, btn btn-primary" ID="bntCreate" runat="server" OnClick="newPasswordUser_Click1"> Crear </asp:LinkButton>
                        &nbsp;
                        &nbsp;
                        <button type="button" class="btn btn-secondary" data-dismiss="modal" id="bntExit">Salir</button>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <br />
        <div id="login">
            <div style="text-align: center">
                <div class="well" style="text-align: center">
                    <br />
                    <asp:Label ID="lbnEmployeesName" runat="server" Text="Seleccionar Usuario:" Font-Size="20px" Font-Bold="True" ForeColor="White"></asp:Label>
                    <br />
                    <br />
                    <asp:DropDownList ID="dlEmployees" CssClass="custom-select" runat="server" Height="40px" Width="300px" Font-Size="Small" Font-Bold="True"></asp:DropDownList>
                    <br />
                    <br />
                    <br />
                    <asp:Label ID="lbContraseña" runat="server" Text="Contraseña:" Font-Size="20px" Font-Bold="True" ForeColor="White"></asp:Label>
                    <br />
                    <br />
                    <asp:TextBox ID="tbPassword" runat="server" placeholder="Contraseña" TextMode="Password" Height="35px" Width="300px" Font-Bold="True" Font-Size="Small" ValidateRequestMode="Enabled"></asp:TextBox>
                    <br />
                    <br />
                    <br />
                    <asp:LinkButton class="btn btn-default btn-lg, btn btn-primary" ID="btnLogin" runat="server" OnClick="btnLogin_Click"><i class="fa fa-sign-in"></i> Ingresar</asp:LinkButton>
                    <br />
                    <br />
                </div>
            </div>
        </div>
    </form>

</asp:Content>
