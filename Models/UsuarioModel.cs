using System;

namespace Senai.Tarefas.Web.Mvc.Models
{
    public class UsuarioModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Tipo { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}