using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Prototype.NetworkLobby
{
    public class EventSystemChecker : MonoBehaviour
    { 
        // Use this for initialization
        void Awake()
        {
            if (!FindObjectOfType<EventSystem>())
            {
                //Instantiate(eventSystem);
                GameObject obj = new GameObject("EventSystem");
                obj.AddComponent<EventSystem>();
                obj.AddComponent<StandaloneInputModule>().forceModuleActive = true;
                if (LobbyManager.INSTANCE != null)
                    LobbyManager.INSTANCE.eventSystem = obj;
            }
        }
    }
}