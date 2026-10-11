/*
Rules: E20-4-return-no-numeric
Authority: ECMA-334 7th ed 20.4
Version: 7.3
Expected: reject
Mutate: delegate object Read();
Into: delegate int Read();
Csc: CS0407
*/
delegate object Read();
class Program
{
    static int ReadValue() { return 89; }
    static void Main() { Read read = ReadValue; }
}
