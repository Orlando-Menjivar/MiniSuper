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

        public Cargo Select(int cargoId)
        {
            Cargo entity = null;
            try
            {
                entity = _repository.Select(cargoId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return entity;
        }

        public int Insert(Cargo entity)
        {
            int result = 0;
            try
            {
                result = _repository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}
