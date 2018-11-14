using System;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Tarefas.Web.Mvc.Models;

namespace Senai.Tarefas.Web.Mvc.Controllers
{
    public class TarefaController : Controller
    {
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(IFormCollection form)
        {
            TarefaModel tarefa = new TarefaModel();

            if (System.IO.File.Exists("tarefa.csv"))
            {
                string[] tarefas = System.IO.File.ReadAllLines("tarefas.csv");

                tarefa.ID = tarefas.Length + 1;
            }
            else
            {
                tarefa.ID = 1;
            }

            tarefa.Nome = form["nome"];
            tarefa.Descricao = form["descricao"];
            tarefa.Tipo = form["tipo"];
            tarefa.DataCriacao = DateTime.Now;

            using(StreamWriter sw = new StreamWriter(new FileStream("tarefas.csv",FileMode.Append, FileAccess.Write), Encoding.UTF8))
            {
                sw.WriteLine($"{tarefa.ID};{tarefa.Nome};{tarefa.Descricao};{tarefa.Tipo};{tarefa.IDUsuario};{tarefa.DataCriacao}");
            }

            ViewBag.Mensagem = "Tarefa Cadastrada!";

            return View();
        }
    }
}