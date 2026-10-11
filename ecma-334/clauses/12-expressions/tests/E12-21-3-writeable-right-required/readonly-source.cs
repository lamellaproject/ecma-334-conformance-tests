/*
Rules: E12-21-3-writeable-right-required
Authority: ECMA-334 7th ed 12.21.3
Version: 7.3
Expected: reject
Mutate: ref int alias = ref storage
Into: ref readonly int alias = ref storage
Csc: CS8331
*/
class Program
{
    static void Move(in int input) { int storage = 0; ref int alias = ref storage; alias = ref input; }
    static void Main() { int input = 4; Move(in input); }
}
