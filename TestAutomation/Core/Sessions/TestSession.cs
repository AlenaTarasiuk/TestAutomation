using System.Collections.Concurrent;
using System.Collections.Generic;
using TestAutomation.Core.Enums;

namespace TestAutomation.Core.Sessions
{
    public class TestSession
    {
        private static readonly ConcurrentDictionary<string, ConcurrentDictionary<string, object>> contextStorage = new ConcurrentDictionary<string, ConcurrentDictionary<string, object>>();

        private static string TestName => NUnit.Framework.TestContext.CurrentContext.Test.FullName;
        private const string GlobalContext = "Global";

        public static void AddOrUpdate(TestSessionKey key, object value, SessionContext context = SessionContext.Test)
        {
            var newSessionStorage = new ConcurrentDictionary<string, object>();
            var contextName = GetContextName(context);
            var sessionStorage = contextStorage.GetOrAdd(contextName, newSessionStorage);
            sessionStorage.GetOrAdd(key.ToString(), value);
            contextStorage.AddOrUpdate(contextName, sessionStorage, (oldkey, oldvalue) => sessionStorage);
        }

        public static void Update(TestSessionKey key, object value, SessionContext context = SessionContext.Test)
        {
            var newSessionStorage = new ConcurrentDictionary<string, object>();
            var contextName = GetContextName(context);
            var sessionStorage = contextStorage.GetOrAdd(contextName, newSessionStorage);
            object oldValue;
            sessionStorage.TryRemove(key.ToString(), out oldValue);
            sessionStorage.GetOrAdd(key.ToString(), value);
            contextStorage.TryAdd(contextName, sessionStorage);
        }

        public static object GetValue(TestSessionKey key, SessionContext context = SessionContext.Test)
        {
            try
            {
                var contextName = GetContextName(context);
                var sessionStorage = contextStorage[contextName];
                return sessionStorage[key.ToString()];
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }

        public static void AddOrUpdate(string key, object value, SessionContext context = SessionContext.Test)
        {
            var contextName = GetContextName(context);
            var newSessionStorage = new ConcurrentDictionary<string, object>();
            var sessionStorage = contextStorage.GetOrAdd(contextName, newSessionStorage);
            sessionStorage.AddOrUpdate(key, value, (k, v) => value);
            contextStorage.AddOrUpdate(contextName, sessionStorage, (oldkey, oldvalue) => sessionStorage);
        }

        public static object GetValue(string key, SessionContext context = SessionContext.Test)
        {
            try
            {
                var contextName = GetContextName(context);
                var sessionStorage = contextStorage[contextName];
                return sessionStorage[key];
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }

        public static void Remove()
        {
            var removedSessionInfo = new ConcurrentDictionary<string, object>();
            contextStorage.TryRemove(TestName, out removedSessionInfo);
        }

        private static string GetContextName(SessionContext context)
        {
            switch (context)
            {
                case SessionContext.Test: return TestName;
                case SessionContext.Global: return GlobalContext;
                default: return string.Empty;
            }
        }
    }
}