/*
Rules: E13-10-5-computes-value-members; E13-10-5-form-return-by-value
Authority: ECMA-334 7th ed 13.10.5
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: return index + 17;
Into: return index + 18;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    struct Box
    {
        public int Number;
        public int Property { get { return Number; } }
        public int this[int index] { get { return index + 17; } }
        public static Box operator +(Box a, Box b) { return new Box { Number = a.Number + b.Number }; }
    }
    static int Value() { return 23; }
    static void Main()
    {
        Box left = new Box { Number = 5 };
        Box right = new Box { Number = 8 };
        Check(Value() == 23, "method-value");
        Check(left.Property == 5, "get-accessor-value");
        Check(left[2] == 19, "indexer-value");
        Check((left + right).Number == 13, "operator-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
