namespace Chapter_2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public DateTime Birddate { get; set; }

        public string Address { get; set; }
    }
}
