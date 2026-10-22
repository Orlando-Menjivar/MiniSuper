using MiniSuper.DataAccess;
using MiniSuper.Entity;
using System;
using System.Collections.Generic;

namespace Super.BusinessLogic
{
    public class DetalleInventarioBL
    {
        private readonly DetalleInventarioRepository _repository;

        public DetalleInventarioBL(DetalleInventarioRepository repository)
        {
            _repository = repository;
        }

        public List<DetalleInventario> SelectAll()
        {
            List<DetalleInventario> result = null;
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
