using System;
using System.Collections.Generic;
using System.Linq;

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace DougKlassen.Revit.ObjExporter.Commands
{
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class Export : IExternalCommand
	{
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			TaskDialog.Show("OBJ Exporter", "running command");
			//Command code goes here

			return Result.Succeeded;
		}
	}
}
