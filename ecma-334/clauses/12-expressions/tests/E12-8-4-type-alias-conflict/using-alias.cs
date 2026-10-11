/*
Rules: E12-8-4-type-alias-conflict
Authority: ECMA-334 7th ed 12.8.4
Version: 7.3
Expected: reject
Mutate: using Cell = Other.Cell;
Into: using Unused = Other.Cell;
Csc: CS0576
*/
namespace Other { public class Cell { public static int Value = 8; } }
namespace World
{
    using Cell = Other.Cell;
    class Cell { public static int Value = 3; }
    class Program { static void Main() { int result = Cell.Value; } }
}
