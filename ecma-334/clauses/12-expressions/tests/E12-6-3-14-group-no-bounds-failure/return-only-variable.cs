/*
Rules: E12-6-3-14-group-no-bounds-failure
Authority: ECMA-334 7th ed 12.6.3.14
Version: 7.3
Expected: reject
Mutate: Func<int> function = Create;
Into: Func<int> function = Create<int>;
*/
using System;
class Program
{
    static T Create<T>() { return default(T); }
    static void Main() { Func<int> function = Create; }
}
