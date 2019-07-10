<%@ Page Title="" Language="C#" MasterPageFile="~/NestedAdmin.master" AutoEventWireup="true" CodeBehind="AddOrderAdmin.aspx.cs" Inherits="PizzeríaElParque.AddOrderAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default" style="border-radius: 20px 20px 20px 20px;">
                <div class="panel-body">
                    <center>
                    <div style="border: 2px solid #0000FF; text-align:center; width:90%; padding: 10px 10px; box-sizing: border-box; border-radius: 20px 20px 20px 20px;" class="form-inline" role="form">
                      <h1 style="font-family: 'Times New Roman'; font-weight: bold; color: #CC3300;">Ingresar Orden</h1>
                        <hr style=" height: 2px; color:#0000FF; width: 90%;" noshade="noshade" />

                        <div class="form-group">
                            <label for="name" style="font-size: medium; font-family: Verdana, Geneva, Tahoma, sans-serif; color: #000000;">Nombre del Cliente:</label>
                            <asp:TextBox type="text" CssClass="form-control" ID="txtClientName" runat="server" BorderColor="Blue" Font-Bold="True" Font-Names="Lucida Sans"></asp:TextBox>
                            <asp:Label ID="lbtable" runat="server" Text="Número de mesa" style="font-size: medium; font-family: Verdana, Geneva, Tahoma, sans-serif; color: #000000;"></asp:Label>
                            <asp:TextBox type="number" CssClass="form-control" ID="txtNumTable" runat="server" aria-placeholder="opcional" BorderColor="Blue" Font-Bold="True" Font-Names="Lucida Sans" Width="110px" MaxLength ="3" ></asp:TextBox>
                        </div>

                        <br />

                        <br/>

                        <div class="form-group">
                            <label for="lastName" style="font-family: Verdana, Geneva, Tahoma, sans-serif; font-size: medium; color: #000000">Tipo de Orden:</label>&nbsp;
                        </div>
                        <br />
<asp:LinkButton id="btnLocal" style="color: #FFFFFF; font-weight: bold; background-color: #800000; border: 3px solid #000000" runat="server" OnClick="btnLocal_Click" Width="150px" Height="60px">Local</asp:LinkButton>
        &nbsp;<asp:LinkButton id="btnExpress" style="color: #FFFFFF; font-weight: bold; background-color: #800000; border: 3px solid #000000;"  runat="server" Width="150px" Height="60px" OnClick="btnExpress_Click">Express</asp:LinkButton>               
                        <br>
                        <hr style=" height: 2px; color:#0000FF; width: 90%;" noshade="noshade">
                         <asp:LinkButton ID="addProduct" runat="server" class="btn btn-default btn-lg, btn btn-primary"  BackColor="Maroon" Font-Bold="True" Font-Size="Medium" Height="41px" Width="242px" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" ForeColor="White"><i class="fa fa-plus"></i> Agregar producto a orden</asp:LinkButton>
           
                        <br>
                        <br>

                        <div class="form-group">

                        </div>

                        <hr style=" color: #0000FF; line-height: 10px; height: 2px; width: 80%;" noshade="noshade">
                        <br>
                        <br>

                        <div class="form-group">
<asp:Label id="direction" runat="server" Text="Dirección" style="font-family: Verdana, Geneva, Tahoma, sans-serif; font-size: medium; color: #000000" Visible="false"></asp:Label>
                           
                            <asp:TextBox ID="tbDirection" runat="server" Height="87px" TextMode="MultiLine" Width="225px" Font-Bold="True" Font-Names="Lucida Sans" Visible="false"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
<asp:Label id="phone" runat="server" Text="Teléfono" style="font-family: Verdana, Geneva, Tahoma, sans-serif; font-size: medium; color: #000000" Visible="false"></asp:Label>
                            <asp:TextBox ID="tbPhone" runat="server" TextMode="Number" Font-Bold="True" Font-Names="Lucida Sans" Visible="false"></asp:TextBox>
                            
                            <br>
                        </div>
                        <br />
            <br />
            <asp:LinkButton ID="btnAgregar" runat="server" class="btn btn-default btn-lg, btn btn-primary"   Font-Bold="True" Font-Size="Medium" Height="49px" Width="143px"><i class="fa fa-plus"></i> Enviar Orden</asp:LinkButton>
            <br />
            <br />
            <br />
                    </div>
                </center>

                </div>


            </div>

        </div>

    </div>
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>

</asp:Content>
