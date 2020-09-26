using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace dev.budget.business.Entities
{
    [Table("PeopleEnterpeises")]
    public class PersonEnterprise
    {
        [Key]
        [Column("person_id",Order =0)]
        public int PersonId { get; set; }
        [Key]
        [Column("enterprise_id",Order =1)]
        public int EnterpriseId { get; set; }

        public Person Person { get; set; }
        public Enterprise Enterprise { get; set; }
    }
}
