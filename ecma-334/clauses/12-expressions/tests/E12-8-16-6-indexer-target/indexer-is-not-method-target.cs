/*
Rules: E12-8-16-6-indexer-target
Authority: ECMA-334 7th ed 12.8.16.6
Version: 7.3
Expected: reject
Mutate: new Reader(receiver[0])
Into: new Reader(receiver.Read)
*/
delegate int Reader();
class Receiver
{
    public int this[int index] { get { return index + 7; } }
    public int Read() { return this[0]; }
}
class Program
{
    static void Main()
    {
        Receiver receiver = new Receiver();
        var operation = new Reader(receiver[0]);
    }
}
