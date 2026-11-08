/*
Rules: E8-3-3-nullable-default-hasvalue; E8-3-12-nullable-value-set
Authority: ECMA-334 7th ed 8.3.3
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: int? explicitDefault = default(int?);
Into: int? explicitDefault = new int?(9);
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    class Holder { public int? Value; }
    static int Main()
    {
        int? explicitDefault = default(int?);
        int? literal = null;
        int? constructed = new int?();
        Holder holder = new Holder();
        int?[] array = new int?[1];
        Check(!explicitDefault.HasValue, "default-expression-null");
        Check(!literal.HasValue && literal == explicitDefault, "null-conversion");
        Check(!constructed.HasValue, "default-constructor-null");
        Check(!holder.Value.HasValue && !array[0].HasValue, "automatic-defaults");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
