/*
Rules: E9-7-2-9-input-parameter-capture
Authority: ECMA-334 7th ed 9.7.2.9
Version: 7.3
Expected: reject
Mutate: int Read() { return cell; }
Into: int Read() { return 30; }
Csc: CS1628
*/
class Program
{
    static int Probe(in int cell) { int Read() { return cell; } return Read(); }
    static void Main() { }
}
