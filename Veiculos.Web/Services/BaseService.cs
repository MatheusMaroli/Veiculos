
using Utils.Web.Responses;

namespace Veiculos.Web.Services
{
    public abstract class BaseService<T> where T: class
    {

        protected object _db;
        public BaseService(object db) {
            _db = db;
        }

        protected abstract void ValidarCadastro(T model);
        protected abstract void ValidarEditar(T model);
        protected abstract void ValidarExcluir(T model);

        public abstract ResponseModelValidator Cadastrar(T model);
        public abstract ResponseModelValidator Editar(T model);
        public abstract ResponseModelValidator Excluir(int id);
    }
}