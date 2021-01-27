using practicemvc.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace practicemvc.Repos
{
    public class Recruit
    {
        private SqlConnection con;
        //To Handle connection related activities    
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["conn"].ToString();
            con = new SqlConnection(constr);

        }
        //To Add Employee details    
        public bool AddEmployee(Recruitment obj)
        {

            connection();
            con.Open();
            SqlCommand com = new SqlCommand("AddIntern", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Intern", obj.intern);
            com.Parameters.AddWithValue("@Intern_Id", obj.Intern_id);
            com.Parameters.AddWithValue("@Address", obj.address);
            com.Parameters.AddWithValue("@Technology", obj.technology);
            com.Parameters.AddWithValue("@Exp", obj.experience);

            
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }
        //To view employee details with generic list     
        public List<Recruitment> GetAllInterns()
        {
            connection();
            con.Open();
            List<Recruitment> EmpList = new List<Recruitment>();


            SqlCommand com = new SqlCommand("ShowIntern", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            
            da.Fill(dt);
          
            foreach (DataRow dr in dt.Rows)
            {

                EmpList.Add(

                    new Recruitment
                    {

                        intern =Convert.ToString(dr["intern"]),
                        Intern_id = Convert.ToInt32(dr["Intern_Id"]),
                        address = Convert.ToString(dr["address"]),
                        technology = Convert.ToString(dr["technology"]),
                        experience = Convert.ToInt32(dr["experience"])
                    }
                    );
            }
            con.Close();
            return EmpList;
        }
        //To Update Employee details    
        public bool UpdateEmployee(Recruitment obj)
        {

            connection();
            con.Open();
            SqlCommand com = new SqlCommand("UpdateIntern", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Intern", obj.intern);
            com.Parameters.AddWithValue("@Intern_Id", obj.Intern_id);
            com.Parameters.AddWithValue("@Address", obj.address);
            com.Parameters.AddWithValue("@Technology", obj.technology);
            com.Parameters.AddWithValue("@Exp", obj.experience);
            
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
        //To delete Employee details    
        public bool DeleteEmployee(int Id)
        {

            connection();
            con.Open();
            SqlCommand com = new SqlCommand("DeleteIntern", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Intern_Id", Id);

            
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {

                return false;
            }
        }
    }
}

