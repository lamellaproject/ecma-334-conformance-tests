/*
Rules: E6-2-5-generic-query-keyword
Authority: ECMA-334 7th ed 6.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Read<int> ascending
Into: Read<int>() ascending
*/
using System;
delegate int Getter();
delegate Getter KeySelector(int item);
delegate int ResultSelector(int item);
class QuerySource
{
    public int Number;
    public QuerySource OrderBy(KeySelector selector) { return new QuerySource { Number = selector(0)() }; }
    public int Select(ResultSelector selector) { return selector(Number); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read<T>() { return 18; }
    static void Main()
    {
        int actual = from item in new QuerySource() orderby Read<int> ascending select item + 0;
        Check(actual == 18, "query-keyword-retains-generic-method-group");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
