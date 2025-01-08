
#if UNITY_IOS

using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;
using System.IO;

namespace SolarEngine
{

	public class InstallSdkInXcode
	{

		private static readonly string[] SKIP_FILES = {@".*\.meta$"};

		private static string BuildPath { get; set; }

		[PostProcessBuild]
		public static void OnPostprocessBuild(BuildTarget buildTarget, string pathToBuiltProject)
		{
			if (buildTarget == BuildTarget.iOS)
			{
				AfterBuild (pathToBuiltProject);
			}
		}

		public static void AfterBuild (string buildPath)
		{
			BuildPath = buildPath;

			if (BuildPath == null)
			{
				return;
			}

			AddFrameworks ();

			UnityEngine.Debug.Log ("Build success!");
		}

		private static void AddFrameworks ()
		{
			string projectFile = Path.Combine (BuildPath, "Unity-iPhone.xcodeproj/project.pbxproj");

			PBXProject pbxProject = new PBXProject ();
			pbxProject.ReadFromFile (projectFile);

			string target = pbxProject.TargetGuidByName ("UnityFramework");

			// ********** Frameworks ********** //
			pbxProject.AddFrameworkToProject (target, "AdServices.framework", false);
			pbxProject.AddFrameworkToProject (target, "iAd.framework", false);
			pbxProject.AddFrameworkToProject (target, "SystemConfiguration.framework", false);
			pbxProject.AddFrameworkToProject (target, "Security.framework", false);
			pbxProject.AddFrameworkToProject (target, "CoreTelephony.framework", false);
			pbxProject.AddFrameworkToProject (target, "AdSupport.framework", false);

			// pbxProject.AddFrameworkToProject (target, "AppTrackingTransparency.framework", false);

			// ********** Link Flags ********** //
			pbxProject.AddBuildProperty (target, "OTHER_LDFLAGS", "-ObjC -lz -lsqlite3 -licucore");
			pbxProject.WriteToFile (projectFile);
		}
	}

}

#endif
