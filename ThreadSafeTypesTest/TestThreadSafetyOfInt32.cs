using ThreadSafeTypes;

namespace ThreadSafeTypesTest
{
    [TestClass]
    public class TestThreadSafetyOfInt32
    {
        /// <summary>
        /// This Test Method is supposed to fail! (actually, it has a small chance of succeeding) It shows how the increment/decrement operations behave erratically when running on multiple threads that target the same value
        /// </summary>
        [TestMethod]
        public void TestThreadUNsafeInt32_IncrementDecrement()
        {
            ThreadUnsafeInt32 threadUnsafeInt32 = new();
            int task_count = 20;
            int internal_loop_count = 10000000; // 10 million
            List<Task> tasks = new();
            // i.e. we are incrementing and decrementing threadUnsafeInt32 200 million times. the result should be 0.
            // the result however will not be 0 because the increment/decrement operations are not thread-safe
            for (int i = 0; i < task_count; i++)
            {
                tasks.Add(Task.Run(() => IncrementInt32(threadUnsafeInt32, internal_loop_count)));
                tasks.Add(Task.Run(() => DecrementInt32(threadUnsafeInt32, internal_loop_count)));
            }

            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("threadUnsafeInt32 = " + threadUnsafeInt32);
            Assert.IsTrue(threadUnsafeInt32 == 0);
        }

        /// <summary>
        /// This Test Method is supposed to succeed because the Thread-Safe implementation uses Interlock.Increment/Decrement
        /// </summary>
        [TestMethod]
        public void TestThreadSafeInt32_IncrementDecrement()
        {
            ThreadSafeInt32 threadSafeInt32 = new();
            int task_count = 20;
            int internal_loop_count = 10000000; // 10 million
            List<Task> tasks = new();
            // i.e. we are incrementing and decrementing threadSafeInt32 200 million times. the result should be 0.
            for (int i = 0; i < task_count; i++)
            {
                tasks.Add(Task.Run(() => IncrementInt32(threadSafeInt32, internal_loop_count)));
                tasks.Add(Task.Run(() => DecrementInt32(threadSafeInt32, internal_loop_count)));
            }

            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("threadSafeInt32 = " + threadSafeInt32);
            Assert.IsTrue(threadSafeInt32 == 0);
        }

        /// <summary>
        /// This Test Method is supposed to fail! (actually, it has a small chance of succeeding) It shows how the add/subtract operations behave erratically when running on multiple threads that target the same value
        /// </summary>
        [TestMethod]
        public void TestThreadUNsafeInt32_AddSubtract()
        {
            ThreadUnsafeInt32 threadUnsafeInt32 = new();
            int task_count = 20;
            int internal_loop_count = 10000000; // 10 million
            int add_value = 3;
            List<Task> tasks = new();
            // i.e. we are adding/subtracting 3 from threadUnsafeInt32 200 million times. the result should be 0.
            // the result however will not be 0 because the add/subtract operations are not thread-safe
            for (int i = 0; i < task_count; i++)
            {
                tasks.Add(Task.Run(() => AddToInt32(threadUnsafeInt32, internal_loop_count, add_value)));
                tasks.Add(Task.Run(() => SubtractFromInt32(threadUnsafeInt32, internal_loop_count, add_value)));
            }

            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("threadUnsafeInt32 = " + threadUnsafeInt32);
            Assert.IsTrue(threadUnsafeInt32 == 0);
        }

        /// <summary>
        /// This Test Method is supposed to succeed because the Thread-Safe implementation puts a lock on the integer while adding/subtracting
        /// </summary>
        [TestMethod]
        public void TestThreadSafeInt32_AddSubtract()
        {
            ThreadSafeInt32 threadSafeInt32 = new();
            int task_count = 20;
            int internal_loop_count = 10000000; // 10 million
            int add_value = 3;
            List<Task> tasks = new();
            for (int i = 0; i < task_count; i++)
            {
                tasks.Add(Task.Run(() => AddToInt32(threadSafeInt32, internal_loop_count, add_value)));
                tasks.Add(Task.Run(() => SubtractFromInt32(threadSafeInt32, internal_loop_count, add_value)));
            }

            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("threadSafeInt32 = " + threadSafeInt32);
            Assert.IsTrue(threadSafeInt32 == 0);
        }


        #region Helper-functions (Increment,Decrement,Add,Subtract)
        private async Task IncrementInt32(IThreadSafeInt32 integer, int increment_n_times)
        {
            for(int i = 0; i < increment_n_times; i++)
            {
                integer.Increment();
            }
        }

        private async Task DecrementInt32(IThreadSafeInt32 integer, int decrement_n_times)
        {
            for (int i = 0; i < decrement_n_times; i++)
            {
                integer.Decrement();
            }
        }

        private async Task AddToInt32(IThreadSafeInt32 integer, int add_n_times, int value)
        {
            for (int i = 0; i < add_n_times; i++)
            {
                integer.Add(value);
            }
        }

        private async Task SubtractFromInt32(IThreadSafeInt32 integer, int subtract_n_times, int value)
        {
            for (int i = 0; i < subtract_n_times; i++)
            {
                integer.Subtract(value);
            }
        }
        #endregion
    }
}