using IRepository;
using IService;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class PeCustomerService:BaseService<PE_Customer>,IPeCustomerService
    {
        private readonly IPeCustomerRepository peCustomerRepository;
        public PeCustomerService(IPeCustomerRepository baseRepository)
        {
            base._BaseRepository = baseRepository;
            peCustomerRepository = baseRepository;
        }

        #region 特例
        //该类特殊的方法
        //void a()
        //{
        //    peCustomerRepository.Delete(1);
        //}
        #endregion
    }
}
