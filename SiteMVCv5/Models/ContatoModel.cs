using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMVCv5.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o Nome do contato")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o Email do contato")]
        [EmailAddress (ErrorMessage = "Digite um Email Valido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite o Celular do contato")]
        [Phone(ErrorMessage = "O celular informado não é valido!")]
        public string Celular { get; set; }
    }
}
