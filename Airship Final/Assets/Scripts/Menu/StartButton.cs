using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // this is actually just all buttons basically
    public GameObject homePanel, panel2, start, quit, text, levelStart, back;
    public GameObject plusHP, minusHP, plusGun, minusGun;
    public Text hpText, gunText;

    private int hp = 200, guns = 3;
    public GameObject playerShip;

    void Start()
    {
        
        BackClick();
    }

    public void LoadScene()
    {
        
        SceneManager.LoadScene("Boss");

        playerShip.GetComponent<Variables>().health = hp;
        playerShip.GetComponent<Variables>().guns = guns;


    }

    public void StartClicked()
    {
        homePanel.SetActive(false);
        start.SetActive(false);
        quit.SetActive(false);
        text.SetActive(false);

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
        Application.Quit();
    }

    public void BackClick()
    {
        homePanel.SetActive(true);
        start.SetActive(true);
        quit.SetActive(true);
        text.SetActive(true);

        panel2.SetActive(false);
        levelStart.SetActive(false);
        back.SetActive(false);
    }

    public void plusHPClick()
    {
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
        hp -= 50;
        if (hp == 200)
        {
            minusHP.SetActive(false);
        }
        plusHP.SetActive(true);
        hpText.text = "Max Health: " + hp.ToString();
    }

    public void plusGunClick()
    {
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
        guns -= 1;
        if (guns == 1)
        {
            minusGun.SetActive(false);
        }
        plusGun.SetActive(true);
        gunText.text = "Number of Guns: " + guns.ToString();
    }
}
