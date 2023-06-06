using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Debuger : MonoBehaviourPun
{
        [SerializeField]
    private float y_sensitivity = 3f;
        [SerializeField]
    private float x_sensitivity = 3f;

        [SerializeField]
    private float speed = 1f;

    // Start is called before the first frame update
    void Awake()
    {
        if (photonView.IsMine)
        {
            this.transform.GetChild(0).gameObject.AddComponent<AudioListener>();
            this.transform.GetChild(0).gameObject.tag="MainCamera";
        }
        else
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float y_mouse = Input.GetAxis("Mouse Y");
        float x_mouse = Input.GetAxis("Mouse X");
        Vector3 newRotation = transform.localEulerAngles;
        newRotation.x -= y_mouse * y_sensitivity;
        newRotation.y -= x_mouse * x_sensitivity;
        transform.localEulerAngles = newRotation;
        if(photonView.IsMine){
            if(Input.GetKey(KeyCode.A)){
                this.transform.position+=speed*-this.transform.right;
            }
            if(Input.GetKey(KeyCode.W)){
                this.transform.position+=speed*this.transform.forward;
            }
            if(Input.GetKey(KeyCode.S)){
                this.transform.position+=speed*-this.transform.forward; 
            }
            if(Input.GetKey(KeyCode.D)){
                this.transform.position+=speed*this.transform.right;
            }
            if(Input.GetKeyDown(KeyCode.T)){
                if(this.tag=="Player"){
                    this.tag="Untagged";
                }else{
                    this.tag="Player";
                }
            }
            if(Input.GetKey(KeyCode.Q)){
                this.transform.position+=speed*this.transform.up;
            }
            if(Input.GetKey(KeyCode.Z)){
                this.transform.position+=speed*-this.transform.up;
            }
            
        }
    }
}
