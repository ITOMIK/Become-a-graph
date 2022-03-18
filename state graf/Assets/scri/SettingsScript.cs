using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SettingsScript : MonoBehaviour
{

    public void onBackButtonClick() {

        SceneManager.LoadScene("MenuScene");
    }
}
