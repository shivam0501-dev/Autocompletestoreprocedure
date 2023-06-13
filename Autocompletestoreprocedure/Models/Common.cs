using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Autocompletestoreprocedure.Models
{
    public class Common
    {

        public static DataTable ExecuteData(string[,]param ,string proc)
        {
            string Constr = ConfigurationManager.AppSettings.Get("Constr");
            SqlConnection con = new SqlConnection(Constr);
            SqlCommand cmd = new SqlCommand(proc,con);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i=0;i<param.Length/2;i++)
            {
                cmd.Parameters.AddWithValue(param[i, 0], param[i,1]);
            }
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }




    }
}