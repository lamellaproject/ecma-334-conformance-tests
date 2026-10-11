/*
Rules: E15-5-4-volatile-read-acquire; E15-5-4-volatile-write-release; E15-5-4-volatile-classification
Authority: ECMA-334 7th ed 15.5.4
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: node.Left = 233; node.Right = 239; Published = node;
Into: Published = node; while (Acknowledged == 0) { } node.Left = 233; node.Right = 239;
*/
using System;
using System.Threading;
class Packet { public int Left, Right; }
class Program
{
    static volatile Packet Published;
    static volatile int Acknowledged;
    static int ObservedLeft, ObservedRight;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Publish()
    {
        Packet node = new Packet();
        node.Left = 233; node.Right = 239; Published = node;
    }
    static void Observe()
    {
        Packet node;
        do { node = Published; } while (node == null);
        ObservedLeft = node.Left;
        ObservedRight = node.Right;
        Acknowledged = 1;
    }
    static void Main()
    {
        Thread publisher = new Thread(Publish);
        Thread observer = new Thread(Observe);
        publisher.Start();
        observer.Start();
        publisher.Join();
        observer.Join();
        Check(ObservedLeft == 233, "acquire-observes-first-store-before-release");
        Check(ObservedRight == 239, "acquire-observes-second-store-before-release");
        Check(Published.Left == 233 && Published.Right == 239, "published-object-final-fields");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
