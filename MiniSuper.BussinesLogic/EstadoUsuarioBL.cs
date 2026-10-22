using MiniSuper.Entity;
using System;
using MiniSuper.DataAccess;
using System.Collections.Generic;


namespace MiniSuper.BussinesLogic
{
    public class EstadoUsuarioBL
    {
        private readonly EstadoUsuarioRepository _Repository;
        public EstadoUsuarioBL(EstadoUsuarioRepository Repository)
        {
            _Repository = Repository;
        }

        public List<EstadoUsuario> SelectAll()
        {
            List<EstadoUsuario> result = null;
            try
            {
                result = _Repository.SelectAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public int Insert(EstadoUsuario entity)
        {
            int result;
            try
            {
                result = _Repository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }





    }
}
