// hello_schema.cs, this software use IfcSharp (see https://github.com/IfcSharp)
class hello_schema {static void Main(string[] args){//#####################################################################
try{ 

ifc.ENTITY.TypeDictionary.FillEntityTypeComponentsDict();
foreach (ifc.ENTITY.ComponentsType ct in ifc.ENTITY.TypeDictionary.EntityTypeComponentsList) 
  foreach (System.Reflection.FieldInfo fi in ct.AttribList) 
    {}// System.Console.WriteLine(ct.EntityType.Name+":"+fi.Name);

}catch(System.Exception e){System.Console.WriteLine(e.Message);} 
}}//########################################################################################################################

