using Utils.DataAnnotations;


namespace Veiculos.Dominio
{
    public enum TipoCombustivel 
    {
        [IsDefaultValue]
        NaoExiste,
        Disel, 
        Alcool,
        Gasolina, 
        Vapor 
    }
}