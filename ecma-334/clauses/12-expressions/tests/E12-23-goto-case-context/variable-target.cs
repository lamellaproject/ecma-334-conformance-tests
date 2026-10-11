/*
Rules: E12-23-goto-case-context
Authority: ECMA-334 7th ed 12.23
Version: 7.3
Expected: reject
Mutate: goto case label;
Into: goto case 2;
Csc: CS0150
*/
class Program
{
    static void Main()
    {
        int selector = 1, label = 2;
        switch (selector) { case 1: goto case label; case 2: break; }
    }
}
