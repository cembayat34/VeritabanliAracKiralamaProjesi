using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace VeritabanliAracKiralamaProjesi
{
    public class ArabaManager
    {
        List<Araba> arabalar = new List<Araba>();
       
        public void ArabaEkle()
        {
            Console.WriteLine("Araba Id giriniz: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Markasini giriniz: ");
            string marka = Console.ReadLine();
            Console.WriteLine("Modelini giriniz: ");
            string model = Console.ReadLine();
            Console.WriteLine("Yakit tipini giriniz: ");
            string yakitTipi = Console.ReadLine();
            Console.WriteLine("Plaka giriniz: ");
            string plaka = Console.ReadLine();

            string connString = @"Data Source = DESKTOP-VK83I53; Initial Catalog = AracKiralamaDB; User ID = deneme; Password = 123456";
            string sqlQuery = $"INSERT INTO Araclar VALUES({id}, '{marka}' , '{model}', '{yakitTipi}', '{plaka}' )";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            using (SqlCommand command = new SqlCommand(sqlQuery, conn))
            {
                int result = command.ExecuteNonQuery();
                Console.WriteLine("Islenen Satır : " + result);
            }
            conn.Close();
        }

        public void ArabaSil()
        {
            ArabaListele();
            Console.WriteLine("Silinecek Arabanin ID Numarasini Giriniz: ");
            int id = Convert.ToInt32(Console.ReadLine());

            string connString = @"Data Source = DESKTOP-VK83I53; Initial Catalog = AracKiralamaDB; User ID = deneme; Password = 123456";
            string sqlQuery = $"DELETE Araclar WHERE ID = {id}";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            using (SqlCommand command = new SqlCommand(sqlQuery, conn))
            {
                int result = command.ExecuteNonQuery();
                Console.WriteLine("Islenen Satır : " + result);
            }
            conn.Close();
        }

        public void ArabaListele()
        {
            string connString = @"Data Source = DESKTOP-VK83I53; Initial Catalog = AracKiralamaDB; User ID = deneme; Password = 123456";
            string sqlQuery = "SELECT * FROM Araclar";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            using (SqlCommand command = new SqlCommand(sqlQuery, conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                arabalar.Clear();
                while (reader.Read())
                {
                    Araba araba = new Araba();
                    araba.Id = reader.GetInt32(0);
                    araba.Marka = reader.GetString(1);
                    araba.Model = reader.GetString(2);
                    araba.YakitTipi = reader.GetString(3);
                    araba.Plaka = reader.GetString(4);
                    arabalar.Add(araba);
                }
            }
            conn.Close();

            Console.WriteLine(" - - - - Araba Bilgileri - - - - ");
            foreach (var item in arabalar)
            {
                Console.WriteLine("Araba Id: " + item.Id);
                Console.WriteLine("Marka : " + item.Marka);
                Console.WriteLine("Model : " + item.Model);
                Console.WriteLine("Yakit Tipi : " + item.YakitTipi);
                Console.WriteLine("Plaka : " + item.Plaka);
                Console.WriteLine("- - - - - - - - - - - - - - - - - ");
            }
        }
    }
}
