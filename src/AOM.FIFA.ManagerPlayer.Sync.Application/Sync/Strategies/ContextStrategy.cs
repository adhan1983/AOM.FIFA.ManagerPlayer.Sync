using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Strategies
{
    public class ContextStrategy
    {
        //https://refactoring.guru/design-patterns/strategy/csharp/example
        private IStrategy _strategy;

        //public Context()
        //{ }

        
        //public Context(IStrategy strategy)
        //{
        //    this._strategy = strategy;
        //}

        
        public void SetStrategy(IStrategy strategy)
        {
            this._strategy = strategy;
        }
        
        public void DoSomeBusinessLogic()
        {
            Console.WriteLine("Context: Sorting data using the strategy (not sure how it'll do it)");
            var result = this._strategy.DoAlgorithm(new List<string> { "a", "b", "c", "d", "e" });

            string resultStr = string.Empty;
            foreach (var element in result as List<string>)
            {
                resultStr += element + ",";
            }

            Console.WriteLine(resultStr);
        }
    }
}
