using System;
using System.Collections.Generic;
using System.Linq;

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

using RevitOBJExport;

namespace DougKlassen.Revit.ObjExporter.Commands
{
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class Export : IExternalCommand
	{
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			Document dbDoc = commandData.Application.ActiveUIDocument.Document;
			View3D exportView = dbDoc.ActiveView as View3D;

			if (exportView == null)
			{
				TaskDialog.Show("Error", "Active view must be a 3D view");
				return Result.Failed;
			}

			String resultString = Main.ExportView3D(
				dbDoc, //Revit document
				exportView,	//View3D to be exported
				"C:\\objexport\\test.obj",	//file path for export including filename
				1,	//ouput units, feet = 1
				1,	//rotation - ProjectNorth = 1, TrueNorth = 2
				15,	//LOD 0-15 (8 is default)
				true,	//YZ flipped
				false,	//group elements
				false,	//selected elements only
				true,	//add materials
				true,	//add textures
				true,	//replace spaces in material names
				1,	//texture scale
				"textures",	//texture directory
				1,	//label type - by material = 1, by name = 2
				1,	//label Id position - none = 1, before = 2, after = 3
				1);	//tag OBJ character = o = 1, g = 2

			TaskDialog.Show("OBJ Export Result", resultString);

			return Result.Succeeded;
		}
	}
}
