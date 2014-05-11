using UnityEngine;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;

[InitializeOnLoad]
#endif
public class SoomSettings : ScriptableObject
{
	public static string AND_PUB_KEY_DEFAULT = "YOUR GOOGLE PLAY PUBLIC KEY";
	public static string ONLY_ONCE_DEFAULT = "SET ONLY ONCE";

	const string soomSettingsAssetName = "SoomSettings";
	const string soomSettingsPath = "Soomla/Resources";
	const string soomSettingsAssetExtension = ".asset";

	private static SoomSettings instance;

	static SoomSettings Instance
    {
        get
        {
            if (instance == null)
            {
				instance = Resources.Load(soomSettingsAssetName) as SoomSettings;
                if (instance == null)
                {
                    // If not found, autocreate the asset object.
					instance = CreateInstance<SoomSettings>();
#if UNITY_EDITOR
                    string properPath = Path.Combine(Application.dataPath, soomSettingsPath);
                    if (!Directory.Exists(properPath))
                    {
                        AssetDatabase.CreateFolder("Assets/Soomla", "Resources");
                    }

                    string fullPath = Path.Combine(Path.Combine("Assets", soomSettingsPath),
                                                   soomSettingsAssetName + soomSettingsAssetExtension
                                                  );
                    AssetDatabase.CreateAsset(instance, fullPath);
#endif
                }
            }
            return instance;
        }
    }

#if UNITY_EDITOR
	[MenuItem("Soomla/Edit Settings")]
    public static void Edit()
    {
        Selection.activeObject = Instance;
    }

	[MenuItem("Soomla/Framework Page")]
    public static void OpenFramework()
    {
        string url = "https://www.github.com/soomla/unity3d-store";
        Application.OpenURL(url);
    }

	[MenuItem("Soomla/SDK Documentation")]
    public static void OpenDocumentation()
    {
        string url = "https://soom.la/docs";
        Application.OpenURL(url);
    }
	[MenuItem("Soomla/Soombots")]
    public static void OpenSoombots()
    {
		string url = "http://soom.la/soombots";
        Application.OpenURL(url);
    }

	[MenuItem("Soomla/Blog")]
	public static void OpenBlog()
	{
		string url = "http://blog.soom.la";
		Application.OpenURL(url);
	}

	[MenuItem("Soomla/Report an issue")]
    public static void ReportIssue()
    {
		string url = "https://mail.google.com/mail/?view=cm&fs=1&tf=1&to=support@soom.la&su=Issue%20report%20-%20SOOMLA%20%26%20Unity";
//		string url = "http://mailto:support@soom.la";
        Application.OpenURL(url);
    }
#endif
	

    [SerializeField]
    private bool iosSSV = false;
	[SerializeField]
	private string androidPublicKey = AND_PUB_KEY_DEFAULT;
    [SerializeField]
	private string customSecret = ONLY_ONCE_DEFAULT;
    [SerializeField]
	private string soomSec = ONLY_ONCE_DEFAULT;
    [SerializeField]
	private string masterKey = "YOUR MASTER KEY (from the dashboard)";


	public static string CustomSecret
	{
		get { return Instance.customSecret; }
		set 
		{
			if (Instance.customSecret != value)
			{
				Instance.customSecret = value;
				DirtyEditor ();
			}
		}
	}

	public static string SoomSecret
	{
		get { return Instance.soomSec; }
		set 
		{
			if (Instance.soomSec != value)
			{
				if (string.IsNullOrEmpty(value)) {

				} else {
					Instance.soomSec = value;
				}
				DirtyEditor ();
			}
		}
	}

	public static string MasterKey
	{
		get { return Instance.masterKey; }
		set 
		{
			if (Instance.masterKey != value)
			{
				Instance.masterKey = value;
				DirtyEditor ();
			}
		}
	}

	public static string AndroidPublicKey
	{
		get { return Instance.androidPublicKey; }
		set 
		{
			if (Instance.androidPublicKey != value)
			{
				Instance.androidPublicKey = value;
				DirtyEditor ();
			}
		}
	}

	public static bool IosSSV
	{
		get { return Instance.iosSSV; }
		set
		{
			if (Instance.iosSSV != value)
            {
				Instance.iosSSV = value;
				DirtyEditor();
            }
        }
    }

//    public static bool Logging
//    {
//        get { return Instance.logging; }
//        set
//        {
//            if (Instance.logging != value)
//            {
//                Instance.logging = value;
//                DirtyEditor();
//            }
//        }
//    }




    private static void DirtyEditor()
    {
#if UNITY_EDITOR
        EditorUtility.SetDirty(Instance);
#endif
    }

}
