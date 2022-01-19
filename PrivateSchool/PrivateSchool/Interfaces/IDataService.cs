using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectPartB.Interfaces
{
    internal interface IDataService
    {
        void PrintAllData();
        void InsertData<T>(object entity);
    }
}
