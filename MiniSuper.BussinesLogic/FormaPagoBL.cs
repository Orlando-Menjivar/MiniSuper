using MiniSuper.DataAccess;
using MiniSuper.Entity;
using System;
using System.Collections.Generic;

namespace Super.BusinessLogic
{
    public class FormaPagoBL
    {
        private readonly FormaPagoRepository _repository;

        public FormaPagoBL(FormaPagoRepository repository)
        {
            _repository = repository;
        }

        public List<FormaPago> SelectAll()
        {
            List<FormaPago> result = null;
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

