/*
Rules: E12-6-4-7-ed5-no-task-inner-preference
Authority: ECMA-334 5th ed 12.6.4.6
Version: 5
Expected: reject
Version-Witness: version-witnesses/E12-6-4-7-ed5-no-task-inner-preference/constructed-task-targets.cs.part
Mutate: Select(new Parcel())
Into: Select((Task<short>)new Parcel())
*/
// ECMA-334 5th ed 12.6.4.1, 12.6.4.4, 12.6.4.6,
// pp. 133-136 (PDF pp. 155-158).
using System.Threading.Tasks;
class Parcel
{
    public static implicit operator Task<short>(Parcel value) { return null; }
    public static implicit operator Task<ushort>(Parcel value) { return null; }
}
class Program
{
    static void Select(Task<short> value) { }
    static void Select(Task<ushort> value) { }
    static void Main()
    {
        Select(new Parcel());
    }
}
