/*
Rules: E12-8-16-2-value-default-classification
Authority: ECMA-334 7th ed 12.8.16.2
Version: 7.3
Expected: reject
Mutate: Touch(ref new State());
Into: Touch(ref value);
Csc: CS1510
*/
struct State { public int Number; }
class Program
{
    static void Touch(ref State value) { value.Number = 5; }
    static void Main() { State value = new State(); Touch(ref new State()); }
}
