using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Veiculos.Dominio.Entidades
{
    [Table("marcas")]
    public class Marca : BaseEntidade
    {
        [Required]
        public string Nome {get;set;}
        public virtual ICollection<Modelo> Marcas {get;set;}
    }
}