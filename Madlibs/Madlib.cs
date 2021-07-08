using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madlibs
{

    public class MadlibQA
    {
        public string MadLib { get; set; }
        public string Name { get; set; }
        public int ID { get; set; }
        public List<QA> qaList { get; set; }

        public MadlibQA()
        {
            qaList = new List<QA>();
        }
    }
}
