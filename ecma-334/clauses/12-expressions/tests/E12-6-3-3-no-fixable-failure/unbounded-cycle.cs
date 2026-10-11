/*
Rules: E12-6-3-3-no-fixable-failure
Authority: ECMA-334 7th ed 12.6.3.3
Version: 7.3
Expected: reject
Mutate: Pair(x => x, y => y)
Into: Pair((int x) => x, y => y)
*/
using System;
class Program
{
    static void Pair<T, U>(Func<T, U> first, Func<U, T> second) { }
    static void Main() { Pair(x => x, y => y); }
}
