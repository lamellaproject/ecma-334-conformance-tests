/*
Rules: E18-4-1-no-byref-only-overload
Authority: ECMA-334 7th ed 18.4.1
Version: 7.3
Expected: reject
Mutate: void Read(out int value);
Into: void Read(int value);
Csc: CS0663
*/
interface IRead { void Read(ref int value); void Read(out int value); }
class Program { static void Main() { } }
