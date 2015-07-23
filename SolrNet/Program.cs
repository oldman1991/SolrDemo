using System;
using System.Collections.Generic;


namespace SolrNetDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dictsTr = new Dictionary<string, string>();
            dictsTr.Add("message", "数据库");
            DateTime start = DateTime.Now.AddDays(-3);
            DateTime end = DateTime.Now.AddDays(-2);
            int count;
            var solr=new SolrNetOperate();
                solr.GroupingSerach(dictsTr, 0, 10, start, end,out count);
        }
    }
}
