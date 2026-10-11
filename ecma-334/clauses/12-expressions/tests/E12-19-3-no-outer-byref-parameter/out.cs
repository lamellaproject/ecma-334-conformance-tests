/*
Rules: E12-19-3-no-outer-byref-parameter
Authority: ECMA-334 7th ed 12.19.3
Version: 7.3
Expected: reject
Mutate: () => value
Into: () => 13
*/
delegate int Result();
class Program
{
    static Result Make(out int value) { value = 13; return () => value; }
    static void Main() { }
}
