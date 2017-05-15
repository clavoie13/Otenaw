using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectifHud : MonoBehaviour {

    [SerializeField]
    GameObject inGamePanel;

    [SerializeField]
    ObjectifScreen objectifScreen;

    [SerializeField]
    GameObject winScreen;

    [SerializeField]
    GameObject gameOverScreen;

    [SerializeField]
    Text nbrSauver;

    [SerializeField]
    Text nbrObjectifs;

    [SerializeField]
    GameObject[] TutosWarrior;

    [SerializeField]
    GameObject[] TutosSpirit;

    GameObject TutoActif;

    [SerializeField]
    Text minute;

    [SerializeField]
    Text seconde;

    [SerializeField]
    Text timerRestart;

    [SerializeField]
    Text timerNextLevel;

    int min;

    bool critique = false;

    //afficher ou desafficher le hud objectif in game au debut ou a la fin de la partie
    public void SetInGamePanels(bool newValue)
    {
        inGamePanel.SetActive(newValue);
    }

    public void InitialiserObjectifScreen(int nObjectifs, int timeObj)
    {
        objectifScreen.GetComponent<ObjectifScreen>().Initialiser(nObjectifs, timeObj);
    }

    //afficher le bon hud quand on affiche
    public void StartGame()
    {
        objectifScreen.gameObject.SetActive(false);
        SetInGamePanels(true);
    }

    public void PlayerSetReady(int index)
    {
        objectifScreen.GetComponent<ObjectifScreen>().SetReady(index);
    }

    //set up le nombre de villageois a sauver dans le Hud
    public void SetObjectif(int nObjectifs, int timeObj)
    {
        nbrObjectifs.text = nObjectifs.ToString();
        UpdateTimer(timeObj);
    }

    //update le nombre de villageois deja sauver dans le Hud
    public void UpdateNbrSauver(int nSauver)
    {
        nbrSauver.text = nSauver.ToString();
        GetComponent<ObjectifHudAnimationController>().AddVillageois();
    }

    public void TutoSpiritActivated(int index)
    {
        TutoActif = TutosSpirit[index];
        TutoActif.SetActive(true);
    }

    public void TutoWarriorActivated(int index)
    {
        TutoActif = TutosWarrior[index];
        TutoActif.SetActive(true);
    }

    public void StopTuto()
    {
        TutoActif.GetComponent<TutoAnimatorController>().SetHide();
    }

    public void UpdateTimer(int newTime)
    {
        if((newTime/60) < min)
        {
            min = newTime / 60;
            GetComponent<ObjectifHudAnimationController>().MoinsMinute();
        }

        minute.text = (newTime / 60).ToString();
        seconde.text = string.Format("{0:0#}",(newTime % 60));

        if (critique)
            return;

        if(newTime <= 30)
        {
            critique = true;
            GetComponent<ObjectifHudAnimationController>().SetCritique();
        }
    }

    public void UpdateRestartTimer(int newTime)
    {
        timerRestart.text = string.Format("Restart level in {0:0}", newTime);
    }

    public void UpdateNextLevelTimer(int newTime)
    {
        timerNextLevel.text = string.Format("Next level in {0:0}", newTime);
    }

    public void AfficherWinScreen()
    {
        winScreen.SetActive(true);
    }

    public void AfficherGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

    public void HideScreen()
    {
        winScreen.SetActive(false);
        gameOverScreen.SetActive(false);
    }
}
