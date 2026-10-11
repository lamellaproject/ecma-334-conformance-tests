/*
Rules: E6-5-3-expression-constant-evaluation; E6-5-3-grammar-pp-equality-expression-1; E6-5-3-grammar-pp-and-expression-1; E6-5-3-grammar-pp-expression-1; E6-5-3-grammar-pp-unary-expression-1; E6-5-3-grammar-pp-primary-expression-1; E6-5-3-grammar-pp-primary-expression-2; E6-5-3-expression-boolean-result; E6-5-3-expression-directive-contexts
Authority: ECMA-334 7th ed 6.5.3
Version: 7.3
Expected: run
Stdout: OK 8
Generated: clauses/06-lexical-structure/generators/preprocessor-booleans.py
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
#if false==false&&false
        int answer0 = 1;
#else
        int answer0 = 0;
#endif
        Check(answer0 == 0, "equal-before-and-0-0-0");
#if false==false&&true
        int answer1 = 1;
#else
        int answer1 = 0;
#endif
        Check(answer1 == 1, "equal-before-and-0-0-1");
#if false==true&&false
        int answer2 = 1;
#else
        int answer2 = 0;
#endif
        Check(answer2 == 0, "equal-before-and-0-1-0");
#if false==true&&true
        int answer3 = 1;
#else
        int answer3 = 0;
#endif
        Check(answer3 == 0, "equal-before-and-0-1-1");
#if true==false&&false
        int answer4 = 1;
#else
        int answer4 = 0;
#endif
        Check(answer4 == 0, "equal-before-and-1-0-0");
#if true==false&&true
        int answer5 = 1;
#else
        int answer5 = 0;
#endif
        Check(answer5 == 0, "equal-before-and-1-0-1");
#if true==true&&false
        int answer6 = 1;
#else
        int answer6 = 0;
#endif
        Check(answer6 == 0, "equal-before-and-1-1-0");
#if true==true&&true
        int answer7 = 1;
#else
        int answer7 = 0;
#endif
        Check(answer7 == 1, "equal-before-and-1-1-1");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
