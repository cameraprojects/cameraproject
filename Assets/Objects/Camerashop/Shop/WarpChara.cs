using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpChara : MonoBehaviour
{
    // public enum WarpCharaState {
    //     Normal,
    //     GoToWarpPoint,
    // };
 
	// private CharacterController characterController;
	// private Animator animator;
	// private Vector3 velocity = Vector3.zero;
	// private WarpCharaState state;
	// private Transform waitPoint;
	// private Transform warpPoint;
	// private InstantiateParticle instantiateParticle;
	// //　歩く速さ
	// public float walkSpeed;
	// //　ワープポイントでキャラクターを中央に移動させたり回転させたりするスピード
	// public float goToWaitPointSpeed;

    // void Start()
    // {
    //     characterController = GetComponent<CharacterController> ();
    //     animator = GetComponent <Animator> ();
    //     state = WarpCharaState.normal;
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     if (state == WarpCharaState.normal) {
    //         if (characterController.isGrounded) {
    //             velocity = Vector3.zero;
    //             var input = new Vector3 (Input.GetAxis ("Horizontal"), 0f, Input.GetAxis ("Vertical"));
    
    //             if (input.magnitude > 0f) {
    //                 transform.LookAt (transform.position + input);
    //                 velocity += transform.forward * walkSpeed;
    //                 animator.SetFloat ("Speed", 1f);
    //             } else {
    //                 animator.SetFloat ("Speed", 0f);
    //             }
    //         }
    //         velocity.y += Physics.gravity.y * Time.deltaTime;
    //         characterController.Move (velocity * Time.deltaTime);
    //     } else if (state == WarpCharaState.goToWarpPoint) {
    //         GoToWarpWaitPoint ();
    //     }
    // }
    // void GoToWarpWaitPoint() {
    //     if (Vector3.Distance(transform.position, waitPoint.position) > 0.1f
    //         || Quaternion.Angle(transform.rotation, waitPoint.rotation) >= 5f
    //     ) {
    //         animator.SetFloat("Speed", 1f);
    //         Debug.Log("移動中");
    //         transform.position = Vector3.Lerp(transform.position, waitPoint.position, goToWaitPointSpeed * Time.deltaTime);
    //         transform.rotation = Quaternion.Lerp(transform.rotation, waitPoint.rotation, goToWaitPointSpeed * Time.deltaTime);
    //     } else if (transform.position != waitPoint.position
    //         //&& Quaternion.Angle(transform.rotation, waitPoint.rotation) < 5f
    //         ) {
    //         animator.SetFloat("Speed", 0f);
    //         Debug.Log("きっちり位置と角度を合わせる");
    //         transform.position = waitPoint.position;
    //         transform.rotation = waitPoint.rotation;
    //         //　3秒後にワープ
    //         Invoke("Warp", 3f);
    //     }
    // }
    // void Warp() {
    //     transform.position = warpPoint.position;
    //     transform.rotation = warpPoint.rotation;
    //     SetState(WarpCharaState.Normal);
    // }
    // public void SetState(WarpCharaState state, Transform waitPoint = null, Transform warpPoint = null) {
    //     this.state = state;
    //     this.waitPoint = waitPoint;
    //     this.warpPoint = warpPoint;
    
    //     //　状態に応じた処理
    //     if (state == WarpCharaState.GoToWarpPoint) {
    //         velocity = Vector3.zero;
    //         characterController.enabled = false;
    //     } else if(state == WarpCharaState.Normal) {
    //         characterController.enabled = true;
    //     }
    // }
}
