using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace WebAppTest
{
    public static class Extensions
    {
        public static void InvokeMethod(this Type t, string methodName, object instance, object[] args = null)
        {
            MethodInfo method = t.GetMethod(methodName);
            object result = method.Invoke(instance, args);


            SaveResponse(result as IRestResponse);
        }

        public static object[] FirstRowArgs(this Table table)
        {
            if (table == null)
            {
                return null;
            }

            List<object> args = new List<object>();
            if (table.RowCount > 0)
            {
                foreach (var header in table.Header)
                {
                    if (table.Rows[0][header].Equals("Stored"))
                    {
                        args.Add(GetStoredElementFromLastResponse(header));
                    }
                    else
                    {
                        AddAppropriateArgType(args, table.Rows[0][header]);
                    }
                }
            }

            return args.ToArray();
        }

        public static object GetStoredElementFromLastResponse(string name)
        {
            if (ScenarioContext.Current.ContainsKey("response") == false)
            {
                return null;
            }

            var response = ScenarioContext.Current.Get<IRestResponse>("response");
            JObject obj = JObject.Parse(response.Content);

            var value = obj.GetValue(name);
            return value;
        }

        private static void AddAppropriateArgType(List<object> args, string s)
        {
            // Check if its a double
            if (s.Contains('.'))
            {
                double d;
                if (double.TryParse(s, out d))
                {
                    args.Add(d);
                    return;
                }
            }

            // Perhaps an int
            int i;
            if (int.TryParse(s, out i))
            {
                args.Add(i);
                return;
            }

            // just return it as is
            args.Add(s);
        }

        public static void SaveResponse(this IRestResponse response)
        {
            if (ScenarioContext.Current.ContainsKey("response"))
            {
                ScenarioContext.Current.Remove("response");
            }

            // Add the response in the current context
            ScenarioContext.Current.Add("response", response);
        }
    }
}
