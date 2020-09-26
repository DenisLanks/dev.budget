using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace dev.budget.business.Entities
{
    [Table("enterprises")]
    public class Enterprise
    {
        [Column("id")]
        public int ID { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("cnpj")]
        public string CNPJ { get; set; }
    }
}
