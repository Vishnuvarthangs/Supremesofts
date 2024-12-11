<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
   <%-- <h3>Contact Us</h3>--%>
    <address>
        Supreme Softs,
        No 8, Mariyamman Kovil Cross Street
        Mathiyazhagan Nagar,Padi,
        Chennai-600050,
        Tamil Nadu,India.
    </address>

    <address>
        <strong>Contact:</strong>  +044- 4283 3856, +91-7448319241<br />
        <strong>Email :</strong> <a href="mailto:admin@supremesofts.com">admin@supremesofts.com</a>
    </address>

    <style>
    .google-maps {
        position: relative;
        padding-bottom: 50%; /*This is the aspect ratio*/
        height: 0;
        overflow: hidden;
    }
    .google-maps iframe {
        position: absolute;
        top: 0;
        left: 0;
        width: 75% !important;
        height: 75% !important;
    }
    
    </style>
</asp:Content>
