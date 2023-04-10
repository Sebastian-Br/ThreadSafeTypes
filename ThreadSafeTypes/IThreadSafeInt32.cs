using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSafeTypes
{
    public interface IThreadSafeInt32
    {
        // can't define 'value' here because properties can't be passed to Interlocked-Methods
        public string ToString();
        public void Increment(); // using dedicated functions is faster than locking objects
        public void Decrement();

        public void Add(int value_to_add);
        public void Subtract(int value_to_subtract);

        public void Add(IThreadSafeInt32 value_to_add);
        public void Subtract(IThreadSafeInt32 value_to_subtract);

        public void Set(IThreadSafeInt32 set_to_this_value);
        public void Set(Int32 set_to_this_value);

        // there is no way to define operator overrides in interfaces
        // there is a hack, see https://stackoverflow.com/questions/3811278/is-there-any-way-in-c-sharp-to-enforce-operator-overloading-in-derived-classes , but it's not very elegant
        //public static extern IThreadSafeInt32 operator +(IThreadSafeInt32 first_value, IThreadSafeInt32 second_value);
        // in any case, operators +, -, *, /, , %, ==, !=, Object.Equals() and GetHashCode() have to be defined
    }
}