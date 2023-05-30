using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class UpdateID : MonoBehaviour
{
    private TextMesh _textMesh;
    [SerializeField]private PhotonView _photonView;
    // Start is called before the first frame update
    void Start()
    {
        _textMesh = this.GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        _textMesh.text = "ID:" + _photonView.ViewID;
    }
}
