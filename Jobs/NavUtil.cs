using RizkyApps.TestNavigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RizkyApps.Jobs
{
    public static class NavUtil
    {
        public static void Examine(INavigation navigation)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var page in navigation.NavigationStack)
            {
                builder.AppendLine(page.GetType().Name);
            }
            builder.AppendLine("-----------");
            Debug.WriteLine(builder.ToString());
        }

        public static void InsertPage(INavigation navigation, string pageName)
        {
            var secondPage = navigation.NavigationStack.ElementAtOrDefault(0);

            var pageToInsert = new TestLoginPageNav() as Page;
            //var pageToInsert = Type.GetType(new TestLoginPageNav());
            //var pageToInsert = Activator.CreateInstance(new TestLoginPageNav()) as Page;
            //Type loginPageType = Type.GetType("TestNavigation\\TestLoginPageNav");
            //var pageToInsert = Activator.CreateInstance(loginPageType) as Page;
            if (pageName != "TestLoginPageNav")
            {
                pageToInsert = navigation.NavigationStack.FirstOrDefault(x => x.GetType().Name == pageName);
            }
            if (secondPage != null)
            {
                navigation.InsertPageBefore(pageToInsert, secondPage);
            }
        }

        public static void DeletePage(INavigation navigation, string pageName)
        {
            var pageToDelete =
                 navigation.NavigationStack
                 .FirstOrDefault(x => x.GetType().Name == pageName);
            if (pageToDelete != null)
            {
                navigation.RemovePage(pageToDelete);
            }
        }
    }
}
