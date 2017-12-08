using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class SimpleFactory
    {
        public Expense getExpenseInstance(String type)
        {
            if (type.Equals("Travel"))
                return new Travel();
            else if (type.Equals("Food"))
                return new Food();
            else if (type.Equals("OnDemand"))
                return new OnDemand();
            else
                return null;
        }
    }

   

    
}
