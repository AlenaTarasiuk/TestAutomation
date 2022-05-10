using System;
using System.Linq;

namespace TestAutomation.Core.Waiters
{
    public sealed class Retry
    {
        public static bool IfAnyError(int waitTime, Action action)
        {
            var result = false;
            Exception e = null;
            var waitTill = DateTime.UtcNow.AddSeconds(waitTime);
            while ((waitTill - DateTime.UtcNow).TotalSeconds > 0)
            {
                try
                {
                    action();
                    result = true;
                    break;
                }
                catch (Exception exception)
                {
                    e = exception;
                }
            }
            return result ? result : throw new Exception("The next exception was thrown: " + e.ToString());
        }

        public static bool IfError(int waitTime, Action action, params Exception[] exceptions)
        {
            var result = false;
            var waitTill = DateTime.UtcNow.AddSeconds(waitTime);
            while ((waitTill - DateTime.UtcNow).TotalSeconds > 0)
            {
                try
                {
                    action();
                    result = true;
                    break;
                }
                catch (Exception e)
                {
                    if (exceptions.Any(ex => ex.GetType().Name.Equals(e.GetType().Name)))
                    {
                        //continue
                    }
                    else
                    {
                        throw new Exception("The next exception was thrown: " + e.ToString());
                    };
                }
            }
            return result;
        }
        public static bool IfFalse(int waitTime, Func<bool> func)
        {
            var result = false;
            var waitTill = DateTime.UtcNow.AddSeconds(waitTime);
            while ((waitTill - DateTime.UtcNow).TotalSeconds > 0 && !result)
            {
                result = func();
            }
            return result;
        }
        public static bool IfFalseOrAnyError(int waitTime, Func<bool> func)
        {
            var result = false;
            var waitTill = DateTime.UtcNow.AddSeconds(waitTime);
            while ((waitTill - DateTime.UtcNow).TotalSeconds > 0 && !result)
            {
                try
                {
                    result = func();
                }
                catch
                {
                    //continue
                }
            }
            return result;
        }
        public static bool IfFalseOrError(int waitTime, Func<bool> func, params Exception[] exceptions)
        {
            var result = false;
            var waitTill = DateTime.UtcNow.AddSeconds(waitTime);

            //exceptions = null;
            while ((waitTill - DateTime.UtcNow).TotalSeconds > 0 && !result)
            {
                try
                {
                    result = func();
                }
                catch (Exception e)
                {
                    if (exceptions != null && exceptions.Any(ex => ex.GetType().Name.Equals(e.GetType().Name)))
                    {
                        //continue
                    }
                    else
                    {
                        throw;
                    };

                }
            }
            return result;
        }
        public static bool IfTrue(int waitTime, Func<bool> func)
        {
            var result = true;
            var waitTill = DateTime.UtcNow.AddSeconds(waitTime);
            while ((waitTill - DateTime.UtcNow).TotalSeconds > 0 && result)
            {
                result = func();
            }
            return result;
        }
        public static bool IfTrueOrAnyError(int waitTime, Func<bool> func)
        {
            var result = true;
            var waitTill = DateTime.UtcNow.AddSeconds(waitTime);
            while ((waitTill - DateTime.UtcNow).TotalSeconds > 0 && result)
            {
                try
                {
                    result = func();
                }
                catch (Exception)
                {
                    return true;
                }
            }
            return result;
        }
        public static bool IfTrueOrError(int waitTime, Func<bool> func, params Exception[] exceptions)
        {
            var result = true;
            var waitTill = DateTime.UtcNow.AddSeconds((int)waitTime);
            while ((waitTill - DateTime.UtcNow).TotalSeconds > 0 && result)
            {
                try
                {
                    result = func();
                }
                catch (Exception e)
                {
                    if (exceptions != null && exceptions.Any(ex => ex.GetType().Name.Equals(e.GetType().Name)))
                    {
                        return true;
                    }
                    else
                    {
                        throw;
                    };
                }
            }
            return !result;
        }
    }
}