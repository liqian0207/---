using SqlSugar;
using System;
using System.Collections.Generic;

#nullable disable

namespace Model.Models
{
    public partial class PE_Customer
    {
        //自增+主键
        [SugarColumn(IsIdentity =true,IsPrimaryKey =true)]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int CustomerType { get; set; }
        public string CustomerSex { get; set; }
        public int CustomerAge { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAddress { get; set; }
    }
}
