using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fak3News.Domain.Models
{
    public abstract class DatabaseUnit
    {
        public Guid Id { get; set; }
    }
}