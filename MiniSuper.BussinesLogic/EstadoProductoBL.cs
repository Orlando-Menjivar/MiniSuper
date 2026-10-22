using MiniSuper.DataAccess;
using MiniSuper.Entity;
using System;
using System.Collections.Generic;

namespace MiniSuper.BusinessLogic
{
    public class EstadoProductoBL
    {
        private readonly EstadoProductoRepository _repository;

        public EstadoProductoBL(EstadoProductoRepository repository)
        {
            _repository = repository;
        }

        public List<EstadoProducto> SelectAll()
        {
            List<EstadoProducto> result = null;
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