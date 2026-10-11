/*
Rules: E13-15-yield-anonymous-function-error
Authority: ECMA-334 7th ed 13.15
Version: 7.3
Expected: reject
Mutate: yield break;
Into: return null;
*/
using System;
using System.Collections.Generic;
class Program
{
    delegate IEnumerator<int> Factory();
    static Factory factory = () => { yield break; };
    static void Main() { }
}
