/*
Rules: E20-2-constructed-arguments
Authority: ECMA-334 7th ed 20.2
Version: 7.3
Expected: reject
Mutate: Read reader = ReadValue
Into: Read<int> reader = ReadValue
Csc: CS0305
*/
delegate T Read<T>();
class Program
{
    static int ReadValue() { return 61; }
    static void Main() { Read reader = ReadValue; }
}
