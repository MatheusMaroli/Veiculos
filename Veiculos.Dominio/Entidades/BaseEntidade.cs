using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Utils.ClassExtensions;


namespace Veiculos.Dominio.Entidades
{
    public class BaseEntidade
    {
        [Key, Required]
        public int Id { get; set; }
        [NotMapped]
        public bool Deletado { get; set; }
        [Column("Deletado")]
        public string DeletadoStr
        {
            get { return Deletado.ToString(); }
            set { Deletado = value.ParseToBool(); }
        }
    }
}