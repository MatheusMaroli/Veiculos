using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Utils.ClassExentions;

namespace Veiculos.Dominio.Entidades
{
    [Table("anuncios")]
    public class Anuncios
    {
        [Required]
        public int IdModelo {get;set;}
         [ForeignKey("IdModelo")]
        public virtual Modelo Modelo {get;set;}
        [Required]
        public int IdMarca {get;set;}
        [ForeignKey("IdMarca")]
        public virtual Marca Macar {get;set;}
        [Required]
        public int Ano {get;set;}
        [Required]
        public double ValorCompra {get;set;}
        public double ValorVenda {get;set;}
        [Required]
        public string Cor {get;set;}
        [Required, Column("TipoCombustivel")]
        public string TipoCombustivelStr 
        {
            get { return TipoCombustivel.ToString(); }
            set { TipoCombustivel = TipoCombustivelStr.ParseToEnum<TipoCombustivel>();  }
        }
        [NotMapped]
        public TipoCombustivel TipoCombustivel { get;set;}
        public DateTime DataVenda {get;set;}
    }
}