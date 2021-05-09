using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace VeritabanliAracKiralamaProjesi
{
    public class CustomerManager : IPersonManager
    {
        List<Customer> customers = new List<Customer>();
        public void Ekle()
        {
            Customer customer = new Customer();
            Console.WriteLine("Musteri Id Giriniz: ");
            customer.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Musteri Adi Soyadi Giriniz: ");
            customer.AdSoyad = Console.ReadLine();
            Console.WriteLine("Musteri Yasi Giriniz: ");
            customer.Yas = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Musteri Adres Bilgilerini Giriniz: ");
            customer.Adres = Console.ReadLine();
          
            string connString = @"Data Source = DESKTOP-VK83I53; Initial Catalog = AracKiralamaDB; User ID = deneme; Password = 123456";
            string sqlQuery = $"INSERT INTO Musteriler VALUES({customer.Id}, '{customer.AdSoyad}' , {customer.Yas}, '{customer.Adres}')";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            using (SqlCommand command = new SqlCommand(sqlQuery, conn))
            {
                int result = command.ExecuteNonQuery();
                Console.WriteLine("Islenen Satır : " + result);
            }
            conn.Close();
        }

        public void Listele()
        {
            string connString = @"Data Source = DESKTOP-VK83I53; Initial Catalog = AracKiralamaDB; User ID = deneme; Password = 123456";
            string sqlQuery = "SELECT * FROM Musteriler";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            using (SqlCommand command = new SqlCommand(sqlQuery, conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                customers.Clear();
                while (reader.Read())
                {
                    Customer customer = new Customer();
                    customer.Id = reader.GetInt32(0);
                    customer.AdSoyad = reader.GetString(1);
                    customer.Yas = reader.GetInt32(2);
                    customer.Adres = reader.GetString(3);
                    customers.Add(customer);
                }
            }
            conn.Close();

            Console.WriteLine(" - - - - Musteri Bilgileri - - - - ");
            foreach (var item in customers)
            {
                Console.WriteLine("Musteri Id: " + item.Id);
                Console.WriteLine("Ad Soyad : " + item.AdSoyad);
                Console.WriteLine("Yas : " + item.Yas);
                Console.WriteLine("Adres Bilgileri : " + item.Adres);
                Console.WriteLine("- - - - - - - - - - - - - - - - - ");
            }
        }

        public void Sil()
        {
            Listele();
            Console.WriteLine("Silinecek Musterinin ID Numarasini Giriniz: ");
            int id = Convert.ToInt32(Console.ReadLine());

            string connString = @"Data Source = DESKTOP-VK83I53; Initial Catalog = AracKiralamaDB; User ID = deneme; Password = 123456";
            string sqlQuery = $"DELETE Musteriler WHERE ID = {id}";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            using (SqlCommand command = new SqlCommand(sqlQuery, conn))
            {
                int result = command.ExecuteNonQuery();
                Console.WriteLine("Islenen Satır : " + result);
            }
            conn.Close();
        }
    }
}
