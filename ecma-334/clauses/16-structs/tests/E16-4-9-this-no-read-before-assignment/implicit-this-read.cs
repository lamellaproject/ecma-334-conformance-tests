/*
Rules: E16-4-9-this-no-read-before-assignment
Authority: ECMA-334 7th ed 16.4.9
Version: 7.3
Expected: reject
Mutate: Value = Read();
Into: Value = value;
*/
struct Entry
{
    public int Value;
    public Entry(int value) { Value = Read(); }
    public int Read() { return 7; }
}
class Program { static void Main() { } }
