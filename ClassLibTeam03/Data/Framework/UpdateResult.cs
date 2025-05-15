using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam03.Data.Framework
{
    public class UpdateResult : BaseResult
    {
        public int AffectedRows { get; set; }
        public DataTable DataTable { get; set; }
    }
}
