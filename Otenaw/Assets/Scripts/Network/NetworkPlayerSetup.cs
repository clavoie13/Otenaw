using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;
using XInputDotNetPure;


[System.Serializable]
public class ToggleEvent : UnityEvent<bool> { }

public class NetworkPlayerSetup : Entity
{

    [SerializeField]
    ToggleEvent onToggleShared;
    [SerializeField]
    ToggleEvent onToggleLocal;
    [SerializeField]
    ToggleEvent onToggleRemote;
    [SerializeField]
    ToggleEvent onToggleStop;
    [SerializeField]
    GameObject CameraRig;

    void Start()
    {
        //EnablePlayer();
    }

    public void DisablePlayer()
    {
        onToggleShared.Invoke(false);

        if (hasAuthority)
        {
            Camera.main.gameObject.SetActive(true);

            onToggleLocal.Invoke(false);
        }
        else
            onToggleRemote.Invoke(false);
    }

    public void EnablePlayer()
    {
        isActive = true;
        EventManager.StartListening("EventStop", DisablePlayerPourFinNiveau);


        onToggleShared.Invoke(true);

        if (hasAuthority)
        {
            Transform transformCam = Camera.main.gameObject.transform;

            Camera.main.gameObject.SetActive(false);

            GameObject laCamera = Instantiate(CameraRig) as GameObject;


            if(gameObject.tag == "Spirit")
            {
                laCamera.transform.position = ObjectifManager.INSTANCE.transform.position;
            }
            else
                laCamera.transform.position = transform.position;


            if (gameObject.tag == "Spirit")
            {
                GetComponent<CameraSpiritDezoom>().setCamera(ObjectifManager.INSTANCE.transCamera);
            }

            onToggleLocal.Invoke(true);
        }
        else
            onToggleRemote.Invoke(true);
    }

    public void DisablePlayerPourFinNiveau()
    {
        XInputDotNetPure.GamePad.SetVibration(PlayerIndex.One, 0f, 0f);

        onToggleStop.Invoke(false);
        EventManager.StopListening("EventStop", DisablePlayerPourFinNiveau);
    }


}
