//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MPG.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Friend
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CarModel { get; set; }
        public int MilesDriven { get; set; }
        public int GallonsFilled { get; set; }
        public System.DateTime FillUpDate { get; set; }
    }
}
