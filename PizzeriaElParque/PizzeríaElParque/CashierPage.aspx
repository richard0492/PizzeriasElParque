<%@ Page Title="" Language="C#" MasterPageFile="~/NestedCashier.master" AutoEventWireup="true" CodeBehind="CashierPage.aspx.cs" Inherits="PizzeríaElParque.CashierPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-body" style="text-align:center">
                    <h1>Bienvenido</h1>
                    <br />
                    <br />
                    <asp:Label ID="lbNombre" runat="server" Text="Nombre" Font-Size="20px"></asp:Label>
                    <br />
                    <br />
                    <p> Puede acceder a las funciones en el menú de la izquierda</p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
