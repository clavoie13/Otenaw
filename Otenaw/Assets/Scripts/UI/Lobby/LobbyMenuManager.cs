using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Prototype.NetworkLobby
{
    public class LobbyMenuManager : MonoBehaviour
    {

        [SerializeField]
        Button firstSelect;

        //selectionner le premier bouton quand est enable
        private void OnEnable()
        {
            StartCoroutine(WaitForIt());
        }

        IEnumerator WaitForIt()
        {
            yield return new WaitForEndOfFrame();
            firstSelect.Select();
        }

    }
}
