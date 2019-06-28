<%@ Page Title="" Language="C#" MasterPageFile="~/NestedAdmin.master" AutoEventWireup="true" CodeBehind="BetweenDates.aspx.cs" Inherits="PizzeríaElParque.BetweenDates" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-body">
               <%-- %> <center>--%>

                    <div style="text-align:center; width:100%; padding: 10px 10px; box-sizing: border-box;background: rgba(0,0,0,.1); " class="form-inline " role="form ">

                     
                        <br />
                        <div >
                            <div class="form-inline">
                                 <asp:Label ID="lbnCodeProduct" runat="server" Text="Codigo del Producto: "   Font-Size="Medium "></asp:Label>
                                &nbsp                                                                  
                                <asp:TextBox ID="TextBox1" runat="server" placeholder="Codigo... " TextMode="search " CssClas="form-control " Height="20px " Width="180px "></asp:TextBox>
                               
                            </div>

                            <br />
                            <div class="form-inline">
                                
                                
                                <asp:Label ID="Label4" runat="server" Text="Label">Fecha Inicial</asp:Label>
                                &nbsp
                                <input type="date" name="dllegada">
                                &nbsp
                                <asp:Label ID="Label5" runat="server" Text="Label">Fecha Final</asp:Label>
                                &nbsp
                                <input type="date" name="dllegada">
                            </div>
                            
                            <br />
                             <br />
                              
                             <div class="form-inline">
                                 <asp:Label ID="LabelPrueba" runat="server" Text="Codigo del Producto: "   Font-Size="Medium "></asp:Label>
                               
                               <asp:LinkButton class="btn btn-default btn-lg, btn btn-primary" ID="btnProbe" runat="server" OnClick="btnLogin_Click"><i class="fa fa-sign-in"></i> Ingresar</asp:LinkButton>
                               
                            </div>

  
                       <%--  <div class="form-group">
                             
                             <asp:Table ID="Table1" runat="server" Height="43px" Width="456px" CellSpacing="40" CellPadding="10">
                                <asp:TableHeaderRow>
                                    <asp:TableHeaderCell>Fecha Inicial</asp:TableHeaderCell>
                                   
                                     <asp:TableHeaderCell>Fecha Final</asp:TableHeaderCell>
                                </asp:TableHeaderRow>
                                 <asp:TableRow>
                                 <asp:TableCell>

                                     <asp:Calendar ID="Calendar3" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
                                 <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                                 <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                 <OtherMonthDayStyle ForeColor="#999999" />
                                 <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                 <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                                 <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                                 <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                 <WeekendDayStyle BackColor="#CCCCFF" />
                             </asp:Calendar>
                                 </asp:TableCell>
                                  <asp:TableCell>Elegir Fechas</asp:TableCell>
                                     <asp:TableCell> 

                                         <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
                                 <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                                 <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                 <OtherMonthDayStyle ForeColor="#999999" />
                                 <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                 <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                                 <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                                 <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                 <WeekendDayStyle BackColor="#CCCCFF" />
                             </asp:Calendar>
                                     </asp:TableCell>
                             </asp:TableRow>
                             </asp:Table>
                             </div>--%>

                           
                        </div>

                    </div>
               <%--  </center>--%>

            </div>

        </div>

    </div>

</div>
</asp:Content>
