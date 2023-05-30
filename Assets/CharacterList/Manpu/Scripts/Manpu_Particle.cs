using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manpu_Particle : MonoBehaviour
{
    private ParticleSystem ps;
    public GameObject obj_base;
    public GameObject obj_trigger;
    private int fg = 0;
    private float timeCount = 0;
    public float time=5f;

    void Start()
    {
        obj_base.SetActive(false);
        ps = obj_base.GetComponent<ParticleSystem>();
        ps.Stop();
    }

    void Update()
    {
        if (obj_trigger.activeSelf)
        {
            if (fg == 0) { obj_base.SetActive(true); ps.Play(); fg = 1; }
            if (fg == 1)
            {
                timeCount+= Time.deltaTime; if (timeCount >= time) { ps.Stop(); fg = 2; }
            }
        }
        else { ps.Stop(); obj_base.SetActive(false); fg = 0; timeCount = 0; }

    }
}
