using Utils.DataAnnotations;


namespace Veiculos.Dominio
{
    public enum TipoCombustivel 
    {
        [IsDefaultValue]
        NaoExiste,
        Diesel, 
        Alcool,
        Gasolina, 
        Vapor 
    }
}