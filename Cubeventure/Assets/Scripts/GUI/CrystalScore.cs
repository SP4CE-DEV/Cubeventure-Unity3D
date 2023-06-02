using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CrystalScore : MonoBehaviour
{
    public static int score;

    public TextMeshProUGUI scoreUI;

    private int crystalValue = 0;

    void Start()
    {
        scoreUI.text = score.ToString();
    }

    void OnTriggerEnter(Collider Crystal)
    {
    // Cry 2
        if (Crystal.gameObject.tag == "Crystal")
        {
            if (Crystal.gameObject.name == "Crystal1")
            {
                crystalValue = 1;
            }
            // Cry 2
            if (Crystal.gameObject.name == "Crystal2")
            {
                crystalValue = 2;
            }
            // Cry 3
            if (Crystal.gameObject.name == "Crystal3")
            {
                crystalValue = 3;
            }

            score += crystalValue;
            scoreUI.text = score.ToString();
            Destroy(Crystal.gameObject);
        }
    }
}
