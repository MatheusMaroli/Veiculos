using System;
using System.Collections.Generic;
using Veiculos.Dominio.Entidades;
using Veiculos.Dominio.AcessoDados;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Veiculos.Dominio.Repositorio
{
    public class Repositorio<T> where T : BaseEntidade
    {
        private Db _db;

        public Repositorio(Db db){
            _db = db;
        }

        public IEnumerable<T> Get
        {
            get
            {
                return _db.Set<T>().ToList().Where(e => !e.Deletado).ToList();
            }
        }

        public IEnumerable<T> GetMetodo()
        {
            return _db.Set<T>().Where(e => !e.Deletado).ToList();
        }  


        
        public bool Editar(T entidade)
        {
            try
            {
                _db.Entry<T>(entidade).State = EntityState.Modified;
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Erro na Edição do Registro", e);
            }
        }

        public bool Adicionar(T entidade)
        {
            try
            {
                _db.Set<T>().Add(entidade);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Erro na Edição do Registro", e);
            }

        }
        

        public void Excluir(T entidade)
        {
            try
            {

                entidade.Deletado = true;
                Editar(entidade);
            }
            catch (Exception e)
            {
                throw new Exception("Erro na Exclusão do Registro", e);
            }
        }


    }
}
