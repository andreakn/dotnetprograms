﻿using System;

namespace VisualFarmStudio.Lib.Scoping
{
    public class InjectionScope
    {
        private static Func<object> _getScope;

        public static object Current
        {
            get { return _getScope(); }
            set { _getScope = () => value; }
        }

        public static void SetScope(Func<object> getScope)
        {
            _getScope = getScope;
        }
    }
}