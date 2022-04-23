
// hello_schema.cs, this software use IfcSharp (see https://github.com/IfcSharp)
using ifc;
using System.Collections.Generic;

class hello_schema {static void Main(string[] args){//#####################################################################
try{ 

ifc.ENTITY.TypeDictionary.FillEntityTypeComponentsDict(); // collect all schema-informations of entities 

foreach (ifc.ENTITY.ComponentsType ct in ifc.ENTITY.TypeDictionary.EntityTypeComponentsList) 
        {bool HasDerivedAttributes=false; foreach (ifc.ENTITY.AttribInfo ai in ct.AttribList) if (ai.IsDerived) HasDerivedAttributes=true; 
         bool NoFilter=false; NoFilter=true;// set to true for all entity-classes
         if (HasDerivedAttributes || NoFilter)  // filter-example
            {System.Console.Write("\nEntity "+ct.EntityType.Name);
             System.Type BaseType=ct.EntityType.BaseType; while (BaseType!=null && BaseType.Name!="ENTITY") {System.Console.Write("<"+BaseType.Name); BaseType=BaseType.BaseType; }
             System.Console.WriteLine(":");
             foreach (ifc.ENTITY.AttribInfo ai in ct.AttribList) 
                     {System.Type FieldType=ai.field.FieldType;  
                      bool Nullable=(System.Nullable.GetUnderlyingType(FieldType)!=null);
                      if (Nullable) FieldType=System.Nullable.GetUnderlyingType(ai.field.FieldType);
                      string TypeName=FieldType.Name;
                      bool IsAbstract=FieldType.IsAbstract;
                      string BaseTypeName="-";
                      if (FieldType.IsEnum)                         BaseTypeName="ENUM";
                      if (FieldType.IsSubclassOf(typeof(TypeBase))) BaseTypeName="TYPE";
                      if (FieldType.IsSubclassOf(typeof(ENTITY)))   BaseTypeName="ENTITY";
                      if (FieldType.IsSubclassOf(typeof(SELECT)))   BaseTypeName="SELECT";
                      System.Console.WriteLine(ai.OrdinalPosition+": "+TypeName+" "+ai.field.Name+((ai.IsDerived)?" IsDerived":"")+((ai.optional)?" [optional]":"")+" ["+((Nullable)?"nullable ":"")+BaseTypeName+"]"+((ai.field.DeclaringType!=ct.EntityType)?" of class "+ai.field.DeclaringType.Name:"")+((IsAbstract)?"[abstract]":""));
                     }
             foreach (System.Reflection.FieldInfo fi in ct.InversList) System.Console.WriteLine("INV: "+fi.FieldType.Name+" "+fi.Name+" of class "+fi.DeclaringType.Name);
           }
       }

}catch(System.Exception e){System.Console.WriteLine(e.Message);} 
}}//########################################################################################################################