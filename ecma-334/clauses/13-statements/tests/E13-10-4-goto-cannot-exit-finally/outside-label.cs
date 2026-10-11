/*
Rules: E13-10-4-goto-cannot-exit-finally; E13-11-finally-goto-target-inside
Authority: ECMA-334 7th ed 13.10.4
Version: 7.3
Expected: reject
Mutate: goto outside;
Into: goto inside;
*/
class Program
{
    static void Main()
    {
        try { } finally { goto outside; inside: ; }
        outside: ;
    }
}
