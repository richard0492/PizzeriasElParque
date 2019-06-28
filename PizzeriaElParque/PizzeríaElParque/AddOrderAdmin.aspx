<%@ Page Title="" Language="C#" MasterPageFile="~/NestedAdmin.master" AutoEventWireup="true" CodeBehind="AddOrderAdmin.aspx.cs" Inherits="PizzeríaElParque.AddOrderAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="MyModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" style="display: none;" aria-hidden="true">
        <div class="modal-dialog modal-sm">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">×</button>
                    <h4 class="modal-title">Agregar Pedido</h4>
                </div>
                <div class="modal-body" style="text-align: center">
                    Digite el código del producto:
                        <br />
                    <asp:TextBox ID="tbCode" runat="server" CssClass="form-control"></asp:TextBox>
                    <br />
                    <br />
                    Digite la cantidad:
                        <br />
                    <asp:TextBox ID="tbquantity" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="modal-footer">
                    <asp:LinkButton class="btn btn-default btn-lg, btn btn-success" ID="bntCreate" runat="server" OnClick="bntCreate_Click" PostBackUrl="~/AddOrderAdmin.aspx"> Agregar </asp:LinkButton>
                    &nbsp;
                        &nbsp;
                        <button type="button" class="btn btn-secondary" data-dismiss="modal" id="bntExit">Salir</button>
                </div>
            </div>
        </div>
    </div>
    <div id="MyModal2" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" style="display: none;" aria-hidden="true">
        <div class="modal-dialog modal-sm">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">×</button>
                    <h4 class="modal-title">Modificar Pedido</h4>
                </div>
                <div class="modal-body" style="text-align: center">
                    Digite el código del producto:
                        <br />
                    <asp:TextBox ID="tbCodeModify" runat="server" CssClass="form-control"></asp:TextBox>
                    <br />
                    <br />
                    Producto:
                        <br />
                    <asp:TextBox ID="tbNameProduct" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    <br />
                    <br />
                    Digite la cantidad:
                        <br />
                    <asp:TextBox ID="tbquantityModify" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="modal-footer">
                    <asp:LinkButton class="btn btn-default btn-lg, btn btn-warning" ID="btnModify" runat="server" PostBackUrl="~/AddOrderAdmin.aspx" OnClick="btnModify_Click"> Modificar </asp:LinkButton>
                    &nbsp;
                        &nbsp;
                    <asp:LinkButton class="btn btn-default btn-lg, btn btn-danger" ID="btnDelete" runat="server" PostBackUrl="~/AddOrderAdmin.aspx" OnClick="btnDelete_Click"> Eliminar </asp:LinkButton>
                    &nbsp;
                        &nbsp;
                </div>
            </div>
        </div>
    </div>

    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
    <asp:GridView ID="GridView1" runat="server" OnRowCommand="GridView1_RowCommand" Width="371px">
        <Columns>
            <asp:CommandField ButtonType="Button" SelectText="Modificar" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>
