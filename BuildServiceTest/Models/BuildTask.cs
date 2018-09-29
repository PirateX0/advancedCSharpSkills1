using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildServiceTest.Models
{
    class BuildTask
    {
        public long Id { get; set; }
        public long BuildInfoId { get; set; }
        public int Status { get; set; }
        public string Name { get; set; }
        public string ProcessId { get; set; }
    }
}
