/*
Rules: E13-10-6-propagation-catch-order; E13-11-form-specific-catches; E13-11-normal-catch-exit-without-finally; E13-10-6-propagation-filter-variable; E13-10-6-propagation-filter-condition; E13-11-catch-search-order; E13-11-catch-filter-match-required; E13-11-filter-exception-variable-assignment; E13-11-filter-evaluation; E13-11-first-matching-catch-entry; E13-11-exception-variable-declaration; E13-11-exception-variable-current-exception; E13-11-exception-variable-definite-assignment; E13-11-form-typed-catch; E13-11-form-exception-specifier; E13-11-form-exception-filter
Authority: ECMA-334 7th ed 13.10.6
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: when (Filter(second, 2, true))
Into: when (Filter(second, 2, false))
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int trace, chosen;
    static bool correctVariables = true;
    static Exception expected = new Exception();
    static bool Filter(Exception actual, int digit, bool match)
    {
        trace = trace * 10 + digit;
        correctVariables = correctVariables && actual == expected;
        return match;
    }
    static void Main()
    {
        try { throw expected; }
        catch (Exception first) when (Filter(first, 1, false)) { chosen = 1; }
        catch (Exception second) when (Filter(second, 2, true)) { chosen = 2; trace = trace * 10 + 3; }
        catch (Exception) { chosen = 3; }
        Check(chosen == 2, "first-true-filter-handler");
        Check(trace == 123, "lexical-filter-order");
        Check(correctVariables, "exception-variable-assigned-before-filter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
