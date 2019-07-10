<%@ Page Title="" Language="C#" MasterPageFile="~/NestedAdmin.master" AutoEventWireup="true" CodeBehind="AddOrderAdmin.aspx.cs" Inherits="PizzeríaElParque.AddOrderAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


 <div class="row">
    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-body">
                <center>
                    <div style="border: 2px solid #0000FF; text-align:center; width:90%; padding: 10px 10px; box-sizing: border-box;
                     background: rgba(0,0,0,.1);" class="form-inline" role="form">
                        <h1 style="font-family: 'Times New Roman'; font-weight: bold; color: #CC3300;">Ingresar Orden</h1>
                        <hr style=" height: 2px; color:#0000FF; width: 90%;" noshade="noshade" />

                        <div class="form-group">
                            <label for="name" style="font-size: medium; font-family: Verdana, Geneva, Tahoma, sans-serif; color: #000000;">Nombre del Cliente:</label>
                            <asp:TextBox type="text" CssClass="form-control" ID="txtClientName" runat="server" BorderColor="Blue" Font-Bold="True" Font-Names="Lucida Sans"></asp:TextBox>
                            <label for="secondName" style="font-size: medium; font-family: Verdana, Geneva, Tahoma, sans-serif; color: #000000;">Número de mesa:</label>
                            <asp:TextBox type="number" CssClass="form-control" ID="txtNumTable" runat="server" aria-placeholder="opcional" BorderColor="Blue" Font-Bold="True" Font-Names="Lucida Sans" Width="110px" MaxLength ="3" ></asp:TextBox>
                        </div>

                        <br />

                        <br/>

                        <div class="form-group">
                            <label for="lastName" style="font-family: Verdana, Geneva, Tahoma, sans-serif; font-size: medium; color: #000000">Tipo de Orden:</label>&nbsp;
                        </div>
                        <br />
                       <button id="btnLocal" style="color: #FFFFFF; font-weight: bold; background-color: #800000; border: 3px solid #000000; height: 50px; width: 140px;">Local</button>
                        <button id="btnExpress" style="color: #FFFFFF; font-weight: bold; background-color: #800000; border: 3px solid #000000; height: 51px; width: 140px;">Express</button>
                        <br>
                        <hr style=" height: 2px; color:#0000FF; width: 90%;" noshade="noshade">
                         <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Código producto:"></asp:Label>
&nbsp;&nbsp;
                        <asp:TextBox ID="txtProductCode" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:LinkButton ID="addProduct" runat="server" class="btn btn-default btn-lg, btn btn-primary"  BackColor="Maroon" Font-Bold="True" Font-Size="Medium" Height="16px" Width="210px" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" ForeColor="White" OnClick="addProduct_Click"><i class="fa fa-plus"></i> Agregar producto a orden</asp:LinkButton>
           
                        <br>
                        <br>

                        <div class="form-group">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="505px"
                    OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting"
                    OnRowDeleted="GridView1_RowDeleted" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CssClass="table-responsive">
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" HeaderText="Editar" />
                        <asp:BoundField DataField="codproducto" HeaderText="Codigo" />
                        <asp:BoundField DataField="desproducto" HeaderText="Descripcion" />
                        <asp:BoundField DataField="preproducto" HeaderText="Precio" />
                        <asp:TemplateField HeaderText="Cantidad">
                            <ItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Height="19px" Width="73px">1</asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="subtotal" HeaderText="Sub Total" />
                    </Columns>
                </asp:GridView>   
                        </div>

                        <hr style=" color: #0000FF; line-height: 10px; height: 2px; width: 80%;" noshade="noshade">
                        <br>
                        <br>

                        <div class="form-group">
                            <label for="Type" style="font-family: Verdana, Geneva, Tahoma, sans-serif; font-size: medium; color: #000000">Dirección:</label>
                           
                            <asp:TextBox ID="TextBox1" runat="server" Height="87px" TextMode="MultiLine" Width="225px" Font-Bold="True" Font-Names="Lucida Sans"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
                            <label for="Type" style="font-family: Verdana, Geneva, Tahoma, sans-serif; font-size: medium; color: #000000">&nbsp;&nbsp;&nbsp; Teléfono:<asp:TextBox ID="TextBox2" runat="server" TextMode="Number" Font-Bold="True" Font-Names="Lucida Sans"></asp:TextBox>
                            </label>
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
    
</asp:Content>
