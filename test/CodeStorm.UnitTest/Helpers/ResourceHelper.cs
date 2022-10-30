using System;
using System.IO;
using System.Linq;

namespace CodeStorm.UnitTest.Helpers;

public class ResourceHelper
{
    public static string GetResourceDirectory()
    {
        var debug = Directory.GetParent(Directory.GetCurrentDirectory());
        if (debug is null) throw new Exception("Project debug folder is not found");

        var bin = debug.Parent;
        if (bin is null) throw new Exception("Project bin folder is not found");

        var app = bin.Parent;
        if (app is null) throw new Exception("Project app folder is not found");

        var src = app.Parent;
        if (src is null) throw new Exception("Project src folder is not found");

        var project = src.Parent;
        if (project is null) throw new Exception("Project folder is not found");

        var assets = project.GetDirectories().FirstOrDefault(dir => dir.Name == "assets");
        if (assets is null) throw new Exception("Project assets folder is not found");
        else return assets.FullName;
    }

    public static string GetProblemSetDirectory()
    {
        var resourceFolder = GetResourceDirectory();
        var directoryInfo = new DirectoryInfo(resourceFolder).GetDirectories()
            .FirstOrDefault(dir => dir.Name == "problemsets");
        if (directoryInfo is null) throw new Exception("Project->assets->problemsets folder is not found");
        else return directoryInfo.FullName;
    }

    public static string GetSourceCodesDirectory()
    {
        var resourceFolder = GetResourceDirectory();
        var directoryInfo = new DirectoryInfo(resourceFolder).GetDirectories()
            .FirstOrDefault(dir => dir.Name == "codes");
        if (directoryInfo is null) throw new Exception("Project->assets->codes folder is not found");
        else return directoryInfo.FullName;
    }

    public static string GetTemporaryDirectory()
    {
        var resourceFolder = GetResourceDirectory();
        var directoryInfo = new DirectoryInfo(resourceFolder).GetDirectories()
            .FirstOrDefault(dir => dir.Name == "temporaryfiles");
        if (directoryInfo is null) throw new Exception("Project->assets->temporaryfiles folder is not found");
        else return directoryInfo.FullName;
    }
}
