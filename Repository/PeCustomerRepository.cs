using IRepository;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    //要加BaseRepository<>,因为要实现IPeCustomerRepository所有的接口
    public class PeCustomerRepository:BaseRepository<PE_Customer>, IPeCustomerRepository
    {

    }
}
