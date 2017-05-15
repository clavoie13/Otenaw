using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IpOptionManager : MonoBehaviour {

    [SerializeField]
    InputField ipAdress;

    [SerializeField]
    InputField port;

    [SerializeField]
    GameObject OptionScreen;

    bool visible = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            if(visible)
            {
                OptionScreen.SetActive(false);
                visible = false;
            }
            else
            {
                OptionScreen.SetActive(true);
                visible = true;
            }
        }
    }

    public string GetIpAdress()
    {
        string temp = ipAdress.text;

        if (temp != "")
            return temp;
        
        temp = PlayerPrefs.GetString("IpAdress");
        if (temp != "")
            return temp;

        return "127.0.0.1";
    }

    public int GetPort()
    {
        int temp;
        if (port.text != "")
        {
            temp = int.Parse(port.text);
            return temp;
        }

        temp = PlayerPrefs.GetInt("Port");
        if (temp != 0)
            return temp;
        
        return 7777;
    }

    public void HideOption()
    {
        OptionScreen.SetActive(false);
        visible = false;
    }

}
