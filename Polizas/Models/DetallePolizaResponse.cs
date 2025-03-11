namespace Polizas.Models
{
    public class DetallePolizaResponse
    {
        public List<DetallePoliza>? DetallePolizas { get; set; }
    }
    public class DetallePoliza
    {
        public string? NumeroPoliza { get; set; }
        public string? NombreCliente { get; set; }
        public string? Identificacion { get; set; }
        public string? Brocker { get; set; }
        public string? Ciudad { get; set; }
        public string? Persona { get; set; }
        public string? Ramo { get; set; }
        public string? MontoAsegurado { get; set; }
        public string? Plan { get; set; }
        public string? Aseguradora { get; set; }
        public string? InicioVigencia { get; set; }
        public string? FinVigencia { get; set; }
        public bool Renovar { get; set; }
    }

}
