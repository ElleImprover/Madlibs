using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madlibs
{
   public class QA
    {
        public string Question { get; set; }
        public string Answer { get; set; }

        public int OrderID { get; set; }

    }

    public class MadlibQA
    {
        public string MadLib { get; set; }
        public List<QA> qaList { get; set; }
     public MadlibQA()
        {
            qaList = new List<QA>();
        }



    }
}
