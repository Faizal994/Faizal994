<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentSessions.aspx.cs" Inherits="UTM_Counselling_System.StudentSessions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <style>
        <style>
        table {
            font-family: arial, sans-serif;
            border-collapse: collapse;
            width: 100%;
        }

        td, th {
            border: 1px solid #dddddd;
            text-align: left;
            padding: 8px;
        }

        tr:nth-child(even) {
            background-color: #dddddd;
        }
    </style>


    <h2>Student Panel</h2>
    <h3>Counselling Sessions</h3>

    <div class="row">
        <div class="col-md-12">
            <p>



                <asp:GridView ID="GridViewSession" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="4" ForeColor="#333333" 
                    GridLines="None" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridViewSession_RowDeleting">

                    <AlternatingRowStyle BackColor="White" />

                    <Columns>

                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%#Bind("SessionID")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="Lecturer">
                            <ItemTemplate>
                                <asp:Label ID="lblLecturerName" runat="server" Text='<%#Bind("LecturerName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Reason">
                            <ItemTemplate>
                                <asp:Label ID="lblSessionReason" runat="server" Text='<%#Bind("SessionReason") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Session Date-Time">
                            <ItemTemplate>
                                <asp:Label ID="lblSessionDateTime" runat="server" Text='<%#Bind("SessionDateTime") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>                        

                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="lblSessionStatus" runat="server" Text='<%#Bind("SessionStatus") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                       

                      <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:Button Text="Cancel Session" runat="server" OnClientClick="return confirm('Are you sure you want to cancel this session request?');"
                                    CommandName="CancelSession" CommandArgument="<%# Container.DataItemIndex %>" 
                                    Visible='<%# Eval("SessionStatus").ToString() == "Pending Confirmation" ? true : false %>' />
                            </ItemTemplate>
                        </asp:TemplateField>


                    </Columns>


                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />


                </asp:GridView>


                <br />

                <asp:Button ID="btnAdd" runat="server" Text="Book a Counselling Session" OnClick="btnAdd_Click" />





            </p>

        </div>

    </div>
</asp:Content>
