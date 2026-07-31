<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server">
    <title>ClinSoft | Sign in</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="icon" type="image/png" href="images/tabIcon.png" sizes="500x302" />
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="~/css/Login.css?v=20260731.1" rel="stylesheet" type="text/css" media="all" runat="server" />
</head>
<body class="login-page">
    <main class="login-shell">
        <section class="login-intro" aria-label="Study information">
            <div class="intro-content">
                <span class="intro-badge">Clinical data management</span>
                <h1>Reliable study data, in one secure workspace.</h1>
                <p>Access subject records, study documents, queries and monitoring workflows for protocol GPL ZANU-401.</p>
                <div class="protocol-card">
                    <span>Active protocol</span>
                    <strong>GPL ZANU-401</strong>
                </div>
            </div>
        </section>
        <section class="login-panel" aria-labelledby="loginTitle">
            <form id="loginForm" class="login-card" runat="server" autocomplete="on">
                <div class="brand-row">
                    <img class="brand-logo" src="images/ClinSoft-(Logo)-opt-3.jpg" width="120" height="69" alt="ClinSoft — Your Electronic Data Partner" />
                    <span>Clinical Study Portal</span>
                </div>
                <div class="login-heading">
                    <span class="eyebrow">Welcome back</span>
                    <h2 id="loginTitle">Sign in to your account</h2>
                    <p>Enter your assigned credentials to continue.</p>
                </div>
                <div class="form-group">
                    <label for="txtLogin">Login ID</label>
                    <div class="input-wrap">
                        <span class="input-icon" aria-hidden="true">
                            <svg viewBox="0 0 24 24" focusable="false"><path d="M12 12a4 4 0 1 0 0-8 4 4 0 0 0 0 8Zm-7 8a7 7 0 0 1 14 0" /></svg>
                        </span>
                        <asp:TextBox ID="txtLogin" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="Enter login ID" autocomplete="username" MaxLength="25" required="" aria-required="true" aria-describedby="LoginRequiredValidator lblError" oninvalid="this.setCustomValidity('Please enter your login ID')" oninput="setCustomValidity('')"></asp:TextBox>
                    </div>
                    <asp:RequiredFieldValidator ID="LoginRequiredValidator" ClientIDMode="Static" runat="server" ControlToValidate="txtLogin" ValidationGroup="Login1" Display="Dynamic" CssClass="field-error" ErrorMessage="Login ID is required." role="alert" />
                </div>
                <div class="form-group">
                    <div class="field-label-row">
                        <label for="txtPassword">Password</label>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ForgotPassword.aspx">Forgot password?</asp:HyperLink>
                    </div>
                    <div class="input-wrap">
                        <span class="input-icon" aria-hidden="true">
                            <svg viewBox="0 0 24 24" focusable="false"><rect x="5" y="10" width="14" height="10" rx="2" /><path d="M8 10V7a4 4 0 0 1 8 0v3" /></svg>
                        </span>
                        <asp:TextBox ID="txtPassword" ClientIDMode="Static" runat="server" CssClass="form-control" TextMode="Password" placeholder="Enter password" autocomplete="current-password" MaxLength="128" required="" aria-required="true" aria-describedby="PasswordRequiredValidator lblError" oninvalid="this.setCustomValidity('Please enter your password')" oninput="setCustomValidity('')"></asp:TextBox>
                    </div>
                    <asp:RequiredFieldValidator ID="PasswordRequiredValidator" ClientIDMode="Static" runat="server" ControlToValidate="txtPassword" ValidationGroup="Login1" Display="Dynamic" CssClass="field-error" ErrorMessage="Password is required." role="alert" />
                </div>
                <asp:Label ID="lblError" ClientIDMode="Static" runat="server" CssClass="login-error" role="alert"></asp:Label>
                <asp:Button ID="LoginButton" runat="server" Text="Sign in securely" CssClass="btn btn-primary btn-block login-button" ValidationGroup="Login1" OnClick="LoginButton_Click" />
                <p class="support-note">Having trouble signing in? Contact your study administrator.</p>
            </form>
        </section>
    </main>
</body>
</html>
