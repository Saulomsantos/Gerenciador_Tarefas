using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Tarefas.Web.Mvc.Models;

namespace Senai.Tarefas.Web.Mvc.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(IFormCollection form)
        {
            // Cria um objeto usuario com as propriedades da classe UsuarioModel
            UsuarioModel usuario = new UsuarioModel();

            // Verifica se o arquivo usuarios.csv existe
            if(System.IO.File.Exists("usuarios.csv"))
            {
                // Se existir, cria um arranjo usuarios e armazena a quantidade de linhas existentes no arquivo usuarios.csv
                string[] usuarios = System.IO.File.ReadAllLines("usuarios.csv");

                // Atribui à propriedade ID do objeto usuario o valor correspondente à quantidade de linhas + 1
                usuario.ID = usuarios.Length + 1;
            } 
            else 
            {
                // Se o arquivo não existir, atribui 1 ao ID
                usuario.ID = 1;
            }

            // Atribui à propriedade Nome o valor recebido no formulário
            usuario.Nome = form["nome"];
            // Atribui à propriedade Email o valor recebido no formulário
            usuario.Email = form["email"];
            // Atribui à propriedade Senha o valor recebido no formulário
            usuario.Senha = form["senha"];
            // Atribui à propriedade Tipo o valor recebido no formulário
            usuario.Tipo = form["tipo"];
            // Atribui à propriedade DataCriacao o valor da hora no momento da criação
            usuario.DataCriacao = DateTime.Now;

            // Escreve no arquivo usuarios.csv o usuario que acabou de ser criado
            using(StreamWriter sw = new StreamWriter("usuarios.csv",true))
            {
                // Conforme esta ordem
                sw.WriteLine($"{usuario.ID};{usuario.Nome};{usuario.Email};{usuario.Senha};{usuario.Tipo};{usuario.DataCriacao}");
            }

            // Mensagem de que o usuário foi cadastrado
            ViewBag.Mensagem = "Usuário Cadastrado!";

            return View();
        }
    }
}