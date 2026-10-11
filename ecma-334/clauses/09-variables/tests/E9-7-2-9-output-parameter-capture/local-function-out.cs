/*
Rules: E9-7-2-9-output-parameter-capture
Authority: ECMA-334 7th ed 9.7.2.9
Version: 7.3
Expected: reject
Mutate: int Read() { return cell; }
Into: int Read() { return 26; }
Csc: CS1628
*/
class Program
{
    static int Probe(out int cell) { cell = 26; int Read() { return cell; } return Read(); }
    static void Main() { }
}
