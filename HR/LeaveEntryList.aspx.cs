using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.DynamicData;
using System.Data.SqlTypes;
using System.Windows.Forms;
using System.Drawing;
//using HR_LeaveEntry;

public partial class HR_LeaveEntryList : System.Web.UI.Page /*: Form*/
{

    string Constr, Query;
    SqlConnection SqlConn;
    SqlCommand SqlCmd;

    //public HR_LeaveEntryList()
    //{
    //    InitializeComponent();
    //}

    //private readonly HR_LeaveEntryList _previous;
    //public HR_LeaveEntry(HR_LeaveEntryList previous)
    //{
    //    InitializeComponent();
    //    _previous = previous;
    //}

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindFirstGrid();
            BindSecondGrid();

            BindDepartment();
            BindEmployee();
        }
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

    public void BindFirstGrid()
    {
        Connection();
        hdnAction.Value = "Select";
        Query = "Sp_LeaveEntry";
        SqlCmd = new SqlCommand(Query, SqlConn);
        SqlCmd.CommandType = CommandType.StoredProcedure;
        SqlCmd.Parameters.AddWithValue("@ActionMain", hdnAction.Value).ToString();

        SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
        //DataSet ds = new DataSet();
        //SqlDa.Fill(ds);
        DataTable dt = new DataTable();
        SqlDa.Fill(dt);

        foreach (DataRow row in dt.Rows)
        {
            if (row["EntryDate"] != DBNull.Value)
            {
                DateTime entryDate = Convert.ToDateTime(row["EntryDate"]);
                row["EntryDate"] = entryDate.ToString("dd-MM-yyyy"); // Format the date
            }
        }

        //SqlDataReader Sqldr = SqlCmdMain.ExecuteReader();
        //if (Sqldr.HasRows)
        //{
        //    grdLeaveEntry.DataSource = Sqldr;
        //    grdLeaveEntry.DataBind();
        //}
        //else
        //{
        //    //Empty DataTable to execute the “else-condition”  
        //    dt = new DataTable();
        //    grdLeaveEntry.DataSource = dt;
        //    grdLeaveEntry.DataBind();
        //}
        //SqlCmdMain.Dispose();
        //Sqldr.Close();

        if (dt.Rows.Count >= 0 && dt.Columns.Count >= 0)
        {
            if (!dt.Columns.Contains("EntryNo"))
                dt.Columns.Add("EntryNo", typeof(int));

            if (!dt.Columns.Contains("EntryDate"))
                dt.Columns.Add("EntryDate", typeof(string));

            if (!dt.Columns.Contains("EmpName"))
                dt.Columns.Add("EmpName", typeof(string));

            if (!dt.Columns.Contains("DepartmentName"))
                dt.Columns.Add("DepartmentName", typeof(string));

            if (!dt.Columns.Contains("Reason"))
                dt.Columns.Add("Reason", typeof(string));

            if (!dt.Columns.Contains("ApprovalBy"))
                dt.Columns.Add("ApprovalBy", typeof(string));

            if (!dt.Columns.Contains("ID"))
                dt.Columns.Add("ID", typeof(int));

            // Create a blank row if no records exist
            dt.Rows.Add(dt.NewRow());

            grdLeaveEntry.DataSource = dt;
            grdLeaveEntry.DataBind();
        }
        SqlCmd.Dispose();
        SqlDa.Dispose();

        //SqlConn.Close();
    }

    public void BindSecondGrid()
    {
        Connection();
        hdnAction.Value = "Select";
        Query = "Sp_LeaveEntry";

        SqlCmd = new SqlCommand(Query, SqlConn);
        SqlCmd.CommandType = CommandType.StoredProcedure;
        SqlCmd.Parameters.AddWithValue("@ActionSub", hdnAction.Value).ToString();

        //SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
        //DataTable dt = new DataTable();
        //SqlDa.Fill(dt);

        SqlDataReader Sqldr = SqlCmd.ExecuteReader();
        if (Sqldr.HasRows)
        {
            grdLeaveEntryList.DataSource = Sqldr;
            grdLeaveEntryList.DataBind();
        }
        else
        {
            //Empty DataTable to execute the “else-condition”  
            DataTable dt = new DataTable();
            grdLeaveEntryList.DataSource = dt;
            grdLeaveEntryList.DataBind();
        }
        SqlCmd.Dispose();
        Sqldr.Close();

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
        ddlDepartment.Items.Insert(0, new ListItem("[ALL]", "0"));
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
        ddlEmployeeCode.DataTextField = "EmpROLLNO";
        ddlEmployeeCode.DataValueField = "EmpNo";
        ddlEmployeeCode.DataBind();
        ddlEmployeeCode.Items.Insert(0, new ListItem("[ALL]", "0"));

        ddlEmployeeName.DataSource = dt;
        ddlEmployeeName.DataBind();
        ddlEmployeeName.DataTextField = "EmpName";
        ddlEmployeeName.DataValueField = "EmpNo";
        ddlEmployeeName.DataBind();
        ddlEmployeeName.Items.Insert(0, new ListItem("[ALL]", "0"));
        SqlConn.Close();
    }

    //private class HR_LeaveEntry
    //{

    //}
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        HR_LeaveEntry obj = new HR_LeaveEntry();
        obj.ShowDialog();
    }

    protected void btnModify_Click(object sender, EventArgs e)
    {

    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        
    }

    private List<FirstGrid> FirstGridData;
    private List<SecondGrid> SecondGridData;
    protected void grdLeaveEntry_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int selectedFirstGridID = int.Parse(e.CommandArgument.ToString());

            // Filter detail data based on selected ID
            List<SecondGrid> filteredDetails = SecondGridData.Where(d => d.EntryNo == selectedFirstGridID).ToList();

            grdLeaveEntryList.DataSource = filteredDetails;
            grdLeaveEntryList.DataBind();
        }
    }

    protected void grdLeaveEntry_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedID = grdLeaveEntry.SelectedDataKey.Value.ToString();
        BindSecondGrid();
    }

    public class FirstGrid
    {
        public int EntryNo { get; set; }
        public DateTime EntryDate { get; set; }
        public string EmpName { get; set; }
        public string DepartmentName { get; set; }
        public string Reason { get; set; }
        public string ApprovalBy { get; set; }
    }

    public class SecondGrid
    {
        public DateTime EntryDate { get; set; }
        public string Status { get; set; }
        public string ApprovalStatus { get; set; }
        public string ApprovalReason { get; set; }
        public int EntryNo { get; set; }
    }

}