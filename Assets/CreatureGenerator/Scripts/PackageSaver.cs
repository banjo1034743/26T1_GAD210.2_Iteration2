//using UnityEngine;
//using System;
//using System.Collections.Generic;

//// See https://docs.unity3d.com/Manual/PlatformDependentCompilation.html
//#if UNITY_EDITOR
//using UnityEditor;
//using UnityEditor.PackageManager;
//using UnityEditor.Compilation;
//#endif

//public class PackageSaver : ScriptableObject
//{
//    // See https://docs.unity3d.com/ScriptReference/HideInInspector.html
//    [HideInInspector] public string Version;

//    #if UNITY_EDITOR
//    // Called automatically after open Unity and each recompilation
//    // See https://docs.unity3d.com/ScriptReference/InitializeOnLoadMethodAttribute.html
//    [InitializeOnLoadMethod]
//    private static void Init()
//    {
//        // See https://docs.unity3d.com/ScriptReference/Compilation.CompilationPipeline-compilationFinished.html
//        // Removing the callback before adding it makes sure it is only added once at a time
//        CompilationPipeline.compilationFinished -= OnCompilationFinished;
//        CompilationPipeline.compilationFinished += OnCompilationFinished;
//    }

//    private static void OnCompilationFinished(object context)
//    {
//        // First get the path of the Package
//        // This is quite easy since this script itself belongs to your package's assemblies
//        var assembly = typeof(PackageSaver).Assembly;

//        // See https://docs.unity3d.com/ScriptReference/PackageManager.PackageInfo.FindForAssembly.html
//        var packageInfo = PackageManager.PackageInfo.FindForAssembly();

//        // Finally we have access to the version!
//        var version = packageInfo.version;

//        // Now to the ScriptableObject instance
//        // Try to find the first instance
//        // See https://docs.unity3d.com/ScriptReference/AssetDatabase.FindAssets.html
//        // See https://docs.unity3d.com/ScriptReference/PackageManager.PackageInfo-assetPath.html
//        var guid = AssetDataBase.FindAssets($"t:{nameof(PackageSaver)}", packageInfo.assetPath).FirstOrDefault();

//        PackageSaver asset;

//        if (!string.isNullOrWhiteSpace(guid))
//        {
//            // See https://docs.unity3d.com/ScriptReference/AssetDatabase.GUIDToAssetPath.html
//            var path = AssetDatabase.GUIDToAssetPath(guid);
//            // See https://docs.unity3d.com/ScriptReference/AssetDatabase.LoadAssetAtPath.html
//            asset = AssetDatabase.LoadAssetAtPath<PackageSaver>(path);
//        }
//        else
//        {

//            // None found -> create a new one
//            asset = ScriptableObject.CreateInstance<PackageSaver>();
//            asset.name = nameof(PackageSaver);
//            // make it non editable via the Inspector
//            // See https://docs.unity3d.com/ScriptReference/HideFlags.NotEditable.html
//            asset.hideFlags = HideFlags.NotEditable;

//            // Store the asset as actually asset
//            // See https://docs.unity3d.com/ScriptReference/AssetDatabase.CreateAsset.html
//            AssetDataBase.CreateAsset(asset, $"{packageInfo.assetPath}/{nameof(PackageSaver)}");
//        }

//        asset.Version = version;

//        // See https://docs.unity3d.com/ScriptReference/EditorUtility.SetDirty.html
//        EditorUtility.SetDirty(asset);
//    }
//#endif
//}
