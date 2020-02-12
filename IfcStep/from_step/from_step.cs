// from_step.cs, this software use IfcSharp (see https://github.com/IfcSharp)

class from_step {static void Main(string[] args){//#######################################################################

ifc.Model.FromStepFile("../../hello_pipe.ifc").ToHtmlFile();

}}//######################################################################################################################

