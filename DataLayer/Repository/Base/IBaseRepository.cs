using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository.Base
{
    public interface IBaseRepository:IRepository
    {
        int CommandTimeout { get; set; }
        string ConnectionString { get; set; }
    }
}
