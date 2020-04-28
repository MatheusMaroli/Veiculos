using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Veiculos.Dominio.Entidades
{
    public class BaseEntidade
    {
        public int Id { get; set; }
        public bool Deletado { get; set; }
        [Column("Deletado")]
        public string DeletadoStr
        {
            get { return Deletado.ToString(); }
            set { Deletado = value == "true"; }
        }
    }
}