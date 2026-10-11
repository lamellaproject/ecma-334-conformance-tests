/*
Rules: E12-8-16-7-readonly-properties
Authority: ECMA-334 7th ed 12.8.16.7
Version: 7.3
Expected: reject
Mutate: value.Count = 19;
Into: scratch = 19;
*/
class Program
{
    static void Main()
    {
        int scratch = 0;
        var value = new { Count = 7 };
        value.Count = 19;
    }
}
