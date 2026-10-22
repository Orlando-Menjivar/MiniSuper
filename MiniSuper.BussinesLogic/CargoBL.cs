using MiniSuper.DataAccess;
using MiniSuper.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSuper.BussinesLogic
{
    public class CargoBL
    {
        private readonly CargoRepository _repository;

        public CargoBL(CargoRepository repository)
        {
            _repository = repository;
        }

        public List<Cargo> SelectAll()
        {
            List<Cargo> result = null;
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
