using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Test1
    {
        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public string surname { get; set; }
    }
}
