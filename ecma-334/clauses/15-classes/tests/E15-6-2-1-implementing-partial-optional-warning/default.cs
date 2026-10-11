/*
Rules: E15-6-2-1-implementing-partial-optional-warning
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: run
Stdout: OK 0
Diagnostic: warning
Mutate: partial void Touch(int value = 37)
Into: partial void Touch(int value)
*/
partial class Holder
{
    partial void Touch(int value);
    partial void Touch(int value = 37) { }
}
class Program { static void Main() { System.Console.WriteLine("OK 0"); } }
