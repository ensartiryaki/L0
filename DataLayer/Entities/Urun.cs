using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Urun
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Ürün Adı"), StringLength(30, MinimumLength = 2, ErrorMessage = "{0} {1} ve {2} arasında olmalı.")]
        public string UrunAdi { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "SonKullanmaTarihi"), DataType(DataType.Date), Column(TypeName = "Date"), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime SonKullanmaTarihi { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Fiyat"), Range(0.01, 999999.99, ErrorMessage = "{0} {1} ve {2} arasında olmalı."), Column(TypeName = "decimal(8, 2)")]
        public decimal Fiyat { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "ParaBirimi"), StringLength(30, MinimumLength = 2, ErrorMessage = "{0} {1} ve {2} arasında olmalı.")]
        public string  ParaBirimi { get; set; }
        public bool Aktiflik { get; set; }

    }
}
