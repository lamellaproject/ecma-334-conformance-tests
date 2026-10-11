/*
Rules: E12-19-2-parameter-name-conflict
Authority: ECMA-334 7th ed 12.19.2
Version: 7.3
Expected: reject
Mutate: (int value) => value + 19
Into: (int inner) => inner + 19
*/
delegate int Transform(int item);
class Program
{
    static Transform Make(int value) { return (int value) => value + 19; }
    static void Main() { }
}
