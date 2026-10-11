/*
Rules: E20-4-return-no-numeric
Authority: ECMA-334 7th ed 20.4
Version: 7.3
Expected: reject
Mutate: delegate long Read();
Into: delegate int Read();
Csc: CS0407
*/
delegate long Read();
class Program
{
    static int ReadValue() { return 83; }
    static void Main() { Read read = ReadValue; }
}
