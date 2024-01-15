using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace 吐泡泡的小鱼的缺氧模组
{
    public static class Helper
    {
        public static object GetPrivateValue<T>(T obj, string fieldName) where T : class
        {
            object result;
            try
            {
                FieldInfo field = typeof(T).GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
                if (field == null)
                {
                    result = null;
                }
                else
                {
                    result = field.GetValue(obj);
                }
            }
            catch (Exception ex)
            {
                result = null;
            }
            return result;
        }
        public static object GetPrivateStaticValue<T>(T obj, string fieldName) where T : class
        {
            object result;
            try
            {
                FieldInfo field = typeof(T).GetField(fieldName, BindingFlags.Static | BindingFlags.NonPublic);
                if (field == null)
                {
                    result = null;
                }
                else
                {
                    result = field.GetValue(obj);
                }
            }
            catch (Exception ex)
            {
                result = null;
            }
            return result;
        }
        public static void SetPrivateValue<T>(T obj, string fieldName, object value) where T : class
        {
            try
            {
                FieldInfo field = typeof(T).GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
                if (!(field == null))
                {
                    field.SetValue(obj, value);
                }
            }
            catch (Exception ex)
            {
            }
        }
        public static object CallPrivateMethod<T>(T obj, string methodName, object[] parameters = null) where T : class
        {
            object result;
            try
            {
                MethodInfo method = typeof(T).GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
                if (method == null)
                {
                    result = null;
                }
                else
                {
                    object obj2 = method.Invoke(obj, parameters);
                    result = obj2;
                }
            }
            catch (Exception ex)
            {
                result = null;
            }
            return result;
        }
    }
}
