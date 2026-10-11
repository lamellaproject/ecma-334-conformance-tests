/*
Rules: E12-8-9-1-invalid-primary; E12-8-9-2-method-group-required; E12-8-9-4-delegate-primary
Authority: ECMA-334 7th ed 12.8.9
Version: 7.3
Expected: reject
Mutate: int primary = 3;
Into: Operation primary = Double;
*/
delegate int Operation(int value);
class Program
{
    static int Double(int value) { return value * 2; }
    static void Main()
    {
        int primary = 3;
        primary(5);
    }
}
