using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.DynamicData;
using System.Data;
using System.Xml.Linq;
using System.Diagnostics;
using System.Data.Linq;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

public partial class HR_LeaveEntry : System.Web.UI.Page
{
    string Constr, Query;
    SqlConnection SqlConn;
    SqlCommand SqlCmd;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadBlankData();

            BindDataGrids();
            BindDepartment();
            BindEmployee();


            //string query = "SELECT * FROM Employee";
            //SqlCommand cmd = new SqlCommand(query);
            //BindFilteredDropdowns(cmd);

            Clear();
        }
    }

    public void Clear()
    {
        btnApproval.Visible = false;
        lblApprovedBy.Visible = false;
        txtApprovedBy.Visible = false;

        //txtEntryDate.Text = DateTime.Today.ToString();
        txtEntryDate.Text = DateTime.Now.ToShortDateString();
        txtEntryNo.Text = string.Empty;
        ddlDepartment.Items.Insert(0, new ListItem("[ALL]", "0"));
        ddlEmployeeCode.Items.Insert(0, new ListItem("[ALL]", "0"));
        ddlEmployeeName.Items.Insert(0, new ListItem("[ALL]", "0"));
        ddlEmployeeRollNo.Items.Insert(0, new ListItem("[ALL]", "0"));
        txtReason.Text = string.Empty;
        txtPreparedBy.Text = string.Empty;
        txtApprovedBy.Text = string.Empty;
    }

    public void Connection()
    {
        if (SqlConn == null)
        {
            Constr = ConfigurationManager.ConnectionStrings["SqlConn"].ToString();
            SqlConn = new SqlConnection(Constr);
            SqlConn.Open();
        }
    }

    //private void LoadBlankData()
    //{
    //    Connection();
    //    using (SqlConnection conn = new SqlConnection(Constr))
    //    {
    //        string query = "SELECT * FROM VPermissionNew";
    //        SqlDataAdapter da = new SqlDataAdapter(query, conn);
    //        DataTable dt = new DataTable();
    //        da.Fill(dt);

    //        if (dt.Rows.Count == 0)
    //        {
    //            // Ensure necessary columns exist
    //            if (!dt.Columns.Contains("EntryDate")) dt.Columns.Add("EntryDate", typeof(DateTime));
    //            if (!dt.Columns.Contains("Status")) dt.Columns.Add("Status", typeof(string));
    //            if (!dt.Columns.Contains("ApprovalStatus")) dt.Columns.Add("ApprovalStatus", typeof(string));
    //            if (!dt.Columns.Contains("ApprovalReason")) dt.Columns.Add("ApprovalReason", typeof(string));
    //            if (!dt.Columns.Contains("ID")) dt.Columns.Add("ID", typeof(int));

    //            // Add a blank row
    //            DataRow dr = dt.NewRow();
    //            dt.Rows.Add(dr);

    //            grdLeaveEntry.DataSource = dt;
    //            grdLeaveEntry.DataBind();

    //            // Set the first row in edit mode
    //            grdLeaveEntry.Rows[0].RowState = DataControlRowState.Edit;
    //        }
    //        else
    //        {
    //            grdLeaveEntry.DataSource = dt;
    //            grdLeaveEntry.DataBind();
    //        }
    //    }
    //}

    private void LoadBlankData()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("EntryDate", typeof(DateTime));
        dt.Columns.Add("Status", typeof(string));
        dt.Columns.Add("ApprovalStatus", typeof(string));
        dt.Columns.Add("ApprovalReason", typeof(string));
        dt.Columns.Add("ID", typeof(int));

        // Add a blank row
        DataRow dr = dt.NewRow();
        dr["ID"] = 0;
        dr["EntryDate"] = DBNull.Value; // Leave blank
        dr["Status"] = string.Empty; // Leave blank
        dr["ApprovalStatus"] = string.Empty; // Leave blank
        dr["ApprovalReason"] = string.Empty; // Leave blank
        dt.Rows.Add(dr);

        grdLeaveEntry.DataSource = dt;
        grdLeaveEntry.DataBind();

        // Set the GridView to edit mode
        grdLeaveEntry.EditIndex = 0;
        grdLeaveEntry.DataBind();
    }

    protected void BindDataGrids()
    {
        Connection();
        hdnAction.Value = "Select";
        Query = "Sp_LeaveEntry";
        SqlCmd = new SqlCommand(Query, SqlConn);
        SqlCmd.CommandType = CommandType.StoredProcedure;
        SqlCmd.Parameters.AddWithValue("@ActionSub", hdnAction.Value).ToString();

        SqlDataReader Sqldr = SqlCmd.ExecuteReader();
        if (Sqldr.HasRows)
        {
            grdLeaveEntry.DataSource = Sqldr;
            grdLeaveEntry.DataBind();
        }
        else
        {
            //Empty DataTable to execute the “else-condition”  
            DataTable dt = new DataTable();
            grdLeaveEntry.DataSource = dt;
            grdLeaveEntry.DataBind();
        }
        SqlConn.Close();
    }

    protected void BindDepartment()
    {
        Connection();
        Query = "Select * from MaDepartment";
        SqlCmd = new SqlCommand(Query, SqlConn);
        SqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
        DataTable dt = new DataTable();
        SqlDa.Fill(dt);
        ddlDepartment.DataSource = dt;
        ddlDepartment.DataBind();
        ddlDepartment.DataTextField = "DepartmentName";
        ddlDepartment.DataValueField = "DepartmentCode";
        ddlDepartment.DataBind();
        //ddlDepartment.Items.Insert(0, new ListItem("[ALL]", "0"));
        SqlConn.Close();
    }

    protected void BindEmployee()
    {
        Connection();
        Query = "Select * from Employee";
        SqlCmd = new SqlCommand(Query, SqlConn);
        SqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
        DataTable dt = new DataTable();
        SqlDa.Fill(dt);
        ddlEmployeeCode.DataSource = dt;
        ddlEmployeeCode.DataBind();
        ddlEmployeeCode.DataTextField = "EmpNo";
        ddlEmployeeCode.DataValueField = "EmpNo";
        ddlEmployeeCode.DataBind();
        //ddlEmployeeCode.Items.Insert(0, new ListItem("[ALL]", "0"));

        ddlEmployeeName.DataSource = dt;
        ddlEmployeeName.DataBind();
        ddlEmployeeName.DataTextField = "EmpName";
        ddlEmployeeName.DataValueField = "EmpNo";
        ddlEmployeeName.DataBind();
        //ddlEmployeeName.Items.Insert(0, new ListItem("[ALL]", "0"));

        ddlEmployeeRollNo.DataSource = dt;
        ddlEmployeeRollNo.DataBind();
        ddlEmployeeRollNo.DataTextField = "EmpROLLNO";
        ddlEmployeeRollNo.DataValueField = "EmpNo";
        ddlEmployeeRollNo.DataBind();
        //ddlEmployeeRollNo.Items.Insert(0, new ListItem("[ALL]", "0"));

        SqlConn.Close();
    }

    private void BindFilteredDropdowns(SqlCommand cmd)
    {
        Connection();

        Query = "Select * from Employee";
        SqlCmd = new SqlCommand(Query, SqlConn);
        SqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
        DataTable dt = new DataTable();
        SqlDa.Fill(dt);

        // Bind data to EmployeeCode dropdown
        ddlEmployeeCode.DataSource = dt;
        ddlEmployeeCode.DataTextField = "EmpNo";
        ddlEmployeeCode.DataValueField = "EmpNo";
        ddlEmployeeCode.DataBind();
        //ddlEmployeeCode.Items.Insert(0, new ListItem("[ALL]", "0"));

        // Bind data to EmployeeName dropdown
        ddlEmployeeName.DataSource = dt;
        ddlEmployeeName.DataTextField = "EmpName";
        ddlEmployeeName.DataValueField = "EmpNo";
        ddlEmployeeName.DataBind();
        //ddlEmployeeName.Items.Insert(0, new ListItem("[ALL]", "0"));

        // Bind data to EmployeeRollNo dropdown
        ddlEmployeeRollNo.DataSource = dt;
        ddlEmployeeRollNo.DataTextField = "EmpROLLNO";
        ddlEmployeeRollNo.DataValueField = "EmpNo";
        ddlEmployeeRollNo.DataBind();
        //ddlEmployeeRollNo.Items.Insert(0, new ListItem("[ALL]", "0"));

        SqlConn.Close();
    }

    private void BindFilteredDropdowns(string columnName, string columnValue)
    {
        string query = "SELECT * FROM Employee WHERE " + columnName + " = @Value";
        SqlCommand cmd = new SqlCommand(query);
        cmd.Parameters.AddWithValue("@Value", columnValue);

        Connection();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            // Update EmployeeName
            ddlEmployeeName.DataSource = dt;
            ddlEmployeeName.DataTextField = "EmpName";
            ddlEmployeeName.DataValueField = "EmpNo";
            ddlEmployeeName.DataBind();

            // Update EmployeeCode
            ddlEmployeeCode.DataSource = dt;
            ddlEmployeeCode.DataTextField = "EmpNo";
            ddlEmployeeCode.DataValueField = "EmpNo";
            ddlEmployeeCode.DataBind();

            // Update EmployeeRollNo
            ddlEmployeeRollNo.DataSource = dt;
            ddlEmployeeRollNo.DataTextField = "EmpROLLNO";
            ddlEmployeeRollNo.DataValueField = "EmpROLLNO";
            ddlEmployeeRollNo.DataBind();
        }
        else
        {
            // Reset all dropdowns to default if no data found
            ddlEmployeeName.Items.Clear();
            ddlEmployeeName.Items.Insert(0, new ListItem("[ALL]", "0"));

            ddlEmployeeCode.Items.Clear();
            ddlEmployeeCode.Items.Insert(0, new ListItem("[ALL]", "0"));

            ddlEmployeeRollNo.Items.Clear();
            ddlEmployeeRollNo.Items.Insert(0, new ListItem("[ALL]", "0"));
        }

        SqlConn.Close();
    }

    protected void btnApproval_Click(object sender, EventArgs e)
    {
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtEntryNo.Text != string.Empty && txtEntryDate.Text != string.Empty && ddlDepartment.SelectedItem.Text != "[ALL]"
                && ddlEmployeeCode.SelectedItem.Text != "[ALL]" || ddlEmployeeRollNo.SelectedItem.Text != "[ALL]" || ddlEmployeeName.SelectedItem.Text != "[ALL]"
                && txtReason.Text != string.Empty && txtPreparedBy.Text != string.Empty)
            {
                Connection();

                hdnAction.Value = "Insert";
                Query = "Sp_LeaveEntry";
                SqlCmd = new SqlCommand(Query, SqlConn);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@ActionMain", hdnAction.Value).ToString();
                SqlCmd.Parameters.AddWithValue("@EntryNo", txtEntryNo.Text).ToString();
                SqlCmd.Parameters.AddWithValue("@EntryDate", txtEntryDate.Text).ToString();
                SqlCmd.Parameters.AddWithValue("@DeptCode", ddlDepartment.SelectedValue).ToString();
                SqlCmd.Parameters.AddWithValue("@Empcode", ddlEmployeeCode.SelectedValue).ToString();
                //SqlCmd.Parameters.AddWithValue("@Empcode", ddlEmployeeRollNo.SelectedValue).ToString();
                //SqlCmd.Parameters.AddWithValue("@Empcode", ddlEmployeeName.SelectedValue).ToString();
                SqlCmd.Parameters.AddWithValue("@Reason", txtReason.Text).ToString();

                SqlCmd.Parameters.AddWithValue("@PermissionType", txtPreparedBy.Text).ToString();

                //GridViewUpdateEventArgs gv = new GridViewUpdateEventArgs(0);
                //SaveGrids(sender, gv);
                foreach (GridViewRow row in grdLeaveEntry.Rows)
                {
                    string EntryDate = ((TextBox)row.FindControl("txtgrdLeaveDate")).Text;
                    string Status = ((TextBox)row.FindControl("ddlgrdStatus")).Text;
                    string ApprovalStatus = ((TextBox)row.FindControl("ddlgrdApprovalStatus")).Text;
                    string ApprovalReason = ((TextBox)row.FindControl("txtgrdApprovalReason")).Text;
                }

                int iResult = SqlCmd.ExecuteNonQuery();
                SqlConn.Close();
                if (iResult >= 1)
                {
                    lblResult.Text = "Entry Saved Successfully";
                }
                //BindDataGrids();
                Clear();
            }
        }
        catch (Exception)
        {

            throw;
        }
    }

    public void SaveGrids(object sender, GridViewUpdateEventArgs gv)
    {
        //if (gv.RowIndex >= 0 && gv.RowIndex < grdLeaveEntry.Rows.Count)
        //{
        //    int id = int.Parse(grdLeaveEntry.DataKeys[gv.RowIndex].Value.ToString());
        //}
        //else
        //{
        //    //MessageBox.Show("Invalid row index. Please try again.");
        //}

        int id = int.Parse(grdLeaveEntry.DataKeys[gv.RowIndex].Value.ToString());

        SqlCmd.Parameters.AddWithValue("@ActionSub", hdnAction.Value).ToString();
        SqlCmd.Parameters.AddWithValue("@EntryDate", ((TextBox)grdLeaveEntry.Rows[gv.RowIndex].Cells[3].Controls[0]).Text.ToString());
        SqlCmd.Parameters.AddWithValue("@Status", ((TextBox)grdLeaveEntry.Rows[gv.RowIndex].Cells[4].Controls[0]).Text.ToString());
        SqlCmd.Parameters.AddWithValue("@ApprovalStatus", ((TextBox)grdLeaveEntry.Rows[gv.RowIndex].Cells[5].Controls[0]).Text.ToString());
        SqlCmd.Parameters.AddWithValue("@ApprovalReason", ((TextBox)grdLeaveEntry.Rows[gv.RowIndex].Cells[6].Controls[0]).Text.ToString());
        SqlCmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;

    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        //this.Close;
    }

    //ddlEmployeeName.SelectedIndexChanged += new System.EventHandler(ddlEmployeeName_SelectedIndexChanged);
    private void ddlEmployeeName_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        //if (ddlEmployeeName.SelectedItem.Text != "[ALL]")
        //{
        //    ddlEmployeeCode.DataTextField = "EmpNo";
        //    ddlEmployeeCode.DataValueField = "EmpNo";
        //    ddlEmployeeCode.DataBind();

        //    //ddlEmployeeName.DataTextField = "EmpName";
        //    //ddlEmployeeName.DataValueField = "EmpNo";
        //    //ddlEmployeeName.DataBind();

        //    ddlEmployeeRollNo.DataTextField = "EmpROLLNO";
        //    ddlEmployeeRollNo.DataValueField = "EmpNo";
        //    ddlEmployeeRollNo.DataBind();
        //}

        //if (ddlEmployeeName.SelectedIndex > 0) // Ensure a valid selection
        //{
        //    string selectedEmpNo = ddlEmployeeName.SelectedValue; // Get the selected employee number

        //    Connection(); // Open the connection again

        //    // Build the query to filter based on selected employee number
        //    Query = "Select * from Employee WHERE EmpNo = @EmpNo";
        //    SqlCmd = new SqlCommand(Query, SqlConn);
        //    SqlCmd.Parameters.AddWithValue("@EmpNo", selectedEmpNo);
        //    SqlCmd.CommandType = CommandType.Text;

        //    SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
        //    DataTable dt = new DataTable();
        //    SqlDa.Fill(dt);

        //    // Bind filtered data to the other dropdowns
        //    ddlEmployeeCode.DataSource = dt;
        //    ddlEmployeeCode.DataBind();
        //    ddlEmployeeCode.DataTextField = "EmpCode"; // Assuming EmpCode exists
        //    ddlEmployeeCode.DataValueField = "EmpCode";

        //    ddlEmployeeRollNo.DataSource = dt;
        //    ddlEmployeeRollNo.DataBind();
        //    ddlEmployeeRollNo.DataTextField = "EmpRollNO";
        //    ddlEmployeeRollNo.DataValueField = "EmpRollNO";

        //    SqlConn.Close();
        //}

        ////////
        //if (ddlEmployeeName.SelectedIndex > 0) // Ensure a valid selection (not "[ALL]")
        //{
        //    string selectedEmpName = ddlEmployeeName.SelectedItem.Text;

        //    // Fetch and bind the other dropdowns based on the selected employee name
        //    string query = "SELECT EmpNo, EmpName, EmpROLLNO FROM Employee WHERE EmpName = @EmpName";
        //    SqlCommand cmd = new SqlCommand(query, SqlConn);
        //    cmd.Parameters.AddWithValue("@EmpName", selectedEmpName);

        //    BindFilteredDropdowns(cmd);
        //}
        //else
        //{
        //    // Reset all dropdowns if "[ALL]" is selected
        //    BindEmployee();
        //}
        ///////////
        ///
        if (ddlEmployeeName.SelectedItem.Text != "[ALL]")
        {
            string selectedEmployeeName = ddlEmployeeName.SelectedItem.Text;
            BindFilteredDropdowns("EmpName", selectedEmployeeName);
        }
        else
        {
            // Reset all dropdowns to show the full list
            BindEmployee();
        }
    }
    private void ddlEmployeeCode_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        //if (ddlEmployeeCode.SelectedIndex > 0) // Ensure a valid selection
        //{
        //    string selectedEmpCode = ddlEmployeeCode.SelectedValue;

        //    Connection();

        //    // Build the query to filter based on selected employee code
        //    Query = "Select * from Employee WHERE EmpCode = @EmpCode";
        //    SqlCmd = new SqlCommand(Query, SqlConn);
        //    SqlCmd.Parameters.AddWithValue("@EmpCode", selectedEmpCode);
        //    SqlCmd.CommandType = CommandType.Text;

        //    SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
        //    DataTable dt = new DataTable();
        //    SqlDa.Fill(dt);

        //    // Bind filtered data to the other dropdowns
        //    ddlEmployeeName.DataSource = dt;
        //    ddlEmployeeName.DataBind();
        //    ddlEmployeeName.DataTextField = "EmpName";
        //    ddlEmployeeName.DataValueField = "EmpNo";

        //    ddlEmployeeRollNo.DataSource = dt;
        //    ddlEmployeeRollNo.DataBind();
        //    ddlEmployeeRollNo.DataTextField = "EmpRollNO";
        //    ddlEmployeeRollNo.DataValueField = "EmpNo";

        //    SqlConn.Close();
        //}
        //////////////
        //if (ddlEmployeeCode.SelectedIndex > 0) // Ensure a valid selection (not "[ALL]")
        //{
        //    string selectedEmpCode = ddlEmployeeCode.SelectedItem.Text;

        //    // Fetch and bind the other dropdowns based on the selected employee code
        //    string query = "SELECT EmpNo, EmpName, EmpROLLNO FROM Employee WHERE EmpNo = @EmpNo";
        //    SqlCommand cmd = new SqlCommand(query, SqlConn);
        //    cmd.Parameters.AddWithValue("@EmpNo", selectedEmpCode);

        //    BindFilteredDropdowns(cmd);
        //}
        //else
        //{
        //    // Reset all dropdowns if "[ALL]" is selected
        //    BindEmployee();
        //}
        ///////////
        ///
        if (ddlEmployeeCode.SelectedItem.Text != "[ALL]")
        {
            string selectedEmployeeCode = ddlEmployeeCode.SelectedItem.Text;
            BindFilteredDropdowns("EmpNo", selectedEmployeeCode);
        }
        else
        {
            // Reset all dropdowns to show the full list
            BindEmployee();
        }
    }
    private void ddlEmployeeRollNo_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        //if (ddlEmployeeRollNo.SelectedIndex > 0) // Ensure a valid selection
        //{
        //    string selectedEmpRollNo = ddlEmployeeRollNo.SelectedValue;

        //    Connection();

        //    // Build the query to filter based on selected employee roll number
        //    Query = "Select * from Employee WHERE EmpRollNO = @EmpRollNo";
        //    SqlCmd = new SqlCommand(Query, SqlConn);
        //    SqlCmd.Parameters.AddWithValue("@EmpRollNo", selectedEmpRollNo);
        //    SqlCmd.CommandType = CommandType.Text;

        //    SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
        //    DataTable dt = new DataTable();
        //    SqlDa.Fill(dt);

        //    // Bind filtered data to the other dropdowns
        //    ddlEmployeeName.DataSource = dt;
        //    ddlEmployeeName.DataBind();
        //    ddlEmployeeName.DataTextField = "EmpName";
        //    ddlEmployeeName.DataValueField = "EmpNo";

        //    ddlEmployeeCode.DataSource = dt;
        //    ddlEmployeeCode.DataBind();
        //    ddlEmployeeCode.DataTextField = "EmpCode";
        //    ddlEmployeeCode.DataValueField = "EmpNo";

        //    SqlConn.Close();
        //}

        /////////////
        //if (ddlEmployeeRollNo.SelectedIndex > 0) // Ensure a valid selection (not "[ALL]")
        //{
        //    string selectedEmpRollNo = ddlEmployeeRollNo.SelectedItem.Text;

        //    // Fetch and bind the other dropdowns based on the selected employee roll number
        //    string query = "SELECT EmpNo, EmpName, EmpROLLNO FROM Employee WHERE EmpROLLNO = @EmpROLLNO";
        //    SqlCommand cmd = new SqlCommand(query, SqlConn);
        //    cmd.Parameters.AddWithValue("@EmpROLLNO", selectedEmpRollNo);

        //    BindFilteredDropdowns(cmd);
        //}
        //else
        //{
        //    // Reset all dropdowns if "[ALL]" is selected
        //    BindEmployee();
        //}
        ///////////
        ///

        if (ddlEmployeeRollNo.SelectedItem.Text != "[ALL]")
        {
            string selectedEmployeeRollNo = ddlEmployeeRollNo.SelectedItem.Text;
            BindFilteredDropdowns("EmpROLLNO", selectedEmployeeRollNo);
        }
        else
        {
            // Reset all dropdowns to show the full list
            BindEmployee();
        }

    }

    protected void grdLeaveEntry_DataBound(object sender, EventArgs e)
    {
        // Prevent duplicate bindings
        if (grdLeaveEntry.Rows.Count > 0)
        {
            grdLeaveEntry.EditIndex = 0; // Ensure the edit index is set
        }
    }

    protected void grdLeaveEntry_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //    if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex == grdLeaveEntry.EditIndex)
        //    {
        //        // Ensure that EditItemTemplate is visible for the empty row
        //        e.Row.RowState = DataControlRowState.Edit;
        //    }


        //if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex == grdLeaveEntry.EditIndex)
        //{
        //    DropDownList ddlStatus = (DropDownList)e.Row.FindControl("ddlgrdApprovalStatus");
        //    if (ddlStatus != null)
        //    {
        //        string currentValue = DataBinder.Eval(e.Row.DataItem, "Status")?.ToString();
        //        if (string.IsNullOrEmpty(currentValue))
        //        {
        //            ddlStatus.SelectedValue = "Select"; // Default value
        //        }
        //    }
        //}

        //if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex == grdLeaveEntry.EditIndex)
        //{
        //    // Find the DropDownList in the current row
        //    DropDownList ddlApprovalStatus = (DropDownList)e.Row.FindControl("ddlgrdApprovalStatus");
        //    if (ddlApprovalStatus != null)
        //    {
        //        // Populate the DropDownList
        //        ddlApprovalStatus.Items.Clear();
        //        ddlApprovalStatus.Items.Add(new ListItem("Yes", "Yes"));
        //        ddlApprovalStatus.Items.Add(new ListItem("No", "No"));

        //        // Get the current value from the data source
        //        string currentValue = DataBinder.Eval(e.Row.DataItem, "ApprovalStatus")?.ToString();

        //        // Set the selected value if it exists in the DropDownList
        //        if (!string.IsNullOrEmpty(currentValue) && ddlApprovalStatus.Items.FindByValue(currentValue) != null)
        //        {
        //            ddlApprovalStatus.SelectedValue = currentValue;
        //        }
        //    }
        //}

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex == grdLeaveEntry.EditIndex)
        {
            DropDownList ddlStatus = (DropDownList)e.Row.FindControl("Status");
            if (ddlStatus != null)
            {
                // Populate the DropDownList with possible values
                ddlStatus.Items.Clear();
                ddlStatus.Items.Add(new ListItem("Leave", "Leave"));
                ddlStatus.Items.Add(new ListItem("Halfday", "Halfday"));

                // Get the current value from the data source
                string currentStatusValue = DataBinder.Eval(e.Row.DataItem, "Status")?.ToString();

                // Check if the value exists in the DropDownList
                if (!string.IsNullOrEmpty(currentStatusValue) && ddlStatus.Items.FindByValue(currentStatusValue) != null)
                {
                    ddlStatus.SelectedValue = currentStatusValue;
                }
                else
                {
                    // Fallback to default or empty selection if value is invalid
                    ddlStatus.SelectedIndex = 0; // Or any default value
                }
            }

            DropDownList ddlApproveStatus = (DropDownList)e.Row.FindControl("ApprovalStatus");
            if (ddlApproveStatus != null)
            {
                // Populate the DropDownList with possible values
                ddlApproveStatus.Items.Clear();
                ddlApproveStatus.Items.Add(new ListItem("Yes", "Yes"));
                ddlApproveStatus.Items.Add(new ListItem("No", "No"));

                // Get the current value from the data source
                string currentApprovalStatusValue = DataBinder.Eval(e.Row.DataItem, "ApprovalStatus")?.ToString();

                // Check if the value exists in the DropDownList
                if (!string.IsNullOrEmpty(currentApprovalStatusValue) && ddlApproveStatus.Items.FindByValue(currentApprovalStatusValue) != null)
                {
                    ddlApproveStatus.SelectedValue = currentApprovalStatusValue;
                }
                else
                {
                    // Fallback to default or empty selection if value is invalid
                    ddlApproveStatus.SelectedIndex = 0; // Or any default value
                }
            }
        }

    }

    protected void grdLeaveEntry_RowCreated(object sender, GridViewRowEventArgs e)
    {

        //    // Force the blank row into edit mode
        //    if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal && e.Row.DataItem != null)
        //    {
        //        e.Row.RowState = DataControlRowState.Edit;
        //    }


        if (e.Row.RowType == DataControlRowType.DataRow && grdLeaveEntry.EditIndex == e.Row.RowIndex)
        {
            // If a blank row, set controls
            DropDownList ddlStatus = (DropDownList)e.Row.FindControl("Status");
            if (ddlStatus != null)
            {
                ddlStatus.Items.Clear();
                ddlStatus.Items.Add(new ListItem("Leave", "Leave"));
                ddlStatus.Items.Add(new ListItem("Halfday", "Halfday"));
            }

            TextBox txtStatus = (TextBox)e.Row.FindControl("Status");
            if (txtStatus != null)
            {
                txtStatus.Text = string.Empty; // Set blank or default value
            }

            //////////////////////////////////////////////////////////////////
            ///
            // If a blank row, set controls
            DropDownList ddlApprovalStatus = (DropDownList)e.Row.FindControl("ApprovalStatus");
            if (ddlApprovalStatus != null)
            {
                ddlApprovalStatus.Items.Clear();
                ddlApprovalStatus.Items.Add(new ListItem("Yes", "Yes"));
                ddlApprovalStatus.Items.Add(new ListItem("No", "No"));
            }

            TextBox txtApprovalStatus = (TextBox)e.Row.FindControl("ApprovalStatus");
            if (txtApprovalStatus != null)
            {
                txtApprovalStatus.Text = string.Empty; // Set blank or default value
            }
        }
    }

}