/*
Rules: E20-4-parameter-no-numeric
Authority: ECMA-334 7th ed 20.4
Version: 7.3
Expected: reject
Mutate: delegate void Notice(int value);
Into: delegate void Notice(long value);
Csc: CS0123
*/
delegate void Notice(int value);
class Program
{
    static void Touch(long value) { }
    static void Main() { Notice notice = Touch; }
}
