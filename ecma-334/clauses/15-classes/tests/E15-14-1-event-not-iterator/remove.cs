/*
Rules: E15-14-1-event-not-iterator
Authority: ECMA-334 7th ed 15.14.1
Version: 7.3
Expected: reject
Mutate: yield break;
Into: return;
*/
using System;
class Gauge { public event Action Signal { add { } remove { yield break; } } }
class Program { static void Main() { } }
