using MiniSuper.Entity;
using System;
using MiniSuper.DataAccess;
using System.Collections.Generic;


namespace MiniSuper.BussinesLogic
{
    public class ClienteBL
    {
        private readonly ClienteRepository _Repository;
        public ClienteBL(ClienteRepository  Repository)
        {
            _Repository = Repository;
        }

        public List<Cliente> SelectAll()
        {
            List<Cliente> result = null;
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

        public int Insert(Rol entity)
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
