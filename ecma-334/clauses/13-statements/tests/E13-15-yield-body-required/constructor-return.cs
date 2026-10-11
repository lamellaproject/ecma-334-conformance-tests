/*
Rules: E13-15-yield-body-required
Authority: ECMA-334 7th ed 13.15
Version: 7.3
Expected: reject
Mutate: yield return 17;
Into: return;
*/
using System;
using System.Collections.Generic;
class Program
{
    public Program() { yield return 17; }
    static void Main() { }
}
