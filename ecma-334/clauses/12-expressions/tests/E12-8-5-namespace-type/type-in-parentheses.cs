/*
Rules: E12-8-5-namespace-type
Authority: ECMA-334 7th ed 12.8.5
Version: 7.3
Expected: reject
Mutate: (Worker).Value
Into: Worker.Value
Csc: CS0119
*/
class Worker { public static int Value = 3; }
class Program { static void Main() { int result = (Worker).Value; } }
