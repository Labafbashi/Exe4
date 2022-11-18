using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exe4
{
    internal class ExamineQueue : Queue
    {
        private List<string> q;

        public ExamineQueue()
        {
            this.q = new List<string>();
        }

        public void AddToQueue (string name)
        {
            q.Add(name);
        }
        public void RemoveFromQueue()
        {
            q.RemoveAt(0);
        }
        public void PrintQueue()
        {
            foreach (string name in q)
            {
                Console.WriteLine(name);
            }
        }
    }
}
