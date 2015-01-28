<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Search Star</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/main.css" rel="stylesheet" />
</head>
<body>
    <div class="page-header">
        <h1>
            <img src="images/logo.jpg" class="img-rounded logo" />
            Search Star <small>COMP4870 Assignment 1</small></h1>
    </div>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="form-group col-sm-9">
                    <div class="input-group">
                        <%--Search bar--%>
                        <asp:TextBox ID="tb_search" class="form-control" placeholder="Search keywords" runat="server"></asp:TextBox>
                        <span class="input-group-btn">
                            <%--Search Button--%>
                            <asp:Button ID="btn_search" class="btn btn-primary" runat="server" Text="Search" OnClick="btn_search_Click" />
                        </span>
                    </div>
                    <div>
                        <asp:RequiredFieldValidator ID="vd_requiredKeyword" CssClass="text-danger" runat="server" 
                            ErrorMessage="Search keyword required." ControlToValidate="tb_search"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group pull-right">
                    <%--Begin Change Text File Controls--%>
                    <asp:LinkButton ID="btn_start" runat="server" class="btn btn-primary" OnClick="btn_start_Click">
                        <i aria-hidden="true" class="glyphicon glyphicon-step-backward"></i>
                    </asp:LinkButton>
                    <asp:LinkButton ID="btn_prev" runat="server" class="btn btn-primary" OnClick="btn_prev_Click">
                        <i aria-hidden="true" class="glyphicon glyphicon-backward"></i>
                    </asp:LinkButton>
                    <asp:LinkButton ID="btn_next" runat="server" class="btn btn-primary" OnClick="btn_next_Click">
                        <i aria-hidden="true" class="glyphicon glyphicon-forward"></i>
                    </asp:LinkButton>
                    <asp:LinkButton ID="btn_end" runat="server" class="btn btn-primary" OnClick="btn_end_Click">
                        <i aria-hidden="true" class="glyphicon glyphicon-step-forward"></i>
                    </asp:LinkButton>
                    <%--End Change Text File Controls--%>
                </div>
            </div>
            <div class="row form-group">
                <div class="col-sm-10">
                    <div>
                        <asp:Label runat="server" class="text-muted" Text="Document: "></asp:Label>
                        <asp:Label ID="lb_docName" runat="server" class="text-info" Text=""></asp:Label>
                    </div>
                    <div>
                        <asp:Label runat="server" Text="Result: "></asp:Label>
                        <asp:Label ID="lb_resultCurr" runat="server" Text=""></asp:Label>
                        <asp:Label runat="server" Text="of"></asp:Label>
                        <asp:Label ID="lb_resultTotal" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="pull-right">
                    <asp:LinkButton id="btn_print" runat="server" class="btn btn-default">
                        <i aria-hidden="true" class="glyphicon glyphicon-print"></i>
                    </asp:LinkButton>
                    <asp:LinkButton ID="btn_download" runat="server" class="btn btn-default">
                        <i aria-hidden="true" class="glyphicon glyphicon-download-alt"></i>
                    </asp:LinkButton>
                </div>
            </div>
            <div class="form-group row">
                <asp:TextBox ID="tb_viewer" class="form-control readonly-tb" Rows="20" 
                    runat="server" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>

            </div>
        </div>
    </form>

    <script src="Scripts/jQuery.print.js"></script>
    <script src="Scripts/main.js"></script>

</body>
</html>
