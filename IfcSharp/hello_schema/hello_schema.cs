// hello_schema.cs, this software use IfcSharp (see https://github.com/IfcSharp)
class hello_schema {static void Main(string[] args){//#####################################################################
try{ 

ifc.ENTITY.TypeDictionary.FillEntityTypeComponentsDict();
int Counter=0;
foreach (ifc.ENTITY.ComponentsType ct in ifc.ENTITY.TypeDictionary.EntityTypeComponentsList) if (++Counter<5)
        {System.Console.WriteLine("Entity "+ct.EntityType.Name);
         foreach (System.Reflection.FieldInfo fi in ct.AttribList) 
                 {foreach (System.Attribute attr in fi.GetCustomAttributes(true)) if (attr is ifcAttribute) System.Console.Write(" ("+((ifcAttribute)attr).OrdinalPosition+")");
                  System.Console.WriteLine(" "+fi.Name+" "+fi.FieldType.ToString());
                 }
       }

}catch(System.Exception e){System.Console.WriteLine(e.Message);} 
}}//########################################################################################################################

