﻿using Microsoft.EntityFrameworkCore;
using SiteMVCv5.Data;
using SiteMVCv5.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiteMVCv5.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    { 
        private readonly BancoContext _context;
        public UsuarioRepositorio(BancoContext bancoContext)
        {
            this._context = bancoContext;
        }
        public UsuarioModel BuscarPorLogin(string login)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
            // listar informações no banco onde o login do db é igual ao login "parametro";
        }
        public UsuarioModel BuscarPorEmailELogin(string email, string login)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Login.ToUpper() == login.ToUpper());
        }
        public UsuarioModel ListarPorId(int id)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Id == id);
            // listar na view informações do id
        }
        public List<UsuarioModel> BuscarTodos()
        {
            return _context.Usuarios
                .Include(x => x.Contatos)
                .ToList();
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            usuario.SetSenhaHash();
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;
            //gravar no banco de dados
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = ListarPorId(usuario.Id);

            if (usuarioDB == null) throw new Exception("Houve um erro na atualização do usuário!");

            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.DataAtualizacao = DateTime.Now;

            _context.Usuarios.Update(usuarioDB);
            _context.SaveChanges();

            return usuarioDB;
        }

        public UsuarioModel AlterarSenha(AlterarSenhaModel alterarSenhaModel)
        {
            UsuarioModel usuarioDB = ListarPorId(alterarSenhaModel.Id);

            if (usuarioDB == null) throw new Exception("Houve um erro na atualização da senha, usuário não encontrado!");

            if (!usuarioDB.SenhaValida(alterarSenhaModel.SenhaAtual)) throw new Exception("Senha atual não confere!");

            if (usuarioDB.SenhaValida(alterarSenhaModel.NovaSenha)) throw new Exception("Nova Senha deve ser diferente da senha atual!");

            usuarioDB.SetNovaSenha(alterarSenhaModel.NovaSenha);
            usuarioDB.DataAtualizacao = DateTime.Now;

            _context.Usuarios.Update(usuarioDB);
            _context.SaveChanges();

            return usuarioDB;

        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDB = ListarPorId(id);

            if (usuarioDB == null) throw new Exception("Houve um erro ao deletar um usuário!");

            _context.Usuarios.Remove(usuarioDB);
            _context.SaveChanges();

            return true;
        }

      
    }
}
