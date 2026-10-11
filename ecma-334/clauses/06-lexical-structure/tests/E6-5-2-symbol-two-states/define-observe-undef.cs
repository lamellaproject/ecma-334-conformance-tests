/*
Rules: E6-5-2-symbol-two-states; E6-5-2-symbol-initially-undefined; E6-5-2-symbol-definition-duration; E6-5-2-defined-symbol-true; E6-5-2-undefined-symbol-false; E6-5-2-undeclared-symbol-reference; E6-5-4-grammar-pp-declaration-1; E6-5-4-grammar-pp-declaration-2; E6-5-4-define-next-line; E6-5-4-undef-next-line; E6-5-3-grammar-pp-primary-expression-3
Authority: ECMA-334 7th ed 6.5.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: #undef CYCLE
Into: #define CYCLE
*/
#if CYCLE
#define INITIAL_DEFINED
#endif
#define CYCLE
#if CYCLE
#define SAW_DEFINED
#endif
#if CYCLE
#define STILL_DEFINED_BEFORE_UNDEF
#endif
#undef CYCLE
#if CYCLE
#define STILL_DEFINED
#endif
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
#if !INITIAL_DEFINED && SAW_DEFINED && STILL_DEFINED_BEFORE_UNDEF && !STILL_DEFINED
        int amount = 17;
#else
        int amount = 0;
#endif
        Check(amount == 17, "initial-defined-persistent-undefined");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
