/*
Rules: E15-14-1-instance-constructor-not-iterator
Authority: ECMA-334 7th ed 15.14.1
Version: 7.3
Expected: reject
Mutate: yield break;
Into: return;
*/
class Gauge { public Gauge() { yield break; } }
class Program { static void Main() { } }
