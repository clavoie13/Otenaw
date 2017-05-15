using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpiritHealthBar : MonoBehaviour {

    [SerializeField]
    Image healthBar;

    [SerializeField]
    Text[] manaText;

    [SerializeField]
    GameObject feedbackPrefab;

    [SerializeField]
    Transform positionSpawn;

    [SerializeField]
    Color couleurGain;

    [SerializeField]
    Color couleurLose;

    HealthSpirit spirit;

    private float maxLife = 100;

    private float curHealth;

    private void Start()
    {
        spirit = GetComponentInParent<HealthSpirit>();
        maxLife = spirit.GetMaxHealth();
        curHealth = maxLife;
        foreach (Text mText in manaText)
        {
            mText.text = curHealth.ToString();
        }
    }

    private void Update()
    {
        if (curHealth == spirit.currentHealth)
            return;

        curHealth = spirit.currentHealth;
        healthBar.fillAmount = curHealth / maxLife;
        foreach (Text mText in manaText)
        {
            mText.text = curHealth.ToString();
        }

    }

    public void TakeDamage(float dmg)
    {
        GameObject feedback = Instantiate(feedbackPrefab);

        feedback.transform.SetParent(positionSpawn.transform);
        feedback.transform.localPosition = Vector3.zero;
        feedback.transform.localScale = Vector3.one;

        feedback.GetComponentInChildren<Text>().text = "-" + dmg.ToString();
        feedback.GetComponentInChildren<Text>().color = couleurLose;
        feedback.GetComponent<Animator>().SetTrigger("play");
    }

    public void GetLife(float gain)
    {
        GameObject feedback = Instantiate(feedbackPrefab, positionSpawn);

        feedback.transform.SetParent(positionSpawn.transform);
        feedback.transform.localPosition = Vector3.zero;
        feedback.transform.localScale = Vector3.one;

        feedback.GetComponentInChildren<Text>().text = "+" + gain.ToString();
        feedback.GetComponentInChildren<Text>().color = couleurGain;
        feedback.GetComponent<Animator>().SetTrigger("play");
    }
}
