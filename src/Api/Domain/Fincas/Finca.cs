using Api.Domain.Abstractions;

namespace Api.Domain.Fincas;

public class Finca : Entity
{
    private Finca()
    {
    }

    private Finca(int id, string nombre, string? ubicacion, decimal hectareas, string? descripcion) : base(id, nombre)
    {
        Ubicacion = ubicacion;
        Hectareas = hectareas;
        Descripcion = descripcion;
    }

    private Finca(string nombre, string? ubicacion, decimal hectareas, string? descripcion) : base(nombre)
    {
        Ubicacion = ubicacion;
        Hectareas = hectareas;
        Descripcion = descripcion;
    }

    public string? Ubicacion { get; private set; }

    public decimal Hectareas { get; private set; }

    public string? Descripcion { get; private set; }


    public static Finca CrearFinca(int? id, string nombre, string? ubicacion, decimal hectareas, string? descripcion)
    {
        if (id is null)
        {
            return new Finca(
                nombre,
                ubicacion,
                hectareas,
                descripcion
            );
        }
        else
        {
            return new Finca(
                id.Value,
                nombre,
                ubicacion,
                hectareas,
                descripcion
            );
        }
    }

    
}
