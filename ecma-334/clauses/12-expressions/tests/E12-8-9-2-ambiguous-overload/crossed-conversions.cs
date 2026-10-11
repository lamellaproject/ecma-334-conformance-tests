/*
Rules: E12-8-9-2-ambiguous-overload
Authority: ECMA-334 7th ed 12.8.9.2
Version: 7.3
Expected: reject
Mutate: Choose(3, 5)
Into: Choose(3, 5L)
*/
class Program
{
    static void Choose(int first, long second) { }
    static void Choose(long first, int second) { }
    static void Main() { Choose(3, 5); }
}
