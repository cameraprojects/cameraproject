using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallObject : MonoBehaviour
{

    public GameObject[] projectilePrefabs;
    public Transform startPoint = null;
    public float launchSpeed = 1.0f;

    GameObject projectfab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Call()
    {
        int random = Random.Range(0, 3);
        
        switch (random)
        {
            case 0:
                projectfab = projectilePrefabs[0];
                break;
            case 1:
                projectfab = projectilePrefabs[1];
                break;
            case 2:
                projectfab = projectilePrefabs[2];
                break;
            default:
                break;
        }


                GameObject newObject = Instantiate(projectfab, startPoint.position, startPoint.rotation);


        if (newObject.TryGetComponent(out Rigidbody rigidBody))
            ApplyForce(rigidBody);
    }

    private void ApplyForce(Rigidbody rigidBody)
    {
        Vector3 force = startPoint.forward * launchSpeed;
        rigidBody.AddForce(force);
    }
}
