using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml;

namespace Scarpe.Models
{
    public static class DB
    {
        public static void SignIn(string name, string surname, string username, string password, string role = "user")
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO [User] (Nome, Cognome, Username, Password, Ruolo) VALUES(@nome, @cognome, @username, @password, @role)";
                cmd.Parameters.AddWithValue("nome", name);
                cmd.Parameters.AddWithValue("cognome", surname);
                cmd.Parameters.AddWithValue("username", username);
                cmd.Parameters.AddWithValue("password", password);
                cmd.Parameters.AddWithValue("role", role);
                int IsOk = cmd.ExecuteNonQuery();

            }

            catch{}
            finally
            {
                conn.Close();
            }
        }

        public static User getUserByUsername(string username)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from [User] where Username = @username", conn);
            cmd.Parameters.AddWithValue("username", username);
            SqlDataReader sqlDataReader;

            conn.Open();
            sqlDataReader = cmd.ExecuteReader();

            User user = new User();
            while (sqlDataReader.Read())
            {
                user.Id = Convert.ToInt32(sqlDataReader["IdUser"]);
                user.Name = sqlDataReader["Nome"].ToString();
                user.Surname = sqlDataReader["Cognome"].ToString();
                user.Username = sqlDataReader["Username"].ToString();
                user.Password = sqlDataReader["Password"].ToString();
                user.Role = sqlDataReader["Ruolo"].ToString();
            }

            conn.Close();
            return user;
        }

        public static void AddScarpa(string name,double price, string description, string coverImg, string img1, string img2, int quantity, bool production, bool visible)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Scarpa (Nome, Prezzo, Descrizione, CoverImg, Img1, Img2, Disponibilita, Produzione, Visibile) VALUES (@name, @price, @description, @coverImg, @img1, @img2, @quantity, @production, @visible)";
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("price", Convert.ToDouble(price));
                cmd.Parameters.AddWithValue("description", description);
                cmd.Parameters.AddWithValue("coverImg", coverImg);
                cmd.Parameters.AddWithValue("img1", img1);
                cmd.Parameters.AddWithValue("img2", img2);
                cmd.Parameters.AddWithValue("quantity", Convert.ToInt32(quantity));
                cmd.Parameters.AddWithValue("production", Convert.ToBoolean(production));
                cmd.Parameters.AddWithValue("visible", Convert.ToBoolean(visible));
                int IsOk = cmd.ExecuteNonQuery();

            }

            catch
            {

            }
            finally
            {
                conn.Close();
            }
        }

        public static Scarpa getScarpaById(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from Scarpa where IdScarpa = @id", conn);
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader sqlDataReader;

            conn.Open();

            Scarpa scarpa = new Scarpa();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                scarpa.Id = Convert.ToInt32(sqlDataReader["IdScarpa"]);
                scarpa.Price = Convert.ToDouble(sqlDataReader["Prezzo"]);
                scarpa.Name = sqlDataReader["Nome"].ToString();
                scarpa.Description = sqlDataReader["Descrizione"].ToString();
                scarpa.CoverImg = sqlDataReader["CoverImg"].ToString();
                scarpa.Img1 = sqlDataReader["Img1"].ToString();
                scarpa.Img2 = sqlDataReader["Img2"].ToString();
                scarpa.Quantity = Convert.ToInt32(sqlDataReader["Disponibilita"]);
                scarpa.Production = Convert.ToBoolean(sqlDataReader["Produzione"]);
                scarpa.Visible = Convert.ToBoolean(sqlDataReader["Visibile"]);
            }

            conn.Close();
            return scarpa;
        }

        public static List<Scarpa> getAllScarpe()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from Scarpa", conn);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<Scarpa> scarpe = new List<Scarpa>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Scarpa scarpa = new Scarpa();
                scarpa.Id = Convert.ToInt32(sqlDataReader["IdScarpa"]);
                scarpa.Price = Convert.ToDouble(sqlDataReader["Prezzo"]);
                scarpa.Name = sqlDataReader["Nome"].ToString();
                scarpa.Description = sqlDataReader["Descrizione"].ToString();
                scarpa.CoverImg = sqlDataReader["CoverImg"].ToString();
                scarpa.Img1 = sqlDataReader["Img1"].ToString();
                scarpa.Img2 = sqlDataReader["Img2"].ToString();
                scarpa.Quantity = Convert.ToInt32(sqlDataReader["Disponibilita"]);
                scarpa.Production = Convert.ToBoolean(sqlDataReader["Produzione"]);
                scarpa.Visible = Convert.ToBoolean(sqlDataReader["Visibile"]);
                scarpe.Add(scarpa);
            }

            conn.Close();
            return scarpe;
        }

        public static List<Scarpa> getAllVisibleScarpe()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from Scarpa where Visibile='true'", conn);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<Scarpa> scarpe = new List<Scarpa>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Scarpa scarpa = new Scarpa();
                scarpa.Id = Convert.ToInt32(sqlDataReader["IdScarpa"]);
                scarpa.Price = Convert.ToDouble(sqlDataReader["Prezzo"]);
                scarpa.Name = sqlDataReader["Nome"].ToString();
                scarpa.Description = sqlDataReader["Descrizione"].ToString();
                scarpa.CoverImg = sqlDataReader["CoverImg"].ToString();
                scarpa.Img1 = sqlDataReader["Img1"].ToString();
                scarpa.Img2 = sqlDataReader["Img2"].ToString();
                scarpa.Quantity = Convert.ToInt32(sqlDataReader["Disponibilita"]);
                scarpa.Production = Convert.ToBoolean(sqlDataReader["Produzione"]);
                scarpa.Visible = Convert.ToBoolean(sqlDataReader["Visibile"]);
                scarpe.Add(scarpa);
            }

            conn.Close();
            return scarpe;
        }

        public static void UpdateScarpa(int id, string name, double price, string description, string coverImg, string img1, string img2, int quantity, bool production, bool visible)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE Scarpa SET Nome=@name,Prezzo=@price,Descrizione=@description,CoverImg=@coverImg,Img1=@img1,Img2=@img2,Disponibilita=@quantity,Produzione=@production,Visibile=@visible WHERE IdScarpa = @id";
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("price", price);
                cmd.Parameters.AddWithValue("description", description);
                cmd.Parameters.AddWithValue("coverImg", coverImg);
                cmd.Parameters.AddWithValue("img1", img1);
                cmd.Parameters.AddWithValue("img2", img2);
                cmd.Parameters.AddWithValue("quantity", quantity);
                cmd.Parameters.AddWithValue("production", production);
                cmd.Parameters.AddWithValue("visible", visible);
                int IsOk = cmd.ExecuteNonQuery();

            }

            catch
            {

            }
            finally
            {
                conn.Close();
            }
        }
        public static void Remove(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM Scarpa where IdScarpa=@id";
            cmd.Parameters.AddWithValue("id", id);

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();
        }
    }
}