/*
Rules: E15-6-1-method-mode-only-overload
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public void Touch(out int value)
Into: public void Touch(int value)
Csc: CS0663
*/
class Holder
{
    public void Touch(ref int value) { value = 3; }
    public void Touch(out int value) { value = 5; }
}
class Program { static void Main() { } }
