﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proje
{
    class veritabani
    {
        public static SqlConnection baglanti = new SqlConnection
            ("Data Source=DESKTOP-UPH564L\\SQLEXPRESS;Initial Catalog=mesaj;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public static void ESG(SqlCommand cmd,string sql)
        {
            baglanti.Open();
            cmd.Connection = baglanti;
            cmd.CommandText = sql; cmd.ExecuteNonQuery();
            baglanti.Close();
        }

        public static DataTable Lİstele_Ara(DataGridView gridView,string sql)
        {
            DataTable tbl = new DataTable();
            baglanti.Open();
            gridView.DataSource = baglanti;
            SqlDataAdapter adtr = new SqlDataAdapter(sql, baglanti);
            adtr.Fill(tbl);
            baglanti.Close();

            return tbl;
        }
    }
}
