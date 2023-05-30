using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.XR.CoreUtils;
using UnityEngine.InputSystem;
using Photon.Pun;
using System.Text.RegularExpressions;
public class VRUIControler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private InputActionReference LeftButton;
    public GameObject vrui; 
    void Start()
    {
        LeftButton.action.started += UIOpen;
    }

    void UIOpen(InputAction.CallbackContext context)
    {
        if (vrui.activeSelf)
        {
            vrui.SetActive(false);
        }
        else
        {
            vrui.SetActive(true);
        }
    }
}
