
// CAUTION! THIS IS A GENERATED FILE! IT WILL BE OVERWRITTEN AT ANY TIME! 
// created with https://github.com/IfcSharp

public class ifcOut{ public static void Generated(){ // ##########################################

ifc.Repository.CurrentModel.ClearEntityList();
ifc.Repository.CurrentModel.Header.name="generated_from_IfcSharp_ifc_Model_ToCsFile()";
var Project1                               =new ifc.Project                        (GlobalId:ifc.GloballyUniqueId.NewId() /*"'0$ymMqCbH0Kgog9omHu_HF'"*/// #1
                                                                                 //,_OwnerHistory:null// #2 [optional] (ifc.OwnerHistory)
                                                                                   ,Name:new ifc.Label("my first ifc-project")// #3 [optional]
                                                                                 //,Description:null// #4 [optional] (ifc.Text)
                                                                                 //,ObjectType:null// #5 [optional] (ifc.Label)
                                                                                 //,LongName:null// #6 [optional] (ifc.Label)
                                                                                 //,Phase:null// #7 [optional] (ifc.Label)
                                                                                 //,RepresentationContexts:null// #8 [optional] (ifc.Set1toUnbounded_RepresentationContext)
                                                                                 //,UnitsInContext:null// #9 [optional] (ifc.UnitAssignment)
                                                                                   );

ifc.Repository.CurrentModel.ToStepFile();
}/* of void */ } // of class #####################################################################

