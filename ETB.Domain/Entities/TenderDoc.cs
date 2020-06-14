using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ETB.Core.Entities
{
    public enum DocFor
    {
        NIT,
        Corrigendum
    }

    public class TenderDoc
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public string DocPath {get; set;}
        [MaxLength(50)]
        public string DocName { get; set; }
        public DocFor DocFor { get; set; }
    }
}
