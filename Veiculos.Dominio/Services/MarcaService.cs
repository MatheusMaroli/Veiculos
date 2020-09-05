using System;
using Utils.Web.Responses;
using Veiculos.Dominio.Entidades;
using Veiculos.Dominio.Repositorio;
using Veiculos.Dominio.AcessoDados;

namespace Veiculos.Dominio.Services
{
    public class MarcaService : BaseService<Marca> 
    {
        public MarcaService(Db db) : base(db)
        {
        }

        public override ResponseModelValidator Cadastrar(Marca model)
        {
            ValidarCadastro(model);
            if (_response.IsValidResponse())
            {
                try
                {
                    var repositorio = new Repositorio<Marca>(_db);
                    repositorio.Adicionar(model);
                }
                catch(Exception e)
                {
                    _response.SetError("Falha para salvar dados. Tente novamente.");
                }
            }

            return _response;
        }

        public override ResponseModelValidator Editar(Marca model)
        {
            ValidarEditar(model);
            if (_response.IsValidResponse())
            {
                try
                {
                    var repositorio = new Repositorio<Marca>(_db);
                    repositorio.Editar(model);
                }
                catch(Exception e)
                {
                    _response.SetError("Falha para salvar dados. Tente novamente.");
                }
            }

            return _response;
        }

        public override ResponseModelValidator Excluir(int id)
        {
            throw new System.NotImplementedException();
        }

        protected override void ValidarCadastro(Marca model)
        {
            if (string.IsNullOrEmpty(model.Nome))
                _response.SetError("Nome", "Informe o nome");
        }

        protected override void ValidarEditar(Marca model)
        {
            if (string.IsNullOrEmpty(model.Nome))
                _response.SetError("Nome", "Informe o nome");
        }

        protected override void ValidarExcluir(Marca model)
        {
            throw new System.NotImplementedException();
        }
    }
}