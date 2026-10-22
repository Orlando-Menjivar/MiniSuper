using MiniSuper.DataAccess;
using MiniSuper.Entity;
using System;
using System.Collections.Generic;

namespace MiniSuper.BusinessLogic
{
    public class ProductoBL
    {
        private readonly ProductoRepository _repository;

        public ProductoBL(ProductoRepository repository)
        {
            _repository = repository;
        }

        public List<Producto> SelectAll()
        {
            List<Producto> result = null;
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