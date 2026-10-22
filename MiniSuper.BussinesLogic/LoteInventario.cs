using MiniSuper.Entity;
using System;
using MiniSuper.DataAccess;
using System.Collections.Generic;


namespace MiniSuper.BussinesLogic
{
    public class LoteInventarioBL
    {
        private readonly LoteInventarioRepository _Repository;
        public LoteInventarioBL(LoteInventarioRepository   Repository)
        {
            _Repository = Repository;
        }

        public List<LoteInventario> SelectAll()
        {
            List<LoteInventario> result = null;
            try
            {
                result = _Repository.SelectAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public int Insert(LoteInventario entity)
        {
            int result;
            try
            {
                result = _Repository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }





    }
}
