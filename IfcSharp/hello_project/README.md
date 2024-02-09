<!-- IfcSharp-documentation, Copyright (c) 2020, Bernhard Simon Bock, Friedrich Eder, MIT License (see https://github.com/IfcSharp/IfcSharpLibrary/tree/master/Licence) --->

# hello_project

This is a program, that create an emty project in different formats:
```csharp
class hello_project {static void Main(string[] args){
try{ 
ifc.Repository.CurrentModel=new ifc.Model(name:"hello_project_output"); 

new ifc.Project(Name:new ifc.Label("my first ifc-project"));  // appends entity to ifc.Repository.CurrentModel

ifc.Repository.CurrentModel.ToStepFile();  // creates hello_project_output.ifc (step-format)
ifc.Repository.CurrentModel.ToHtmlFile();  // creates hello_project_output.html (syntax highlighting)
ifc.Repository.CurrentModel.ToCsFile();    // creates c# code (useful for creating code from existing files)
ifc.Repository.CurrentModel.ToSqliteFile();// creates hello_project_output.sqlite3  
ifc.Repository.CurrentModel.ToXmlFile();   // creates hello_project_output.ifcXml
ifc.Repository.CurrentModel.ToSqlFile();   // creates SQL for ifcSQL without server-connection
ifc.Repository.CurrentModel.ToSql(ServerName: System.Environment.GetEnvironmentVariable("SqlServer"), 
                                  DatabaseName:"ifcSQL",ProjectId:3,
                                  WriteMode:ifc.Model.eWriteMode.CreateNewProject); // SQL Server required
}catch(System.Exception e){System.Console.WriteLine(e.Message);} 
}}

```
