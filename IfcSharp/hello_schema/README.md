<!-- IfcSharp-documentation, Copyright (c) 2020, Bernhard Simon Bock, Friedrich Eder, MIT License (see https://github.com/IfcSharp/IfcSharpLibrary/tree/master/Licence) --->

# hello_schema


This example shows, how to traverse the IFC-schema with the reflections-methods of C# by evaluating the class-hierarchy of the C#-code.

```csharp
// hello_schema.cs, this software use IfcSharp (see https://github.com/IfcSharp)
class hello_schema {static void Main(string[] args){//#####################################################################
try{ 

ifc.ENTITY.TypeDictionary.FillEntityTypeComponentsDict();
foreach (ifc.ENTITY.ComponentsType ct in ifc.ENTITY.TypeDictionary.EntityTypeComponentsList) 
  foreach (System.Reflection.FieldInfo fi in ct.AttribList) 
     System.Console.WriteLine(ct.EntityType.Name+":"+fi.Name);

}catch(System.Exception e){System.Console.WriteLine(e.Message);} 
}}//########################################################################################################################


```
