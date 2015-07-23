using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Practices.ServiceLocation;
using SolrNet;
using SolrNet.Commands.Parameters;


namespace SolrNetDemo
{
    public  class SolrNetOperate
    {
     public   SolrNetOperate()
        {
            Startup.Init<LogitemsSolr>("http://218.244.130.242:5000/solr/logs");
        }

        /// <summary>
        /// </summary>
        /// <param name="dictPars">查询参数字典</param>
        /// <param name="start">分页开始标识</param>
        /// <param name="rows">每页数量</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="count">输出参数 总个数</param>
        /// <returns></returns>
        public  List<int> GroupingSerach(Dictionary<string, string> dictPars, int start, int rows,
            DateTime startTime, DateTime endTime, out int count)
        {
            //定义solr
            var solr = ServiceLocator.Current.GetInstance<ISolrOperations<LogitemsSolr>>();
            var queryOptions = new QueryOptions();
            //定义分组
            var groupingParameters = new GroupingParameters();
            groupingParameters.Fields = new Collection<string> {"logs_id"};
            groupingParameters.Ngroups = true; //设置查询分组的总个数为true
            //定义过滤条件
            var timeRange = new SolrQueryByRange<DateTime>("logs_time", startTime, endTime);
            queryOptions.AddFilterQueries(timeRange);
            foreach (string key in dictPars.Keys)
            {
                queryOptions.AddFilterQueries(new SolrQueryByField(key, dictPars[key]));
            }
            //定义排序
            queryOptions.OrderBy = new Collection<SortOrder> {new SortOrder("logs_id", Order.DESC)};
            queryOptions.Grouping = groupingParameters;
            queryOptions.Start = start;
            queryOptions.Rows = rows;
            SolrQueryResults<LogitemsSolr> res = solr.Query(SolrQuery.All, queryOptions);
            GroupedResults<LogitemsSolr> items = res.Grouping["logs_id"];
            count = items.Ngroups ?? 0;
            var listStr = new List<int>();
            foreach (var item in items.Groups)
            {
                listStr.Add(Convert.ToInt32(item.GroupValue));
            }
            return listStr;
        }
    }
}