/*
Rules: E7-5-5-constraint-accessibility
Authority: ECMA-334 7th ed 7.5.5
Version: 7.3
Expected: reject
Mutate: internal interface IHidden
Into: public interface IHidden
*/
internal interface IHidden { }
public class Api { public void Call<T>() where T : IHidden { } }
class Program { static void Main() { } }
