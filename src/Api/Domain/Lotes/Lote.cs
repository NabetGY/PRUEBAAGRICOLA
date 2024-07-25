using Api.Domain.Abstractions;

namespace Api.Domain.Lotes;

public class Lote : Entity
{
    public Lote()
    {
    }

    public Lote(int id, string nombre, int id_Finca, int arboles, string? etapa) : base(id, nombre)
    {
        Id_Finca = id_Finca;
        Arboles = arboles;
        Etapa = etapa;
    }

    public Lote(string nombre, int id_Finca, int arboles, string? etapa) : base(nombre)
    {
        Id_Finca = id_Finca;
        Arboles = arboles;
        Etapa = etapa;
    }

    public int Id_Finca { get; private set; }

    public int Arboles { get; private set; }

    public string? Etapa { get; private set; }


    public static Lote CrearLote(int? id, string nombre, int id_Finca, int arboles, string etapa)
    {
        if(id is null)
        {
            return new Lote(nombre, id_Finca, arboles, etapa);
        }
        else
        {
            return new Lote(id.Value, nombre, id_Finca, arboles, etapa);
        }
    }
}
