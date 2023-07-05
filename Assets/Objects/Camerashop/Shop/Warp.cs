using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    public Transform warpPoint;
    public GameObject XR;
    private Collider cam;
    private bool flag=false;

    void Start()
    {
        
    }
 
	void OnTriggerEnter(Collider col) {
		if(col.tag == "Player"&&!flag) {
            cam=col;
            cam.GetComponent<Rigidbody>().isKinematic=true;
            flag=true;
            StartCoroutine(TimeManege());
			//　キャラクターの状態をワープ状態に変更
            cam.transform.position = warpPoint.position;
            cam.transform.rotation = warpPoint.rotation;
            XR.transform.position = warpPoint.position;
            XR.transform.rotation = warpPoint.rotation;
            Debug.Log(cam.transform.position);
		}
	}
    IEnumerator TimeManege() 
    {
        //終わるまで待ってほしい処理を書く
        //待つ
        yield return new WaitForSeconds(2);
        //再開してから実行したい処理を書く
        cam.GetComponent<Rigidbody>().isKinematic=false;
        flag=false;
    } 
    void Update()
    {
        
    }
}
