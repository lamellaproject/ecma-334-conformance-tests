/*
Rules: E18-6-4-implicit-constraint-equivalence
Authority: ECMA-334 7th ed 18.6.4
Version: 7.3
Expected: reject
Mutate: public U Read<U>(U value) where U : class
Into: public U Read<U>(U value) where U : T
Csc: CS0425
*/
interface IRead<T> where T : class { U Read<U>(U value) where U : T; }
class Reader<T> : IRead<T> where T : class
{
    public U Read<U>(U value) where U : class { return value; }
}
class Program { static void Main() { } }
