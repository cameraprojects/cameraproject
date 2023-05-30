/*
 * ���[�h���ɁAInspector�Ɏ����\�������Readme�A�Z�b�g�쐬�pScriptableObject
 * 
 * �쐬����Readme�A�Z�b�g�̕ҏW�́AInspector�E�B���h�E�E��̏c�O�_���[�_�[���N���b�N���A
 * �\�����[�h��Normal����Debug�ɂ��邱�Ƃŉ\�ɂȂ�܂��B
 * 
 * ProjectReadme.cs�����ProjectReadmeEditor.cs�́AUnity��URP��HDRP�e���v���[�g�쐬���ɓ�������Ă���
 * TutorialInfo�A�Z�b�g���Q�l�ɍ쐬���܂����B�v���W�F�N�g�̗p�r�ɍ��킹�āA���R�ɏ��������Ă��������B
 * 
 * 2023.3.10 ��c�ɑ��Y
 */
using System;
using UnityEngine;

// 18�s�ڂ̃R�����g�A�E�g���������邱�ƂŁA
// Create����ProjectReadme�A�Z�b�g���쐬�ł���悤�ɂȂ�܂��B
// �쐬��͎ז��Ȃ̂ŁA�ēx�R�����g�A�E�g�����B
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
