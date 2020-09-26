using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace dev.budget.business.Entities
{
    [Table("people_addresses")]
    public class PersonAddress
    {
        [Key]
        [Column("person_id", Order =0)]
        public int PersonId { get; set; }
        [Key]
        [Column("address_id", Order =1)]
        public int AddressId { get; set; }

        public Person Person { get; set; }
        public Address Address { get; set; }
    }
}
