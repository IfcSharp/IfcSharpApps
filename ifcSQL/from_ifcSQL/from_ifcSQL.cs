// from_ifcSQL.cs, this software use IfcSharp (see https://github.com/IfcSharp)
class from_ifcSQL {static void Main(string[] args){//#######################################################################
try{ 
ifc.Model m = ifc.Model.FromSql(ServerName:System.Environment.GetEnvironmentVariable("SqlServer"), DatabaseName:"ifcSQL_Instance",ProjectId:0);
          m.ToHtmlFile();
          m.ToStepFile();
}catch(System.Exception e){System.Console.WriteLine(e.Message);} 
}}//########################################################################################################################

