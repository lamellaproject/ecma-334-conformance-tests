/*
Rules: E15-3-3-constructed-member-substitution
Authority: ECMA-334 7th ed 15.3.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public T Value;
Into: public object Value;
*/
using System;
class Cell<T>
{
    public T Value;
    public T Store(T input) { Value = input; return Value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Cell<int> number = new Cell<int>();
        int stored = number.Store(263);
        Check(stored == 263 && number.Value == 263, "int-field-parameter-and-result-substitution");
        Cell<string> text = new Cell<string>();
        string word = text.Store("cell");
        Check(word == "cell" && text.Value == "cell", "string-field-parameter-and-result-substitution");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
