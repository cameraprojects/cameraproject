using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;

public class TrainControl : MonoBehaviourPun
{
    public GameObject Train;
    public Transform target;
    public GameObject Lark;
    private const string key_isAction = "isAction";
    private const string key_isDeath = "isDeath";
    public GameObject TrainBgm;
    [SerializeField]Transform[] targets;
    UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
      //  agent = Lark.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    IEnumerator TrainMove(GameObject a, Vector3 toPos)
    {
        float count = 0f;
        Vector3 wasPos = a.transform.position;
        while (true)
        {
            count += Time.deltaTime;
            if (count <= 20f)
            {
                a.transform.position = Vector3.Lerp(wasPos, toPos, count / 20f); //��Ԃ�wasPos����toPos�ֈړ�����
            }else if (count > 20f)
            {
                a.transform.position = toPos;

                
            }
            else if (count > 40f)
            {
                //列車を元の場所に戻してアクティブを消す
                TrainBgm.SetActive(false);
                a.transform.position = wasPos;
                a.SetActive(false);

                break;
            }
            TrainBgm.SetActive(true);
            yield return null;
        }
    }

    
    public void StartTrainEvent()
    {
        //列車を動かすコルーチンを動かすためのPunRPCを動かす
        photonView.RPC(nameof(movetrain), RpcTarget.AllBuffered);
    }
    [PunRPC]
    void movetrain(){
        if(Train.activeSelf){
            //列車のイベントが始まっている時は何もしない
        }else{
        Train.SetActive(true);
        //ラークが動く処理を消した
        /*
        Lark.GetComponent<NavMeshAgent>().enabled = true; //�L�����N�^�[���ړ����J�n����
        Lark.GetComponent<Animator>().SetBool(key_isAction, true); //�L�����N�^�[�������A�j���[�V�������Đ�����
        agent.SetDestination(targets[0].position); //�L�����N�^�[��targets[0].position�Ɉړ�����
        Invoke("StopLark", 22.0f); //�L�����N�^�[��22�b��Ƀ|�[�Y�����
        */
        StartCoroutine(TrainMove(Train, target.position)); //��Ԃ�target.position�Ɉړ�����
        }
    }
    void StopLark()
    {
        Lark.GetComponent<Animator>().SetBool(key_isDeath, true);
    }
}
