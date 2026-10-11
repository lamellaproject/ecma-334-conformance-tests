/*
Rules: E18-2-4-base-accessibility
Authority: ECMA-334 7th ed 18.2.4
Version: 7.3
Expected: reject
Mutate: interface IHidden
Into: public interface IHidden
Csc: CS0061
*/
interface IHidden { }
public interface IExposed : IHidden { }
class Program { static void Main() { } }
