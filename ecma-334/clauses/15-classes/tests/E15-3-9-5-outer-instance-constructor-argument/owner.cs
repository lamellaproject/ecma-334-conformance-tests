/*
Rules: E15-3-9-5-outer-instance-constructor-argument; E15-3-9-6-containing-private
Authority: ECMA-334 7th ed 15.3.9
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: new Node(this)
Into: new Node(null)
*/
using System;
class Host
{
    private int code;
    public Host(int value) { code = value; }
    public Node Create() { return new Node(this); }
    public class Node
    {
        private Host owner;
        public Node(Host owner) { this.owner = owner; }
        public int Read() { return owner.code; }
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Host first = new Host(349);
        Host second = new Host(353);
        Check(first.Create().Read() == 349, "nested-instance-reads-first-passed-owner");
        Check(second.Create().Read() == 353, "nested-instance-reads-second-passed-owner");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
