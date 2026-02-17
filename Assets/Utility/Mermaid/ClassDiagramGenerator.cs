#if UNITY_EDITOR
using System.IO;
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;

public class MermaidClassDiagramFileWindow : EditorWindow
{
    string fullClassDiagramPath = "Assets/";
    string fullClassDiagramPathKey = "MyProjectClassDiagramPath";

    string scriptsFolderPathPath = "Assets/Scripts/";
    string scriptsFolderPathKey = "MyScriptsFolderPath";

    private void OnEnable()
    {
        fullClassDiagramPath = EditorPrefs.GetString(fullClassDiagramPathKey, "Assets");
        scriptsFolderPathPath = EditorPrefs.GetString(scriptsFolderPathKey, "Assets/Scripts");
    }

    [MenuItem("Tools/Mermaid Class Diagram File Window")]
    public static void ShowWindow()
    {
        //Show existing window instance. If one doesn't exist, make one.
        GetWindow(typeof(MermaidClassDiagramFileWindow));
    }

    private void OnGUI()
    {
        GUILayout.Label("Create Class Diagrams to all scripts", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        fullClassDiagramPath = EditorGUILayout.TextField("Diagram Path", fullClassDiagramPath);
        scriptsFolderPathPath = EditorGUILayout.TextField("Scripts Path", scriptsFolderPathPath);

        EditorGUILayout.Space();
        if (GUILayout.Button("Generate Full Class Diagram")) GenerateFullProjectClassDiagram();
        if (GUILayout.Button("Generate Class Diagram for Scripts in Folder")) GenerateClassDiagramForScripts();

        EditorPrefs.SetString(fullClassDiagramPathKey, fullClassDiagramPath);
        EditorPrefs.SetString(scriptsFolderPathKey, scriptsFolderPathPath);
    }

    public void GenerateFullProjectClassDiagram()
    {
    }

    public void GenerateClassDiagramForScripts()
    {
        string[] scriptsPath = ProjectScripts();
        List<string> diagramsPath = ProjectMermaidDiagrams().ToList();

        for (int i = 0; i < scriptsPath.Length; i++)
        {
            string scriptName = Path.GetFileNameWithoutExtension(scriptsPath[i]);
            if (diagramsPath.Exists(path => path.EndsWith($"{scriptName}_Diagram.mmd"))) continue;

            string folderDirectory = Path.GetFullPath(Path.GetDirectoryName(scriptsPath[i]));
            Debug.Log($"{folderDirectory} + {scriptName}");
            using (StreamWriter sw = File.CreateText(folderDirectory + $"/{scriptName}_Diagram.mmd"))
            {
                sw.WriteLine("classDiagram");
                sw.WriteLine("class " + scriptName + " {");
                sw.WriteLine("}");
            }

            AssetDatabase.Refresh();
        }
    }

    public string[] ProjectScripts()
    {
        return Directory.GetFiles($"{Application.dataPath}/{scriptsFolderPathPath}", "*.cs", SearchOption.AllDirectories);
    }

    public string[] ProjectMermaidDiagrams()
    {
        return Directory.GetFiles($"{Application.dataPath}/{scriptsFolderPathPath}", "*.mmd", SearchOption.AllDirectories);
    }
}
#endif