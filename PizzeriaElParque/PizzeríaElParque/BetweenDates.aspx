<%@ Page Title="" Language="C#" MasterPageFile="~/NestedAdmin.master" AutoEventWireup="true" CodeBehind="BetweenDates.aspx.cs" Inherits="PizzeríaElParque.BetweenDates" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
    <div class="col-md-12">
        <div class="panel panel-default" style="border-radius: 20px 20px 20px 20px;">
            <div class="panel-body">

                <center>
                    <div style="border: 2px solid #0000FF; text-align:center; width:90%; padding: 10px 10px; box-sizing: border-box; border-radius: 20px 20px 20px 20px;" class="form-inline" role="form">

                        <h1 style="font-family: 'Times New Roman'; font-weight: bold; color: #CC3300;">Reporte De Productos</h1>
                        <hr style=" height: 2px; color:#0000FF; width: 90%;" noshade="noshade" />

                        <br />
                        <br />

                        <asp:Label ID="LBStartDateBD" runat="server" Text="Label">Fecha Inicial</asp:Label>
                        &nbsp
                        <input type="date" runat="server" name="dllegada" id="StartDateProductBD"> &nbsp
                        <asp:Label ID="LBEndDateBD" runat="server" Text="Label">Fecha Final</asp:Label>
                        &nbsp
                        <input type="date" runat="server" name="dSalida" id="EndDateProductBD">

                      <br />
                      <br />
                      <br />


                    <asp:GridView ID="GridViewBetweenDates" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="4" RowHeaderColumn="Hola" Width="700px">
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" ForeColor="#330099" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#0000A9" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#000065" />
                    </asp:GridView>

                    </div>

                    <hr style=" height: 2px; color:#0000FF; width: 90%;" noshade="noshade" />

                     


                </Center>
            </div>

            <div class="form-inline">

                <Center>
                     
                    <br />
                    
                    <asp:LinkButton class="btn btn-default btn-lg, btn btn-primary" ID="btnSearchBD" runat="server" OnClick="btnSearchReportProductBD_Click"><i class="fa fa-sign-in"></i> Reporte</asp:LinkButton>
                   
                  
                    <asp:LinkButton class="btn btn-default btn-lg, btn btn-primary" ID="btnRefrech" runat="server" OnClick="btnRefresh_Click" href="BetweenDates.aspx">><i class="fa fa-sign-in"></i> Refrescar</asp:LinkButton>
              
                </Center>

            </div>

        </div>

    </div>

</div>
</asp:Content>