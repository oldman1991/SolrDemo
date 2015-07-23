using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolrNet.Attributes;


namespace SolrNetDemo
{
  public  class LogitemsSolr
    {
        [SolrUniqueKey("id")]
        public int Id { get; set; }
        [SolrField("uid")]
        public string Uid { get; set; }
        [SolrField("loglevel")]
        public int LogLevel { get; set; }
        [SolrField("method")]
        public string Method { get; set; }
        [SolrField("entry")]
        public string Entry { get; set; }
        [SolrField("eventid")]
        public int EventId { get; set; }
        [SolrField("category")]
        public string Category { get; set; }

        [SolrField("message")]
        public string Message { get; set; }
        [SolrField("time")]
        public DateTime Time { get; set; }
        [SolrField("value")]
        public string Value { get; set; }
        [SolrField("callstack")]
        public string CallStack { get; set; }
        [SolrField("ticks")]
        public string Ticks { get; set; }
        [SolrField("module")]
        public string Module { get; set; }
        [SolrField("logs_loglevel")]
        public int LogsLogLevel { get; set; }
        [SolrField("logs_time")]
        public DateTime LogsTime { get; set; }
        [SolrField("logs_id")]
        public int LogsId { get; set; }
    }
}
