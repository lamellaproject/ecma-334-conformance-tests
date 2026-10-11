/*
Rules: E12-6-4-2-group-return-conversion
Authority: ECMA-334 7th ed 12.6.4.2
Version: 7.3
Expected: reject
Mutate: Func<object> function = Read;
Into: Func<int> function = Read;
*/
using System;
class Program
{
    static int Read() { return 3; }
    static void Main() { Func<object> function = Read; }
}
