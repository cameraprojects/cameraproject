using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WebCamSelector : MonoBehaviour
{
    // Start is called before the first frame update
    public Dropdown _dropdown;
    private WebCamDevice[] _webcam;
    void Start()
    {
        _webcam = WebCamTexture.devices;
        for (int i = 0; i < _webcam.Length; i++)
        {
            _dropdown.options.Add(new Dropdown.OptionData { text = _webcam[i].name });
            DontDestroyOnLoad(this.gameObject);
        }
        _dropdown.RefreshShownValue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string getCamname()
    {
        //Debug.Log(_webcam[_dropdown.value].name);
        return _webcam[_dropdown.value].name; 
    }
}
