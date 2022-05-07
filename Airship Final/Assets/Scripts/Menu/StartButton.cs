using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // this is actually just all buttons basically
    public GameObject homePanel, panel2, controlPanel, start, quit, text, levelStart, back, controls;
    public GameObject plusHP, minusHP, plusGun, minusGun;
    public Text hpText, gunText;

    private int hp = 200, guns = 3;
    public GameObject playerShip;

    AudioSource sound;

    void Start()
    {
        sound = GetComponent<AudioSource>();

        homePanel.SetActive(true);
        start.SetActive(true);
        quit.SetActive(true);
        text.SetActive(true);
        controls.SetActive(true);

        panel2.SetActive(false);
        levelStart.SetActive(false);
        back.SetActive(false);

        controlPanel.SetActive(false);
    }

    public void LoadScene()
    {
        sound.Play();
        SceneManager.LoadScene("Boss");

        playerShip.GetComponent<Variables>().health = hp;
        playerShip.GetComponent<Variables>().guns = guns;


    }

    public void StartClicked()
    {
        sound.Play();
        homePanel.SetActive(false);
        start.SetActive(false);
        quit.SetActive(false);
        text.SetActive(false);
        controls.SetActive(false);

        panel2.SetActive(true);

        hp = 200;
        hpText.text = "Max Health: " + hp.ToString();
        guns = 3;
        gunText.text = "Number of Guns: " + guns.ToString();
        plusGun.SetActive(true);
        minusGun.SetActive(true);
        plusHP.SetActive(true);
        minusHP.SetActive(true);
        levelStart.SetActive(true);
        back.SetActive(true);
    }

    public void QuitClick()
    {
        sound.Play();
        Application.Quit();
    }

    public void BackClick()
    {
        sound.Play();
        homePanel.SetActive(true);
        start.SetActive(true);
        quit.SetActive(true);
        text.SetActive(true);
        controls.SetActive(true);

        panel2.SetActive(false);
        levelStart.SetActive(false);
        back.SetActive(false);
    }

    public void plusHPClick()
    {
        sound.Play();
        hp += 50;
        if (hp == 500)
        {
            plusHP.SetActive(false);
        }
        minusHP.SetActive(true);
        hpText.text = "Max Health: " + hp.ToString();
    }

    public void minusHPClick()
    {
        sound.Play();
        hp -= 50;
        if (hp == 50)
        {
            minusHP.SetActive(false);
        }
        plusHP.SetActive(true);
        hpText.text = "Max Health: " + hp.ToString();
    }

    public void plusGunClick()
    {
        sound.Play();
        guns += 1;
        if (guns == 5)
        {
            plusGun.SetActive(false);
        }
        minusGun.SetActive(true);
        gunText.text = "Number of Guns: " + guns.ToString();

    }

    public void minusGunClick()
    {
        sound.Play();
        guns -= 1;
        if (guns == 1)
        {
            minusGun.SetActive(false);
        }
        plusGun.SetActive(true);
        gunText.text = "Number of Guns: " + guns.ToString();
    }

    public void controlClick()
    {
        sound.Play();
        
        homePanel.SetActive(false);
        start.SetActive(false);
        quit.SetActive(false);
        text.SetActive(false);
        controls.SetActive(false);

        controlPanel.SetActive(true);
    }

    public void controlBack()
    {
        sound.Play();

        controlPanel.SetActive(false);

        homePanel.SetActive(true);
        start.SetActive(true);
        quit.SetActive(true);
        text.SetActive(true);
        controls.SetActive(true);
    }
}
