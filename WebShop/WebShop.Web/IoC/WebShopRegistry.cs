﻿using System.Data;
using NHibernate;
using StructureMap;
using StructureMap.Configuration.DSL;
using WebShop.Core.Data;

namespace WebShop.Web.IoC
{
    public class WebShopRegistry : Registry
    {
        public WebShopRegistry()
        {
            Scan(s =>
                {
                    s.TheCallingAssembly();
                    s.Assembly("WebShop.Common");
                    s.Assembly("WebShop.Core");
                    s.WithDefaultConventions().OnAddedPluginTypes(c => c.LifecycleIs(Lifecycle.Current));
                });

            For<ISession>().LifecycleIs(Lifecycle.Current).Use(GetSession);
            For<IDbConnection>().LifecycleIs(Lifecycle.Current).Use(GetConnection);
        }

        private static IDbConnection GetConnection(IContext context)
        {
            return GetSession(context).Connection;
        }

        private static ISession GetSession(IContext context)
        {
            return context.GetInstance<ISessionProvider>().CurrentSession;
        }
    }
}