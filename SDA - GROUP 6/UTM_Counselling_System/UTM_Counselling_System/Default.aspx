<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UTM_Counselling_System._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>UTM COUNSELLING SYSTEM</h1> 
        <img src="images/download.png" />
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Student Panel</h2>
            
            <p>
                <a class="btn btn-default" href="StudentLogin.aspx">Login</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Counselling Lecturer Panel</h2>
            
            <p>
                <a class="btn btn-default" href="LecturerLogin.aspx">Login</a>
            </p>
        </div>        
    </div>

</asp:Content>
