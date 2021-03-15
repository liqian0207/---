using SqlSugar;
using System;
using System.Collections.Generic;

#nullable disable

namespace Model.Models
{
    public partial class PE_Sheet
    {
        [SugarColumn(IsIdentity = true, IsPrimaryKey = true)]
        public int PeId { get; set; }
        public string PeNumber { get; set; }
        public int PeCustomerId { get; set; }
        public int PeType { get; set; }
        public int? IsDelete { get; set; }
        public TimeSpan? CreateTime { get; set; }
        public TimeSpan? DeleteTime { get; set; }
    }
}
