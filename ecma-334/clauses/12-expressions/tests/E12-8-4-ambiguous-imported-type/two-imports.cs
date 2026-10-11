/*
Rules: E12-8-4-ambiguous-imported-type
Authority: ECMA-334 7th ed 12.8.4
Version: 7.3
Expected: reject
Mutate: int result = Cell.Value;
Into: int result = First.Cell.Value;
Csc: CS0104
*/
using First;
using Second;
namespace First { public class Cell { public static int Value = 3; } }
namespace Second { public class Cell { public static int Value = 8; } }
class Program { static void Main() { int result = Cell.Value; } }
