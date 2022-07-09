// hello_project.cs, this software use IfcSharp (see https://github.com/IfcSharp)
class hello_project {static void Main(string[] args){//#####################################################################
try{ 
// ifc.Repository.CurrentModel is required as the standard model for code created modells, 
// otherwise: ifc.Model myModel=new ifc.Model(name:"my_model"); myModel.ToStepFile(); or: ifc.Model.FromStepFile("__.ifc").ToHtmlFile();
ifc.Repository.CurrentModel=new ifc.Model(Name:"hello_project_output"); 

#if IFC2X3
new ifc.Project(_OwnerHistory:null,RepresentationContexts:null,UnitsInContext:null,GlobalId:ifc.GloballyUniqueId.NewId(),Name:new ifc.Label("my first ifc-project"));  // appends entity to ifc.Repository.CurrentModel
#else
new ifc.Project(GlobalId:ifc.GloballyUniqueId.NewId(),Name:new ifc.Label("my first ifc-project"));  // appends entity to ifc.Repository.CurrentModel
#endif

ifc.Repository.CurrentModel.ToStepFile();  // creates hello_project_output.ifc (step-format)
ifc.Repository.CurrentModel.ToHtmlFile();  // creates hello_project_output.html in step-format with syntax highlighting
ifc.Repository.CurrentModel.ToCsFile();    // creates hello_project_output.cs with c# code (useful for creating code from existing files)
ifc.Repository.CurrentModel.ToSqliteFile();// creates hello_project_output.sqlite3 with the default option exportCompleteSchema=false 
ifc.Repository.CurrentModel.ToXmlFile();   // creates hello_project_output.ifcXml
ifc.Repository.CurrentModel.ToSqlFile();   // creates SQL for ifcSQL without server-connection
//ifc.Repository.CurrentModel.ToSql(ServerName: System.Environment.GetEnvironmentVariable("SqlServer"), DatabaseName:"ifcSQL",ProjectId:0,WriteMode:ifc.Model.eWriteMode.OnlyIfEmpty); // Sql server connection required
//ifc.Repository.CurrentModel.ToSql(ServerName: System.Environment.GetEnvironmentVariable("SqlServer"), DatabaseName:"ifcSQL",WriteMode:ifc.Model.eWriteMode.CreateNewProject); // Sql server connection required
//ifc.Repository.CurrentModel.ToSql(ServerName: System.Environment.GetEnvironmentVariable("SqlServer"), DatabaseName:"ifcSQL",WriteMode:ifc.Model.eWriteMode.DeleteBeforeWrite); // Sql server connection required
}catch(System.Exception e){System.Console.WriteLine(e.Message);} 
}}//########################################################################################################################

