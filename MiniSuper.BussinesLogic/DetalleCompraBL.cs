using MiniSuper.Entity;
using System;
using MiniSuper.DataAccess;
using System.Collections.Generic;


namespace MiniSuper.BussinesLogic
{
    public class DetalleCompraBL
    {
        private readonly DetalleCompraRepository _Repository;
        public DetalleCompraBL(DetalleCompraRepository Repository)
        {
            _Repository = Repository;
        }

        public List<DetalleCompra> SelectAll()
        {
            List<DetalleCompra> result = null;
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

        public int Insert(DetalleCompra entity)
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
