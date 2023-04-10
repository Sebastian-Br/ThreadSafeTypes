using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreadSafeTypes;

namespace ThreadSafeTypesTest
{
    internal class ThreadUnsafeInt32 : IThreadSafeInt32
    {
        public ThreadUnsafeInt32()
        {
            Value = 0;
        }

        private Int32 Value;

        public override string ToString()
        {
            return Value.ToString();
        }

        public void Increment()
        {
            Value++;
        }

        public void Decrement()
        {
            Value--;
        }

        public void Add(int value_to_add)
        {
            Value += value_to_add;
        }

        public void Subtract(int value_to_subtract)
        {
            Value -= value_to_subtract;
        }

        public void Add(IThreadSafeInt32 value_to_add)
        {
            Value += ((ThreadUnsafeInt32)value_to_add).Value;
        }

        public void Subtract(IThreadSafeInt32 value_to_subtract)
        {
            Value -= ((ThreadUnsafeInt32)value_to_subtract).Value;
        }

        public void Set(IThreadSafeInt32 set_to_this_value)
        {
            Value = ((ThreadUnsafeInt32)set_to_this_value).Value;
        }

        public void Set(Int32 set_to_this_value)
        {
            Value = set_to_this_value;
        }

        public static ThreadUnsafeInt32 operator +(ThreadUnsafeInt32 first_value, ThreadUnsafeInt32 second_value)
        {
            Int32 temp_first_value, temp_second_value;
            temp_first_value = first_value.Value;
            temp_second_value = second_value.Value;

            ThreadUnsafeInt32 result = new();
            result.Value = temp_first_value + temp_second_value;
            return result;
        }

        public static ThreadUnsafeInt32 operator -(ThreadUnsafeInt32 first_value, ThreadUnsafeInt32 second_value)
        {
            Int32 temp_first_value, temp_second_value;
            temp_first_value = first_value.Value;
            temp_second_value = second_value.Value;

            ThreadUnsafeInt32 result = new();
            result.Value = temp_first_value - temp_second_value;
            return result;
        }

        public static ThreadUnsafeInt32 operator *(ThreadUnsafeInt32 first_value, ThreadUnsafeInt32 second_value)
        {
            Int32 temp_first_value, temp_second_value;
            temp_first_value = first_value.Value;
            temp_second_value = second_value.Value;

            ThreadUnsafeInt32 result = new();
            result.Value = temp_first_value * temp_second_value;
            return result;
        }

        public static ThreadUnsafeInt32 operator /(ThreadUnsafeInt32 first_value, ThreadUnsafeInt32 second_value)
        {
            Int32 temp_first_value, temp_second_value;
            temp_first_value = first_value.Value;
            temp_second_value = second_value.Value;

            ThreadUnsafeInt32 result = new();
            result.Value = temp_first_value / temp_second_value;
            return result;
        }

        public static ThreadUnsafeInt32 operator %(ThreadUnsafeInt32 first_value, ThreadUnsafeInt32 second_value)
        {
            Int32 temp_first_value, temp_second_value;
            temp_first_value = first_value.Value;
            temp_second_value = second_value.Value;

            ThreadUnsafeInt32 result = new();
            result.Value = temp_first_value % temp_second_value;
            return result;
        }

        public static bool operator ==(ThreadUnsafeInt32 first_value, ThreadUnsafeInt32 second_value)
        {
            Int32 temp_first_value, temp_second_value;
            temp_first_value = first_value.Value;
            temp_second_value = second_value.Value;

            return temp_first_value == temp_second_value;
        }

        public static bool operator !=(ThreadUnsafeInt32 first_value, ThreadUnsafeInt32 second_value)
        {
            Int32 temp_first_value, temp_second_value;
            temp_first_value = first_value.Value;
            temp_second_value = second_value.Value;

            return temp_first_value != temp_second_value;
        }

        public static ThreadUnsafeInt32 operator +(ThreadUnsafeInt32 first_value, Int32 second_value)
        {
            Int32 temp_first_value;
            temp_first_value = first_value.Value;

            ThreadUnsafeInt32 result = new();
            result.Value = temp_first_value + second_value;
            return result;
        }

        public static ThreadUnsafeInt32 operator -(ThreadUnsafeInt32 first_value, Int32 second_value)
        {
            Int32 temp_first_value;
            temp_first_value = first_value.Value;

            ThreadUnsafeInt32 result = new();
            result.Value = temp_first_value - second_value;
            return result;
        }

        public static ThreadUnsafeInt32 operator *(ThreadUnsafeInt32 first_value, Int32 second_value)
        {
            Int32 temp_first_value;
            temp_first_value = first_value.Value;

            ThreadUnsafeInt32 result = new();
            result.Value = temp_first_value * second_value;
            return result;
        }

        public static ThreadUnsafeInt32 operator /(ThreadUnsafeInt32 first_value, Int32 second_value)
        {
            Int32 temp_first_value;
            temp_first_value = first_value.Value;

            ThreadUnsafeInt32 result = new();
            result.Value = temp_first_value / second_value;
            return result;
        }

        public static ThreadUnsafeInt32 operator %(ThreadUnsafeInt32 first_value, Int32 second_value)
        {
            Int32 temp_first_value;
            temp_first_value = first_value.Value;

            ThreadUnsafeInt32 result = new();
            result.Value = temp_first_value % second_value;
            return result;
        }

        public static bool operator ==(ThreadUnsafeInt32 first_value, Int32 second_value)
        {
            Int32 temp_first_value;
            temp_first_value = first_value.Value;

            return temp_first_value == second_value;
        }

        public static bool operator !=(ThreadUnsafeInt32 first_value, Int32 second_value)
        {
            Int32 temp_first_value;
            temp_first_value = first_value.Value;

            return temp_first_value != second_value;
        }
    }
}