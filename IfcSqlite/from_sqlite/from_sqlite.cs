// from_sqlite.cs, this software use IfcSharp (see https://github.com/IfcSharp)
using System;

namespace ifc
{
    class from_sqlite
    {
        static void Main(string[] args)
        {
            Model m = ifc.Model.FromSqliteFile("../../hello_pipe_short.sqlite");
            m.Header.name = "hello_pipe_short_FROM_SQLITE";
            m.ToSqliteFile();
            m.ToHtmlFile();
            m.ToStepFile();
        }
    }
}
