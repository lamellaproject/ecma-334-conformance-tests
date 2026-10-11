/*
Rules: E13-11-form-exception-filter
Authority: ECMA-334 7th ed 13.11
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: when (new Decision { Match = true })
Into: when (new Decision { Match = false })
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int tested;
    struct Decision
    {
        public bool Match;
        public static bool operator true(Decision value) { tested++; return value.Match; }
        public static bool operator false(Decision value) { return !value.Match; }
    }
    static void Main()
    {
        int selected = 0;
        try { throw new Exception(); }
        catch when (new Decision { Match = true }) { selected = 1; }
        catch { selected = 2; }
        Check(selected == 1 && tested == 1, "filter-accepts-boolean-expression-true-operator");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
