using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolrNetDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,string>paraDict=new Dictionary<string, string>();
            paraDict.Add("message","数据库");
            DateTime start = DateTime.Now.AddDays(-3);
            DateTime end = DateTime.Now.AddDays(-1);
            int count;
          var res=  SolrNetOperate.GroupingSerach(paraDict, 0, 10, start, end, out count);
        }
    }
}
