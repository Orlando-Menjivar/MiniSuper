using MiniSuper.DataAccess;
using MiniSuper.Entity;
using System;
using System.Collections.Generic;

namespace Super.BusinessLogic
{
    public class PagoBL
    {
        private readonly PagoRepository _repository;

        public PagoBL(PagoRepository repository)
        {
            _repository = repository;
        }

        public List<Pago> SelectAll()
        {
            List<Pago> result = null;
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
