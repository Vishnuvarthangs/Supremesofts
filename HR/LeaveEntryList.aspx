<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeaveEntryList.aspx.cs" Inherits="HR_LeaveEntryList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Leave Entry List</title>
    <link href="../Content/common.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-md-8">
                <section id="LeaveEntryListForm">
                    <div class="form-horizontal">
                        <table>
                            <asp:Panel ID="Panel1" runat="server" BorderColor="WhiteSmoke" BorderWidth="1px">
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblDepartment" CssClass="">Department</asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="font" Width="200px"></asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="ApprovalStatus" CssClass="">Approval Status</asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlApprovalStatus" runat="server" CssClass="" Width="120px">
                                            <asp:ListItem Value="[ALL]"></asp:ListItem>
                                            <asp:ListItem Value="Yes"></asp:ListItem>
                                            <asp:ListItem Value="No"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="FromDate" CssClass="">From Date</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFromDate" runat="server" TextMode="Date" CssClass="" Width="120px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="EmployeeCode" CssClass="">EmployeeCode</asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlEmployeeCode" runat="server" CssClass="" Width="120px"></asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="LeaveStatus" CssClass="">Leave Status</asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlLeaveStatus" runat="server" CssClass="" Width="120px">
                                            <asp:ListItem Value="[ALL]"></asp:ListItem>
                                            <asp:ListItem Value="Leave"></asp:ListItem>
                                            <asp:ListItem Value="Halfday"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="ToDate" CssClass="">To Date</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtToDate" runat="server" TextMode="Date" CssClass="" Width="120px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="EmployeeName" CssClass="">Employee Name</asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlEmployeeName" runat="server" CssClass="" Width="200"></asp:DropDownList>
                                    </td>
                                </tr>
                            </asp:Panel>
                        </table>
                        <table>
                            <asp:Panel ID="Panel2" runat="server" BorderColor="WhiteSmoke" BorderWidth="1px">
                                <tr>
                                    <td>
                                        <div class="form-group">
                                            <div class="col-md-10">
                                                <asp:GridView ID="grdLeaveEntry" runat="server" DataKeyNames="id"
                                                    GridLines="None" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True"
                                                    BorderColor="Black" BorderWidth="1px">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>

                                                        <asp:BoundField DataField="EntryNo" HeaderText="Entry No." />
                                                        <asp:BoundField DataField="EntryDate" HeaderText="Date" 
                                                                        DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false"/>
                                                        <asp:BoundField DataField="EmpName" HeaderText="Employee Name" />
                                                        <asp:BoundField DataField="DepartmentName" HeaderText="Department Name" />
                                                        <asp:BoundField DataField="Reason" HeaderText="Reason" />
                                                        <asp:BoundField DataField="ApprovalBy" HeaderText="Approved By" />

                                                        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="id" Visible="false" />

                                                        <%--<asp:TemplateField ItemStyle-Width="30px" HeaderText="Entry No.">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEntryNo" runat="server" Text='<%#Eval("EntryNo")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="30px" HeaderText="Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEntryDate" runat="server" Text='<%#Eval("EntryDate")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="30px" HeaderText="Employee Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEmpName" runat="server" Text='<%#Eval("EmpName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="30px" HeaderText="Department Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDepartmentName" runat="server" Text='<%#Eval("DepartmentName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="30px" HeaderText="Reason">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblReason" runat="server" Text='<%#Eval("Reason")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="30px" HeaderText="Approved By">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblApprovalBy" runat="server" Text='<%#Eval("ApprovalBy")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                    </Columns>
                                                    <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                                    <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                                    <RowStyle BackColor="LightSkyBlue" ForeColor="#333333" />
                                                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                                                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                                                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                                                    <SortedDescendingHeaderStyle BackColor="#820000" />
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </asp:Panel>
                        </table>
                        <table>
                            <asp:Panel ID="Panel3" runat="server" BorderColor="WhiteSmoke" BorderWidth="1px">
                                <tr>
                                    <td>
                                        <div class="form-group">
                                            <div class="col-md-10">
                                                <asp:GridView ID="grdLeaveEntryList" runat="server" DataKeyNames="id"
                                                    GridLines="None" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True"
                                                    BorderColor="Black" BorderWidth="1px">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>
                                                        <asp:BoundField DataField="EntryDate" HeaderText="Leave Date" />
                                                        <asp:BoundField DataField="Status" HeaderText="Status" />
                                                        <asp:BoundField DataField="ApprovalStatus" HeaderText="Approval Status" />
                                                        <asp:BoundField DataField="ApprovalReason" HeaderText="Approval Reason" />

                                                        <asp:BoundField DataField="EntryNo" HeaderText="Entry No." Visible="false" />

                                                        <%--<asp:TemplateField ItemStyle-Width="30px" HeaderText="Leave Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLeaveDate" runat="server" Text='<%#Eval("EntryDate")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="30px" HeaderText="Status">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="30px" HeaderText="Approval Status">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblApprovalStatus" runat="server" Text='<%#Eval("ApprovalStatus")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="30px" HeaderText="Approval Reason">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblApprovalReason" runat="server" Text='<%#Eval("ApprovalReason")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                    </Columns>
                                                    <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                                    <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                                    <RowStyle BackColor="LightSkyBlue" ForeColor="#333333" />
                                                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                                                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                                                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                                                    <SortedDescendingHeaderStyle BackColor="#820000" />
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </asp:Panel>
                        </table>
                        <table class="text-align: left">
                            <tr>
                                <td>
                                    <div class="form-group">
                                        <div class="col-md-offset-2 col-md-10">
                                            <asp:Button runat="server" ID="btnAdd" OnClick="btnAdd_Click" Text="Add" CssClass="" Font-Names="Verdana"  Width="80px" BorderColor="Black" BorderWidth="1px" />
                                        </div>
                                    </div>
                                </td>
                                <td>
                                    <div class="form-group">
                                        <div class="col-md-offset-2 col-md-10">
                                            <asp:Button runat="server" ID="btnModify" OnClick="btnModify_Click" Text="Modify" CssClass="" Font-Names="Verdana"  Width="80px" BorderColor="Black" BorderWidth="1px" />
                                        </div>
                                    </div>
                                </td>
                                <td>
                                    <div class="form-group">
                                        <div class="col-md-offset-2 col-md-10">
                                            <asp:Button runat="server" ID="btnDelete" OnClick="btnDelete_Click" Text="Delete" CssClass="" Font-Names="Verdana"  Width="80px" BorderColor="Black" BorderWidth="1px" />
                                        </div>
                                    </div>
                                </td>
                                <td>
                                    <div class="form-group">
                                        <div class="col-md-offset-2 col-md-10">
                                            <asp:Button runat="server" ID="btnClose" OnClick="btnClose_Click" Text="Close" CssClass="" Font-Names="Verdana"  Width="80px" BorderColor="Black" BorderWidth="1px" />
                                        </div>
                                    </div>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:HiddenField ID="hdnAction" runat="server" />
                                </td>
                                <td>
                                    <asp:Label ID="lblResult" runat="server" Text="Result" Visible="false"></asp:Label>
                                </td>
                            </tr>

                        </table>
                    </div>

                </section>
            </div>

        </div>
    </form>
</body>
</html>




