//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Var15.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class VW_House
    {
        public string NameComplex { get; set; }
        public string NameStreet { get; set; }
        public string NumberHouse { get; set; }
        public string NameStatus { get; set; }
        public Nullable<int> CountSold { get; set; }
        public Nullable<int> CountReady { get; set; }
        public Nullable<int> IdStreet { get; set; }
        public Nullable<int> IdComplex { get; set; }
        public decimal AddingCostApartament { get; set; }
        public decimal BuildingCostHouse { get; set; }
        public int IdHouseInComplex { get; set; }
    }
}
