using System;

namespace Utilities
{
    public static class ArgumentCheckExtension
    {
        public static void CheckNotNull(this object toCheck, string name)
        {
            if(toCheck == null)
            {
                throw new ArgumentNullException(name);
            }
        }
    }
}
