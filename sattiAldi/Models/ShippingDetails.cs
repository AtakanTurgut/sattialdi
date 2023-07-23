using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace sattiAldi.Models
{
    public class ShippingDetails
    {
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen Adres Tanımını Giriniz")]
        public string AddressTitle { get; set; }
        [Required(ErrorMessage = "Lütfen Adres Giriniz")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Lütfen Şehir Bilgisini Giriniz")]
        public string City { get; set; }
        [Required(ErrorMessage = "Lütfen Semt Bilgisini Giriniz")]
        public string District { get; set; }
        [Required(ErrorMessage = "Lütfen Mahalle Bilgisini Giriniz")]
        public string Neighbourhood { get; set; }
        [Required(ErrorMessage = "Lütfen Posta Kodunu Giriniz")]
        public string PostCode { get; set; }

    }
}