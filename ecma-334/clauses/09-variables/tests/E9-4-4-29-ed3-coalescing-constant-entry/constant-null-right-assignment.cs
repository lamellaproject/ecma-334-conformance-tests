/*
Rules: E9-4-4-29-ed3-coalescing-constant-entry
Authority: ECMA-334 3rd ed 12.3.3
Version: ISO-2
Expected: run
Stdout: OK 2
Mutate: (Box)null
Into: new Box(0)
*/
using System;
class Box
{
    public int Number;
    public Box(int number) { Number = number; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Box Create(out int label) { label = 43; return new Box(19); }
    static void Main()
    {
        int label;
        Box answer = (Box)null ?? Create(out label);
        Check(answer.Number == 19, "constant-null-evaluates-second-operand");
        Check(label == 43, "second-operand-assignment-reaches-following-read");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
