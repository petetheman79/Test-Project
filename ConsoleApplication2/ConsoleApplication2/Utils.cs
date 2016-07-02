using System;
using System.Collections.Generic;

namespace NextSteps
{
    public static class Utils
    {
        public static Func<Arg, Ret> Memoize<Arg, Ret>( this Func<Arg, Ret> functor)
        {
            var memoTable = new Dictionary<Arg, Ret>();

            return (arg0) =>
            {
                Ret funcReturnValue;

                if (!memoTable.TryGetValue(arg0, out funcReturnValue))
                {
                    funcReturnValue = functor(arg0);
                    memoTable.Add(arg0, funcReturnValue);
                }
                return funcReturnValue;
            };
        }
    }
}
