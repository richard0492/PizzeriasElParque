<%@ Page Title="" Language="C#" MasterPageFile="~/NestedCook.master" AutoEventWireup="true" CodeBehind="Cook.aspx.cs" Inherits="PizzeríaElParque.Cook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="MyModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" style="display: none;" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">×</button>
                    <h4 class="modal-title">Detalle de orden</h4>
                    Nombre cliente: <asp:label id="lbClient" runat="server" text="NameClient"></asp:label>
                </div>
                <div class="modal-body" style="text-align: center">
                    <asp:gridview id="lineOrderGridView" runat="server" style="text-align: center" backcolor="White" bordercolor="#CCCCCC" borderstyle="None" borderwidth="1px" cellpadding="3" width="100%" horizontalalign="Center">
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:gridview>

                </div>
                <div class="modal-footer">
                    <asp:linkbutton class="btn btn-success" id="bntDeliver" runat="server" OnClick="bntDeliver_Click"> Entregar </asp:linkbutton>
                    &nbsp;
                        &nbsp;
                        <button type="button" class="btn btn-secondary" data-dismiss="modal" id="bntExit">Salir</button>
                </div>
            </div>
        </div>
    </div>
    <center>
        <div class="modal fade" id="MyModal2" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" style="padding-top:250px">
            <div class="modal-sm" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <h5 class="modal-title" id="exampleModalLongTitle" style="text-align: center">Confirmar Entrega</h5>
                    </div>
                    <div class="modal-body">
                        <asp:Button ID="BntConfirm" class="btn btn-success" runat="server" Text="Aceptar" OnClick="BntConfirm_Click" />
            <asp:Button ID="BntClose" class="btn btn-danger" runat="server" Text="Rechazar" OnClick="BntClose_Click"/>

                    </div>
                </div>
            </div>
        </div>
            </center>
   <%-- <asp:updatepanel id="UpdatePanel1" runat="server">
            <ContentTemplate>--%>

                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="15000">
                </asp:Timer>
    <div class="row" style="padding-top: 15px; padding-left: 10px; padding-right: 10px">
        <div class="col-md-12">
            <div class="panel panel-default" style="border-radius: 20px 20px 20px 20px;">
                <div class="panel-body">
                    <table class="table" style="text-align: center">
                        <thead>
                            <tr style="text-align: center">
                                <th scope="col" style="border-width: thin; border-style: groove; text-align: center">Local</th>
                                <th scope="col" style="border-style: groove; border-width: thin; text-align: center">Express</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <asp:gridview id="localGridview" runat="server" backcolor="White" bordercolor="#CCCCCC" borderstyle="None" borderwidth="1px" cellpadding="3" width="100%" OnRowCommand="localGridview_RowCommand">
                        <Columns>
                            <asp:ButtonField ButtonType="Button"  ControlStyle-CssClass="btn btn-success" CommandName="ButtonDeliver" Text="Entregar" >
<ControlStyle CssClass="btn btn-success"></ControlStyle>
                            </asp:ButtonField>
                            <asp:ButtonField ButtonType="Button"  ControlStyle-CssClass="btn btn-warning" CommandName="ButtonView" Text="Ver Detalles" >
<ControlStyle CssClass="btn btn-warning"></ControlStyle>
                            </asp:ButtonField>
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White"/>
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:gridview>
                                </td>
                                <td>
                                    <asp:gridview id="ExpressGridView" runat="server" backcolor="White" bordercolor="#CCCCCC" borderstyle="None" borderwidth="1px" cellpadding="3" width="100%" OnRowCommand="ExpressGridView_RowCommand">
                        <Columns>
                            <asp:ButtonField ButtonType="Button"  ControlStyle-CssClass="btn btn-success" CommandName="ButtonDeliver" Text="Entregar" />
                            <asp:ButtonField ButtonType="Button"  ControlStyle-CssClass="btn btn-warning" CommandName="ButtonView" Text="Ver Detalles" />
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:gridview>
                                </td>
                            </tr>


                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
                <%--</ContentTemplate>
            
        </asp:updatepanel>--%>
</asp:Content>

