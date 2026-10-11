/*
Rules: E12-6-2-3-parameter-array-forms; E12-6-2-3-parameter-array-declarations; E12-6-2-3-normal-array-value; E12-6-2-3-expanded-arguments; E12-6-2-3-expanded-array; E12-6-2-3-expanded-array-length; E12-6-2-3-expanded-creation-equivalence; E12-6-2-2-expanded-correspondence
Authority: ECMA-334 7th ed 12.6.2.3
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: int[] expanded = Read(3, Evaluate(1, 5), Evaluate(2, 7));
Into: int[] expanded = Read(3, Evaluate(2, 7), Evaluate(1, 5));
*/
using System;
class Box
{
    public int[] values;
    public Box(int first, params int[] rest) { values = rest; }
    public int this[int first, params int[] rest] { get { return first + rest[0] + rest[1]; } }
}
class Program
{
    static int checks, failures, trace;
    static int Evaluate(int tag, int value) { trace = trace * 10 + tag; return value; }
    static int[] Read(int first, params int[] rest) { rest[0] += first; return rest; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[] supplied = new int[] { 11, 17 }; int[] normal = Read(3, supplied);
        Check(normal == supplied && supplied[0] == 14, "normal-parameter-array-reference");
        int[] expanded = Read(3, Evaluate(1, 5), Evaluate(2, 7));
        Check(expanded.Length == 2 && expanded[0] == 8 && expanded[1] == 7 && trace == 12, "expanded-array-order-and-length");
        Box box = new Box(3, 5, 7);
        Check(box.values.Length == 2 && box.values[0] == 5 && box.values[1] == 7, "constructor-parameter-array");
        Check(box[3, 5, 7] == 15, "indexer-parameter-array");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
