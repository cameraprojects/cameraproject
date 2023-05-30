using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody rigid;
    CapsuleCollider capsuleCollider;
    MeshRenderer[] mesh_array;

    // Start is called before the first frame update
    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        mesh_array = GetComponentsInChildren<MeshRenderer>();
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Laser")
        {
            Vector3 reactVec = transform.position - other.transform.position;
            StartCoroutine(OnDamage(reactVec));
        }
    }

    IEnumerator OnDamage(Vector3 reactVec)
    {
        foreach(MeshRenderer mesh in mesh_array)
        {
            if (mesh != null)
            {
                mesh.materials[0].color = Color.red;


                reactVec = reactVec.normalized;
                rigid.AddForce(reactVec * 10, ForceMode.Impulse);

                yield return new WaitForSeconds(0.1f);


                mesh.materials[0].color = Color.white;

                Debug.Log("Shot!");
            }    
        }    

    }

}
