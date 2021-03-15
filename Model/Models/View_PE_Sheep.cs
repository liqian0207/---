using SqlSugar;
using System;
using System.Collections.Generic;

#nullable disable

namespace Model.Models
{
    public partial class View_PE_Sheep
    {
        [SugarColumn(IsIdentity = true, IsPrimaryKey = true)]
        public int PeId { get; set; }
        public string PeNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSex { get; set; }
        public int? CustomerAge { get; set; }
        public int PeType { get; set; }
        public string PeName { get; set; }
        public int? IsDelete { get; set; }
        public TimeSpan? CreateTime { get; set; }
        public TimeSpan? DeleteTime { get; set; }
    }
}
