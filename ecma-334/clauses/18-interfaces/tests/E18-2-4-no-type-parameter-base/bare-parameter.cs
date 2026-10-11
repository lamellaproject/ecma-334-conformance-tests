/*
Rules: E18-2-4-no-type-parameter-base
Authority: ECMA-334 7th ed 18.2.4
Version: 7.3
Expected: reject
Mutate: interface IEnvelope<T> : T
Into: interface IEnvelope<T>
Csc: CS0689
*/
interface IEnvelope<T> : T { }
class Program { static void Main() { } }
