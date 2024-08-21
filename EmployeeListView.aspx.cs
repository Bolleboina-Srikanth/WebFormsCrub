using EmployeeCrubWebForms.EmployeeDb;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeCrubWebForms
{
    public partial class EmployeeListView : System.Web.UI.Page
    {
        private EmployeeContext db = new EmployeeContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {

            GridView1.DataSource = db.Employees.ToList();
            GridView1.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string name = TextBox1.Text;
            string department = TextBox3.Text;
            string salaryText = TextBox2.Text;
            var employee = new Employee
            {
                EName = name,
                Salary = salaryText,
                Department = department,
            };

            db.Employees.Add(employee);
            db.SaveChanges();
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            BindGrid();


        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            if (ViewState["SelectedEmployeeId"] != null)
            {
                int empid = (int)ViewState["SelectedEmployeeId"];

                using (var context = new EmployeeContext())
                {
                    var employee = context.Employees.Find(empid);
                    if (employee != null)
                    {
                        employee.EName = TextBox1.Text;
                        employee.Salary = TextBox2.Text;
                        employee.Department = TextBox3.Text;

                        context.Employees.AddOrUpdate(employee);
                        context.SaveChanges();
                        TextBox1.Text = "";
                        TextBox2.Text = "";
                        TextBox3.Text = "";

                        BindGrid();
                    }
                }


            }
        }



        

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;

            // Get the Employee ID from the corresponding cell
            if (int.TryParse(GridView1.Rows[rowindex].Cells[0].Text, out int empid))
            {
                using (var context = new EmployeeContext())
                {
                    var employee = context.Employees.Find(empid);
                    if (employee != null)
                    {
                        context.Employees.Remove(employee);
                        context.SaveChanges();
                    }
                }
            }

            // Rebind the GridView to reflect the updated data
            BindGrid();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            // Store the Employee ID in a hidden field or ViewState for later use
            int empid = Convert.ToInt32(GridView1.Rows[rowindex].Cells[0].Text);
            ViewState["SelectedEmployeeId"] = empid;
            TextBox1.Text = (GridView1.Rows[rowindex].Cells[1].Text);
            TextBox2.Text = (GridView1.Rows[rowindex].Cells[2].Text);
            TextBox3.Text = (GridView1.Rows[rowindex].Cells[3].Text);
        }
    }
}