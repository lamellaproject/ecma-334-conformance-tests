/*
Rules: E12-20-2-query-recognition
Authority: ECMA-334 7th ed 12.20.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: from orderby, let;
Into: from orderby in let;
*/
using System;
class from
{
    public int Value;
    public from(int value) { Value = value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        from select = new from(4), where = new from(6);
        from join;
        join = select;
        from orderby, let;
        orderby = new from(5);
        let = new from(7);
        Check(select.Value == 4 && where.Value == 6, "equals-starts-declaration");
        Check(join.Value == 4, "semicolon-ends-declaration");
        Check(orderby.Value == 5 && let.Value == 7, "comma-continues-declaration");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
