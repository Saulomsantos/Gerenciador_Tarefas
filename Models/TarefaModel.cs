using System;

namespace Senai.Tarefas.Web.Mvc.Models
{
    public class TarefaModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public int IDUsuario { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}