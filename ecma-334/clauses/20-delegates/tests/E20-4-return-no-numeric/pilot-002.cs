/*
Rules: E20-4-return-no-numeric
Authority: ECMA-334 7th ed 20.4
Version: 7.3
Expected: reject
Mutate: Func<object> converted=Bridge.Read;
Into: Func<object> converted=default(Func<object>);
Csc: CS0407
*/
using System;

static class Bridge {public static int Read(){return 61;} }
class Program
{
    static void Main()
    {
        Func<object> converted=Bridge.Read;
    }
}
