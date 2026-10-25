/*
Rules: P08-static-local-no-enclosing-state
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: reject
Mutate: return () => outside;
Into: return () => inside;
*/
using System;
class Program
{
    static int Main()
    {
        int outside = 41;
        static Func<int> Make(int inside)
        {
            return () => outside;
        }
        return Make(outside)() == 41 ? 0 : 1;
    }
}
