using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadSafeTypes
{
    public class ThreadSafeInt32 : IThreadSafeInt32
    {
        public ThreadSafeInt32()
        {
            value = 0;
        }

        public ThreadSafeInt32(Int32 _value)
        {
            value = _value;
        }

        private Int32 value;

        #region ToString(), Increment(), Decrement(), Add(), Subtract()
        public override string ToString()
        {
            return value.ToString();
        }

        public void Increment()
        {
            Interlocked.Increment(ref value);
        }

        public void Decrement()
        {
            Interlocked.Decrement(ref value);
        }

        public void Add(int value_to_add)
        {
            Interlocked.Add(ref value, value_to_add);
        }

        public void Subtract(int value_to_subtract)
        {
            Interlocked.Add(ref value, -value_to_subtract);
        }

        public void Add(IThreadSafeInt32 value_to_add)
        {
            lock (this) lock (value_to_add)
            {
                this.value += Volatile.Read(ref ((ThreadSafeInt32)value_to_add).value);
            }
        }

        public void Subtract(IThreadSafeInt32 value_to_subtract)
        {
            lock (this) lock (value_to_subtract)
            {
                this.value -= Volatile.Read(ref ((ThreadSafeInt32)value_to_subtract).value);
            }
        }

        public void Set(IThreadSafeInt32 set_to_this_value)
        {
            lock(this) lock (set_to_this_value)
            {
                this.value = Volatile.Read(ref ((ThreadSafeInt32)set_to_this_value).value);
            }
        }

        public void Set(Int32 set_to_this_value)
        {
            lock (this)
            {
                this.value = Volatile.Read(ref set_to_this_value);
            }
        }
        #endregion

        #region Defines operators between 2 ThreadSafeInt32's

        public static ThreadSafeInt32 operator+(ThreadSafeInt32 first_value, ThreadSafeInt32 second_value)
        {
            Int32 temp_first_value, temp_second_value;
            lock (first_value) lock (second_value)
            {
                    temp_first_value = Volatile.Read(ref first_value.value);
                    temp_second_value = Volatile.Read(ref second_value.value);
            }

            ThreadSafeInt32 result = new();
            result.value = temp_first_value + temp_second_value;
            return result;
        }

        public static ThreadSafeInt32 operator -(ThreadSafeInt32 first_value, ThreadSafeInt32 second_value)
        {
            Int32 temp_first_value, temp_second_value;
            lock (first_value) lock (second_value)
            {
                temp_first_value = Volatile.Read(ref first_value.value); // saw this on https://learn.microsoft.com/en-us/dotnet/api/system.threading.interlocked.increment?view=net-7.0 
                temp_second_value = Volatile.Read(ref second_value.value);
            }

            ThreadSafeInt32 result = new();
            result.value = temp_first_value - temp_second_value;
            return result;
        }

        public static ThreadSafeInt32 operator *(ThreadSafeInt32 first_value, ThreadSafeInt32 second_value)
        {
            Int32 temp_first_value, temp_second_value;
            lock (first_value) lock (second_value)
            {
                temp_first_value = Volatile.Read(ref first_value.value);
                temp_second_value = Volatile.Read(ref second_value.value);
            }

            ThreadSafeInt32 result = new();
            result.value = temp_first_value * temp_second_value;
            return result;
        }

        public static ThreadSafeInt32 operator /(ThreadSafeInt32 first_value, ThreadSafeInt32 second_value)
        {
            Int32 temp_first_value, temp_second_value;
            lock (first_value) lock (second_value)
            {
                temp_first_value = Volatile.Read(ref first_value.value);
                temp_second_value = Volatile.Read(ref second_value.value);
            }

            ThreadSafeInt32 result = new();
            result.value = temp_first_value / temp_second_value;
            return result;
        }

        public static ThreadSafeInt32 operator %(ThreadSafeInt32 first_value, ThreadSafeInt32 second_value)
        {
            Int32 temp_first_value, temp_second_value;
            lock (first_value) lock (second_value)
            {
                temp_first_value = Volatile.Read(ref first_value.value);
                temp_second_value = Volatile.Read(ref second_value.value);
            }

            ThreadSafeInt32 result = new();
            result.value = temp_first_value % temp_second_value;
            return result;
        }

        public static bool operator ==(ThreadSafeInt32 first_value, ThreadSafeInt32 second_value)
        {
            Int32 temp_first_value, temp_second_value;
            lock (first_value) lock (second_value)
            {
                temp_first_value = Volatile.Read(ref first_value.value);
                temp_second_value = Volatile.Read(ref second_value.value);
            }

            return temp_first_value == temp_second_value;
        }

        public static bool operator !=(ThreadSafeInt32 first_value, ThreadSafeInt32 second_value)
        {
            Int32 temp_first_value, temp_second_value;
            lock (first_value) lock (second_value)
            {
                temp_first_value = Volatile.Read(ref first_value.value);
                temp_second_value = Volatile.Read(ref second_value.value);
            }

            return temp_first_value != temp_second_value;
        }

        #endregion

        #region Defines operators between one ThreadSafeInt32 and an Int32 (that may not be Thread-Safe)
        public static ThreadSafeInt32 operator +(ThreadSafeInt32 first_value, Int32 second_value)
        {
            Int32 temp_first_value;
            lock (first_value)
            {
                temp_first_value = Volatile.Read(ref first_value.value);
            }

            ThreadSafeInt32 result = new();
            result.value = temp_first_value + second_value;
            return result;
        }

        public static ThreadSafeInt32 operator -(ThreadSafeInt32 first_value, Int32 second_value)
        {
            Int32 temp_first_value;
            lock (first_value)
            {
                temp_first_value = Volatile.Read(ref first_value.value);
            }

            ThreadSafeInt32 result = new();
            result.value = temp_first_value - second_value;
            return result;
        }

        public static ThreadSafeInt32 operator *(ThreadSafeInt32 first_value, Int32 second_value)
        {
            Int32 temp_first_value;
            lock (first_value)
            {
                temp_first_value = Volatile.Read(ref first_value.value);
            }

            ThreadSafeInt32 result = new();
            result.value = temp_first_value * second_value;
            return result;
        }

        public static ThreadSafeInt32 operator /(ThreadSafeInt32 first_value, Int32 second_value)
        {
            Int32 temp_first_value;
            lock (first_value)
            {
                temp_first_value = Volatile.Read(ref first_value.value);
            }

            ThreadSafeInt32 result = new();
            result.value = temp_first_value / second_value;
            return result;
        }

        public static ThreadSafeInt32 operator %(ThreadSafeInt32 first_value, Int32 second_value)
        {
            Int32 temp_first_value;
            lock (first_value)
            {
                temp_first_value = Volatile.Read(ref first_value.value);
            }

            ThreadSafeInt32 result = new();
            result.value = temp_first_value % second_value;
            return result;
        }

        public static bool operator ==(ThreadSafeInt32 first_value, Int32 second_value)
        {
            Int32 temp_first_value;
            lock (first_value)
            {
                temp_first_value = Volatile.Read(ref first_value.value);
            }

            return temp_first_value == second_value;
        }

        public static bool operator !=(ThreadSafeInt32 first_value, Int32 second_value)
        {
            Int32 temp_first_value;
            lock (first_value)
            {
                temp_first_value = Volatile.Read(ref first_value.value);
            }

            return temp_first_value != second_value;
        }

        public static implicit operator ThreadSafeInt32(int _value)
        {
            return new ThreadSafeInt32(_value);
        }
        #endregion

        #region Equals and GetHashCode
        public override bool Equals(object obj)
        {
            // If the passed object is null, return False
            if (obj == null)
            {
                return false;
            }
            // If the passed object is not Customer Type, return False
            if (!(obj is ThreadSafeInt32))
            {
                return false;
            }

            return this == (ThreadSafeInt32)obj;
        }

        public override int GetHashCode()
        {
            lock(this)
            {
                return value.GetHashCode();
            }
        }

        #endregion
    }
}