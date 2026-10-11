/*
Rules: E12-6-5-instance-receiver-check; E12-6-5-no-candidate
Authority: ECMA-334 7th ed 12.6.5
Version: 7.3
Expected: reject
Mutate: Worker.Pick(value);
Into: new Worker().Pick(value);
Csc: CS0120
*/
class Worker
{
    public void Pick(int value) { }
}
class Program
{
    static void Main()
    {
        dynamic value = 8;
        Worker.Pick(value);
    }
}
