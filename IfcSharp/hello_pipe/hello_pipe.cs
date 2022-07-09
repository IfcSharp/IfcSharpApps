// hello_pipe.cs, this software use IfcSharp (see https://github.com/IfcSharp)
class hello_pipe {static void Main(string[] args) {//#######################################################################
 #if IFC2X3
 System.Console.WriteLine("This example runs only higher than IFC2X3");
 #else

ifc.Model                   PipeModel=new ifc.Model();
                            PipeModel.Header.Name = "hello_pipe_short";
                            PipeModel.Header.ViewDefinition = @"see http://www.team-solutions.de/ifc-examples/";
                            PipeModel.Header.Author = "Bernhard Simon Bock, Friedrich Eder";
                            PipeModel.Header.Organization=@"https://github.com/IfcSharp";
                            PipeModel.Header.OriginatingSystem = "IfcSharp";
                            PipeModel.Header.Documentation = "no docs";
ifc.Repository.CurrentModel=PipeModel;

                         new ifc.EntityComment             (CommentLine     :"local coords:");
var Origin              =new ifc.CartesianPoint            (x:0,y:0,z:0,EndOfLineComment:"origin");
var DirX                =new ifc.Direction                 (x:1,y:0,z:0,EndOfLineComment:"X-axis");
                         new ifc.Direction                 (x:0,y:1,z:0,EndOfLineComment:"Y-axis (not needed)"); 
var DirZ                =new ifc.Direction                 (x:0,y:0,z:1,EndOfLineComment:"Z-axis");
var LocalCoords         =new ifc.Axis2Placement3D          (Location        :Origin,
                                                            Axis            :DirZ,
                                                            RefDirection    :DirX,
                                                            EndOfLineComment:"cartesian coordinate system"
                                                           );
                         new ifc.EntityComment             (CommentLine     :"unit-declaration:");

var LengthUnit          =new ifc.SIUnit                    (UnitType        :ifc.UnitEnum.LENGTHUNIT,
                                                            Name            :ifc.SIUnitName.METRE,
                                                            EndOfLineComment:"e.g. cartesian point coordinates"
                                                           );
var LengthUnitmm        =new ifc.SIUnit                    (UnitType        :ifc.UnitEnum.LENGTHUNIT,
                                                            Name            :ifc.SIUnitName.METRE,
                                                            Prefix          :ifc.SIPrefix.MILLI,
                                                            EndOfLineComment:"mm, e.g. nominal diameter"
                                                           );
var PlaneAngleRadUnit   =new ifc.SIUnit                    (UnitType        :ifc.UnitEnum.PLANEANGLEUNIT,
                                                            Name            :ifc.SIUnitName.RADIAN,
                                                            EndOfLineComment:"rotation angles"
                                                           );
var UnitAssignment      =new ifc.UnitAssignment            (Units           :new ifc.Set1toUnbounded_Unit(new ifc.Unit(LengthUnit), 
                                                                                                          new ifc.Unit(PlaneAngleRadUnit)
                                                                                                         )
                                                           ); 
                         new ifc.EntityComment             (CommentLine     :"ways to display:");
var GeomReprContext3D   =new ifc.GeometricRepresentationContext
                                                           (CoordinateSpaceDimension:(ifc.DimensionCount)(3),
                                                            WorldCoordinateSystem   :new ifc.Axis2Placement(LocalCoords),
                                                            ContextIdentifier       :new ifc.Label("3D body"),
                                                            ContextType             :new ifc.Label("3D-Models VR" )
                                                           );

var SubContextBody      =new ifc.GeometricRepresentationSubContext
                                                           (CoordinateSpaceDimension:(ifc.DimensionCount)(3),
                                                            WorldCoordinateSystem   :new ifc.Axis2Placement(LocalCoords),
                                                            ParentContext           :GeomReprContext3D,
                                                            TargetView              :ifc.GeometricProjectionEnum.MODEL_VIEW
                                                           );
                         new ifc.EntityComment             (CommentLine     :"assign global coords to 3D representation context:");
var Projection          =new ifc.ProjectedCRS              (Name            :new ifc.Label("EPSG:25832"), 
                                                            Description     :new ifc.Text("UTM in band 32"), 
                                                            GeodeticDatum   :new ifc.Identifier("ETRS89"), 
                                                            VerticalDatum   :new ifc.Identifier("DHHN92"), 
                                                            MapProjection   :new ifc.Identifier("UTM"), 
                                                            MapZone         :new ifc.Identifier("UTM32"), 
                                                            MapUnit         :LengthUnit);
                         new ifc.MapConversion             (SourceCRS       :new ifc.CoordinateReferenceSystemSelect(GeomReprContext3D), 
                                                            TargetCRS       :Projection, 
                                                            Eastings        :new ifc.LengthMeasure(439949), 
                                                            Northings       :new ifc.LengthMeasure(5466152), 
                                                            OrthogonalHeight:new ifc.LengthMeasure(130), 
                                                            XAxisAbscissa   :new ifc.Real(1.0), 
                                                            XAxisOrdinate   :new ifc.Real(0.0), 
                                                            Scale           :new ifc.Real(1.0), 
                                                            EndOfLineComment:"base of local coords");
                         new ifc.EntityComment             (CommentLine     :"assign contexts, units to project:");
var Project             =new ifc.Project                   (GlobalId        :null,
                                                            Name            :new ifc.Label("hello pipe project"),
                                                            RepresentationContexts:new ifc.Set1toUnbounded_RepresentationContext(GeomReprContext3D),
                                                            UnitsInContext  :UnitAssignment
                                                           );

// reinforced concrete pipe DN400 DIN V 1201-DIN EN1916-Typ 2-SB-K 3000
double d1_m=400*units.mm2m;            double t_m=75*units.mm2m;               double dg_m=694*units.mm2m;
double da_m=d1_m+2*t_m;                double dsp_m=526*units.mm2m;            double l_m=3000*units.mm2m;
double lso_m=100*units.mm2m;           double dso_m=543.8*units.mm2m;
double ri_m=d1_m/2;                    double rg_m=dg_m/2;                     double ra_m=da_m/2;
double rsp_m=dsp_m/2;                  double rso_m=dso_m/2;

                         new ifc.EntityComment             (CommentLine     :"3D-body-context LOD 300:");
var FlowSegmentPoly     =new ifc.Polyline                  (Points          :
                         new ifc.List2toUnbounded_CartesianPoint(
                         new ifc.CartesianPoint(0                ,ri_m  ," (1): x=0          , y=ri "), 
                         new ifc.CartesianPoint(0                ,rsp_m ," (2): x=0          , y=rsp"),
                         new ifc.CartesianPoint(lso_m            ,rsp_m ," (3): x=lso        , y=rsp"), //  3*(rg-ra)
                         new ifc.CartesianPoint(lso_m            ,ra_m  ," (4): x=lso        , y=ra "), // +l-lso
                         new ifc.CartesianPoint(l_m-3*(rg_m-ra_m),ra_m  ," (5): x=l-3*(rg-ra), y=ra "),
                         new ifc.CartesianPoint(l_m              ,rg_m  ," (6): x=l          , y=rg "),
                         new ifc.CartesianPoint(l_m+lso_m        ,rg_m  ," (7): x=l+lso      , y=rg "),
                         new ifc.CartesianPoint(l_m+lso_m        ,rso_m ," (8): x=l+lso      , y=rso"),
                         new ifc.CartesianPoint(l_m              ,rso_m ," (9): x=l          , y=rso"),
                         new ifc.CartesianPoint(l_m              ,ri_m  ,"(10): x=l          , y=ri "),
                         new ifc.CartesianPoint(0                ,ri_m  ,"(11)=(1)                  ")
                                                                )
                                                           );
var rpd                 =new ifc.ArbitraryClosedProfileDef (ProfileType     :ifc.ProfileTypeEnum.AREA,
                                                            OuterCurve      :FlowSegmentPoly,
                                                            EndOfLineComment:"declare poly as area"
                                                           ); 
var RevolveInsCoords    =new ifc.Axis2Placement3D          (Location        :Origin,
                                                            Axis            :DirZ,
                                                            RefDirection    :DirX,
                                                            EndOfLineComment:"revolve-plane"
                                                           );
var RevolvedPoly        =new ifc.RevolvedAreaSolid         (SweptArea       :rpd,
                                                            Position        :RevolveInsCoords,
                                                            Axis            :new ifc.Axis1Placement(Location        :Origin, 
                                                                                                    Axis            :DirX, 
                                                                                                    EndOfLineComment:"rotation axis"
                                                                                                   ),
                                                            Angle           :(ifc.PlaneAngleMeasure)(2*System.Math.PI)
                                                           );
var PipeSegmentShpRepr1 =new ifc.ShapeRepresentation       (ContextOfItems  :SubContextBody,
                                                            Items           :new ifc.Set1toUnbounded_RepresentationItem(RevolvedPoly)
                                                           );
                         new ifc.EntityComment             (CommentLine     :"product shape definition, placement and instancing:");
var PipeSegProductDefShp=new ifc.ProductDefinitionShape    (Representations :new ifc.List1toUnbounded_Representation(PipeSegmentShpRepr1));
var PipeSegmentPlacement=new ifc.LocalPlacement            (RelativePlacement:new ifc.Axis2Placement(LocalCoords));
var PipeSegment         =new ifc.PipeSegment               (GlobalId        :null,
                                                            Name            :(ifc.Label)"pipe",
                                                           _ObjectPlacement :PipeSegmentPlacement,
                                                           _Representation  :PipeSegProductDefShp
                                                           );
                         new ifc.EntityComment             (CommentLine     :"assign properties to pipe:");
var psv                 =new ifc.PropertySingleValue       (Name            :new ifc.Identifier("DN"),
                                                            NominalValue    :new ifc.Value(new ifc.Real(400)),
                                                            Unit            :new ifc.Unit(LengthUnitmm)
                                                           );
var ps1                 =new ifc.PropertySet               (Name            :new ifc.Label("pipe-properties"),
                                                            HasProperties   :new ifc.Set1toUnbounded_Property(psv)
                                                           );
                         new ifc.RelDefinesByProperties    (RelatedObjects  :new  ifc.Set1toUnbounded_ObjectDefinition(PipeSegment),
                                                            RelatingPropertyDefinition:new ifc.PropertySetDefinitionSelect(ps1)
                                                           );
                         new ifc.RelAggregates             (RelatingObject  : Project,
                                                            RelatedObjects  : new ifc.Set1toUnbounded_ObjectDefinition(PipeSegment),
                                                            EndOfLineComment:"assign elements to project:"
                                                           );
PipeModel.ToStepFile(); 
PipeModel.ToHtmlFile();
PipeModel.ToXmlFile();
//PipeModel.ToSqliteFile();
PipeModel.ToSql(ServerName: System.Environment.GetEnvironmentVariable("SqlServer"), DatabaseName:"ifcSQL",WriteMode:ifc.Model.eWriteMode.CreateNewProject); // Sql server connection required

#endif
}}//########################################################################################################################


