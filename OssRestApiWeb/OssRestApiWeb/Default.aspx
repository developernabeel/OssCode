<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OssRestApiWeb.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OSS API</title>
    <link href="css/jquery-ui.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="padding:20px;">
        <h2>OSS API</h2>
        <div>
            Insert pattern:
            <asp:TextBox ID="txtPattern" ValidationGroup="patternGroup" runat="server"></asp:TextBox>
            <asp:Button ID="btnAddPattern" Text="Add" runat="server" OnClick="btnAddPattern_Click" />
            <asp:RequiredFieldValidator ControlToValidate ="txtPattern" ValidationGroup="patternGroup" ForeColor="Red" Display="Dynamic" ErrorMessage="Pattern is required" runat="server"></asp:RequiredFieldValidator>
        </div>
        <br />

        <div>
            Start crawler:
            <asp:Button ID="btnStartCrawler" Text="Start Crawler" runat="server" OnClick="btnStartCrawler_Click" />
        </div>
        <br />

        <div>
            Stop crawler:
            <asp:Button ID="btnStopCrawler" Text="Stop Crawler" runat="server" OnClick="btnStopCrawler_Click" />
        </div>
        <br />

        <div>
            <asp:TextBox ID="txtQuery" ValidationGroup="queryGroup" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearchQuery" Text="Search Query" runat="server" OnClick="btnSearchQuery_Click" />
            <asp:RequiredFieldValidator ControlToValidate ="txtQuery" ValidationGroup="queryGroup" ForeColor="Red" Display="Dynamic" ErrorMessage="Query is required" runat="server"></asp:RequiredFieldValidator>
        </div>
        <br />
        
        <div>
            <asp:TextBox ID="txtFieldName" ValidationGroup="fieldGroup" runat="server"></asp:TextBox>
            <asp:Button ID="btnFieldCreate" Text="Create Field" runat="server" OnClick="btnCreateField_Click" />
            <asp:RequiredFieldValidator ControlToValidate ="txtQuery" ValidationGroup="fieldGroup" ForeColor="Red" Display="Dynamic" ErrorMessage="Field name is required" runat="server"></asp:RequiredFieldValidator>
        </div>
        <br />
        
        <div>
            Search Features and Analysis:
            <asp:Button ID="btnFa" Text="Featrues & Analysis" runat="server" OnClick="btnFa_Click" />
        </div>
        <br />

        <div>
            <h2>Output:</h2>
            <asp:Literal ID="literalResponse" runat="server"></asp:Literal>            
        </div>
    </div>
    </form>
    <script src="Scripts/jquery-1.8.2.min.js"></script>
    <script src="Scripts/jquery-ui-1.8.24.min.js"></script>
    <script>
        $(function () {
            var textQueryId = '#<%=txtQuery.ClientID%>';
            $(textQueryId).autocomplete({
                source: function (request, response) {
                    var data = {
                        q: request.term
                    };
                    $.ajax({
                        type: 'POST',
                        url: 'Default.aspx/GetSearchTerms',
                        contentType: "application/json; charset=utf-8",
                        dataType : 'json',
                        data: JSON.stringify(data),
                        success: function (result) {
                            var terms = JSON.parse(result.d).terms;
                            response(terms);
                        }
                    })
                },
                minLength: 2
            });
        });
    </script>
</body>
</html>
