using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSafeTypes
{
    public interface IThreadSafeList
    {
        protected IList List { get; set; }
        public int Count();

        public void Add(Object obj);

        public void Remove(Object obj);
    }
}