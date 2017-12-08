using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    interface Expense
    {
        float GetExpense();
        void Report();
    }

    class Travel : Expense
    {
        public float GetExpense()
        {
            throw new NotImplementedException();
        }

        public void Report()
        {
            throw new NotImplementedException();
        }
    }

    class Food : Expense
    {
        public float GetExpense()
        {
            throw new NotImplementedException();
        }

        public void Report()
        {
            throw new NotImplementedException();
        }
    }

    class OnDemand : Expense
    {
        public float GetExpense()
        {
            throw new NotImplementedException();
        }

        public void Report()
        {
            throw new NotImplementedException();
        }
    }

    class Client
    {
        String type = "Travel";

        private Expense getExpenseInstance()
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

        private float CalculateExpense()
        {
            Expense expense;
            if (type.Equals("Travel"))
                expense = new Travel();
            else if (type.Equals("Food"))
                expense = new Food();
            else if (type.Equals("OnDemand"))
                expense = new OnDemand();
            else
                expense = null;
            return expense.GetExpense();
        }


        private void GenerateExpenseReport()
        {
            Expense expense;
            if (type.Equals("Travel"))
                expense = new Travel();
            else if (type.Equals("Food"))
                expense = new Food();
            else if (type.Equals("OnDemand"))
                expense = new OnDemand();
            else
                expense = null;
            expense.Report();
        }

        //public Expense GetExpenseFromSimpleFactory()
        //{

        //    SimpleFactory simpleFactory = new SimpleFactory();
        //    expense = simpleFactory.getExpenseInstance(this.type);
        //    return expense;
        //}




    }
}
