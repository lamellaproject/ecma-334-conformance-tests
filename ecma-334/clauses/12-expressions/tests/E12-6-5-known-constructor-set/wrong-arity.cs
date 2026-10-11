/*
Rules: E12-6-5-known-constructor-set; E12-6-5-limited-check; E12-6-5-no-candidate
Authority: ECMA-334 7th ed 12.6.5
Version: 7.3
Expected: reject
Mutate: new Worker(value);
Into: new Worker(value, 8);
Csc: CS7036
*/
class Worker
{
    public Worker(int first, int second) { }
}
class Program
{
    static void Main()
    {
        dynamic value = 3;
        new Worker(value);
    }
}
