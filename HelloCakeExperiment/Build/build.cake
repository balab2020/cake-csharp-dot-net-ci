#tool nuget:?package=NUnit.ConsoleRunner&version=3.4.0
var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

// Define directories.
var buildDir = Directory("../bin/") + Directory(configuration);
var solutionFullPath = "../HelloCakeExperiment.sln";
//clean build directory
Task("Clean").Does(()=>{CleanDirectory(buildDir);});

//nuget restore
Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() =>{NuGetRestore(solutionFullPath);});

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
    {
        if(IsRunningOnWindows())
        {
          // Use MSBuild
          MSBuild(solutionFullPath, settings =>
            settings.SetConfiguration(configuration));
        }
        else
        {
          Information("Build only supported in windows environment");      
        }
    });


Task("Run-Unit-Tests")
    .IsDependentOn("Build")
    .Does(() =>
{
    NUnit3("../bin/" + configuration + "/*.Tests.dll", new NUnit3Settings  {
       NoResults = true
    });
});

Task("Default").IsDependentOn("Run-Unit-Tests");

RunTarget(target);