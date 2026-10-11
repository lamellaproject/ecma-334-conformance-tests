/*
Rules: E13-15-yield-finally-error
Authority: ECMA-334 7th ed 13.15
Version: 7.3
Expected: reject
Mutate: finally { yield return 19; }
Into: finally { }
*/
using System;
using System.Collections.Generic;
class Program
{
    static IEnumerator<int> Items() { try { yield return 17; } finally { yield return 19; } }
    static void Main() { }
}
