<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Search Star</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <div class="page-header">
        <h1>
            <img src="images/logo.jpg" class="img-rounded" style="height: 90px;" />
            Search Star <small>COMP4870 Assignment 1</small></h1>
    </div>
    <form id="form1" runat="server">
        <div class="container">
            <div class="form-group">
                <div class="input-group">
                    <asp:TextBox ID="tb_search" class="form-control" placeholder="Search keywords" runat="server"></asp:TextBox>
                    <span class="input-group-btn">
                        <asp:Button ID="btn_search" class="btn btn-primary" runat="server" Text="Search" />
                    </span>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
