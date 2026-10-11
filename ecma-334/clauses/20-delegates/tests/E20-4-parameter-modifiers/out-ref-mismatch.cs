/*
Rules: E20-4-parameter-modifiers
Authority: ECMA-334 7th ed 20.4
Version: 7.3
Expected: reject
Mutate: static void Touch(ref int value) { value = 67; }
Into: static void Touch(out int value) { value = 67; }
Csc: CS0123
*/
delegate void Notice(out int value);
class Program
{
    static void Touch(ref int value) { value = 67; }
    static void Main() { Notice notice = Touch; }
}
