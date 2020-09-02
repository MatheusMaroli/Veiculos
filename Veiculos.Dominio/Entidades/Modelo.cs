using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Veiculos.Dominio.Entidades
{
    [Table("modelos")]
    public class Modelo : BaseEntidade
    {
        [Required]
        public string Nome {get;set;}
        [Required]
        public int IdMarca {get;set;}
        [ForeignKey("IdMarca")]
        public virtual Marca Marca {get;set;}
    }
}