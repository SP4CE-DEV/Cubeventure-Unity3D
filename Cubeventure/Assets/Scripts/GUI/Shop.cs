using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    int score = CrystalScore.score;
    int[] priceList = new int[4];
    static bool[] ownedSkins = new bool[4];
    static bool ownedSkinsDefault = false;
  
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreLabel;
    public TextMeshProUGUI[] textList = new TextMeshProUGUI[4];

    public Color[] playerSkins;
    public Material playerMaterial;

    private void Start()
    {
        // filling the list
        if (!ownedSkinsDefault)
        {
            ownedSkins[0] = false; ownedSkins[1] = false; ownedSkins[2] = false; ownedSkins[3] = false;
            ownedSkinsDefault = true;
        }
        priceList[0] = 0;  priceList[1] = 20; priceList[2] = 45; priceList[3] = 69;
    }

    public void buyPlayerSkin(int number)
    {
        // if not owned, and enough crystals
        if (!ownedSkins[number])
        {
            if ((score - priceList[number]) > -1)
            {
                score -= priceList[number];
                CrystalScore.score = score;
                ownedSkins[number] = true;
                scoreText.text = score.ToString();
                textList[number].text = "Select";
            }
        }
        // if skin already owned, select it
        else
        {
            playerMaterial.color = playerSkins[number];
            scoreText.text = score.ToString();
        }
    }
}