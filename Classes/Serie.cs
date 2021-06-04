using System;

namespace Cadastro_de_series
{
    public class Serie : EntidadeBase
    {
      private Genero Genero { get; set; }

      private string Titulo { get; set; }

      private string Descricao { get; set; }

      private int Ano { get; set; } 

      public bool Excluido { get; set; }      
      

      public Serie( int id, Genero genero, string titulo, string  descricao, int ano )
      {
        this.Id = id;
        this.Genero = genero;
        this.Titulo = titulo;
        this.Descricao = descricao;
        this.Ano = ano;
        this.Excluido = false;
      }

      public override string ToString()
      {
      //referencia do Newline https://docs.microsoft.com/pt-br/dotnet/api/system.environment.newline?view=net-5.0
      string retorno = "";
        retorno += "Gerenero"  + this.Genero + Environment.NewLine;
        retorno += "Titulo" + this.Titulo + Environment.NewLine;
        retorno += "Descrição" + this.Descricao + Environment.NewLine;
        retorno += "Ano" + this.Ano;
        retorno += "Excluído" + this.Excluido;

        return retorno;        
      }     

      public string RetornaTitulo()
      {
        return this.Titulo;
      }

      public int RetornaId()
      {
        return this.Id;
      }

      public void Excluir()
      {
        this.Excluido = true;
      }

      public bool RetornaExcluido()
      {
        return this.Excluido;
      }
  }
}