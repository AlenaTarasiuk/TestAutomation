using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TestAutomation.Core.Enums;
using TestAutomation.Core.UIElements.Behaviors;
using TestAutomation.Core.Waiters;

namespace TestAutomation.Core.UIElements
{
    public class UIList<T> : UIElement, IEnumerable<T> where T : UIElement
    {
        List<T> mylist = new List<T>();

        public T this[int index]
        {
            get
            {
                PopulateList();
                return mylist[index];
            }
            private set
            {
                mylist.Insert(index, value);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            PopulateList();
            return mylist.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public UIList(string locator, int secondsToWait = 1, int extraSeconds = 0, LocatorType locatorType = LocatorType.XPath) : base(locator, secondsToWait, extraSeconds, locatorType) { }

        private void PopulateList()
        {
            Retry.IfTrue(SecondsToWait, () => Core.Driver.FindElements(GetBy()).Count == 0);

            var cnt = Core.Driver.FindElements(GetBy()).Count;
            mylist.Clear();
            for (int i = 0; i < cnt; i++)
            {
                var locator = $"({Locator})[{i + 1}]";
                var element = Activator.CreateInstance(typeof(T), new object[] { locator, SecondsToWait, ExtraSeconds, LocatorType }) as T;
                mylist.Add(element);
            }
        }

        public List<string> GetTexts()
        {
            PopulateList();
            return mylist.Select(a => ((IHasText)a).Text()?.Trim()).ToList();
        }
    }
}

