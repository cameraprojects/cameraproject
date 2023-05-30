using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class IsRendered : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField]
    Transform[] targets;
    [SerializeField]
    Transform PlayerTrans;

    private int i = 0;



    public GameObject[] objects;
    private const string MAIN_CAMERA_TAG_NAME = "CameraView";

    int cameraNum = 0;
    int contactNum = 0;
    int contactNum2 = 0;




    private Animator animator;
    private const string key_isAction = "isAction";
    private const string key_isDeath = "isDeath";

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        this.animator = GetComponent<Animator>();
        InvokeRepeating("AgentRun", 0, 10f);
    }





    public void Update()
    {
        StopObject(contactNum);
        TakeList(cameraNum, contactNum2);
        cameraNum = 0;
        contactNum = 0;
        contactNum2 = 0;

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MoveObject(1);
        }


    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            contactNum=1;
        }

        if (other.CompareTag("Player_me"))
        {
            contactNum2++;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MoveObject(0);
            agent.Resume();
            AgentRun();
        }


    }

    void OnWillRenderObject()
    {
        if (Camera.current.tag == MAIN_CAMERA_TAG_NAME)
        {

            cameraNum++;

        }


    }

    void StopObject(int num)
    {
        if (num >= 1)
        {
            agent.Stop(true);
        }
    }

    void MoveObject(int num)
    {
        if (num >= 1)
        {

            transform.LookAt(PlayerTrans);
            this.animator.SetBool(key_isAction, true);
        }
        else
        {


            this.animator.SetBool(key_isAction, false);
            //Debug.Log("Action");
        }




    }

    void AgentRun()
    {
        //agent.Resume();
        int random = Random.Range(0, targets.Length);
        if (targets.Length == 1)
        {

        }
        else
        {
            while (i == random)
            {
                random = Random.Range(0, targets.Length);
            }

        }

        i = random;
        agent.SetDestination(targets[random].position);
    }

    void TakeList(int num, int num2)
    {
        switch (num)
        {
            case 0:
                if (objects[0].GetComponent<SubjectList>().subjects.Contains(this.name) == true)
                {
                    objects[0].GetComponent<SubjectList>().subjects.Remove(this.name);
                }
                break;
            case 1:
                if (objects[0].GetComponent<SubjectList>().subjects.Contains(this.name) == false)
                {
                    if (num2 == 1)
                    {
                        objects[0].GetComponent<SubjectList>().subjects.Add(this.name);
                    }

                }
                break;
            default:
                break;
        }
    }

    public void Pose1()
    {

        this.animator.SetBool(key_isDeath, true);
        agent.Stop(true);

        StartCoroutine(PoseDeathReset());
    }

    IEnumerator PoseDeathReset()
    {
        yield return new WaitForSeconds(5.0f);
        this.animator.SetBool(key_isDeath, false);
        agent.Resume();
    }

}