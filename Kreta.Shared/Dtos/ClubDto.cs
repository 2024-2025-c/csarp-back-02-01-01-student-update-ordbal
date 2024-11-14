using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Shared.Dtos
{
    public class ClubDto
    {
        public Guid Id { get; set; }
        public string ClubName { get; set; } = string.Empty;
        public DateTime Alapitas { get; set; }
        public string Edzo { get; set; } = string.Empty;
    }
}
