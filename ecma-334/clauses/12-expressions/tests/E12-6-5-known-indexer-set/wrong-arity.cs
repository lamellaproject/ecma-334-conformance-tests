/*
Rules: E12-6-5-known-indexer-set; E12-6-5-limited-check; E12-6-5-no-candidate
Authority: ECMA-334 7th ed 12.6.5
Version: 7.3
Expected: reject
Mutate: worker[value];
Into: worker[value, 8];
Csc: CS7036
*/
class Worker
{
    public int this[int first, int second] { get { return first + second; } }
}
class Program
{
    static void Main()
    {
        dynamic value = 3;
        Worker worker = new Worker();
        int result = worker[value];
    }
}
