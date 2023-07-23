using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sattiAldi.Entity
{
    public enum EnumOrderState
    {
        [Display(Name = "Onay Bekleniyor.")]
        Bekleniyor,

        [Display(Name = "Sipariş Paketlendi.")]
        Paketlendi,

        [Display(Name = "Sipariş Kargoya Verildi.")]
        Kargolandı,

        [Display(Name = "Sipariş Tamamlandı.")]
        Tamamlandı,
    }
}