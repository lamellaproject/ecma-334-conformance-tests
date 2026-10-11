/*
Rules: E20-4-arity-modifiers; E20-4-parameter-arity
Authority: ECMA-334 7th ed 20.4
Version: 7.3
Expected: reject
Mutate: static void Touch(int value, int extra)
Into: static void Touch(int value)
Csc: CS0123
*/
delegate void Notice(int value);
class Program
{
    static void Touch(int value, int extra) { }
    static void Main() { Notice notice = Touch; }
}
