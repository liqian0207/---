using SqlSugar;
using System;
using System.Collections.Generic;

#nullable disable

namespace Model.Models
{
    public partial class PE_EX_Urinalysis
    {
        [SugarColumn(IsIdentity = true, IsPrimaryKey = true)]
        public int Id { get; set; }
        public int? RepresentationTypeId { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Note { get; set; }
    }
}
