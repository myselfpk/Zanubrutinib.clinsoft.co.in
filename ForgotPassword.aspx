<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server">
    <title>ClinSoft | Account recovery</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="icon" type="image/png" href="images/tabIcon.png" sizes="500x302" />
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="~/css/Login.css?v=20260731.2" rel="stylesheet" type="text/css" media="all" runat="server" />
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
        <section class="login-panel" aria-labelledby="forgotPasswordTitle">
            <form id="forgotPasswordForm" class="login-card recovery-card" runat="server" autocomplete="on">
                <div class="brand-row">
                    <img class="brand-logo" src="images/ClinSoft-(Logo)-opt-3.jpg" width="120" height="69" alt="ClinSoft — Your Electronic Data Partner" />
                    <span>Clinical Study Portal</span>
                </div>
                <div class="login-heading">
                    <span class="eyebrow">Account recovery</span>
                    <h2 id="forgotPasswordTitle">Forgot your password?</h2>
                    <p>Enter your assigned Login ID and we’ll send recovery details to your registered email address.</p>
                </div>
                <div class="form-group">
                    <label for="txtemail">Login ID</label>
                    <div class="input-wrap">
                        <span class="input-icon" aria-hidden="true">
                            <svg viewBox="0 0 24 24" focusable="false"><path d="M12 12a4 4 0 1 0 0-8 4 4 0 0 0 0 8Zm-7 8a7 7 0 0 1 14 0" /></svg>
                        </span>
                        <asp:TextBox ID="txtemail" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="Enter login ID" autocomplete="username" MaxLength="25" required="" aria-required="true" aria-describedby="ForgotLoginRequiredValidator lbresult" oninvalid="this.setCustomValidity('Please enter your login ID')" oninput="setCustomValidity('')"></asp:TextBox>
                    </div>
                    <asp:RequiredFieldValidator ID="ForgotLoginRequiredValidator" ClientIDMode="Static" runat="server" ControlToValidate="txtemail" ValidationGroup="ForgotPassword" Display="Dynamic" CssClass="field-error" ErrorMessage="Login ID is required." role="alert" />
                </div>
                <asp:Label ID="lbresult" ClientIDMode="Static" runat="server" CssClass="login-error recovery-result" role="status" aria-live="polite" aria-atomic="true"></asp:Label>
                <asp:Button ID="btnsend" runat="server" Text="Send recovery email" CssClass="btn btn-primary btn-block login-button" ValidationGroup="ForgotPassword" OnClick="btnsend_Click" />
                <div class="recovery-actions">
                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="back-login-link" NavigateUrl="~/Login.aspx">Back to sign in</asp:HyperLink>
                </div>
                <p class="support-note">For additional help, contact your study administrator.</p>
            </form>
        </section>
    </main>
</body>
</html>
