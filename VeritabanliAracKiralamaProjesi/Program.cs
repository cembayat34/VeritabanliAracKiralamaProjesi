using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace VeritabanliAracKiralamaProjesi
{
    class Program
    {
        public static List<string> kullaniciAdlari = new List<string>();
        public static List<string> sifreler = new List<string>();

        static void Main(string[] args)
        {
            kullaniciAdlari.Add("a");
            sifreler.Add("a");

            ArabaManager arabaManager = new ArabaManager();
            IPersonManager customerManager = new CustomerManager();




            int istek = -1;
            int i = 0;
            string kullaniciAdi;
            string sifre;


            while (istek != 0)
            {
                Console.WriteLine("---BYT Rent A Car---  \n\n\n1-Yönetici Girişi \n2-Personel Girişi");
                Console.Write("Giriş yöntemini seçiniz-->");
                istek = Convert.ToInt32(Console.ReadLine());
                Console.Clear();


                if (istek == 1)
                {
                    Console.Write("Kullanıcı adınızı giriniz:");
                    kullaniciAdi = Console.ReadLine();
                    Console.Write("Parolanızı giriniz:");
                    sifre = Console.ReadLine();

                    for (i = 0; i < kullaniciAdlari.Count; i++)
                    {
                        if (kullaniciAdi == kullaniciAdlari[i])
                        {
                            if (sifre == sifreler[i])
                            {
                                Console.Clear();
                                Console.WriteLine("Girş Yapıldı \n");
                                Console.Clear();
                                int yoneticiIstek = -1;
                                while (yoneticiIstek != 0)
                                {
                                    Console.WriteLine("---Yönetici Paneli---");
                                    Console.WriteLine("1-Arac Yonetimi \n2-Personel Yonetimi \n3-Musteri Yonetimi \n0-Bir Üst Menü");
                                    Console.Write("Yapmak istediğiniz işlemi seçiniz-->");
                                    yoneticiIstek = Convert.ToInt32(Console.ReadLine());
                                    Console.Clear();

                                    switch (yoneticiIstek)
                                    {
                                        case 1:
                                            Console.WriteLine("---ARAC YONETIMI---");
                                            Console.WriteLine("1-Arac Ekle \n2-Arac Sil \n3-Araclari Listele \n0-Bir Üst Menü");
                                            yoneticiIstek = Convert.ToInt32(Console.ReadLine());
                                            Console.Clear();
                                            switch (yoneticiIstek)
                                            {
                                                case 1:
                                                    Console.Clear();
                                                    arabaManager.ArabaEkle();
                                                    Console.Clear();
                                                    Console.WriteLine("Arac Veritabanina Eklendi");

                                                    break;
                                                case 2:
                                                    Console.Clear();
                                                    arabaManager.ArabaSil();
                                                    Console.Clear();
                                                    Console.WriteLine("Arac Veritabanindan Silindi");
                                                    break;
                                                case 3:
                                                    Console.Clear();
                                                    arabaManager.ArabaListele();
                                                    break;
                                                case 0:
                                                    Console.WriteLine("Bir üst menüye dönülüyor...");
                                                    break;
                                                default:
                                                    break;

                                            }
                                            break;

                                        case 2:
                                            Console.WriteLine("---PERSONEL YONETIMI---");
                                            Console.WriteLine("1-Personel Ekle \n2-Personel Sil \n3-Personelleri Listele \n0-Bir Üst Menü");
                                            yoneticiIstek = Convert.ToInt32(Console.ReadLine());
                                            Console.Clear();
                                            switch (yoneticiIstek)
                                            {
                                                case 1:
                                                    Console.WriteLine("PERSONEL EKLENDI");

                                                    break;
                                                case 2:
                                                    Console.WriteLine("PERSONEL SILINDI");
                                                    Console.Clear();
                                                    break;
                                                case 3:
                                                    Console.WriteLine("PERSONELLER LISTELENDI");
                                                    Console.Clear();
                                                    break;
                                                case 0:
                                                    Console.WriteLine("Bir üst menüye dönülüyor...");
                                                    break;
                                                default:
                                                    break;
                                            }
                                            break;

                                        case 3:
                                            Console.WriteLine("---MUSTERI YONETIMI---");
                                            Console.WriteLine("1-Musteri Ekle \n2-Musteri Sil \n3-Musterileri Listele \n0-Bir Üst Menü");
                                            yoneticiIstek = Convert.ToInt32(Console.ReadLine());
                                            Console.Clear();
                                            switch (yoneticiIstek)
                                            {
                                                case 1:
                                                    Console.Clear();
                                                    customerManager.Ekle();
                                                    Console.Clear();
                                                    Console.WriteLine("Musteri EKLENDI");

                                                    break;
                                                case 2:
                                                    Console.Clear();
                                                    //musteri sil ekle
                                                    customerManager.Sil();
                                                    Console.Clear();
                                                    Console.WriteLine("Musteri SILINDI");
                                                    break;
                                                case 3:
                                                    Console.Clear();
                                                    customerManager.Listele();
                                                    break;
                                                case 0:
                                                    Console.WriteLine("Bir üst menüye dönülüyor...");
                                                    break;
                                                default:
                                                    break;
                                            }
                                            break;

                                        case 0:
                                            Console.WriteLine("Bir üst menüye dönülüyor...");
                                            break;

                                        default:
                                            Console.WriteLine("Hatalı Tuşlama Yaptınız!");
                                            break;
                                    }
                                }

                            }

                }
                            else if (istek == 2)
                            {

                                Console.Write("Kullanıcı adınızı giriniz:");
                                kullaniciAdi = Console.ReadLine();
                                Console.Write("Parolanızı giriniz:");
                                sifre = Console.ReadLine();

                                for (i = 0; i < kullaniciAdlari.Count; i++)
                                {
                                    if (kullaniciAdi == kullaniciAdlari[i])
                                    {
                                        if (sifre == sifreler[i])
                                        {
                                            Console.WriteLine("Girş Yapıldı \n");

                                            while (true)
                                            {
                                                Console.WriteLine("1-Araç Kiralama \n2-Araç Teslim Alma \n0-ÇIKIŞ");
                                                Console.Write("Yapmak istediğiniz işlemi seçiniz:");
                                                int aracIstek = Convert.ToInt32(Console.ReadLine());

                                                if (aracIstek == 1)
                                                {
                                                    Console.WriteLine("0-Tüm araçları listele\n1-Markaya Göre Listele");
                                                    Console.Write("Yapmak istediğiniz işlemi seçiniz:");
                                                    int filtreIstek = Convert.ToInt32(Console.ReadLine());

                                                    if (filtreIstek == 0)
                                                    {
                                                        //araclari listele
                                                        Console.Clear();
                                                        arabaManager.ArabaListele();
                                                        break;
                                                    }

                                                    else if (filtreIstek == 1)
                                                    {

                                                        //markalara gore listele
                                                    }

                                                    else if (aracIstek == 0)
                                                    {
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                        else { Console.WriteLine("Şifre Yanlış"); }
                                    }
                                }
                            }

                            else if (istek == 0)
                            {
                                Console.WriteLine("Sistemden çıkış yapılıyor...");
                            }

                            else
                            {
                                Console.WriteLine("Hatalı Tuşlama Yaptınız!");
                            }
                        }

                    }



                    //int menuIstek = 0;
                    //int menuIstek2 = 0;
                    //while (menuIstek != 9)
                    //{
                    //    Console.WriteLine("---Yönetici Paneli---");
                    //    Console.WriteLine("1-Arac Yonetimi \n2-Musteri Yonetim \n3-Araçlari Listele \n4-Musteri Ekle \n5-Musterileri Listele \n6-Personel Çıkar \n7-Personelleri Listele \n8-Sistemden Cikis Yap");
                    //    Console.Write("Yapmak istediğiniz işlemi seçiniz-->");
                    //    menuIstek = Convert.ToInt32(Console.ReadLine());      

                    //    switch (menuIstek)
                    //    {
                    //        case 1:
                    //            Console.Clear();
                    //            while (menuIstek2 != 0)
                    //            {
                    //                Console.WriteLine("1-Arac Ekle");
                    //                Console.WriteLine("2-Arac Sil");
                    //                Console.WriteLine("3-Arac Listele");
                    //                Console.WriteLine("4-Ust Menuye Don");
                    //                menuIstek2 = Convert.ToInt32(Console.ReadLine());

                    //                if (menuIstek2 == 1)
                    //                {
                    //                    Console.Clear();
                    //                    arabaManager.ArabaEkle();
                    //                    break;
                    //                }

                    //                if (menuIstek2 == 2)
                    //                {
                    //                    Console.Clear();
                    //                    arabaManager.ArabaSil();
                    //                    break;
                    //                }

                    //                if (menuIstek2 == 3)
                    //                {
                    //                    Console.Clear();
                    //                    arabaManager.ArabaListele();
                    //                    break;
                    //                }

                    //                if (menuIstek2 == 4)
                    //                {
                    //                    break;
                    //                }
                    //            }

                    //            Console.Clear();

                    //            arabaManager.ArabaEkle();
                    //            break;

                    //        case 2:
                    //            Console.Clear();
                    //            arabaManager.ArabaSil();
                    //            break;

                    //        case 3:
                    //            Console.Clear();
                    //            arabaManager.ArabaListele();
                    //            break;

                    //        case 4:                       
                    //            Console.Clear();
                    //            customerManager.Ekle();
                    //            break;

                    //        case 5:
                    //            Console.Clear();
                    //            customerManager.Listele();
                    //            break;

                    //        case 6:
                    //            Console.Clear();
                    //            break;

                    //        default:
                    //            break;
                    //    }
                    //}


                }
            }
        }
    }
}


