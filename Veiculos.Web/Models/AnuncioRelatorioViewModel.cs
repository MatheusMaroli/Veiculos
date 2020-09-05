using System;

namespace Veiculos.Web.Models
{
    public class AnuncioRelatorioViewModel
    {
        public string Modelo{get;set;}
        public string Marca {get;set;}
        public int Ano{get;set;}
        public DateTime DataVenda {get;set;}
        public double ValorCompra {get;set;}
        public double ValorVenda {get;set;}
        public double Lucro {get;set;}
    }
}