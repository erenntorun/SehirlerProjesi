using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErenDenemeProje1
{
    public class SehirlerVT
    {

        public static List<Sehirler> SehirlerListesiniGetir() 
        {
            List<Sehirler> list = new List<Sehirler>();

            SqlConnection connection = new SqlConnection(VTFonksiyonlar.ConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Sehirler";
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = connection;

            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) 
            {
                Sehirler sehir = new Sehirler();
                sehir.SehirId = dr["SehirId"] is DBNull ? 0 : (int)dr["SehirId"];
                sehir.SehirAdi = dr["SehirAdi"] is DBNull ? string.Empty : dr["SehirAdi"].ToString();
                sehir.CografiBolge = dr["CografiBolge"] is DBNull ? string.Empty : dr["CografiBolge"].ToString();

                list.Add(sehir);
            }
            connection.Close();

            return list;
        }


        public static List<string> CografiBolgeleriGetir() 
        {
            List<string> list = new List<string>();

            SqlConnection connection = new SqlConnection(VTFonksiyonlar.ConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select distinct CografiBolge from Sehirler";
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = connection;

            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(dr["CografiBolge"] is DBNull ? string.Empty : dr["CografiBolge"].ToString());
            }
            connection.Close();

            return list;
        }


        public static List<Sehirler> SehirlerListesiniGetir(string CografiBolge)
        {
            List<Sehirler> list = new List<Sehirler>();

            SqlConnection connection = new SqlConnection(VTFonksiyonlar.ConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Sehirler WHERE CografiBolge=(case when @CografiBolge='TÜMÜ' then CografiBolge else @CografiBolge end)";
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = connection;

            SqlParameter prm = new SqlParameter("@CografiBolge", System.Data.SqlDbType.VarChar);
            prm.Value = CografiBolge;
            cmd.Parameters.Add(prm);

            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Sehirler sehir = new Sehirler();
                sehir.SehirId = dr["SehirId"] is DBNull ? 0 : (int)dr["SehirId"];
                sehir.SehirAdi = dr["SehirAdi"] is DBNull ? string.Empty : dr["SehirAdi"].ToString();
                sehir.CografiBolge = dr["CografiBolge"] is DBNull ? string.Empty : dr["CografiBolge"].ToString();

                list.Add(sehir);
            }
            connection.Close();

            return list;
        }



        public static List<Sehirler> SehirlerListesiniGetir(string CografiBolge, string Ara)
        {
            List<Sehirler> list = new List<Sehirler>();

            SqlConnection connection = new SqlConnection(VTFonksiyonlar.ConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SehirlerListesiniGetirSP"; // "select * from Sehirler WHERE SehirAdi like '%'+ @Ara +'%' and CografiBolge=(case when @CografiBolge='TÜMÜ' then CografiBolge else @CografiBolge end)";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = connection;

            SqlParameter prm = new SqlParameter("@CografiBolge", System.Data.SqlDbType.VarChar);
            prm.Value = CografiBolge;
            cmd.Parameters.Add(prm);


            SqlParameter prm1 = new SqlParameter("@Ara", System.Data.SqlDbType.VarChar);
            prm1.Value = Ara;
            cmd.Parameters.Add(prm1);


            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Sehirler sehir = new Sehirler();
                sehir.SehirId = dr["SehirId"] is DBNull ? 0 : (int)dr["SehirId"];
                sehir.SehirAdi = dr["SehirAdi"] is DBNull ? string.Empty : dr["SehirAdi"].ToString();
                sehir.CografiBolge = dr["CografiBolge"] is DBNull ? string.Empty : dr["CografiBolge"].ToString();
                sehir.ilcesayisi = dr["ilcesayisi"] is DBNull ? 0 : (int)dr["ilcesayisi"];

                list.Add(sehir);
            }
            connection.Close();

            return list;
        }


        public static Sehirler SehirIdyeGoreGetir(int SehirId) 
        {
            Sehirler sehir = new Sehirler();

            SqlConnection connection = new SqlConnection(VTFonksiyonlar.ConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Sehirler WHERE SehirId=@SehirId";
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = connection;

            SqlParameter prm = new SqlParameter("@SehirId", System.Data.SqlDbType.Int);
            prm.Value = SehirId;
            cmd.Parameters.Add(prm);

            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Sehirler a = new Sehirler();
                a.SehirId = dr["SehirId"] is DBNull ? 0 : (int)dr["SehirId"];
                a.SehirAdi = dr["SehirAdi"] is DBNull ? string.Empty : dr["SehirAdi"].ToString();
                a.CografiBolge = dr["CografiBolge"] is DBNull ? string.Empty : dr["CografiBolge"].ToString();

                sehir = a;
            }



            connection.Close();

            return sehir;
        }


        public static bool SehirEkle(Sehirler sehir) 
        {
            bool islem = false;

            SqlConnection connection = new SqlConnection(VTFonksiyonlar.ConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Sehirler(SehirId,SehirAdi,CografiBolge) VALUES(@SehirId,@SehirAdi,@CografiBolge)";
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = connection;
            
            SqlParameter prm = new SqlParameter("@SehirId", System.Data.SqlDbType.Int);
            prm.Value = sehir.SehirId;
            cmd.Parameters.Add(prm);

            SqlParameter prm1 = new SqlParameter("@SehirAdi", System.Data.SqlDbType.VarChar);
            prm1.Value = sehir.SehirAdi;
            cmd.Parameters.Add(prm1);

            SqlParameter prm2 = new SqlParameter("@CografiBolge", System.Data.SqlDbType.VarChar);
            prm2.Value = sehir.CografiBolge;
            cmd.Parameters.Add(prm2);

            connection.Open();
            int islemsayisi = cmd.ExecuteNonQuery();
            if (islemsayisi > 0) { islem = true; } else { islem = false; }
            connection.Close();

            return islem;
        }


        public static bool SehirGuncelle(Sehirler sehir)
        {
            bool islem = false;

            SqlConnection connection = new SqlConnection(VTFonksiyonlar.ConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Update Sehirler set SehirAdi= @SehirAdi,CografiBolge= @CografiBolge where  SehirId = @SehirId";
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = connection;

            SqlParameter prm = new SqlParameter("@SehirId", System.Data.SqlDbType.Int);
            prm.Value = sehir.SehirId;
            cmd.Parameters.Add(prm);

            SqlParameter prm1 = new SqlParameter("@SehirAdi", System.Data.SqlDbType.VarChar);
            prm1.Value = sehir.SehirAdi;
            cmd.Parameters.Add(prm1);

            SqlParameter prm2 = new SqlParameter("@CografiBolge", System.Data.SqlDbType.VarChar);
            prm2.Value = sehir.CografiBolge;
            cmd.Parameters.Add(prm2);

            connection.Open();
            int islemsayisi = cmd.ExecuteNonQuery();
            if (islemsayisi > 0) { islem = true; } else { islem = false; }

            connection.Close();


            return islem;

            
           
        }


        public static bool SehirSil(int SehirId)
        {
            bool islem = false;

            SqlConnection connection = new SqlConnection(VTFonksiyonlar.ConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Delete from Sehirler where  SehirId = @SehirId";
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = connection;

            SqlParameter prm = new SqlParameter("@SehirId", System.Data.SqlDbType.Int);
            prm.Value = SehirId;
            cmd.Parameters.Add(prm);



            connection.Open();
            int islemsayisi = cmd.ExecuteNonQuery();
            if (islemsayisi > 0) { islem = true; } else { islem = false; }

            connection.Close();


            return islem;



        }



        public static List<Ilceler> IlcelerListesiniGetir(int SehirId)
        {
            List<Ilceler> list = new List<Ilceler>();

            SqlConnection connection = new SqlConnection(VTFonksiyonlar.ConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select IlceId, IlceAdi from Ilceler where SehirId = @SehirId";
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = connection;

            SqlParameter prm = new SqlParameter("@SehirId", System.Data.SqlDbType.Int);
            prm.Value = SehirId;
            cmd.Parameters.Add(prm);

            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Ilceler ilce = new Ilceler();
                ilce.IlceId = dr["IlceId"] is DBNull ? 0 : (int)dr["IlceId"];
                ilce.IlceAdi = dr["IlceAdi"] is DBNull ? string.Empty : dr["IlceAdi"].ToString();
                

                list.Add(ilce);
            }



            connection.Close();



            return list;
        }


        public static bool IlceEkle(Ilceler ilce)
        {
            bool islem = false;

            SqlConnection connection = new SqlConnection(VTFonksiyonlar.ConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Ilceler(IlceAdi,SehirId) VALUES(@IlceAdi,@SehirId)";
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = connection;
        

            SqlParameter prm1 = new SqlParameter("@IlceAdi", System.Data.SqlDbType.VarChar);
            prm1.Value = ilce.IlceAdi;
            cmd.Parameters.Add(prm1);

            SqlParameter prm2 = new SqlParameter("@SehirId", System.Data.SqlDbType.Int);
            prm2.Value = ilce.SehirId;
            cmd.Parameters.Add(prm2);



            connection.Open();
            int islemsayisi = cmd.ExecuteNonQuery();
            if (islemsayisi > 0) { islem = true; } else { islem = false; }

            connection.Close();


            return islem;
        }



        public static bool IlceGuncelle(Ilceler ilce)
        {
            bool islem = false;

            SqlConnection connection = new SqlConnection(VTFonksiyonlar.ConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Update Ilceler set IlceAdi= @IlceAdi where  IlceId = @IlceId";
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = connection;

            SqlParameter prm = new SqlParameter("@IlceAdi", System.Data.SqlDbType.VarChar);
            prm.Value = ilce.IlceAdi;
            cmd.Parameters.Add(prm);

            SqlParameter prm1 = new SqlParameter("@IlceId", System.Data.SqlDbType.Int);
            prm1.Value = ilce.IlceId;
            cmd.Parameters.Add(prm1);

           
            connection.Open();
            int islemsayisi = cmd.ExecuteNonQuery();
            if (islemsayisi > 0) { islem = true; } else { islem = false; }

            connection.Close();


            return islem;


        }
        
        public static bool IlceSil(int IlceId)
        {
            bool islem = false;

            SqlConnection connection = new SqlConnection(VTFonksiyonlar.ConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Delete from Ilceler where  IlceId = @IlceId";
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = connection;

            SqlParameter prm = new SqlParameter("@IlceId", System.Data.SqlDbType.Int);
            prm.Value = IlceId;
            cmd.Parameters.Add(prm);



            connection.Open();
            int islemsayisi = cmd.ExecuteNonQuery();
            if (islemsayisi > 0) { islem = true; } else { islem = false; }

            connection.Close();


            return islem;



        }

        

    }
}
