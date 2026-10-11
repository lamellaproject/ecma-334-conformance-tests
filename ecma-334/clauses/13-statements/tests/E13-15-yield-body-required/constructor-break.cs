/*
Rules: E13-15-yield-body-required
Authority: ECMA-334 7th ed 13.15
Version: 7.3
Expected: reject
Mutate: yield break;
Into: return;
*/
using System;
using System.Collections.Generic;
class Program
{
    public Program() { yield break; }
    static void Main() { }
}
