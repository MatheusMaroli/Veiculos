using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Veiculos.Dominio.Entidades
{
    [Table("usuarios")]
    public class Usuario : BaseEntidade
    {
        [Required]
        public string Nome {get;set;}
        [Required]
        public string Email {get;set;}
        [Required]
        public string Senha {get;set;}
    }
}