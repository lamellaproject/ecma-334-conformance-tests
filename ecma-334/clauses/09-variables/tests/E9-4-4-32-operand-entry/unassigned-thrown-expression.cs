/*
Rules: E9-4-4-32-operand-entry
Authority: ECMA-334 7th ed 9.4.4.32
Version: 7.3
Expected: reject
Mutate: System.Exception error;
Into: System.Exception error = new System.Exception();
Csc: CS0165
*/
class Program
{
    static int Read(bool fail)
    {
        System.Exception error;
        return fail ? throw error : 1;
    }
    static void Main() { Read(false); }
}
