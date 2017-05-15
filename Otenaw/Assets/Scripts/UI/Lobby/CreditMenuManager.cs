using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Prototype.NetworkLobby
{
    public class CreditMenuManager : MonoBehaviour
    {
        [SerializeField]
        Button firstSelect;

        //selectionner le premier bouton quand est enable
        private void OnEnable()
        {
            //firstSelect.Select();
            StartCoroutine(WaitForIt());
        }

        IEnumerator WaitForIt()
        {
            yield return new WaitForEndOfFrame();
            firstSelect.Select();
        }
    }
}
