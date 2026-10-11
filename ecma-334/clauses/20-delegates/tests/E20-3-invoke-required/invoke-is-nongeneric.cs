/*
Rules: E20-3-invoke-required
Authority: ECMA-334 7th ed 20.3
Version: 7.3
Expected: reject
Mutate: read.Invoke<int>()
Into: read.Invoke()
Csc: CS0308
*/
delegate int Read();
class Program
{
    static int ReadValue() { return 113; }
    static void Main() { Read read = ReadValue; read.Invoke<int>(); }
}
