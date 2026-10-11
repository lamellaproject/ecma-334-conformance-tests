/*
Rules: E12-8-16-7-backing-fields-type; E12-8-16-7-backing-fields; E12-8-16-7-backing-fields-readonly; E12-8-16-7-object-base; E12-8-16-7-anonymous-class; E12-8-16-7-constructor-parameters; E12-8-16-7-constructor-public; E12-8-16-7-constructor-parameter-types; E12-8-16-7-constructor-values; E12-8-16-7-public-getters; E12-8-16-7-getter-values; E12-8-16-7-property-types
Authority: ECMA-334 7th ed 12.8.16.7
Version: 7.3
Expected: run
Stdout: OK 9
Mutate: new { Number = 7, Link = anchor }
Into: new { Number = 7L, Link = anchor }
*/
using System;
using System.Reflection;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object anchor = new object();
        var value = new { Number = 7, Link = anchor };
        Type type = value.GetType();
        Check(type.IsClass, "anonymous-schema-class");
        Check(type.BaseType == typeof(object), "anonymous-direct-object-base");
        PropertyInfo number = type.GetProperty("Number"), link = type.GetProperty("Link");
        bool propertyTypes = number != null && number.PropertyType == typeof(int) &&
                             link != null && link.PropertyType == typeof(object);
        Check(propertyTypes, "schema-property-expression-types");
        bool getters = number != null && number.GetGetMethod() != null && number.GetGetMethod().IsPublic &&
                       link != null && link.GetGetMethod() != null && link.GetGetMethod().IsPublic;
        Check(getters, "schema-public-property-getters");
        bool numberField = false, linkField = false;
        // Inspect only the stated fields, without assuming their generated names or forbidding helper fields.
        foreach (FieldInfo field in type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly))
        {
            if (!field.IsPrivate || !field.IsInitOnly) continue;
            if (field.FieldType == typeof(int) && (int)field.GetValue(value) == 7) numberField = true;
            if (field.FieldType == typeof(object) && object.ReferenceEquals(field.GetValue(value), anchor)) linkField = true;
        }
        Check(numberField && linkField, "private-readonly-typed-backing-fields");
        ConstructorInfo constructor = type.GetConstructor(new Type[] { typeof(int), typeof(object) });
        Check(constructor != null && constructor.IsPublic, "schema-public-constructor");
        ParameterInfo[] parameters = constructor == null ? new ParameterInfo[0] : constructor.GetParameters();
        bool parameterTypes = parameters.Length == 2 && parameters[0].ParameterType == typeof(int) &&
                              parameters[1].ParameterType == typeof(object);
        Check(parameterTypes, "constructor-parameter-types-in-property-order");
        bool originalValues = propertyTypes && (int)number.GetValue(value) == 7 &&
                              object.ReferenceEquals(link.GetValue(value), anchor);
        Check(originalValues, "schema-original-getter-values");
        object created = constructor == null ? null : constructor.Invoke(new object[] { 31, anchor });
        bool createdValues = propertyTypes && created != null && (int)number.GetValue(created) == 31 &&
                             object.ReferenceEquals(link.GetValue(created), anchor);
        Check(createdValues, "schema-constructor-stores-corresponding-arguments");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
