using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class SetIcon
{
    static SetIcon()
    {
        string iconPath = "Assets/Images/pong-logo.png";
        Texture2D icon = AssetDatabase.LoadAssetAtPath(iconPath, typeof(Texture2D)) as Texture2D;

        if (icon != null)
        {
            PlayerSettings.SetIconsForTargetGroup(BuildTargetGroup.Standalone, new Texture2D[] { icon });
        }
    }
}