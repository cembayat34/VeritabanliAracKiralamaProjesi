using System;
using System.Collections.Generic;
using System.Text;

namespace VeritabanliAracKiralamaProjesi
{
    public class Customer : IPerson
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public int Yas { get; set; }
        public string Adres { get; set; }
        
    }
}
