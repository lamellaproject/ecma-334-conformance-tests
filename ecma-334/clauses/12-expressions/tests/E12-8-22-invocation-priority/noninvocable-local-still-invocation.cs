/*
Rules: E12-8-22-invocation-priority
Authority: ECMA-334 7th ed 12.8.22
Version: 7.3
Expected: reject
Mutate: int nameof = 0;
Into: int other = 0;
*/
class Program
{
    static void Main()
    {
        // Block lookup finds this local before member lookup.
        int nameof = 0;
        int count = 7;
        string name = nameof(count);
    }
}
