/*
Rules: E9-4-4-28-other-exit-unassigned
Authority: ECMA-334 7th ed 9.4.4.28
Version: 7.3
Expected: reject
Mutate: !gate
Into: !((cell = 13) > 0)
Csc: CS0165
*/
class Program
{
    static int Read(bool gate) { int cell; bool result = !gate; return cell; }
    static void Main() { Read(true); }
}
