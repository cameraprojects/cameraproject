/*
 * ロード時に、Inspectorに自動表示されるReadmeアセット作成用ScriptableObject
 * 
 * 作成したReadmeアセットの編集は、Inspectorウィンドウ右上の縦三点リーダーをクリックし、
 * 表示モードをNormalからDebugにすることで可能になります。
 * 
 * ProjectReadme.csおよびProjectReadmeEditor.csは、UnityのURPやHDRPテンプレート作成時に同梱されている
 * TutorialInfoアセットを参考に作成しました。プロジェクトの用途に合わせて、自由に書き換えてください。
 * 
 * 2023.3.10 作田遼太郎
 */
using System;
using UnityEngine;

// 18行目のコメントアウトを解除することで、
// CreateからProjectReadmeアセットを作成できるようになります。
// 作成後は邪魔なので、再度コメントアウト推奨。
[CreateAssetMenu]
public class ProjectReadme : ScriptableObject
{
    public Header header;
    public Intro intro;
    public Member[] members;
    public bool autoSelectOnLoad;

    [Serializable]
    public class Header
    {
        public Texture2D icon;
        public string title;
    }
    
    [Serializable]
    public class Intro
    {
        public string heading;
        public string text;
    }

    [Serializable]
    public class Member
    {
        public Texture2D icon;
        public string name;
        public string text;
    }
}
