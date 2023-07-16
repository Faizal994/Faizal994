<%@ Page Title="Counselling Lecturer Login" Language="C#" MasterPageFile="~/Lecturer.Master" AutoEventWireup="true" CodeBehind="LecturerLogin.aspx.cs" Inherits="UTM_Counselling_System.LecturerLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <style>
        body {
            font-family: Arial, Helvetica, sans-serif;
        }

        form {
            border: 3px solid #f1f1f1;
        }

        input[type=text], input[type=password] {
            width: 100%;
            padding: 12px 20px;
            margin: 8px 0;
            display: inline-block;
            border: 1px solid #ccc;
            box-sizing: border-box;
        }

        button {
            background-color: #376064;
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            cursor: pointer;
            width: 20%;
        }

            button:hover {
                opacity: 0.8;
            }

        .cancelbtn {
            width: auto;
            padding: 10px 18px;
            background-color: #f44336;
        }

        .imgcontainer {
            text-align: center;
            margin: 24px 0 12px 0;
        }

        img.avatar {
            width: 40%;
            border-radius: 50%;
        }

        .container {
            padding: 16px;
        }

        span.psw {
            float: right;
            padding-top: 16px;
        }

        /* Change styles for span and cancel button on extra small screens */
        @media screen and (max-width: 300px) {
            span.psw {
                display: block;
                float: none;
            }

            .cancelbtn {
                width: 100%;
            }
        }

        table {
            border-collapse: collapse;
            width: 100%;
            color: #333;
            font-family: Arial, sans-serif;
            font-size: 14px;
            text-align: left;
            border-radius: 10px;
            overflow: hidden;
            box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
            margin: auto;
            margin-top: 5px;
            margin-bottom: 5px;
        }
    </style>


    <h2>Couselling Lecturer Panel</h2>
    <h3>Login</h3>
    

    <div class="container">
        <table>
            <tr>
                <td>
                    <label for="uname"><b>Email</b></label>
                </td>
                <td>
                    <input type="text" placeholder="Enter Email" name="email" id="email" runat="server" required>
                </td>
            </tr>
            <tr>
                <td>
                    <label for="psw"><b>Password</b></label>
                </td>
                <td>
                    <input type="password" placeholder="Enter Password" name="psw" id="pwd" runat="server" required>
                </td>
            </tr>
        </table>

        <div class="container" style="background-color: #f1f1f1">

            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary w-100 py-3" Text="Login" OnClick="btnSubmit_Click"/>
           <%--  <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel"/> --%>

            
            <span class="psw">Sign Up <a href="LecturerSignup.aspx"><b>HERE</b></a></span>
        </div>
    </div>


</asp:Content>
