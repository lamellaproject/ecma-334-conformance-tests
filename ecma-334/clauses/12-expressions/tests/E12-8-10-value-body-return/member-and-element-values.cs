/*
Rules: E12-8-10-value-body-return; E12-8-10-method-body-context; E12-8-10-function-body-context
Authority: ECMA-334 7th ed 12.8.10
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: int? Read(Cell receiver) => receiver?.Number();
Into: int? Read(Cell receiver) => null;
*/
using System;
class Cell { public int Number() { return 17; } }
class Program
{
    static int checks, failures;
    static int? Read(Cell receiver) => receiver?.Number();
    static int Answer() { return 23; }
    static int? ReadElement(Func<int>[] array) => array?[0]();
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Func<Cell, int?> member = receiver => receiver?.Number();
        Check(Read(new Cell()) == 17 && member(new Cell()) == 17, "value-member-body-returns-lifted-result");
        Check(!Read(null).HasValue && !member(null).HasValue, "value-member-body-returns-null");
        Func<Func<int>[], int?> element = array => array?[0]();
        Func<int>[] values = new Func<int>[] { Answer };
        Check(ReadElement(values) == 23 && element(values) == 23, "value-element-body-returns-lifted-result");
        Check(!ReadElement(null).HasValue && !element(null).HasValue, "value-element-body-returns-null");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
