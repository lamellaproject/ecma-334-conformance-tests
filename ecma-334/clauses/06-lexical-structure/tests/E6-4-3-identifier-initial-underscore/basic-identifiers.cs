/*
Rules: E6-4-3-identifier-initial-underscore; E6-4-3-grammar-identifier-1; E6-4-3-grammar-simple-identifier-1; E6-4-3-grammar-available-identifier-1; E6-4-3-grammar-basic-identifier-1; E6-4-3-grammar-identifier-start-character-1; E6-4-3-grammar-identifier-start-character-2; E6-4-3-grammar-underscore-character-1; E6-4-3-grammar-identifier-part-character-1; E6-4-3-grammar-identifier-part-character-2; E6-4-3-grammar-identifier-part-character-3; E6-4-3-grammar-letter-character-1; E6-4-3-grammar-decimal-digit-character-1; E6-4-3-grammar-connecting-character-1; E6-4-1-grammar-token-1
Authority: ECMA-334 7th ed 6.4.3
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: int _entry9 = 37;
Into: int 9entry = 37;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int _entry9 = 37;
        int A = 41;
        int digit7 = 43;
        int row_next = 47;
        Check(_entry9 == 37, "initial-underscore-and-letter-part");
        Check(A == 41, "letter-start-no-parts");
        Check(digit7 == 43, "decimal-digit-part");
        Check(row_next == 47, "connecting-part");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
