/*
Rules: E12-8-22-invocation-priority
Authority: ECMA-334 7th ed 12.8.22
Version: 7.3
Expected: reject
Mutate: static string nameof()
Into: static string named()
*/
class Program
{
    static string nameof() { return "called"; }
    static void Main()
    {
        int count = 7;
        string name = nameof(count);
    }
}
