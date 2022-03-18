using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public void onGameButtonClick() {

        SceneManager.LoadScene("SampleScene");
    }

    public void onQuitButtonClick() {

        Application.Quit();
    }

    public void onSettingsButtonClick() {

        SceneManager.LoadScene("SettingsScene");
    }
}
