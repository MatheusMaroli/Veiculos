using System.Runtime.Serialization;
using System;
using Utils.Web.Responses;
using Veiculos.Dominio.Entidades;
using Veiculos.Dominio.Repositorio;
using Veiculos.Dominio.AcessoDados;

namespace Veiculos.Dominio.Services
{
    public class ModeloService : BaseService<Modelo> 
    {
        public ModeloService(Db db) : base(db)
        {
        }

        public override ResponseModelValidator Cadastrar(Modelo model)
        {
            ValidarCadastro(model);
            if (_response.IsValidResponse())
            {
                try
                {
                    var repositorio = new Repositorio<Modelo>(_db);
                    repositorio.Adicionar(model);
                    _response.Body = model.Id;
                }
                catch(Exception e)
                {
                    _response.SetError("Falha para salvar dados. Tente novamente. Erro ===> " + e.ToString());
                }
            }

            return _response;
        }

        public override ResponseModelValidator Editar(Modelo model)
        {
            ValidarEditar(model);
            if (_response.IsValidResponse())
            {
                try
                {
                    var repositorio = new Repositorio<Modelo>(_db);
                    repositorio.Editar(model);
                }
                catch(Exception e)
                {
                    _response.SetError("Falha para salvar dados. Tente novamente."+ e.ToString());
                }
            }

            return _response;
        }

        public override ResponseModelValidator Excluir(int id)
        {
            throw new System.NotImplementedException();
        }

        private void ValidacaoPadrao(Modelo model) 
        {
            if (model.IdMarca <= 0)    
                _response.SetError("IdMarca", "Informe a marca");

            if (string.IsNullOrEmpty(model.Nome))
                _response.SetError("Nome", "Informe o nome");
        }

        protected override void ValidarCadastro(Modelo model)
        {
            ValidacaoPadrao(model);
        }

        protected override void ValidarEditar(Modelo model)
        {
            if (model.Id <=0)
                _response.SetError("Id", "Id não informado para edição");
            ValidacaoPadrao(model);
        }

        protected override void ValidarExcluir(Modelo model)
        {
            throw new System.NotImplementedException();
        }
    }
}