using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreKamp.EntityLayer.Concrete
{
    public class NewsLetters
    {
        [Key]
        public int MailID { get; set; }
        public string Mail { get; set; }
        public bool MailStatus { get; set; }
    }
}
