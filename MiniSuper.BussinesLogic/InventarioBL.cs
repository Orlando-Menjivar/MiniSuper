using MiniSuper.DataAccess;
using MiniSuper.Entity;
using System;
using System.Collections.Generic;

namespace Super.BusinessLogic
{
    public class InventarioBL
    {
        private readonly InventarioRepository _repository;

        public InventarioBL(InventarioRepository repository)
        {
            _repository = repository;
        }

        public List<Inventario> SelectAll()
        {
            List<Inventario> result = null;
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
