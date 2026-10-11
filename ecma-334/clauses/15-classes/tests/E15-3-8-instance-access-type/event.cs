/*
Rules: E15-3-8-instance-access-type; E15-3-8-instance-access-receiver
Authority: ECMA-334 7th ed 15.3.8
Version: 7.3
Expected: reject
Mutate: Register.Changed
Into: new Register().Changed
*/
class Register
{
    public delegate void Signal();
    public event Signal Changed { add { } remove { } }
}
class Program
{
    static void OnSignal() { }
    static void Main() { Register.Changed += OnSignal; }
}
