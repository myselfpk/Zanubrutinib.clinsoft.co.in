<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Clinsoft | Forgot Password</title>
    <link rel="icon" type="image/png" href="images/tabIcon.png" sizes="96x96" />
    <link href="css/Login.css" rel="stylesheet" type="text/css" media="all" />
    <link href='http://fonts.googleapis.com/css?family=Rokkitt' rel='stylesheet' type='text/css' />
</head>

    <div class="wrap">
        <!-- strat-contact-form -->
        <div class="contact-form">
            <!-- start-form -->
            <form class="contact_form" action="#" method="post" name="contact_form" runat="server">
                
                <h1>Forgot Your Password?</h1>


                <h6>Enter your Login ID to receive your password.</h6>

                <ul>
                    <li>
                        <asp:TextBox ID="txtemail" runat="server" class="textbox1" placeholder="Login ID" required=""  oninvalid="this.setCustomValidity('Please enter valid login Id')" oninput="setCustomValidity('')"></asp:TextBox>
                        <span class="form_hint">Enter Login ID</span>
                        <p>
                            <img src="images/contact.png" alt="" />
                        </p>
                    </li>
                </ul>
                <asp:Button ID="btnsend" runat="server" CommandName="Login" Text="Send" OnClick="btnsend_Click" />
                
                <div class="checkbox">
                    <asp:Label ID="lbresult" runat="server"></asp:Label>
                </div>
                <div class="clear"></div>
                <div class="forgot">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Login.aspx">Back to login page.</asp:HyperLink>
                </div>
                <div class="clear"></div>

            </form>
            <!-- end-form -->
            <!-- start-account -->
            <div class="account" style="align-items: center">
                
                <div class="span">
                   
                    <a href="#">
                        <img src="images/ClinSoft-(Logo)-opt-3.jpg" alt="" />
                    </a>
                </div>
            </div>
            <!-- end-account -->
            <div class="clear"></div>
        </div>
        <!-- end-contact-form -->
       
    </div>


</html>
