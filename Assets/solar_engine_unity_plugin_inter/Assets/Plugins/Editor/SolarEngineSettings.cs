
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System.IO;


namespace SolarEngine
{

	#if UNITY_EDITOR
    [InitializeOnLoad]
	#endif
    public class SolarEngineSettings : ScriptableObject
	{
		private const string ASSET_NAME = "SolarEngineSettings";
		private const string ASSET_PATH = "SolarEngineSDK/Editor/Resources";
		private const string ASSET_EXT = ".asset";

		private static SolarEngineSettings instance;

		[SerializeField]
		private string _iOSUrlIdentifier;
		[SerializeField]
		private string[] _iOSUrlSchemes = new string[0];
		[SerializeField]
		private string[] _iOSUniversalLinksDomains = new string[0];

		private static SolarEngineSettings Instance
	    {
	        get
	        {
	            if (instance == null)
	            {
					instance = Resources.Load(ASSET_NAME) as SolarEngineSettings;
	                if (instance == null)
	                {
	                    // If not found, autocreate the asset object.
	                    instance = ScriptableObject.CreateInstance<SolarEngineSettings>();
	                    #if UNITY_EDITOR
	                    string properPath = Path.Combine(Application.dataPath, ASSET_PATH);
	                    if (!Directory.Exists(properPath))
	                    {
	                        Directory.CreateDirectory(properPath);
	                    }

	                    string fullPath = Path.Combine(Path.Combine("Assets", ASSET_PATH), ASSET_NAME + ASSET_EXT);
	                    AssetDatabase.CreateAsset(instance, fullPath);
	                    #endif
	                }
				}

	            return instance;
	        }
	    }

		public static string iOSUrlIdentifier
		{
			get { return Instance._iOSUrlIdentifier; }
			set { Instance._iOSUrlIdentifier = value; }
		}

		public static string[] iOSUrlSchemes
		{
			get { return Instance._iOSUrlSchemes; }
			set { Instance._iOSUrlSchemes = value; }
		}

		public static string[] iOSUniversalLinksDomains
		{
			get { return Instance._iOSUniversalLinksDomains; }
			set { Instance._iOSUniversalLinksDomains = value; }
		}

		#if UNITY_EDITOR
		[MenuItem("SolarEngineSDK/Edit Settings", false, 0)]
	    public static void EditSettings ()
	    {
	        Selection.activeObject = Instance;
	    }
		#endif

	}

}
