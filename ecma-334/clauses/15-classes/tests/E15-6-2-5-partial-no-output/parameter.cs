/*
Rules: E15-6-2-5-partial-no-output
Authority: ECMA-334 7th ed 15.6.2.5
Version: 7.3
Expected: reject
Mutate: out int value
Into: ref int value
Csc: CS8797
*/
partial class Program
{
    partial void Write(out int value);
    static void Main() { }
}
