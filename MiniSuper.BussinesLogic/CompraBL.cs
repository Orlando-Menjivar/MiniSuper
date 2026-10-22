using MiniSuper.DataAccess;
using MiniSuper.Entity;
using System;
using System.Collections.Generic;

namespace MiniSuper.BusinessLogic
{
    public class CompraBL
    {
        private readonly CompraRepository _repository;

        public CompraBL(CompraRepository repository)
        {
            _repository = repository;
        }

        public List<Compra> SelectAll()
        {
            List<Compra> result = null;
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