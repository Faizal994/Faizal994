<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Lecturer.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="UTM_Counselling_System.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Lecturer Panel</h2>
    <h3>Dashboard</h3>


    <div class="row">
        <div class="col-md-12">
            <h2>Pending Session Requests By Date in Current Month</h2>

            <p>
                <asp:Chart ID="ChartPendingConfirmationSession" runat="server" Height="300px" Width="700">
                    <Titles>
                        <asp:Title ShadowOffset="3" Name="Items" />
                    </Titles>

                    <Series>
                        <asp:Series Name="Default" ChartType="Line" />
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea2" BorderWidth="0" />
                    </ChartAreas>
                </asp:Chart>
            </p>
        </div>


        <div class="col-md-12">
            <h2>Confirmed Sessions in Current Month</h2>

            <p>
                <asp:Chart ID="ChartConfirmedSession" runat="server" Height="300px" Width="700">
                    <Titles>
                        <asp:Title ShadowOffset="3" Name="Items" />
                    </Titles>

                    <Series>
                        <asp:Series Name="Default" ChartType="Line" />
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea2" BorderWidth="0" />
                    </ChartAreas>
                </asp:Chart>
            </p>
        </div>


       <%-- <div class="col-md-12">
            <h2>Session Requests By Month</h2>
            <p>

                <asp:Chart ID="Chart1" runat="server" Height="300px" Width="700px" Visible="false">
                    <Titles>
                        <asp:Title ShadowOffset="3" Name="Items" />
                    </Titles>

                    <Series>
                        <asp:Series Name="Default" ChartType="Line" />
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1" BorderWidth="0" />
                    </ChartAreas>
                </asp:Chart>

            </p>

        </div>--%>

    </div>
</asp:Content>
