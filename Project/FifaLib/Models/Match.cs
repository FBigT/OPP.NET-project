using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaLib.Models {
    public class Match {
        public string Venue { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public string Time { get; set; }
        public string FifaId { get; set; }
    }
}
