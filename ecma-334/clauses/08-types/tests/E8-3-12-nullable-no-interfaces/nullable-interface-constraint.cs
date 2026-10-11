/*
Rules: E8-3-12-nullable-no-interfaces
Authority: ECMA-334 7th ed 8.3.12
Version: 7.3
Expected: reject
Mutate: Need<Number?>();
Into: Need<Number>();
*/
interface ITag { }
struct Number : ITag { }
class Program { static void Need<T>() where T : ITag { } static void Main() { Need<Number?>(); } }
