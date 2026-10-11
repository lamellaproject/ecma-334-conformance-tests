/*
Rules: E12-8-16-6-property-target
Authority: ECMA-334 7th ed 12.8.16.6
Version: 7.3
Expected: reject
Mutate: new Reader(receiver.Number)
Into: new Reader(receiver.Read)
*/
delegate int Reader();
class Receiver
{
    public int Number { get { return 7; } }
    public int Read() { return Number; }
}
class Program
{
    static void Main()
    {
        Receiver receiver = new Receiver();
        var operation = new Reader(receiver.Number);
    }
}
