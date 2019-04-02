using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using MyFramework.Core.Aspects.Postsharp.ExceptionAspects;
using MyFramework.Core.Aspects.Postsharp.LogAspects;
using MyFramework.Core.Aspects.Postsharp.PerformanceAspects;
using MyFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Logger;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("MyFramework.Business")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("MyFramework.Business")]
[assembly: AssemblyCopyright("Copyright ©  2019")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: LogAspect(typeof(FileLogger), AttributeTargetTypes = "MyFramework.Business.Concrete.Managers.*")]
[assembly: LogAspect(typeof(DatabaseLogger), AttributeTargetTypes = "MyFramework.Business.Concrete.Managers.*")]
[assembly: ExceptionLogAspect(typeof(DatabaseLogger), AttributeTargetTypes = "MyFramework.Business.Concrete.Managers.*")]
[assembly: ExceptionLogAspect(typeof(FileLogger), AttributeTargetTypes = "MyFramework.Business.Concrete.Managers.*")]
[assembly: PerformanceCounterAspect(6, AttributeTargetTypes = "MyFramework.Business.Concrete.Managers.*")]
//[assembly: PerformanceCounterAspect(6, AttributeTargetTypes = "DevFramework.Northwind.Business.Concrete.Managers.*")]
// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("dbbaf299-d5bd-4090-a07e-268f726579a0")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
