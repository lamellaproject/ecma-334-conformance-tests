/*
Rules: E12-20-2-escaped-query-identifier; E12-20-2-contextual-keywords
Authority: ECMA-334 7th ed 12.20.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: @orderby + @select + @where
Into: @orderby + @select
*/
using System;
delegate int Selector(int item);
class Source
{
    public int Select(Selector selector) { return selector(20); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int ascending = 1, by = 2, descending = 3, equals = 4, from = 5, group = 6, into = 7;
        int join = 8, let = 9, on = 10, orderby = 11, select = 12, where = 13;
        int result = from item in new Source()
                     select item + @ascending + @by + @descending + @equals + @from + @group + @into
                            + @join + @let + @on + @orderby + @select + @where;
        Check(result == 111, "all-query-keywords-escaped-as-identifiers");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
