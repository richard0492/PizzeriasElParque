<%@ Page Title="" Language="C#" MasterPageFile="~/NestedAdmin.master" AutoEventWireup="true" CodeBehind="DailyReport.aspx.cs" Inherits="PizzeríaElParque.DailyReport" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="row">
    <div class="col-md-12">
        <div class="panel panel-default" style="border-radius: 20px 20px 20px 20px;">
            <div class="panel-body">

                <center>
                    <div style="border: 2px solid #0000FF; text-align:center; width:90%; padding: 10px 10px; box-sizing: border-box; border-radius: 20px 20px 20px 20px;" class="form-inline" role="form">

                        <h1 style="font-family: 'Times New Roman'; font-weight: bold; color: #CC3300;">Reporte De Producto</h1>
                        <hr style=" height: 2px; color:#0000FF; width: 90%;" noshade="noshade" />
                        <asp:Label ID="lbnCodeProduct" runat="server" Text="Codigo del Producto: " Font-Size="Medium "></asp:Label>
                        &nbsp
                        <asp:TextBox ID="TBCodeProduct" runat="server" placeholder="Codigo... " TextMode="search " CssClas="form-control " Height="20px " Width="180px "></asp:TextBox>
                        <br />

                        <div class="form-inline">
                            <br />
                            <br />

                            <asp:Label ID="LBStartDate" runat="server" Text="Label">Fecha Inicial</asp:Label>
                            &nbsp
                            <input type="date" runat="server" name="dllegada" id="StartDateProduct"> &nbsp
                            <asp:Label ID="LBEndDate" runat="server" Text="Label">Fecha Final</asp:Label>
                            &nbsp
                            <input type="date" runat="server" name="dSalida" id="EndDateProduct">

                            <br />
                            <br />

                            <asp:GridView ID="GridViewOneProduct" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="4" RowHeaderColumn="Hola" Width="700px">
                                <AlternatingRowStyle BackColor="#DCDCDC" />
                                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#000065" />
                            </asp:GridView>

                        </div>
                    </div>

                    <hr style=" height: 2px; color:#0000FF; width: 90%;" noshade="noshade" />
                </center>
                <div class="form-inline">
                    <Center>

                        <br />
                        <asp:LinkButton class="btn btn-default btn-lg, btn btn-primary" ID="btnSearchReportProduct" runat="server" OnClick="btnSearchReportProduct_Click"><i class="fa fa-sign-in"></i> Reporte</asp:LinkButton>
                        <asp:LinkButton class="btn btn-default btn-lg, btn btn-primary" ID="btnDRefrech" runat="server" OnClick="btnDRefresh_Click" href="DailyReport.aspx">><i class="fa fa-sign-in"></i> Refrescar</asp:LinkButton>
                        &nbsp &nbsp

                    </Center>

                </div>

            </div>

        </div>

    </div>

</div>
    </asp:Content>