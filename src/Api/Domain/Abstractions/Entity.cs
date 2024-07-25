namespace Api.Domain.Abstractions;

public abstract class Entity
{
    protected Entity()
    {
        
    }

    protected Entity(int id, string nombre)
    {
        Id = id;
        Nombre = nombre;
    }

    protected Entity(string nombre)
    {
        Nombre = nombre;
    }

    // init porque el id nunca va a cambiar
    public int Id { get; init; }

    public string? Nombre { get; private set; }
}
