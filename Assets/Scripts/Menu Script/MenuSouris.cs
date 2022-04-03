using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSouris : MonoBehaviour
{
    public GameObject optionsMenu, mainMenu, campagneMenu, versusMenu, streamMenu;

    public MenuScript menuScript;

    int count = 0;

    public void afficheCampagne()
    {
        campagneMenu.SetActive(true);
        mainMenu.SetActive(false);
        menuScript.campagneMenu.SetActive(true);
        count = 1;
        menuScript.SelectedButton = 7;
        menuScript.pointCampagne.transform.position = menuScript.ButtonPosition15.position;
        menuScript.droite = true;
        menuScript.pointCampagne.SetActive(true);

    }

    public void afficheVersus()
    {
        versusMenu.SetActive(true);
        mainMenu.SetActive(false);
        menuScript.versusMenu.SetActive(true);
        count = 2;
        menuScript.SelectedButton = 10;
        menuScript.pointVersus.transform.position = menuScript.ButtonPosition7.position;
        menuScript.droite = true;
        menuScript.pointVersus.SetActive(true);
    }

    public void afficheOption()
    {
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);
        menuScript.optionsMenu.SetActive(true);
        count = 3;
        menuScript.SelectedButton = 6;
        menuScript.pointOption.transform.position = menuScript.ButtonPosition6.position;
        menuScript.droite = true;
        menuScript.pointOption.SetActive(true);
    }

    public void afficheStream()
    {
        streamMenu.SetActive(true);
        mainMenu.SetActive(false);
        menuScript.streamMenu.SetActive(true);
        count = 4;
        menuScript.SelectedButton = 14;
        menuScript.pointStream.transform.position = menuScript.ButtonPosition11.position;
        menuScript.droite = true;
        menuScript.pointStream.SetActive(true);
    }

    public void afficheMenu()
    {
        if(count == 1 )
        {
            campagneMenu.SetActive(false);
            menuScript.campagneMenu.SetActive(false);
            menuScript.pointCampagne.SetActive(false);
        }
        if (count == 2)
        {
            versusMenu.SetActive(false);
            menuScript.versusMenu.SetActive(false);
            menuScript.pointVersus.SetActive(false);
        }
        if (count == 3)
        {
            optionsMenu.SetActive(false);
            menuScript.optionsMenu.SetActive(false);
            menuScript.pointOption.SetActive(false);
        }
        if (count ==4)
        {
            streamMenu.SetActive(false);
            menuScript.streamMenu.SetActive(false);
            menuScript.pointStream.SetActive(false);
        }

        mainMenu.SetActive(true);
        menuScript.mainMenu.SetActive(true);
        menuScript.SelectedButton = 1;
        menuScript.pointMenu.transform.position = menuScript.ButtonPosition1.position;
        menuScript.droite = false;
        menuScript.pointMenu.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Nouveau()
    {
        SceneManager.LoadScene("intro");
    }

    public void SelectionPersoPVP()
    {
        SceneManager.LoadScene("CharacterSelection");
    }

    public void SelectionPersoPVE()
    {
        SceneManager.LoadScene("CharacterSelection IA");
    }


    public void Continuer()
    {
        Debug.Log("Continuer");
        if (PlayerPrefs.GetInt("LastChapterFinished") != 0)
        {
            if (ChapitreManager.instance != null)
            {
                ChapitreManager.instance.chapitreCombat = PlayerPrefs.GetInt("LastChapterFinished");
            }
            int i = PlayerPrefs.GetInt("LastChapterFinished");
            if (i == 1)
            {
                SceneManager.LoadScene("SuiteManequin");
            }
            else if (i == 2)
            {
                SceneManager.LoadScene("Flashback");
            }
            else if (i == 3)
            {
                SceneManager.LoadScene("Pouvoir");
            }
            else
            {
                PlayerPrefs.SetInt("LastChapterFinished", 0);
            }
        }
    }

}

