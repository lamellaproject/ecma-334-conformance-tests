/*
Rules: E12-23-predefined-binary; E12-23-predefined-unary; E12-23-conditional; E12-23-constant-evaluation-semantics; E12-23-compile-time-evaluation
Authority: ECMA-334 7th ed 12.23
Version: 7.3
Expected: run
Stdout: OK 16
Mutate: const int left = 3 << 2;
Into: const int left = 3 >> 2;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        const int add = 6 + 3; Check(add == 9, "constant-add");
        const int subtract = 8 - 3; Check(subtract == 5, "constant-subtract");
        const int multiply = 4 * 3; Check(multiply == 12, "constant-multiply");
        const int divide = 11 / 3; Check(divide == 3, "constant-divide");
        const int remainder = 11 % 3; Check(remainder == 2, "constant-remainder");
        const int left = 3 << 2; Check(left == 12, "constant-left-shift");
        const int right = -9 >> 2; Check(right == -3, "constant-right-shift");
        const int and = 13 & 6; Check(and == 4, "constant-and");
        const int or = 13 | 6; Check(or == 15, "constant-or");
        const int xor = 13 ^ 6; Check(xor == 11, "constant-xor");
        const bool conditional = true && false || true; Check(conditional, "constant-conditional-logical");
        const bool equality = 2 == 2 && 4 != 5; Check(equality, "constant-equality");
        const bool relational = 1 < 2 && 2 <= 2 && 4 > 3 && 4 >= 4; Check(relational, "constant-relational");
        const int negated = -(+4); Check(negated == -4, "constant-unary-plus-minus");
        const bool not = !false; Check(not, "constant-logical-not");
        const int selected = false ? 17 : ~2; Check(selected == -3, "constant-conditional-and-complement");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
