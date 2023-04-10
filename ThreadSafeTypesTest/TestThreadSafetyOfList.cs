using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreadSafeTypes;

namespace ThreadSafeTypesTest
{
    [TestClass]
    public class TestThreadSafetyOfList
    {
        /// <summary>
        /// This method will throw an exception when the List is not thread-safe
        /// </summary>
        [TestMethod]
        public void TestAddRemoveItems()
        {
            try
            {
                int task_count = 10;
                int internal_loop_count = 10000;

                List<Task> tasks = new();
                //IThreadSafeList list = new(); implement & uncomment these lines

                for (int i = 0; i < task_count; i++)
                {
                    //tasks.Add(Task.Run(() => AddAndRemoveObject(list, internal_loop_count)));
                }

                Task.WaitAll(tasks.ToArray());
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        private async Task AddAndRemoveObject(IThreadSafeList list, int add_remove_n_times)
        {
            for(int i = 0; i < add_remove_n_times; i++)
            {
                object obj = new object();
                list.Add(obj);
                list.Remove(obj);
            }
        }
    }
}
