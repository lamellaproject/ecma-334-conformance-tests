/*
Rules: E13-8-3-subsumed-pattern-error
Authority: ECMA-334 7th ed 13.8.3
Version: 7.3
Expected: reject
Mutate: case object broad:
Into: case int broad:
*/
class Program
{
    static void Main()
    {
        object selector = "token";
        switch (selector) { case object broad: break; case string narrow: break; }
    }
}
