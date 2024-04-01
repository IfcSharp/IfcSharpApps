// ifcStep2ifcSQL.cs, this software use IfcSharp (see https://github.com/IfcSharp), C# 9.0 with Top-level statements

ifc.Model.FromStepFile(args[0]).ToSql(ServerName: System.Environment.GetEnvironmentVariable("SqlServer"), DatabaseName:"ifcSQL",WriteMode:ifc.Model.eWriteMode.CreateNewProject); // Sql server connection required

