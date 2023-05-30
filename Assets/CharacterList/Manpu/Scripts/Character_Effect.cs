using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Photon.Pun;

public class Character_Effect : MonoBehaviourPunCallbacks
{
    private SkinnedMeshRenderer smr;
    private Animator animator;
    private int flag = 0, taikifg = 0;
    public int emset = 0, type = 0, CharaID = 0, i=0;
    private Vector3 initialPosition; 
    private Quaternion initialRotation;
    private Action[] funclist;
    private string[] Motion_sp = { "None", "Is_Walking", "Is_Running", "test" }, Taiki_key= { "None", "is_taiki_Kyokua", "is_taiki_Contrast", "is_taiki_Uouo", "is_taiki_Lark" };
    [System.NonSerialized]
    public string[] Em_key = { "Standing", "BothHandShake", "PartHandShake_R", "Punch", "Hirahira", "Gakkuri", "Nono", "Yubinarasi", "Atamanite", "Bikkuri", "Hakusyu", "Banzai", "Mesomeso", "Udekumi", "Yatta", "Ehehe", "Omakase", "Kirakira", "Dame", "OK",
                                "Punpun", "BothGattuPose", "PartGattuPose", "Tukareta", "Uun", "Dance", "Zzz", "Onegai", "Obieru", "Samui", "Atui", "Jump", "Munku", "PartHandShake_L", "Dance2", "Dance3", "Dance4", "Spin"
                             };

    void Start() 
    {
        animator = GetComponent<Animator>(); smr = GameObject.Find("Face").GetComponent<SkinnedMeshRenderer>(); initialPosition = this.transform.position; initialRotation = this.transform.rotation;
        funclist = new Action[38] { test, BothHandShake, PartHandShake_R, Punch, Hirahira, Gakkuri, Nono, Yubinarasi, Atamanite, Bikkuri, Hakusyu, Banzai, Mesomeso, Udekumi, Yatta, Ehehe, Omakase, Kirakira, Dame, OK,
                                    Punpun, BothGattuPose, PartGattuPose, Tukareta, Uun, Dance, Zzz, Onegai, Obieru, Samui, Atui, Jump, Munku, PartHandShake_L, Dance2, Dance3, Dance4, Spin
                                  };
    }
    public Vector3 pos() { return animator.GetBoneTransform(HumanBodyBones.Head).position; }
    public Vector3 direction() { return this.transform.forward; }
    public void reset() { reset_motion(); emset = 0; this.transform.position = initialPosition; this.transform.rotation = initialRotation; }
    public void AnimationControl(string index, int on_off) { if (on_off == 1) { animator.SetBool(index, true); } else if (on_off == 0) { animator.SetBool(index, false); } }
    public void walk() { flag = -1; AnimationControl(Motion_sp[-flag], 1); }
    public void run() { flag = -2; AnimationControl(Motion_sp[-flag], 1); }
    public void test() { flag = -3; AnimationControl(Motion_sp[-flag], 1); }
    public void taiki(int t) { if (CharaID >= 1 && CharaID < Taiki_key.Length) { AnimationControl(Taiki_key[CharaID], t); } }

    public void BothHandShake() { flag = 1; AnimationControl(Em_key[flag], 1); }
    public void PartHandShake_R() { flag = 2; AnimationControl(Em_key[flag], 1); }
    public void Punch() { flag = 3; AnimationControl(Em_key[flag], 1); }
    public void Hirahira() { flag = 4; AnimationControl(Em_key[flag], 1); }
    public void Gakkuri() { flag = 5; AnimationControl(Em_key[flag], 1); }
    public void Nono() { flag = 6; AnimationControl(Em_key[flag], 1); }
    public void Yubinarasi() { flag = 7; AnimationControl(Em_key[flag], 1); }
    public void Atamanite() { flag = 8; AnimationControl(Em_key[flag], 1); }
    public void Bikkuri() { flag = 9; AnimationControl(Em_key[flag], 1); }
    public void Hakusyu() { flag = 10; AnimationControl(Em_key[flag], 1); }
    public void Banzai() { flag = 11; AnimationControl(Em_key[flag], 1); }
    public void Mesomeso() { flag = 12; AnimationControl(Em_key[flag], 1); }
    public void Udekumi() { flag = 13; AnimationControl(Em_key[flag], 1); }
    public void Yatta() { flag = 14; AnimationControl(Em_key[flag], 1); }
    public void Ehehe() { flag = 15; AnimationControl(Em_key[flag], 1); }
    public void Omakase() { flag = 16; AnimationControl(Em_key[flag], 1); }
    public void Kirakira() { flag = 17; AnimationControl(Em_key[flag], 1); }
    public void Dame() { flag = 18; AnimationControl(Em_key[flag], 1); }
    public void OK() { flag = 19; AnimationControl(Em_key[flag], 1); }
    public void Punpun() { flag = 20; AnimationControl(Em_key[flag], 1); }
    public void BothGattuPose() { flag = 21; AnimationControl(Em_key[flag], 1); }
    public void PartGattuPose() { flag = 22; AnimationControl(Em_key[flag], 1); }
    public void Tukareta() { flag = 23; AnimationControl(Em_key[flag], 1); }
    public void Uun() { flag = 24; AnimationControl(Em_key[flag], 1); }
    public void Dance() { flag = 25; AnimationControl(Em_key[flag], 1); }
    public void Zzz() { flag = 26; AnimationControl(Em_key[flag], 1); }
    public void Onegai() { flag = 27; AnimationControl(Em_key[flag], 1); }
    public void Obieru() { flag = 28; AnimationControl(Em_key[flag], 1); }
    public void Samui() { flag = 29; AnimationControl(Em_key[flag], 1); }
    public void Atui() { flag = 30; AnimationControl(Em_key[flag], 1); }
    public void Jump() { flag = 31; AnimationControl(Em_key[flag], 1); }
    public void Munku() { flag = 32; AnimationControl(Em_key[flag], 1); }
    public void PartHandShake_L() { flag = 33; AnimationControl(Em_key[flag], 1); }
    public void Dance2() { flag = 34; AnimationControl(Em_key[flag], 1); }
    public void Dance3() { flag = 35; AnimationControl(Em_key[flag], 1); }
    public void Dance4() { flag = 36; AnimationControl(Em_key[flag], 1); }
    public void Spin() { flag = 37; AnimationControl(Em_key[flag], 1); }

    public void emfunc(int j) { funclist[j](); }

    public void reset_motion() { if (flag < 0) { AnimationControl(Motion_sp[-flag], 0); } else { AnimationControl(Em_key[flag], 0); } flag = 0; }
    void Update()
    {
        if (photonView.IsMine) {
            // if (Input.GetKeyDown(KeyCode.Alpha1)) { reset_motion(); if (type == 0) { emset = 27; } else { emset = 10 * type + 1; } }
            // if (Input.GetKeyDown(KeyCode.Alpha2)) { reset_motion(); if (type == 0) { emset = 2; } else { emset = 10 * type + 2; } }
            // if (Input.GetKeyDown(KeyCode.Alpha3)) { reset_motion(); if (type == 0) { emset = 3; } else { emset = 10 * type + 3; } }
            // if (Input.GetKeyDown(KeyCode.Alpha4)) { reset_motion(); if (type == 0) { emset = 4; } else { emset = 10 * type + 4; } }
            // if (Input.GetKeyDown(KeyCode.Alpha5)) { reset_motion(); if (type == 0) { emset = 5; } else { emset = 10 * type + 5; } }
            // if (Input.GetKeyDown(KeyCode.Alpha6)) { reset_motion(); if (type == 0) { emset = 6; } else { emset = 10 * type + 6; } }
            // if (Input.GetKeyDown(KeyCode.Alpha7)) { reset_motion(); if (type == 0) { emset = 7; } else { emset = 10 * type + 7; } }  
            // if (Input.GetKeyDown(KeyCode.Alpha8)) { reset_motion(); if (type == 0) { emset = 8; } else { emset = 10 * type + 8; } }
            // if (Input.GetKeyDown(KeyCode.Alpha9)) { reset_motion(); if (type == 0) { emset = 9; } else { emset = 10 * type + 9; } }
            // if (Input.GetKeyDown(KeyCode.Alpha0)) { reset_motion(); if (type == 0) { emset = 10; } else { emset = 10 * type + 10; } }
            if (Input.GetKeyDown(KeyCode.Alpha1)) { photonView.RPC(nameof(IsEmset), RpcTarget.AllBuffered,27); }
            if (Input.GetKeyDown(KeyCode.Alpha2)) { photonView.RPC(nameof(IsEmset), RpcTarget.AllBuffered,2); }
            if (Input.GetKeyDown(KeyCode.Alpha3)) { photonView.RPC(nameof(IsEmset), RpcTarget.AllBuffered,3); }
            if (Input.GetKeyDown(KeyCode.Alpha4)) { photonView.RPC(nameof(IsEmset), RpcTarget.AllBuffered,4); }
            if (Input.GetKeyDown(KeyCode.Alpha5)) { photonView.RPC(nameof(IsEmset), RpcTarget.AllBuffered,5); }
            if (Input.GetKeyDown(KeyCode.Alpha6)) { photonView.RPC(nameof(IsEmset), RpcTarget.AllBuffered,6); }
            if (Input.GetKeyDown(KeyCode.Alpha7)) { photonView.RPC(nameof(IsEmset), RpcTarget.AllBuffered,7); }
            if (Input.GetKeyDown(KeyCode.Alpha8)) { photonView.RPC(nameof(IsEmset), RpcTarget.AllBuffered,8); }
            if (Input.GetKeyDown(KeyCode.Alpha9)) { photonView.RPC(nameof(IsEmset), RpcTarget.AllBuffered,9); }
            if (Input.GetKeyDown(KeyCode.Alpha0)) { photonView.RPC(nameof(IsEmset), RpcTarget.AllBuffered,10); }
            if (Input.GetKeyDown(KeyCode.R)) { reset(); }
            //if (Input.GetKeyDown(KeyCode.T)) { reset_motion(); emset = -1; }
            //if (Input.GetKeyDown(KeyCode.L)) { if (taikifg == 0) { taikifg = 1; } else if (taikifg == 1) { taikifg = 0; } taiki(taikifg); }
        }
    }
    [PunRPC]
    void IsEmset(int k){
           reset_motion(); emset=k;
    }
}