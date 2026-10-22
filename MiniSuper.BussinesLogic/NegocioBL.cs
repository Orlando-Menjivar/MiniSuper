using MiniSuper.DataAccess;
using MiniSuper.Entity;
using System;
using System.Collections.Generic;

namespace Super.BusinessLogic
{
    public class NegocioBL
    {
        private readonly NegocioRepository _repository;

        public NegocioBL(NegocioRepository repository)
        {
            _repository = repository;
        }

        public List<Negocio> SelectAll()
        {
            List<Negocio> result = null;
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
