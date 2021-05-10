using System;
using System.Collections.Generic;
using System.Text;

namespace ModularMonolith.Core.Entity
{
    public class OutBoxMessage
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public DateTime SavedOn { get; set; }
        public DateTime ExecutedOn { get; set; }
    }
}
