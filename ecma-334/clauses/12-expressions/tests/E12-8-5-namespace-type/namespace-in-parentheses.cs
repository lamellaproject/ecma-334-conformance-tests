/*
Rules: E12-8-5-namespace-type
Authority: ECMA-334 7th ed 12.8.5
Version: 7.3
Expected: reject
Mutate: (Space).Worker.Value
Into: Space.Worker.Value
Csc: CS0118
*/
namespace Space { public class Worker { public static int Value = 3; } }
class Program { static void Main() { int result = (Space).Worker.Value; } }
