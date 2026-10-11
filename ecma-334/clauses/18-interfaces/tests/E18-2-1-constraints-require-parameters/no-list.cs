/*
Rules: E18-2-1-constraints-require-parameters
Authority: ECMA-334 7th ed 18.2.1
Version: 7.3
Expected: reject
Mutate: interface IStore where T : class
Into: interface IStore<T> where T : class
*/
interface IStore where T : class { }
class Program { static void Main() { } }
