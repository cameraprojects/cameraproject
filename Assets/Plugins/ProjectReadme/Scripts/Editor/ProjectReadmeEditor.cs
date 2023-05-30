using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ProjectReadme))]
[InitializeOnLoad]
public class ProjectReadmeEditor : Editor
{
    private static string _showedReadmeSessionStateName = "MyReadmeEditor.showedReadme";

    private const float SPACE = 16f;

    static ProjectReadmeEditor()
    {
        EditorApplication.delayCall += SelectReadmeAutomatically;
    }

    private static void SelectReadmeAutomatically()
    {
        if(!SessionState.GetBool(_showedReadmeSessionStateName, false))
        {
            SelectReadme();
            SessionState.SetBool(_showedReadmeSessionStateName, true);
        }
    }

    [MenuItem("Help/Project Readme")]
    private static void SelectReadme()
    {
        var ids = AssetDatabase.FindAssets("Readme t:ProjectReadme");
        if(ids.Length == 1)
        {
            var readmeObject = AssetDatabase.LoadMainAssetAtPath(AssetDatabase.GUIDToAssetPath(ids[0]));
            Selection.objects = new UnityEngine.Object[] { readmeObject };
        }
        else
        {
            Debug.Log("Couldn't find a readme asset");
        }
    }

    protected override void OnHeaderGUI()
    {
        var readme = (ProjectReadme)target;
        Init();

        GUILayout.BeginHorizontal("In BigTitle");
        {
            // アイコン
            if(readme.header.icon != null)
            {
                GUILayout.Space(SPACE);
                var iconWidth = Mathf.Min(EditorGUIUtility.currentViewWidth / 3f - 20f, 128f);
                GUILayout.FlexibleSpace();
                GUILayout.BeginVertical();
                {
                    GUILayout.FlexibleSpace();
                    GUILayout.Label(readme.header.icon, GUILayout.Width(iconWidth), GUILayout.Height(iconWidth));
                    GUILayout.FlexibleSpace();
                }
                GUILayout.EndVertical();
            }

            // タイトル
            if (!string.IsNullOrEmpty(readme.header.title))
            {
                GUILayout.Space(SPACE);
                GUILayout.BeginVertical();
                {
                    GUILayout.FlexibleSpace();
                    GUILayout.Label(readme.header.title, TitleStyle);
                    GUILayout.FlexibleSpace();
                }
                GUILayout.EndVertical();
            }
            GUILayout.FlexibleSpace();
            GUILayout.Space(SPACE);
        }
        GUILayout.EndHorizontal();
    }

    public override void OnInspectorGUI()
    {
        var readme = (ProjectReadme)target;
        Init();

        // プロジェクト説明
        GUILayout.Space(5);
        GUILayout.Label(readme.intro.heading, HeadingStyle);
        GUILayout.Space(SPACE);
        GUILayout.Label(readme.intro.text, BodyStyle);
        GUILayout.Space(SPACE);

        DrawHorizontalGUILine();

        // メンバー紹介
        GUILayout.Label("メンバー", HeadingStyle);
        var iconWidth = Mathf.Min(EditorGUIUtility.currentViewWidth / 4f - 20f, 64f);
        foreach (var member in readme.members)
        {
            GUILayout.Space(SPACE);
            GUILayout.BeginHorizontal();
            {
                if(member.icon != null)
                {
                    GUILayout.Space(SPACE);
                    GUILayout.Label(member.icon, GUILayout.Width(iconWidth), GUILayout.Height(iconWidth));
                }
                GUILayout.Space(SPACE);
                GUILayout.BeginVertical();
                {
                    GUILayout.Label(member.name, HeadingStyle);
                    GUILayout.Label(member.text, BodyStyle);
                }
                GUILayout.EndVertical();
            }
            GUILayout.EndHorizontal();
        }
    }

    private static void DrawHorizontalGUILine(int height = 1)
    {
        GUILayout.Space(4);

        Rect rect = GUILayoutUtility.GetRect(10, height, GUILayout.ExpandWidth(true));
        rect.height = height;
        rect.xMin = 0;
        rect.xMax = EditorGUIUtility.currentViewWidth;

        Color lineColor = new Color(0.10196f, 0.10196f, 0.10196f, 1);
        EditorGUI.DrawRect(rect, lineColor);
        GUILayout.Space(4);
    }

    private bool _initialized;

    [SerializeField] 
    private GUIStyle _titleStyle;
    private GUIStyle TitleStyle { get { return _titleStyle; } }

    [SerializeField] 
    private GUIStyle _headingStyle;
    private GUIStyle HeadingStyle { get { return _headingStyle; } }

    [SerializeField] 
    private GUIStyle _bodyStyle;
    private GUIStyle BodyStyle { get { return _bodyStyle; } }

    private void Init()
    {
        if (_initialized) return;

        _bodyStyle = new GUIStyle(EditorStyles.label);
        _bodyStyle.wordWrap = true;
        _bodyStyle.richText = true;
        _bodyStyle.fontSize = 14;

        _titleStyle = new GUIStyle(_bodyStyle);
        _titleStyle.fontSize = 26;
        _titleStyle.fontStyle = FontStyle.Bold;

        _headingStyle = new GUIStyle(_bodyStyle);
        _headingStyle.fontSize = 18;
        _headingStyle.fontStyle = FontStyle.Bold;

        _initialized = true;
    }
}
