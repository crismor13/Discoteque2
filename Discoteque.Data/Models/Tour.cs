using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Discoteque.Data.Models
{
    public class Tour : BaseEntity<int>
    {
        public string Name { get; set; } = "";
        public string City { get; set; } = "";
        public DateOnly Date { get; set; }
        public bool CompletelySold { get; set; }

        [ForeignKey("Id")]
        public int ArtistId { get; set; }

        public virtual Artist? Artist { get; set; }
    }
}