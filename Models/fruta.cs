namespace Tarea1.Models;

public class Fruta
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Color { get; set; }
    public string? Sabor { get; set; }
    public string? PesoPromedio { get; set; }
    public string? Imagen { get; set; }
}

public class FrutaContainer
{
    public List<Fruta> Frutas { get; set; } = new List<Fruta>();
}
