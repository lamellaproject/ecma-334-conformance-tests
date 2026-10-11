/*
Rules: E12-6-5-static-receiver-check; E12-6-5-no-candidate
Authority: ECMA-334 7th ed 12.6.5
Version: 7.3
Expected: reject
Mutate: worker.Pick(value);
Into: Worker.Pick(value);
Csc: CS0176
*/
class Worker
{
    public static void Pick(int value) { }
}
class Program
{
    static void Main()
    {
        dynamic value = 8;
        Worker worker = new Worker();
        worker.Pick(value);
    }
}
