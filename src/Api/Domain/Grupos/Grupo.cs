using Api.Domain.Abstractions;

namespace Api.Domain.Grupos;

public class Grupo : Entity
{
    private Grupo()
    {
    }

    private Grupo(int id, string nombre, int id_Lote) : base(id, nombre)
    {
        Id_Lote = id_Lote;
    }

    private Grupo(string nombre, int id_Lote) : base(nombre)
    {
        Id_Lote = id_Lote;
    }

    public int Id_Lote { get; private set; }


    public static Grupo CrearGrupo(int? id, string nombre, int id_lote)
    {
        if(id is null)
        {
            return new Grupo(nombre, id_lote);
        }
        else
        {
            return new Grupo(id.Value, nombre, id_lote);
        }
    }

}
