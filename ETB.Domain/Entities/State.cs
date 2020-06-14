using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ETB.Core.Entities
{
    public enum StateOrOthers
    {
        State, 
        Others
    }

    public class State
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Capital { get; set; }
        public StateOrOthers StateOrOthers { get; set; }
    }
}
