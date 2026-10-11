/*
Rules: E15-3-8-static-access-instance; E15-3-8-static-access-type
Authority: ECMA-334 7th ed 15.3.8
Version: 7.3
Expected: reject
Mutate: new Register().Changed
Into: Register.Changed
*/
class Register
{
    public delegate void Signal();
    public static event Signal Changed { add { } remove { } }
}
class Program
{
    static void OnSignal() { }
    static void Main() { new Register().Changed += OnSignal; }
}
