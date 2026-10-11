/*
Rules: E20-4-parameter-modifiers; E20-4-arity-modifiers
Authority: ECMA-334 7th ed 20.4
Version: 7.3
Expected: reject
Mutate: static void Touch(ref int value)
Into: static void Touch(in int value)
Csc: CS0123
*/
delegate void Notice(in int value);
class Program
{
    static void Touch(ref int value) { }
    static void Main() { Notice notice = Touch; }
}
