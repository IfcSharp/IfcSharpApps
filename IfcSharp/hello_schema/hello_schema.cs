
// hello_schema.cs, this software use IfcSharp (see https://github.com/IfcSharp)
using ifc;
using System.Collections.Generic;

class hello_schema {static void Main(string[] args){//#####################################################################
try{ 

System.Collections.Generic.SortedSet<string> set=new SortedSet<string>();

ifc.ENTITY.TypeDictionary.FillEntityTypeComponentsDict();
int Counter=0;
foreach (ifc.ENTITY.ComponentsType ct in ifc.ENTITY.TypeDictionary.EntityTypeComponentsList) //if (++Counter<5)
        {//System.Console.WriteLine("Entity "+ct.EntityType.Name);
         foreach (System.Reflection.FieldInfo fi in ct.AttribList) 
                 {foreach (System.Attribute attr in fi.GetCustomAttributes(true)) if (attr is ifcAttribute) 
                    if (fi.Name[0]=='_') set.Add(fi.Name);
                  //System.Console.WriteLine(" "+fi.Name+" "+fi.FieldType.ToString());
                 }
       }

foreach (string s in set) 
System.Console.WriteLine(s);

}catch(System.Exception e){System.Console.WriteLine(e.Message);} 
}}//########################################################################################################################