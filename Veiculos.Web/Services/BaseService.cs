
using Utils.Web.Responses;
using Veiculos.Dominio.AcessoDados;

namespace Veiculos.Web.Services
{
    public abstract class BaseService<T> where T: class
    {

        protected Db _db;
        protected ResponseModelValidator _response;
        public BaseService(Db db) {
            _db = db;
            _response = new ResponseModelValidator();
        }

        protected abstract void ValidarCadastro(T model);
        protected abstract void ValidarEditar(T model);
        protected abstract void ValidarExcluir(T model);

        public abstract ResponseModelValidator Cadastrar(T model);
        public abstract ResponseModelValidator Editar(T model);
        public abstract ResponseModelValidator Excluir(int id);
    }
}