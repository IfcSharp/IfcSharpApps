echo ^<?xml version="1.0" encoding="utf-8"?^> > IfcSpecification.csproj
echo ^<Project ToolsVersion="4.0" DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003"^> >> IfcSpecification.csproj
echo   ^<PropertyGroup^> >> IfcSpecification.csproj
echo     ^<IfcSpecification^>%1^</IfcSpecification^> >> IfcSpecification.csproj
echo     ^<DefineConstants^>$(DefineConstants);$(IfcSpecification)^</DefineConstants^> >> IfcSpecification.csproj
echo   ^</PropertyGroup^> >> IfcSpecification.csproj
echo ^</Project^> >> IfcSpecification.csproj