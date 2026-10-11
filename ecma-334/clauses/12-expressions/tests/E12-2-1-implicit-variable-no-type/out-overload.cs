/*
Rules: E12-2-1-implicit-variable-no-type
Authority: ECMA-334 7th ed 12.2.1
Version: 7.3
Expected: reject
Mutate: out var item
Into: out int item
*/
class Program
{
    static void Read(out int item) { item = 31; }
    static void Read(out string item) { item = "red"; }
    static void Main()
    {
        // An output variable has no type while overload resolution is deciding what to infer.
        Read(out var item);
    }
}
