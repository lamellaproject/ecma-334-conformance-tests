/*
Rules: E20-2-new-type; E20-2-name-equivalence
Authority: ECMA-334 7th ed 20.2
Version: 7.3
Expected: reject
Mutate: Second destination = source
Into: First destination = source
Csc: CS0029
*/
delegate int First(int value);
delegate int Second(int value);
class Program
{
    static int Read(int value) { return value; }
    static void Main() { First source = Read; Second destination = source; }
}
