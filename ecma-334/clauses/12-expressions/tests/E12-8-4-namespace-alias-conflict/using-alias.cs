/*
Rules: E12-8-4-namespace-alias-conflict
Authority: ECMA-334 7th ed 12.8.4
Version: 7.3
Expected: reject
Mutate: using Branch = Other;
Into: using Unused = Other;
Csc: CS0576
*/
namespace Other { public class Worker { public static int Value = 8; } }
namespace World
{
    using Branch = Other;
    namespace Branch { public class Worker { public static int Value = 3; } }
    class Program
    {
        static void Main() { int result = Branch.Worker.Value; }
    }
}
