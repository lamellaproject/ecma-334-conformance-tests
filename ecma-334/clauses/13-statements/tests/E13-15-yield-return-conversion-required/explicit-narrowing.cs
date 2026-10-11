/*
Rules: E13-15-yield-return-conversion-required
Authority: ECMA-334 7th ed 13.15
Version: 7.3
Expected: reject
Mutate: yield return value;
Into: yield return (int)value;
*/
using System;
using System.Collections.Generic;
class Program
{
    static IEnumerator<int> Items(long value) { yield return value; }
    static void Main() { }
}
