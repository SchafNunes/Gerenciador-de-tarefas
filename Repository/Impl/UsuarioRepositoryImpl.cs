using GerenciadorDeTarefas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Repository.Impl
{
    public class UsuarioRepositoryImpl : IUsuarioRepository
    {
        private readonly GerenciadorDeTarefasContext _contexto;
        public UsuarioRepositoryImpl(GerenciadorDeTarefasContext contexto)
        {
            _contexto = contexto;
        }

    public bool ExisteUsuarioPeloEmail(string email)
    {
      return _contexto.Usuario.Any(Usuario => Usuario.Email.ToLower() == email);
    }

    public Usuario GetUsuarioByLoginSenha(string login, string Senha)
    {
      return _contexto.Usuario.FirstOrDefault(Usuario => Usuario.Email == login.ToLower() && Usuario.Senha == Senha);
    }

    public void Salvar(Usuario usuario)
        {
            _contexto.Usuario.Add(usuario);
            _contexto.SaveChanges();
        }
    }
}
