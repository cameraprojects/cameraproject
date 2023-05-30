using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdpReceiver;
using System;

public class GeoMotionPos : MonoBehaviour, IUdpCallback
{
    [SerializeField] private int _receivePort = 50001;
    [SerializeField] private float _moveScale = 1f;

    private Udp _udp;
    private int _prevTime = 0;
    private int fg = 0;
    private int rou = 2;
    [SerializeField] public Vector3 _pos = Vector3.zero;
    [SerializeField] public Vector3 _poslim = Vector3.zero;
    [SerializeField] public Vector3 _accbase = Vector3.zero;
    [SerializeField] public Vector3 acc = Vector3.zero;
    [SerializeField] public Vector3 _accnowval = Vector3.zero;
    [SerializeField] public Quaternion _Quat ;
    [SerializeField] public Quaternion Quainit;
    [SerializeField] public Vector3 _vecang = Vector3.zero;

    public void OnReceivedCallback(string val)
    {
        var data = val.Split(" ");
        if(data.Length > 1)
        {
            var _accnow = new Vector3((float)Math.Round(float.Parse(data[1]), rou), (float)Math.Round(float.Parse(data[3]), rou), (float)Math.Round(float.Parse(data[2]), rou));
            var Qua = new Quaternion(float.Parse(data[10]), float.Parse(data[11]), float.Parse(data[12]), float.Parse(data[13]));
            _accnowval = _accnow;
            if (fg == 0) {
                var curTime = DateTime.Now.Millisecond;
                _prevTime = curTime; _accbase = _accnow; fg = 1;Quainit = Qua;
            } else {
                //var acc = new Vector3((float)Math.Round(float.Parse(data[1]) - _posinit.x, rou), (float)Math.Round(float.Parse(data[2]) - _posinit.y, rou), (float)Math.Round(float.Parse(data[3]) - _posinit.z, rou));
                var curTime = DateTime.Now.Millisecond;
                acc = new Vector3((float)Math.Round(_accnow.x - _accbase.x,rou), (float)Math.Round(_accnow.y - _accbase.y,rou), (float)Math.Round(_accnow.z - _accbase.z,rou));
                //_Quat = new Quaternion(Qua.x-Quainit.x, Qua.y - Quainit.y, Qua.z - Quainit.z, Qua.w - Quainit.w);
                _Quat = Qua;
                //Debug.Log("acc: "+acc);
                //Debug.Log("CurTime: "+curTime);
                var elapsedTime = curTime - _prevTime;
                elapsedTime = elapsedTime >= 0 ? elapsedTime : elapsedTime + 1000;
                Debug.Log("elTime: "+elapsedTime);
                //Debug.Log("Pos_pre: " + _pos);
                _pos += _moveScale * elapsedTime * elapsedTime * Mathf.Pow(10, -4f) * acc;
                //Debug.Log("Pos_aft: " + _pos);
                //transform.position += _moveScale * elapsedTime * elapsedTime * acc;
                _prevTime = curTime; _accbase = _accnow;
            }
            
        }
    }

    private void OnDisable() => _udp?.CloseClient();

    private void OnApplicationQuit() => _udp?.CloseClient();

    void Start()
    {
        _udp = new Udp();
        _udp.InitRcvClient(_receivePort);
        _udp.ReceiveMessage(this, out _);
        _pos = this.transform.position;
        _Quat = this.transform.rotation;
    }

    void Update()
    {
        if(Mathf.Abs(transform.position.x)<Mathf.Abs(_poslim.x)&& Mathf.Abs(transform.position.y) < Mathf.Abs(_poslim.y) && Mathf.Abs(transform.position.z) < Mathf.Abs(_poslim.z))
        {
            transform.position = _pos;
            transform.rotation = _Quat;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _pos = Vector3.zero;
            transform.position = Vector3.zero;
        }
    }
}
