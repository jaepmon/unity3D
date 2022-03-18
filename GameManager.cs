using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    BossHP bhp;
    public GameObject clearPanel;
    public TextMeshProUGUI clearText;

    void Start()
    {
        bhp = FindObjectOfType<BossHP>();
    }
    void Update()
    {
        if(bhp.currentHP < 0)
        {
            Time.timeScale = 0;
            clearPanel.SetActive(true);
            clearText.gameObject.SetActive(true);
        }
        if(bhp.currentHP < 0 && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
    }
}
