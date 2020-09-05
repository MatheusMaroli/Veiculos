using System;
using Utils.Web.Responses;
using Veiculos.Dominio.AcessoDados;
using Veiculos.Dominio.Entidades;
using Veiculos.Dominio.Repositorio;

namespace Veiculos.Dominio.Services
{
    public class AnuncioService : BaseService<Anuncio>
    {
        public AnuncioService(Db db) : base(db)
        {
        }

        public override ResponseModelValidator Cadastrar(Anuncio model)
        {
            ValidarCadastro(model);
            if(_response.IsValidResponse())
            {
                try
                {
                    var respositorio = new Repositorio<Anuncio>(_db);
                    respositorio.Adicionar(model);
                }
                catch(Exception e)
                {
                    _response.SetError("Erro fatal no servidor. Erro ===> " + e.ToString());
                }
            }

            return _response;
        }

        public override ResponseModelValidator Editar(Anuncio model)
        {
            ValidarEditar(model);
            if(_response.IsValidResponse())
            {
                try
                {
                    var respositorio = new Repositorio<Anuncio>(_db);
                    respositorio.Editar(model);
                }
                catch(Exception e)
                {
                    _response.SetError("Erro fatal no servidor. Erro ===> " + e.ToString());
                }
            }

            return _response;
        }

        public override ResponseModelValidator Excluir(int id)
        {
            throw new System.NotImplementedException();
        }

        private void ValidarPadrao(Anuncio model) {
            if (model.IdMarca <=0)
                _response.SetError("IdMarca", "Informe a marca");
            if (model.IdModelo <=0)
                _response.SetError("IdMarca", "Informe o Modelo");
            if (model.Ano <=0)
                _response.SetError("Ano", "Informe o Ano");
            if (model.ValorCompra <= 0)
                _response.SetError("ValorCompra", "Informe o valor de compra");
            if (model.ValorVenda <= 0)
                _response.SetError("ValorVenda", "Informe o valor de venda");
            if (string.IsNullOrEmpty(model.Cor))   
                _response.SetError("Cor", "Informe a cor"); 
            if (model.TipoCombustivel == TipoCombustivel.NaoExiste)               
                _response.SetError("TipoCombustivel", "Informe o tipo do combustivel");  
        }

        protected override void ValidarCadastro(Anuncio model)
        {
            ValidarPadrao(model);
        }

        protected override void ValidarEditar(Anuncio model)
        {
            
            ValidarPadrao(model);
        }

        protected override void ValidarExcluir(Anuncio model)
        {
            throw new System.NotImplementedException();
        }
    }
}