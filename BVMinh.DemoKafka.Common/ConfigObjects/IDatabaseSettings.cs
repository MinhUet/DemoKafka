using System;
using System.Collections.Generic;
using System.Text;

namespace BVMinh.DemoKafka.Common.ConfigObjects
{
    public interface IDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
