/*
Rules: E12-8-22-compile-time-lookup
Authority: ECMA-334 7th ed 12.8.22
Version: 7.3
Expected: reject
Mutate: nameof(Receiver.Missing)
Into: nameof(Receiver.Number)
*/
class Receiver { public int Number; }
class Program
{
    static void Main() { string name = nameof(Receiver.Missing); }
}
