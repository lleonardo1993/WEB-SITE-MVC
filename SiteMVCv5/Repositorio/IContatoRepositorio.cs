using SiteMVCv5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMVCv5.Repositorio
{
    public interface IContatoRepositorio
    {
        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar(ContatoModel contato);

    }
}
