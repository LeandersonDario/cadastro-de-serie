using System;

using System.Collections.Generic;

namespace Cadastro_de_series
{
  public class SerieRepositorio : IRepositorio<Serie>
  {
    private List<Serie> ListaSerie = new List<Serie>();
    public List<Serie> Lista()
    {  
      return ListaSerie;      
    }

    public Serie RetornaPorId(int id)
    {
      return ListaSerie[id];      
    }

    public void Insere(Serie entidade)
    {
      ListaSerie.Add(entidade);
    }

    public void Excluir(int id)
    {
      ListaSerie[id].Excluir();      
    }

    public void Atualizar(int id, Serie entidade)
    {
      ListaSerie[id] = entidade;
    }

    public int ProximoId()
    {
      return ListaSerie.Count;
    }
        
  }
}