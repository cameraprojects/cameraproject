using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Text.RegularExpressions;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    private GameObject playerList;
    public GameObject[] mainvrCams;
    public GameObject[] mainkeyCams;

    public string pNum = "";
    public string ppNum = "";

    public string dNum;
    public RoomOptions options;
    public int tempNum;

    public Transform[] keyModelSpawn;

    public Stack<string> keyList = new Stack<string>();
    public Stack<string> vrList = new Stack<string>();
    private int i=0;
    private int vrplayernum=0;
    void Start()
    {
        /*vrList.Push("vr4");
        vrList.Push("vr3");
        vrList.Push("vr2");
        vrList.Push("vr1"); //vrList�� vr1~4�܂�(�J�����}�����̃j�b�N�l�[��)���X�^�b�N���܂�
*/
        keyList.Push("key4");
        keyList.Push("key3");
        keyList.Push("key2");
        keyList.Push("key1"); //keyList�� key1~4�܂�(���f�����̃j�b�N�l�[��)���X�^�b�N���܂�

        //key1ModelSpawn = GameObject.Find("Key1ModelSpawn").GetComponent<Transform>(); //���f���̃L�����N�^�[���Ăяo���ʒu

        playerList = GameObject.Find("InputWorld"); //�V�[���uLobby�v��InputWorld�I�u�W�F�N�g
        dNum = playerList.GetComponent<InputWorld>().deviceNum; //dNum��deviceNum�u"1" or "2"�v�ɂ���

        PhotonNetwork.ConnectUsingSettings(); //Photon�ɐڑ�����
        options = new RoomOptions();
        options.PublishUserId = true; //UserId���J
        options.MaxPlayers = 8; //�ő�l��


        Invoke("checkNum", 5.0f); //5�b���chekNum()�����s����
    }

    void checkNum()
    {
        Debug.Log(pNum);
        if (pNum == "" && ppNum == "") //pNum��ppNum�̒l���X�V����Ă��Ȃ��ꍇ(�ڑ����s�̏ꍇ)�A(�Ď��s����悤��)�Q�[�����I��������
        {
            Debug.Log("Failed to connect");
            //UnityEditor.EditorApplication.isPlaying = false;
        }
    }

    [PunRPC]
    void listkeyManage() //���f�����̏ꍇ(�L�[�{�[�h��key)�AkeyList����j�b�N�l�[������o����pNum�ɂ���
    {
        Debug.Log("listkeyManage");
        pNum = keyList.Pop();
        //GameObject.Find(pNum).SetActive(false);
    }

    [PunRPC]
    void listvrManage() //�J�����}�����̏ꍇ(vr)�AvrList����j�b�N�l�[������o����ppNum�ɂ���
    {
        Debug.Log("listvrManage");
        //ppNum = vrList.Pop();
        vrplayernum++;
        ppNum=$"vr{vrplayernum}";
    }
    [PunRPC]
    void debugerlist() //�J�����}�����̏ꍇ(vr)�AvrList����j�b�N�l�[������o����ppNum�ɂ���
    {
        ppNum = $"debuger{i}";
        i++;
    }





    public override void OnConnectedToMaster()
    {
        // "Room"�Ƃ������O�̃��[���ɎQ������i���[�������݂��Ȃ���΍쐬���ĎQ������j
        PhotonNetwork.JoinOrCreateRoom("Room", options, TypedLobby.Default);
    }

    public override void OnJoinedRoom() //���[���ɎQ������Ǝ��s�����
    {
        Invoke("joinAndPlay", 1.0f);
    }

    void joinAndPlay()
    {
        if (dNum == "1") //���f�����Ȃ�S�Ẵv���C���[��listkeyManage()�����s����
        {
            photonView.RPC(nameof(listkeyManage), RpcTarget.AllBuffered);
        }
        else if (dNum == "2") //�J�����}�����Ȃ�S�Ẵv���C���[��listvrManage()�����s����
        {
            photonView.RPC(nameof(listvrManage), RpcTarget.AllBuffered);
        }
        else if (dNum == "3") //�J�����}�����Ȃ�S�Ẵv���C���[��listvrManage()�����s����
        {
            photonView.RPC(nameof(debugerlist), RpcTarget.AllBuffered);
        }
        Invoke("setNick", 1.0f); //(PunRPC�Ɏ��Ԃ�������̂�)1�b���setNick()�����s����
    }

    void setNick()
    {
        if (dNum == "1") //���f�����Ȃ�A�j�b�N�l�[���̐����Ɠ������f�����̃J������L���ɂ���(���ꂪ���C���J�����ƂȂ�)
        {
            PhotonNetwork.NickName = pNum; //�v���C���[�j�b�N�l�[����key1~4�ɂ���
            tempNum = int.Parse(Regex.Replace(pNum, @"[^0-9]", ""));
            mainkeyCams[tempNum - 1].SetActive(true);
            
            if (PhotonNetwork.NickName == "key1") //�����̃j�b�N�l�[�����ƂɃA�o�^�[�𕪂��ČĂяo��
            {
                PhotonNetwork.Instantiate("key1", keyModelSpawn[0].position, keyModelSpawn[0].rotation);
                GameObject.Find("key Cam1").AddComponent(typeof(AudioListener));
            }
            if (PhotonNetwork.NickName == "key2") //�����̃j�b�N�l�[�����ƂɃA�o�^�[�𕪂��ČĂяo��
            {
                PhotonNetwork.Instantiate("key2", keyModelSpawn[1].position, keyModelSpawn[1].rotation);
                GameObject.Find("key Cam2").AddComponent(typeof(AudioListener));

            }
            if (PhotonNetwork.NickName == "key3") //�����̃j�b�N�l�[�����ƂɃA�o�^�[�𕪂��ČĂяo��
            {
                PhotonNetwork.Instantiate("key3", keyModelSpawn[2].position, keyModelSpawn[2].rotation);
                GameObject.Find("key Cam3").AddComponent(typeof(AudioListener));
            }
            if (PhotonNetwork.NickName == "key4") //�����̃j�b�N�l�[�����ƂɃA�o�^�[�𕪂��ČĂяo��
            {
                PhotonNetwork.Instantiate("key4", keyModelSpawn[3].position, keyModelSpawn[3].rotation);
                GameObject.Find("key Cam4").AddComponent(typeof(AudioListener));
            }



            /*PhotonNetwork.Instantiate("key2", keyModelSpawn[1].position, keyModelSpawn[1].rotation);
            GameObject.Find("key Cam1").AddComponent(typeof(AudioListener));
        */

        }
        else if (dNum == "2")
        {
            PhotonNetwork.NickName = ppNum; //�v���C���[�j�b�N�l�[����vr1~4�ɂ���
            mainvrCams[0].SetActive(true); //XR Origin�I�u�W�F�N�g(���ꂪ���C���J�����ƂȂ�)
            if (GameObject.Find("Main Camera1").GetComponent<AudioListener>() == null)
            {
                GameObject.Find("Main Camera1").AddComponent(typeof(AudioListener));
            }
            PhotonNetwork.Instantiate($"MainAvatar {(vrplayernum-1)%4+1}",new Vector3(0f, 0f, 0f), Quaternion.identity);
            /*
            if (PhotonNetwork.NickName == "vr1") //�����̃j�b�N�l�[�����ƂɃA�o�^�[�𕪂��ČĂяo��
            {
                PhotonNetwork.Instantiate("MainAvatar 1", new Vector3(0f, 0f, 0f), Quaternion.identity);
            }
            else if (PhotonNetwork.NickName == "vr2")
            {
                PhotonNetwork.Instantiate("MainAvatar 2", new Vector3(0f, 0f, 0f), Quaternion.identity);
            }
            else if (PhotonNetwork.NickName == "vr3")
            {
                PhotonNetwork.Instantiate("MainAvatar 3", new Vector3(0f, 0f, 0f), Quaternion.identity);
            }
            else if (PhotonNetwork.NickName == "vr4")
            {
                PhotonNetwork.Instantiate("MainAvatar 4", new Vector3(0f, 3f, 0f), Quaternion.identity);
            }
            */
        }
        else if (dNum == "3")
        {
            PhotonNetwork.NickName = ppNum; //�v���C���[�j�b�N�l�[����vr1~4�ɂ���
            PhotonNetwork.Instantiate("debuger", new Vector3(0f, 3f, 0f), Quaternion.identity);
            
        }
    }
    void Update()
    {
        PhotonNetwork.SerializationRate = 10; //1�b��10��X�V���� 
    }

    public override void OnLeftRoom() //�v���C���[�����[������ޏꂵ���ꍇ�A���X�g�Ɏ����̃j�b�N�l�[����Ԃ�
    {
        if (dNum == "1")
        {
            //GameObject.Find(pNum).SetActive(true);
            keyList.Push(PhotonNetwork.NickName);
        }
        else if (dNum == "2")
        {
            //vrList.Push(PhotonNetwork.NickName);
        }
        else if (dNum == "3")
        {
            vrList.Push(PhotonNetwork.NickName);
        }
        else
        {

        }
        base.OnLeftRoom();
    }

}