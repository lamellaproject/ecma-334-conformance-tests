/*
Rules: E12-19-3-no-outer-byref-parameter
Authority: ECMA-334 7th ed 12.19.3
Version: 7.3
Expected: reject
Mutate: () => value
Into: () => 19
*/
delegate int Result();
delegate Result Factory(ref int value);
class Program
{
    static void Main()
    {
        Factory outer = (ref int value) => { Result inner = () => value; return inner; };
    }
}
