/*
Rules: E12-4-4-unary-ambiguous
Authority: ECMA-334 7th ed 12.4.4
Version: 7.3
Expected: reject
Mutate: +operand
Into: +(decimal)operand
*/
struct Box
{
    public static implicit operator double(Box x) { return 3.0; }
    public static implicit operator decimal(Box x) { return 5M; }
}
class Program { static void Main() { Box operand = new Box(); var result = +operand; } }
