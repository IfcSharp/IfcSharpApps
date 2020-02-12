// hello_pipe.cs, this software use IfcSharp (see https://github.com/IfcSharp)
class hello_pipe {static void Main(string[] args) {//#######################################################################

ifc.Model                   PipeModel=new ifc.Model();
                            PipeModel.Header.name = "hello_pipe_short";
                            PipeModel.Header.description = @"see http://www.team-solutions.de/ifc-examples/";
                            PipeModel.Header.author = "Bernhard Simon Bock, Friedrich Eder";
                            PipeModel.Header.organization=@"https://github.com/IfcSharp";
                            PipeModel.Header.originating_system = "IfcSharp";
                            PipeModel.Header.documentation = "no docs";
ifc.Repository.CurrentModel=PipeModel;

new ifc.EntityComment("local coords:");ifc.ENTITY.NextGlobalId=101;
var Origin      =new ifc.CartesianPoint  (0,0,0,"origin");
var DirX        =new ifc.Direction       (1,0,0,"X-axis");
                 new ifc.Direction       (0,1,0,"Y-axis"); 
var DirZ        =new ifc.Direction       (0,0,1,"Z-axis");
var LocalCoords =new ifc.Axis2Placement3D(Origin,DirZ,DirX,"cartesian coordinate system");
//-------------------------------
new ifc.EntityComment("unit-declaration:");ifc.ENTITY.NextGlobalId=121;
var LengthUnit           =new ifc.SIUnit                         (new ifc.DimensionalExponents(1, 0, 0, 0, 0, 0, 0), ifc.UnitEnum.LENGTHUNIT,null,ifc.SIUnitName.METRE,"e.g. cartesian point coordinates");
var PlaneAngleRadianUnit =new ifc.SIUnit                         (new ifc.DimensionalExponents(0, 0, 0, 0, 0, 0, 0), ifc.UnitEnum.PLANEANGLEUNIT,null,ifc.SIUnitName.RADIAN,"rotation angles");
var UnitAssignment       =new ifc.UnitAssignment                 (new ifc.Set1toUnbounded_Unit(new ifc.Unit(LengthUnit), new ifc.Unit(PlaneAngleRadianUnit))); // ,new ifc.Unit(AreaUnit),new ifc.Unit(VolumeUnit)
//--------------------------------
new ifc.EntityComment("ways to display:");ifc.ENTITY.NextGlobalId=141;
ifc.ENTITY.NextGlobalId=142;var GeometricRepresentationContext3D   =new ifc.GeometricRepresentationContext (new ifc.Label("3D body"),new ifc.Label("3D-Models VR" ),(ifc.DimensionCount)(3),null,new ifc.Axis2Placement(LocalCoords),null);
ifc.ENTITY.NextGlobalId=145;var SubContextBody     =new ifc.GeometricRepresentationSubContext(new ifc.Label("body300") ,new ifc.Label("LOD300"),null,null,null,null,GeometricRepresentationContext3D,null,ifc.GeometricProjectionEnum.MODEL_VIEW,null);

new ifc.EntityComment("assign global coords to 3D representation context:");ifc.ENTITY.NextGlobalId=161;
var Projection = new ifc.ProjectedCRS(Name: new ifc.Label("EPSG:25832"), Description: new ifc.Text("UTM in band 32"), GeodeticDatum: new ifc.Identifier("ETRS89"), VerticalDatum: new ifc.Identifier("DHHN92"), MapProjection: new ifc.Identifier("UTM"), MapZone: new ifc.Identifier("UTM32"), MapUnit: LengthUnit);
new ifc.MapConversion(SourceCRS: new ifc.CoordinateReferenceSystemSelect(GeometricRepresentationContext3D), TargetCRS: Projection, Eastings: new ifc.LengthMeasure(439949), Northings: new ifc.LengthMeasure(5466152), OrthogonalHeight: new ifc.LengthMeasure(130), XAxisAbscissa: new ifc.Real(1.0), XAxisOrdinate: new ifc.Real(0.0), Scale: new ifc.Real(1.0), EndOfLineComment: "base of local coords");
new ifc.EntityComment("assign contexts, units to project:");ifc.ENTITY.NextGlobalId=181;
var Project   =new ifc.Project(Name:new ifc.Label("hello pipe project"),RepresentationContexts:new ifc.Set1toUnbounded_RepresentationContext(GeometricRepresentationContext3D),UnitsInContext:UnitAssignment);

//===================================================================

double d1_m=400*units.mm2m; //mm
double t_m=75*units.mm2m;//mm
double dg_m=694*units.mm2m; //Glocke
double da_m=d1_m+2*t_m;//550
double dsp_m=526*units.mm2m;
double l_m=3000*units.mm2m;
double lso_m=100*units.mm2m;
double dso_m=543.8*units.mm2m;

double ri_m=d1_m/2;
double rg_m=dg_m/2;
double ra_m=da_m/2;
double rsp_m=dsp_m/2;
double rso_m=dso_m/2;

new ifc.EntityComment("3D-body-context LOD 300:");ifc.ENTITY.NextGlobalId=201;

var FlowSegmentPoly  =new ifc.Polyline (new ifc.List2toUnbounded_CartesianPoint(
new ifc.CartesianPoint(0                    ,ri_m  ," (1): x=0              , y=ri "), 
new ifc.CartesianPoint(0                    ,rsp_m ," (2): x=0              , y=rsp"),
new ifc.CartesianPoint(lso_m                ,rsp_m ," (3): x=lso            , y=rsp"),  //  3*(rg-ra)
new ifc.CartesianPoint(lso_m                ,ra_m  ," (4): x=lso            , y=ra "), // +l-lso
new ifc.CartesianPoint(l_m-3*(rg_m-ra_m)    ,ra_m  ," (5): x=l-3*(rg-ra)    , y=ra "),
new ifc.CartesianPoint(l_m                  ,rg_m  ," (6): x=l              , y=rg "),
new ifc.CartesianPoint(l_m+lso_m            ,rg_m  ," (7): x=l+lso          , y=rg "),
new ifc.CartesianPoint(l_m+lso_m            ,rso_m ," (8): x=l+lso          , y=rso"),
new ifc.CartesianPoint(l_m                  ,rso_m ," (9): x=l              , y=rso"),
new ifc.CartesianPoint(l_m                  ,ri_m  ,"(10): x=l              , y=ri "),
new ifc.CartesianPoint(0                    ,ri_m  ,"(11)=(1)                      ")
));
var rpd=new ifc.ArbitraryClosedProfileDef(ifc.ProfileTypeEnum.AREA,null,FlowSegmentPoly,"declare poly as area"); 
var RevolveInsCoords        =new ifc.Axis2Placement3D               (/*RevolveIns*/ Origin,DirZ,DirX,"revolve-plane");
var RevolvedPoly                      =new ifc.RevolvedAreaSolid(rpd,RevolveInsCoords,new ifc.Axis1Placement(/*Revolve*/ Origin,DirX,"rotation axis"),new ifc.PlaneAngleMeasure(2*System.Math.PI),"how");
var FlowSegmentShapeRepresentation1   =new ifc.ShapeRepresentation            (SubContextBody,new ifc.Label("body300"),null,new ifc.Set1toUnbounded_RepresentationItem(RevolvedPoly),"as");

new ifc.EntityComment("product shape definition, placement and instancing:");  ifc.ENTITY.NextGlobalId=501;
var FlowSegmentProductDefinitionShape =new ifc.ProductDefinitionShape         (null,null,new ifc.List1toUnbounded_Representation(FlowSegmentShapeRepresentation1),"with");

var FlowSegmentPlacement   =new ifc.LocalPlacement                 (null,new ifc.Axis2Placement(LocalCoords /*FlowSegmentCoords*/),"where");
var FlowSegment=new ifc.FlowSegment(null,null,new ifc.Label("pipe"),null,null,FlowSegmentPlacement,FlowSegmentProductDefinitionShape,null,"what");

new ifc.EntityComment("assign properties to pipe:");ifc.ENTITY.NextGlobalId=701;
var psv=new ifc.PropertySingleValue(new ifc.Identifier("DN"),null,new ifc.Value(new ifc.Real(400)));
var ps1=new ifc.PropertySet(null,null,new ifc.Label("pipe-properties"),null,new ifc.Set1toUnbounded_Property(psv));
new ifc.RelDefinesByProperties(new  ifc.Set1toUnbounded_ObjectDefinition(FlowSegment),new ifc.PropertySetDefinitionSelect(ps1));


new ifc.EntityComment("assign elements to project:");ifc.ENTITY.NextGlobalId=901;
new ifc.RelAggregates(RelatingObject: Project,RelatedObjects: new ifc.Set1toUnbounded_ObjectDefinition(FlowSegment));


PipeModel.ToStepFile(); 
PipeModel.ToHtmlFile();
PipeModel.ToSqliteFile();
PipeModel.ToSql(ServerName: System.Environment.GetEnvironmentVariable("SqlServer"), DatabaseName:"ifcSQL_Instance",WriteMode:ifc.Model.eWriteMode.CreateNewProject); // Sql server connection required

}}//########################################################################################################################


