// hello_pipe_type.cs, this software use IfcSharp (see https://github.com/IfcSharp) 
// and Memeful Comments from visualstudio marketplace for inserting pictures into code 
class hello_pipe_type {static void Main(string[] args) {//##################################################################

 #if IFC2X3
 System.Console.WriteLine("This example runs only higher than IFC2X3");
 #else

ifc.Model                   PipeModel=new ifc.Model();
                            PipeModel.Header.name = "hello_pipe_type";
                            PipeModel.Header.description = "multiple instances of a pype type";
                            PipeModel.Header.author = "Bernhard Simon Bock, Friedrich Eder";
                            PipeModel.Header.organization=@"https://github.com/IfcSharp";
                            PipeModel.Header.originating_system = "IfcSharp";
                            PipeModel.Header.documentation = "no docs";
ifc.Repository.CurrentModel=PipeModel;


                         new ifc.EntityComment             (CommentLine     :"local coords:");
var Origin              =new ifc.CartesianPoint            (x:0,y:0,z:0,EndOfLineComment:"origin");
var DirX                =new ifc.Direction                 (x:1,y:0,z:0,EndOfLineComment:"X-axis");
var DirY                =new ifc.Direction                 (x:0,y:1,z:0,EndOfLineComment:"Y-axis"); 
var DirZ                =new ifc.Direction                 (x:0,y:0,z:1,EndOfLineComment:"Z-axis");
var LocalCoords         =new ifc.Axis2Placement3D          (Location        :Origin,
                                                            Axis            :DirZ,
                                                            RefDirection    :DirX
                                                           );
var LengthUnit          =new ifc.SIUnit                    (UnitType        :ifc.UnitEnum.LENGTHUNIT,
                                                            Name            :ifc.SIUnitName.METRE
                                                           );
var LengthUnitmm        =new ifc.SIUnit                    (UnitType        :ifc.UnitEnum.LENGTHUNIT,
                                                            Name            :ifc.SIUnitName.METRE,
                                                            Prefix          :ifc.SIPrefix.MILLI
                                                           );
var PlaneAngleRadUnit   =new ifc.SIUnit                    (UnitType        :ifc.UnitEnum.PLANEANGLEUNIT,
                                                            Name            :ifc.SIUnitName.RADIAN
                                                           );
var UnitAssignment      =new ifc.UnitAssignment            (Units           :new ifc.Set1toUnbounded_Unit(new ifc.Unit(LengthUnit), 
                                                                                                          new ifc.Unit(PlaneAngleRadUnit)
                                                                                                         )
                                                           ); 
var GeomReprContext3D   =new ifc.GeometricRepresentationContext
                                                           (CoordinateSpaceDimension:(ifc.DimensionCount)(3),
                                                            WorldCoordinateSystem   :new ifc.Axis2Placement(LocalCoords)
                                                           );
var SubContextBody      =new ifc.GeometricRepresentationSubContext
                                                           (CoordinateSpaceDimension:(ifc.DimensionCount)(3),
                                                            WorldCoordinateSystem   :new ifc.Axis2Placement(LocalCoords),
                                                            ParentContext           :GeomReprContext3D,
                                                            TargetView              :ifc.GeometricProjectionEnum.MODEL_VIEW
                                                           );
var Projection          =new ifc.ProjectedCRS              (Name            :new ifc.Label("EPSG:25832"), 
                                                            Description     :new ifc.Text("UTM in band 32"), 
                                                            GeodeticDatum   :new ifc.Identifier("ETRS89"), 
                                                            VerticalDatum   :new ifc.Identifier("DHHN92"), 
                                                            MapProjection   :new ifc.Identifier("UTM"), 
                                                            MapZone         :new ifc.Identifier("UTM32"), 
                                                            MapUnit         :LengthUnit
                                                           );
                         new ifc.MapConversion             (SourceCRS       :new ifc.CoordinateReferenceSystemSelect(GeomReprContext3D), 
                                                            TargetCRS       :Projection, 
                                                            Eastings        :new ifc.LengthMeasure(437566), 
                                                            Northings       :new ifc.LengthMeasure(5466314), 
                                                            OrthogonalHeight:new ifc.LengthMeasure(180), 
                                                            XAxisAbscissa   :new ifc.Real(1.0), 
                                                            XAxisOrdinate   :new ifc.Real(0.0), 
                                                            Scale           :new ifc.Real(1.0)
                                                           );
var Project             =new ifc.Project                   (GlobalId        :null,
                                                            Name            :new ifc.Label("hello pipe_type project"),
                                                            RepresentationContexts:new ifc.Set1toUnbounded_RepresentationContext(GeomReprContext3D),
                                                            UnitsInContext  :UnitAssignment
                                                           );
var ProjectElements     =new ifc.RelAggregates             (RelatingObject  : Project,
                                                            RelatedObjects  : new ifc.Set1toUnbounded_ObjectDefinition()  // Elements are added futher down
                                                           );

// reinforced concrete pipe DN400 DIN V 1201-DIN EN1916-Typ 2-SB-K 3000
double d1_m=400*units.mm2m;            double t_m=75*units.mm2m;               double dg_m=694*units.mm2m;
double da_m=d1_m+2*t_m;                double dsp_m=526*units.mm2m;            double l_m=3000*units.mm2m;
double lso_m=100*units.mm2m;           double dso_m=543.8*units.mm2m;
double ri_m=d1_m/2;                    double rg_m=dg_m/2;                     double ra_m=da_m/2;
double rsp_m=dsp_m/2;                  double rso_m=dso_m/2;

///<ximage url="Abbildung6.png" scale="0.75" />

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
                                                            OuterCurve      :FlowSegmentPoly
                                                           ); 
var RevolveInsCoords    =new ifc.Axis2Placement3D          (Location        :Origin,
                                                            Axis            :DirZ,
                                                            RefDirection    :DirX
                                                           );
var RevolvedPoly        =new ifc.RevolvedAreaSolid         (SweptArea       :rpd,
                                                            Position        :RevolveInsCoords,
                                                            Axis            :new ifc.Axis1Placement(Location        :Origin, 
                                                                                                    Axis            :DirX
                                                                                                   ),
                                                            Angle           :(ifc.PlaneAngleMeasure)(2*System.Math.PI+0.0001)
                                                           );
var FlowSegmentShpRepr1 =new ifc.ShapeRepresentation       (ContextOfItems  :SubContextBody,
                                                            Items           :new ifc.Set1toUnbounded_RepresentationItem(RevolvedPoly)
                                                           );


                         new ifc.EntityComment             (CommentLine     :"pipe type:");//##############################################
var psv                 =new ifc.PropertySingleValue       (Name            :new ifc.Identifier("DN"),
                                                            NominalValue    :new ifc.Value(new ifc.Real(400)),
                                                            Unit            :new ifc.Unit(LengthUnitmm)
                                                           );
var ps1                 =new ifc.PropertySet               (Name            :new ifc.Label("Diameter"),
                                                            HasProperties   :new ifc.Set1toUnbounded_Property(psv)
                                                           );

var RepresentationMap1  =new ifc.RepresentationMap         (MappingOrigin   :new ifc.Axis2Placement(LocalCoords),
                                                            MappedRepresentation:FlowSegmentShpRepr1
                                                           );

var PipeSegmentType     =new ifc.PipeSegmentType           (Name            :new ifc.Label("## 1: pipe"),
                                                            HasPropertySets :new ifc.Set1toUnbounded_PropertySetDefinition(ps1), // not ifc.RelDefinesByProperties 
                                               #if (IFC4X2) 
                                                            RepresentationMaps:new ifc.List1toUnbounded_RepresentationMap(RepresentationMap1), 
                                               #else
                                                            RepresentationMaps:new ifc.List1toUnboundedUnique_RepresentationMap(RepresentationMap1),
                                               #endif
                                                            PredefinedType  :ifc.PipeSegmentTypeEnum.USERDEFINED
                                                           );



// Container for InstanceAssigment of the Type (not the representation!)
var RelDefByPsType1     =new ifc.RelDefinesByType          (RelatedObjects  :new ifc.Set1toUnbounded_Object(), // Elements are added futher down
                                                            RelatingType    :PipeSegmentType
                                                           );

var From=new ifc.DistributionPort(GlobalId:null,_ObjectPlacement:new ifc.LocalPlacement(new ifc.Axis2Placement(LocalCoords)), FlowDirection: ifc.FlowDirectionEnum.SOURCE,PredefinedType:ifc.DistributionPortTypeEnum.PIPE,SystemType:ifc.DistributionSystemEnum.DRAINAGE);
var From2FlowSegment=new ifc.RelNests(PipeSegmentType, new ifc.List1toUnbounded_ObjectDefinition(From));
RelDefByPsType1.RelatedObjects.Add(From);



// Graphic Representation:
var TransformOperator3D =new ifc.CartesianTransformationOperator3DnonUniform // insert, scaling and alignment of the type-definition
                                                           (LocalOrigin     :Origin); /* Origin.Add(0,0,0), // not scaled //Scale: new ifc.Real(1),    //Axis1:DirY,Axis2:DirZ,Axis3:DirX, */ 
var MappedItem1         =new ifc.MappedItem                (MappingSource:RepresentationMap1,MappingTarget:TransformOperator3D);
var ShapeRepresentation1=new ifc.ShapeRepresentation       (ContextOfItems  :GeomReprContext3D,Items:new ifc.Set1toUnbounded_RepresentationItem(MappedItem1));
var PipeSegmentPdefShp1 =new ifc.ProductDefinitionShape    (Representations :new ifc.List1toUnbounded_Representation(ShapeRepresentation1));


///<image url="https://standards.buildingsmart.org/IFC/DEV/IFC4_2/FINAL/HTML/figures/ifcelementcomponent_multiple.png" scale="0.6" />
///<image url="https://standards.buildingsmart.org/IFC/DEV/IFC4_2/FINAL/HTML/figures/ifcreldefinesbytype_fig-1.png" scale="0.6" />
///<image url="https://standards.buildingsmart.org/IFC/DEV/IFC4_2/FINAL/HTML/figures/examples/mapped_shape_multiple-1.png" scale="0.1" />
///<image url="https://standards.buildingsmart.org/IFC/DEV/IFC4_2/FINAL/HTML/figures/ifcreldefinesbyobject_fig-1.png" scale="0.6" />
///<image url="https://standards.buildingsmart.org/IFC/DEV/IFC4_2/FINAL/HTML/figures/ifcreldefinesbyobject_fig-2.png" scale="0.6" />
///<image url="https://standards.buildingsmart.org/IFC/DEV/IFC4_2/FINAL/HTML/figures/ifcpropertysettemplate_fig-1.png" scale="0.6" />
///<image url="https://standards.buildingsmart.org/IFC/DEV/IFC4_2/FINAL/HTML/figures/ifcdistributioncontrolelement-classification.png" scale="0.5" />
///<image url="https://standards.buildingsmart.org/IFC/DEV/IFC4_2/FINAL/HTML/figures/ifcdistributionport-connection.png" scale="0.5" />
///<image url="https://standards.buildingsmart.org/IFC/DEV/IFC4_2/FINAL/HTML/figures/ifcdistributionsystem-01.png" scale="0.6" />
///<image url="https://standards.buildingsmart.org/IFC/DEV/IFC4_2/FINAL/HTML/figures/ifcsimplepropertytemplate_fig-1.png" scale="1.0" />




var InsertDist1=1.0; // First insert dist
///<ximage url="pipe_instances.png" scale="1.0" /> // result with ifc++-viewer:

                         new ifc.EntityComment             (CommentLine     :"Instance 1");//##############################################
var InsertOrigin1       =new ifc.CartesianPoint            (x:InsertDist1,y:0,z:0);
var InsertCoords1       =new ifc.Axis2Placement3D          (Location        :InsertOrigin1, 
                                                            Axis            :DirZ,
                                                            RefDirection    :DirX
                                                           );
var InsertPlacement1    =new ifc.LocalPlacement            (RelativePlacement:new ifc.Axis2Placement(InsertCoords1));
var PipeSegment1        =new ifc.PipeSegment               (GlobalId        :null,
                                                           _ObjectPlacement :InsertPlacement1,
                                                           _Representation  :PipeSegmentPdefShp1
                                                           );
RelDefByPsType1.RelatedObjects.Add(PipeSegment1);// assign instance to type
ProjectElements.RelatedObjects.Add(PipeSegment1);// assign instance to project ############################################################



                         new ifc.EntityComment             (CommentLine     :"Instance 2");//##############################################
var PipeSegment2        =new ifc.PipeSegment               (GlobalId        :ifc.GloballyUniqueId.NewId(),
                                                           _ObjectPlacement :new ifc.LocalPlacement (RelativePlacement:new ifc.Axis2Placement(InsertCoords1.Clone(InsertCoords1.Location.Add(x:l_m,y:0,z:0)))),
                                                           _Representation  :PipeSegmentPdefShp1 //xx
                                                           );
RelDefByPsType1.RelatedObjects.Add(PipeSegment2);// assign instance to type
ProjectElements.RelatedObjects.Add(PipeSegment2);// assign instance to project ############################################################

var To=new ifc.DistributionPort(GlobalId:null,_ObjectPlacement:new ifc.LocalPlacement(new ifc.Axis2Placement(LocalCoords)), FlowDirection: ifc.FlowDirectionEnum.SOURCE,PredefinedType:ifc.DistributionPortTypeEnum.PIPE,SystemType:ifc.DistributionSystemEnum.DRAINAGE);
var To2FlowSegment=new ifc.RelConnectsPortToElement(From,PipeSegment2);

var From2FlowSegmentc=new ifc.RelNests(PipeSegment2, new ifc.List1toUnbounded_ObjectDefinition(From));



// representaions: line, cylinder, full type, full type withs voids and assemblies

// assemblies
// TypeInformation: PipeSegmentType (geometry(s),type-properties,Type, ports-templates with location)
// Instance: Placement (location and alignment, also linearPlacement) , instance-Ports, Instance-properties
// Project: Cennections
// system assignemt (drainage System, catchment area -> also possible via properties


//new ifc.LinearPlacement
/*
var From=new ifc.DistributionPort(GlobalId:null,_ObjectPlacement: FromPlacement,FlowDirection: ifc.FlowDirectionEnum.SOURCE,PredefinedType:ifc.DistributionPortTypeEnum.PIPE,SystemType:ifc.DistributionSystemEnum.DRAINAGE);
BuildingElements.RelatedObjects.Add(From);
var From2FlowSegment=new ifc.RelConnectsPortToElement(From,FlowSegment);
*/
//ifc.RelConnectsPorts                ConnectPort1and2=new ifc.RelConnectsPorts(ifc.GloballyUniqueId.NewId(),OwnerHistory,new ifc.Label("VN"),new ifc.Text("KN1 to KN2"),FlowFittingDistributionPort1,FlowFittingDistributionPort2,null);



// hier noch Konnektiviät und versch. LODs, sowie 2D+3D, ggf. Ausgabe als AcadScr
// durchgängiges Besipiel mit Schächten, Haltungen udn Anschlussleitungen, auch mit Ausparungen im Rohr

PipeModel.ToStepFile(); 
PipeModel.ToHtmlFile();

#endif // IFC2X3

}}//########################################################################################################################


