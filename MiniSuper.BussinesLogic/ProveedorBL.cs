using MiniSuper.DataAccess;
using MiniSuper.Entity;
using System;
using System.Collections.Generic;

namespace MiniSuper.BusinessLogic
{
    public class ProveedorBL
    {
        private readonly ProveedorRepository _repository;

        public ProveedorBL(ProveedorRepository repository)
        {
            _repository = repository;
        }

        public List<Proveedor> SelectAll()
        {
            List<Proveedor> result = null;
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