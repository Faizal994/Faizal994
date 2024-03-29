﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Support.aspx.cs" Inherits="UTM_Counselling_System.Support" %>
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


    <h2>Student Panel</h2>
    <h3>Support</h3>


   <div class="container">

        <table>
            
            <tr>
                <td>
                    <label for="session"><b>Support Reason</b></label>
                </td>
                <td>
                    <textarea style="height: 100px; width: 300px" id="tasupportreason" runat="server" required></textarea>
                </td>
            </tr>
            <tr>
                <td>
                    <label for="lecturer"><b>Counselling Lecturer</b></label>
                </td>
                <td>
                    <asp:DropDownList ID="ddl_CounsellingLecturer" runat="server" Width="100%" ForeColor="Black">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvMenuCat" runat="server" Text="*" ForeColor="Red" SetFocusOnError="true" InitialValue="0"  ControlToValidate="ddl_CounsellingLecturer"></asp:RequiredFieldValidator>
                </td>
            </tr>


        </table>


        <div class="container" style="background-color: #f1f1f1">
            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary w-100 py-3" Text="Submit" OnClick="btnSubmit_Click" />
           <%-- <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel" />--%>
        </div>
    </div>



</asp:Content>
