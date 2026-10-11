/*
Rules: E13-9-4-form-for; E13-9-4-for-absent-condition-body; E13-9-4-for-condition-evaluation
Authority: ECMA-334 7th ed 13.9.4
Version: 7.3
Expected: run
Stdout: OK 8
Generated: clauses/13-statements/generators/for-parts.py
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Tick(ref int value) { value++; }
    static bool Gate(ref int value) { value++; return value <= 2; }
    static void Main()
    {
        {
            int a = 0, b = 0, c = 0, n = 0;
            for (; ; ) { n++; if (n == 2) break; }
            Check(a == 0 && b == 0 && c == 0 && n == 2, "parts-000");
        }
        {
            int a = 0, b = 0, c = 0, n = 0;
            for (; ; Tick(ref c)) { n++; if (n == 2) break; }
            Check(a == 0 && b == 0 && c == 1 && n == 2, "parts-001");
        }
        {
            int a = 0, b = 0, c = 0, n = 0;
            for (; Gate(ref b); ) { n++; if (n == 2) break; }
            Check(a == 0 && b == 2 && c == 0 && n == 2, "parts-010");
        }
        {
            int a = 0, b = 0, c = 0, n = 0;
            for (; Gate(ref b); Tick(ref c)) { n++; if (n == 2) break; }
            Check(a == 0 && b == 2 && c == 1 && n == 2, "parts-011");
        }
        {
            int a = 0, b = 0, c = 0, n = 0;
            for (Tick(ref a); ; ) { n++; if (n == 2) break; }
            Check(a == 1 && b == 0 && c == 0 && n == 2, "parts-100");
        }
        {
            int a = 0, b = 0, c = 0, n = 0;
            for (Tick(ref a); ; Tick(ref c)) { n++; if (n == 2) break; }
            Check(a == 1 && b == 0 && c == 1 && n == 2, "parts-101");
        }
        {
            int a = 0, b = 0, c = 0, n = 0;
            for (Tick(ref a); Gate(ref b); ) { n++; if (n == 2) break; }
            Check(a == 1 && b == 2 && c == 0 && n == 2, "parts-110");
        }
        {
            int a = 0, b = 0, c = 0, n = 0;
            for (Tick(ref a); Gate(ref b); Tick(ref c)) { n++; if (n == 2) break; }
            Check(a == 1 && b == 2 && c == 1 && n == 2, "parts-111");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
