/*
Rules: E12-8-4-implicit-instance-member
Authority: ECMA-334 7th ed 12.8.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: get { return value; }
Into: get { return other; }
*/
using System;
class Worker
{
    int value, other = 8;
    public Worker(int input) { value = input; }
    public int Read() { return value; }
    public int Value { get { return value; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Worker worker = new Worker(3);
        Check(worker.Read() == 3, "constructor-and-method-simple-instance-name-means-this-field");
        Check(worker.Value == 3, "accessor-simple-instance-name-means-this-field");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
