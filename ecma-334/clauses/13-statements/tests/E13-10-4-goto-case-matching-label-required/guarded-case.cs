/*
Rules: E13-10-4-goto-case-matching-label-required
Authority: ECMA-334 7th ed 13.10.4
Version: 7.3
Expected: reject
Mutate: case 2 when flag:
Into: case 2:
*/
class Program
{
    static void Main()
    {
        int value = 1;
        bool flag = true;
        switch (value) { case 1: goto case 2; case 2 when flag: break; }
    }
}
