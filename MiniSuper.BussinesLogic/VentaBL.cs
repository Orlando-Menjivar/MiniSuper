using MiniSuper.DataAccess;
using MiniSuper.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSuper.BussinesLogic
{
    public class VentaBL
    {
        private readonly VentaRepository _repository;

        public VentaBL(VentaRepository repository)
        {
            _repository = repository;
        }

        public List<Venta> SelectAll()
        {
            List<Venta> result = null;
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
