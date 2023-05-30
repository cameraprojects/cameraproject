using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Manpu_Effect : MonoBehaviourPun
{
    public Character_Effect ce;
    private Vector3 p, p1;
    private float add_x = 0f, add_y = 0f, add_z = 0f;
    private int Manpu_fg = 0, i = 0;
    private GameObject[] em;
    private string[] trigger_name;

    void Start()
    {
        trigger_name = ce.Em_key; em = new GameObject[trigger_name.Length];
        for (int n = 0; n < trigger_name.Length; n++) { em[n] = transform.Find(trigger_name[n]).gameObject; }

        ce = this.transform.parent.gameObject.GetComponent<Character_Effect>();
    }
    [PunRPC]
    public void reset_b() { /*ce.reset_motion();*/ if (Manpu_fg >= 1) { em[Manpu_fg].SetActive(false); Manpu_fg = 0; } }
    void Update()
    {
        ManpuPos();
        photonView.RPC(nameof(reset_b), RpcTarget.AllBuffered);
        i = ce.emset;
        if (i > 0 && i < trigger_name.Length)
        {
            photonView.RPC(nameof(playmanpueffects), RpcTarget.AllBuffered);
        }
        if(i==0){photonView.RPC(nameof(playreset), RpcTarget.AllBuffered);}
        if (i == -1) { ce.test(); }
    }
    void ManpuPos(){
        p = ce.pos();
        p1 = new Vector3(p.x + add_x, p.y + add_y, p.z + add_z);
        this.transform.position = p1;
        p = ce.direction();
        p1 = new Vector3(p.x + add_x, p.y + add_y, p.z + add_z);
        this.transform.forward = p1;
    }
    [PunRPC]
    void playmanpueffects(){
            em[i].SetActive(true);
            ce.emfunc(i);
            Manpu_fg = i;
    }
    [PunRPC]
    void playreset(){
            ce.reset();
    }
}