/*
Rules: E13-10-1-jump-cannot-enter-block; E13-10-4-goto-label-scope-required
Authority: ECMA-334 7th ed 13.10.1
Version: 7.3
Expected: reject
Mutate: goto nested;
Into: goto outer;
*/
class Program
{
    static void Main()
    {
        goto nested;
        { nested: ; }
        outer: ;
    }
}
