<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeListView.aspx.cs" Inherits="EmployeeCrubWebForms.EmployeeListView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employees List</title>
    <style>
        .div-container {
            width: 100vw;
            height: 100vh;
            display: flex;
            flex-direction:column;
            justify-content: center;
            align-items: center;
            background-color: orange;
            margin: 0;
            padding: 0;
        }
    </style>
</head>
<body>

    <div class="div-container">
        <h2>********Employees List**********</h2>

        <form id="form1" runat="server">
            <asp:Table ID="Table1" runat="server">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="label1" runat="server" Text="Name:"></asp:Label>&nbsp;
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="label2" runat="server" Text="salary:"></asp:Label>&nbsp;
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="label3" runat="server" Text="Department:"></asp:Label>&nbsp;
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ColumnSpan="2">
                    <asp:TableCell>
                        <asp:Button ID="btnAdd" runat="server" Text="Add New Employee" OnClick="btnAdd_Click" />

                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button ID="Button1" runat="server" Text="Update Changes" OnClick="btnUpdate_Click" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <br />

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="EmId" HeaderText="Employee ID" ReadOnly="true" />
                    <asp:BoundField DataField="EName" HeaderText="Name" />
                    <asp:BoundField DataField="Salary" HeaderText="Salary" />
                    <asp:BoundField DataField="Department" HeaderText="Department" />
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <%--<asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="Edit" CommandArgument='<%# Eval("EmId") %>' />--%>
                            <%--<asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("EmId") %>' />--%>
                            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Update</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Delete</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </form>


    </div>

</body>
</html>
