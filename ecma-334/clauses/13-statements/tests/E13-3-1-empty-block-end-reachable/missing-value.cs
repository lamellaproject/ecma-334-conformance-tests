/*
Rules: E13-3-1-empty-block-end-reachable; E13-2-function-block-reachable; E13-2-value-function-end-error
Authority: ECMA-334 7th ed 13.3.1
Version: 7.3
Expected: reject
Mutate: static int Uncalled() { {} }
Into: static int Uncalled() { { return 6; } }
Csc: CS0161
*/
class Program
{
    static int Uncalled() { {} }
    static void Main() { }
}
