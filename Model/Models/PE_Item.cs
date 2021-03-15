using SqlSugar;
using System;
using System.Collections.Generic;

#nullable disable

namespace Model.Models
{
    public partial class PE_Item
    {
        [SugarColumn(IsIdentity = true, IsPrimaryKey = true)]
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int ItemTypeId { get; set; }
        public string ItemTypeName { get; set; }
    }
}
