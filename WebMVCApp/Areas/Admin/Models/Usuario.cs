using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMVCApp.Areas.Admin.Models
{
    public class Usuario
    {
        public int id { get; set; }

        public string nomape { get; set; }

        [Required(ErrorMessage = "Username required.", AllowEmptyStrings = false)]
        public string nomuser { get; set; }

        [Required(ErrorMessage = "Password required.", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string passuser { get; set; }

        public string email { get; set; }

        // Variable sin asignar tiene el valor por defecto: default(T)
        DateTime _ultLogin;
        public DateTime ultLogin {
            get {
                if (_ultLogin == default(DateTime)) return DateTime.Now;
                return _ultLogin;
            }
            set { _ultLogin = value;  }
        } //= DateTime.Now;

        public int idRol { get; set; }

        public string nomRol { get; set; }

        public DateTime fecreg { get; set; }

    }
}