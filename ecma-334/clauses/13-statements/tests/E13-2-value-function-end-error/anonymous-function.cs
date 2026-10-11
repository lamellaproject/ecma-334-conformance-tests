/*
Rules: E13-2-value-function-end-error; E13-2-function-block-reachable
Authority: ECMA-334 7th ed 13.2
Version: 7.3
Expected: reject
Mutate: () => { }
Into: () => { return 6; }
*/
delegate int Compute();
class Program
{
    static void Main() { Compute action = () => { }; }
}
