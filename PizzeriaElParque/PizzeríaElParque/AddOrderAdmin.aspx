<%@ Page Title="" Language="C#" MasterPageFile="~/NestedAdmin.master" AutoEventWireup="true" CodeBehind="AddOrderAdmin.aspx.cs" Inherits="PizzeríaElParque.AddOrderAdmin" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="row">
            <div class="col-md-12">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <center>
                            <div  style="border: 2px solid #0000FF; text-align:center; width:90%; padding: 10px 10px; box-sizing: border-box;
                     background: rgba(0,0,0,.1);" class="form-inline" role="form">
                                <h1 style="font-family: 'Times New Roman'; font-weight: bold; color: #CC3300;">Ingresar Orden</h1>
                                <hr style=" height: -39px; color:#0000FF; width: 90%;" noshade="noshade" />

                                
                                    <label for="name" style="font-size: medium; font-family: Verdana, Geneva, Tahoma, sans-serif; color: #000000;">Nombre del Cliente:</label>
                                    <asp:TextBox type="text" CssClass="form-control" ID="txtClientName" runat="server" BorderColor="Blue" Font-Bold="True" Font-Names="Lucida Sans"></asp:TextBox>
                                    <asp:Label ID="lbtable" runat="server" Text="Número de mesa:" style="font-size: medium; font-family: Verdana, Geneva, Tahoma, sans-serif; color: #000000;" Font-Bold="True"></asp:Label>
                                    <asp:TextBox type="number" CssClass="form-control" ID="txtNumTable" runat="server" aria-placeholder="opcional" BorderColor="Blue" Font-Bold="True" Font-Names="Lucida Sans" Width="110px" MaxLength="3">1</asp:TextBox>
                                

                                <br />

                                <br/>

                               
                                    <label for="lastName" style="font-family: Verdana, Geneva, Tahoma, sans-serif; font-size: medium; color: #000000">Tipo de Orden:</label>&nbsp;<br>
                                    <br />
                                    <asp:LinkButton id="btnLocal" style="color: #FFFFFF; font-weight: bold; background-color: #800000; border: 3px solid #000000" runat="server" OnClick="btnLocal_Click" Width="150px" Height="50px" Font-Bold="True" Font-Size="Larger">Local &nbsp;&nbsp;<asp:Label ID="checkLocal" class="fa fa-check-square-o fa-2x" runat="server" Text=""></asp:Label></asp:LinkButton>
                                    &nbsp;
                                    <asp:LinkButton id="btnExpress" style="color: #FFFFFF; font-weight: bold; background-color: #800000; border: 3px solid #000000;" runat="server" Width="150px" Height="50px" OnClick="btnExpress_Click" Font-Bold="True" Font-Size="Larger">Express &nbsp;&nbsp;<asp:Label ID="checkExpress" class="fa fa-check-square-o fa-2x" runat="server" Text="" Visible="False"></asp:Label></asp:LinkButton>
                                    <br>
                                    <hr style=" height: 2px; color:#0000FF; width: 90%;" noshade="noshade">
                                
                              

                              

                                
                                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Código producto:"></asp:Label>
                                 
                                &nbsp;&nbsp;
                                <asp:TextBox ID="txtProductCode" runat="server"></asp:TextBox>
                                 
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:LinkButton ID="addProduct" runat="server" class="btn btn-default btn-lg, btn btn-primary" BackColor="Maroon" Font-Bold="True" Font-Size="Medium" Height="39px" Width="235px" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" ForeColor="White" OnClick="addProduct_Click"><i class="fa fa-plus"></i> Agregar producto a orden</asp:LinkButton>

                                <br>
                                <br>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
<asp:ScriptManager runat="server"></asp:ScriptManager>

<asp:Timer runat="server" Interval="3000" OnTick="Unnamed2_Tick"></asp:Timer>
    <center>
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="700px" OnRowDeleting="GridView1_RowDeleting" CssClass="table-responsive" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" Font-Bold="True" Font-Size="Large">
                                        <Columns>
                                            <asp:CommandField ShowDeleteButton="True" HeaderText="Editar" ButtonType="Button">
                                                <ControlStyle BackColor="Maroon" BorderColor="Black" BorderStyle="Solid" Font-Bold="True" ForeColor="White" />
                                            </asp:CommandField>
                                            <asp:BoundField DataField="codigoProducto" HeaderText="Código" />
                                            <asp:BoundField DataField="descripcionProducto" HeaderText="Nombre" />
                                            <asp:BoundField DataField="precioProducto" HeaderText="Precio/₡" />
                                            <asp:TemplateField HeaderText="Cantidad">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Height="19px" Width="73px"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="subTotal" HeaderText="SubTotal/₡" />
                                        </Columns>
                                        <FooterStyle BackColor="#CCCCCC" />
                                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                                        <RowStyle BackColor="White" />
                                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                        <SortedAscendingHeaderStyle BackColor="#808080" />
                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                        <SortedDescendingHeaderStyle BackColor="#383838" />
                                    </asp:GridView>
                                    </center>
    
                                
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Total a Pagar:" ForeColor="Black" Font-Size="X-Large"></asp:Label>
                                    &nbsp;
                                    <asp:Label ID="lbTotal" runat="server" Font-Bold="True" ForeColor="Black" Font-Size="X-Large"></asp:Label>
                               

                                    <br />
                                    <br />
                               

                               </ContentTemplate>
</asp:UpdatePanel>
 <asp:Label ID="lbDescription" runat="server" Text="Descripción de la orden:" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                    <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" Height="80px" TextMode="MultiLine" Width="481px" style="max-height:80px;max-width:480px;min-height:80px;min-width:480px;" Font-Bold="True"></asp:TextBox>
                                   
                               
                                     <hr style=" color: #0000FF; line-height: 10px; height: 2px; width: 80%;" noshade="noshade">
                                <br>
                                <br>
                                    <asp:Label id="direction" runat="server" Text="Dirección:" style="font-family: Verdana, Geneva, Tahoma, sans-serif; font-size: medium; color: #000000" Visible="False" Font-Bold="True"></asp:Label>

                                    &nbsp;

                                    <asp:TextBox ID="tbDirection" CssClass="form-control" runat="server" Height="87px" TextMode="MultiLine" Width="225px" Font-Bold="True" Font-Names="Lucida Sans" Visible="false" MaxLength="200" style="max-height:300px;max-width:300px;min-height:87px;min-width:200px;"></asp:TextBox>

                                    <asp:Label id="phone" runat="server" Text="Teléfono:" style="font-family: Verdana, Geneva, Tahoma, sans-serif; font-size: medium; color: #000000" Visible="False" Font-Bold="True"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:TextBox ID="tbPhone" runat="server" TextMode="Number" CssClass="form-control" Font-Bold="True" Font-Names="Lucida Sans" Visible="false"></asp:TextBox>
                                    <br>
                                    <br>
                                     <br />
                                <asp:LinkButton ID="btnAgregar" runat="server" class="btn btn-default btn-lg, btn btn-primary" Font-Bold="True" Font-Size="Medium" Height="49px" Width="143px" OnClick="btnAgregar_Click"><i class="fa fa-plus"></i> Enviar Orden</asp:LinkButton>
                                <br />
                                <br />
                                <br />
                                
<div id="MyModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" style="margin: 15% 0% 0% 0%; display: none;" aria-hidden="true">
            <div class="modal-dialog modal-lg">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title" style="font-family: 'Times New Roman', Times, serif; font-size: medium; font-weight: bold">Confirmación</h1>
                    </div>
                    <div class="modal-body" style="text-align: center">
                    <asp:Label ID="lbConfirm" runat="server"   Font-Size="Medium" Font-Bold="True">Su orden se agregó <i>correctamente</i></asp:Label>
                    </div>
                    <div class="modal-footer">
                  
                       <center><asp:LinkButton ID="lnkRedireccion" runat="server" CssClass="btn btn-success" OnClick="lnkRedireccion_Click"   BorderStyle="Solid" ForeColor="White" Text="Aceptar" Font-Bold="True" Height="55px" Width="300px" Font-Size="20px"></asp:LinkButton></center>
                     </div>
                </div>
            </div>
        </div><br />
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