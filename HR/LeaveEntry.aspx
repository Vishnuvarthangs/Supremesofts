<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeaveEntry.aspx.cs" Inherits="HR_LeaveEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Leave Entry</title>
    <link href="../Content/common.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-md-8">
                <section id="LeaveEntryForm">
                    <div class="form-horizontal">
                        <table>
                            <asp:Panel ID="Panel1" runat="server" BorderColor="WhiteSmoke" BorderWidth="1px">
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblEntryNo" CssClass="">Entry No.</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEntryNo" runat="server" CssClass="" Width="125px" Height="15px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblEntryDate" CssClass="">Entry Date</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEntryDate" runat="server" TextMode="Date" CssClass="" Width="125px" Height="15px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblDepartment" CssClass="">Department</asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="" Width="300px" Height="20px"></asp:DropDownList>
                                        <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="ddlDepartment" CssClass="text-danger" ErrorMessage="The Department field is required." />--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="EmployeeCode" CssClass="">Employee Code</asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlEmployeeCode" runat="server" CssClass="" AutoPostBack="True" Width="130px" Height="20px"></asp:DropDownList>
                                        <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="ddlEmployeeCode" CssClass="text-danger" ErrorMessage="The Employee Code is required." />--%>
                                    </td>

                                    <td>
                                        <asp:Label runat="server" ID="EmployeeRollNo" CssClass="">Employee RollNo</asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlEmployeeRollNo" runat="server" CssClass="" AutoPostBack="True" Width="130px" Height="20px"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="EmployeeName" CssClass="">Employee Name</asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlEmployeeName" runat="server" CssClass="" AutoPostBack="True" Width="130px" Height="20px"></asp:DropDownList>
                                        <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="ddlEmployeeName" CssClass="text-danger" ErrorMessage="The Employee Name is required." />--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblReason" CssClass="">Reason</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtReason" runat="server" CssClass="" TextMode="MultiLine" Width="300px" Height="80px"></asp:TextBox>
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
                                                <%--<asp:GridView ID="grdLeaveEntry" runat="server" DataKeyNames="id"
                                                    GridLines="None" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True"
                                                    BorderColor="Black" BorderWidth="1px">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>


                                                        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" Visible="false" />

                                                        <asp:TemplateField ItemStyle-Width="30px" HeaderText="Leave Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgrdLeaveDate" runat="server" Text='<%#Eval("EntryDate")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txtgrdLeaveDate" runat="server" Text='<%#Eval("EntryDate")%>' TextMode="Date"></asp:TextBox>
                                                            </EditItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="30px" HeaderText="Status">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgrdStatus" runat="server" Text='<%#Eval("Status")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:DropDownList ID="ddlgrdStatus" runat="server" Text='<%#Eval("Status")%>'>
                                                                    <asp:ListItem Value="Leave"></asp:ListItem>
                                                                    <asp:ListItem Value="Halfday"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </EditItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="30px" HeaderText="Approval Status" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgrdApprovalStatus" runat="server" Text='<%#Eval("ApprovalStatus")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:DropDownList ID="ddlgrdApprovalStatus" runat="server" Text='<%#Eval("ApprovalStatus")%>'>
                                                                    <asp:ListItem Value="Yes"></asp:ListItem>
                                                                    <asp:ListItem Value="No"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </EditItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="30px" HeaderText="Approval Reason" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgrdApprovalReason" runat="server" Text='<%#Eval("ApprovalReason")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txtApprovalReason" runat="server" Text='<%#Eval("ApprovalReason")%>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                        </asp:TemplateField>
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
                                                </asp:GridView>--%>

                                                <asp:GridView ID="grdLeaveEntry" runat="server" AutoGenerateColumns="False"
                                                    OnRowDataBound="grdLeaveEntry_RowDataBound" OnRowCreated="grdLeaveEntry_RowCreated" OnDataBound="grdLeaveEntry_DataBound"
                                                    EmptyDataText="No Record Available" ShowHeaderWhenEmpty="True">
                                                    <Columns>
                                                        <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />

                                                        <asp:TemplateField HeaderText="Leave Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgrdLeaveDate" runat="server" Text='<%# Eval("EntryDate") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txtgrdLeaveDate" runat="server" Text='<%# Bind("EntryDate") %>' TextMode="Date"></asp:TextBox>
                                                            </EditItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Status">
                                                            <%--<ItemTemplate>
                                                                <asp:Label ID="lblgrdStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:DropDownList ID="ddlgrdStatus" runat="server" SelectedValue='<%# Bind("Status") %>'>
                                                                    <asp:ListItem Value="Leave">Leave</asp:ListItem>
                                                                    <asp:ListItem Value="Halfday">Halfday</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </EditItemTemplate>--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgrdStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:DropDownList ID="ddlgrdStatus" runat="server"></asp:DropDownList>
                                                            </EditItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Approval Status">
                                                            <%-- <ItemTemplate>
                                                                <asp:Label ID="lblgrdApprovalStatus" runat="server" Text='<%# Eval("ApprovalStatus") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                               <asp:DropDownList ID="ddlgrdApprovalStatus" runat="server" SelectedValue='<%# Bind("ApprovalStatus") %>'>
                                                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                                    <asp:ListItem Value="No">No</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </EditItemTemplate>--%>

                                                            <ItemTemplate>
                                                                <asp:Label ID="lblApprovalStatus" runat="server" Text='<%# Eval("ApprovalStatus") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:DropDownList ID="ddlgrdApprovalStatus" runat="server"></asp:DropDownList>
                                                            </EditItemTemplate>
                                                            
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Approval Reason">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgrdApprovalReason" runat="server" Text='<%# Eval("ApprovalReason") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txtgrdApprovalReason" runat="server" Text='<%# Bind("ApprovalReason") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>

                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </asp:Panel>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblPreparedBy" CssClass="">Prepared By</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPreparedBy" runat="server" CssClass="" Width="125px" Height="15px"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>
                                    <div class="form-group">
                                        <div class="col-md-offset-2 col-md-10">
                                        </div>
                                    </div>
                                </td>
                                <td>
                                    <div class="form-group">
                                        <div class="col-md-offset-2 col-md-10">
                                        </div>
                                    </div>
                                </td>
                                <td>
                                    <div class="form-group">
                                        <div class="col-md-offset-2 col-md-10">
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblApprovedBy" CssClass="">Approved By</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtApprovedBy" runat="server" TextMode="Date" Width="125px" Height="15px"></asp:TextBox>
                                </td>
                                <td></td>
                                <td></td>
                                <td>
                                    <asp:Button runat="server" ID="btnApproval" OnClick="btnApproval_Click" Text="Approval" Font-Names="Verdana" CssClass="" Width="80px" BorderColor="Black" BorderWidth="1px" />
                                </td>
                                <td>
                                    <asp:Button runat="server" ID="btnSave" OnClick="btnSave_Click" Text="Save" CssClass="" Font-Names="Verdana" Width="80px" BorderColor="Black" BorderWidth="1px" />
                                </td>
                                <td>
                                    <asp:Button runat="server" ID="btnClose" OnClick="btnClose_Click" Text="Close" CssClass="" Font-Names="Verdana" Width="80px" BorderColor="Black" BorderWidth="1px" />
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




