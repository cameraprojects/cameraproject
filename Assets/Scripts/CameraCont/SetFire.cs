using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFire : MonoBehaviour
{
    
    public GameObject fire;




    public void FireOn()
    {
        fire.SetActive(true);
    }

    public void FireOff()
    {
        fire.SetActive(false);
    }

}
