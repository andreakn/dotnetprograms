using System.Collections.Generic;

namespace DbTool.Lib.Meta.Types
{
    public abstract class TypeMeta
    {
        public string TypeName { get; private set; }
        public string MemberName { get; private set; }

        protected TypeMeta(string typeName, string memberName)
        {
            TypeName = typeName;
            MemberName = memberName;
        }

        public abstract IEnumerable<TypeMeta> Members { get; }
        public abstract IEnumerable<TypeMeta> Properties { get; }

        public override string ToString()
        {
            return string.Format("{0} {1}", TypeName, MemberName);
        }
    }
}