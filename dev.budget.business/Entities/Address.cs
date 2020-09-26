using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace dev.budget.business.Entities
{
    [Table("addresses")]
    public class Address
    {
        [Column("id")]
        public int ID { get; set; }
        [Column("postal_code")]
        public string PostalCode { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("number")]
        public string Number { get; set; }
        [Column("state")]
        public string State { get; set; }
        [Column("city")]
        public string City { get; set; }
        [Column("complement")]
        public string Complement { get; set; }
    }
}
