/*
Rules: E12-2-1-nothing-contexts; E12-2-2-value-required
Authority: ECMA-334 7th ed 12.2.1
Version: 7.3
Expected: reject
Mutate: int result = Touch();
Into: Touch();
*/
class Program
{
    static void Touch() { }
    static void Main() { int result = Touch(); }
}
