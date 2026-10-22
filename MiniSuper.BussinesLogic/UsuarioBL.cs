using MiniSuper.DataAccess;
using MiniSuper.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSuper.BussinesLogic
{
    public class UsuarioBL
    {
        private readonly UsuarioRepository _repository;

        public UsuarioBL(UsuarioRepository repository)
        {
            _repository = repository;
        }

        public List<Usuario> SelectAll()
        {
            List<Usuario> result = null;
            try
            {
                result = _repository.SelectAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
