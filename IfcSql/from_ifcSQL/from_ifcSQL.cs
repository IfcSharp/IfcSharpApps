// from_ifcSQL.cs, this software use IfcSharp (see https://github.com/IfcSharp)
class from_ifcSQL {static void Main(string[] args){//#######################################################################
//try{ 
ifc.Log.Reset(); // bb 10.11.2024
ifc.ENTITY.IfcLineConstText="= IFC";
ifc.Model m = ifc.Model.FromSql(ServerName:System.Environment.GetEnvironmentVariable("SqlServer"), DatabaseName:"ifcSQL",ProjectId:0);// 0 = current project
                       m.Header.Name="from_ifcSQL";
if (args.Length>0)     m.Header.Name=args[0]; 
          m.ToStepFile(m.Header.Name+".ifc");
//}catch(System.Exception e){System.Console.WriteLine("from_ifcSQL:"+e.Message);} 
}}//########################################################################################################################

