/*
Rules: E12-8-9-2-no-applicable-method
Authority: ECMA-334 7th ed 12.8.9.2
Version: 7.3
Expected: reject
Mutate: Choose("fir")
Into: Choose(3)
*/
class Program
{
    static void Choose(int value) { }
    static void Main() { Choose("fir"); }
}
