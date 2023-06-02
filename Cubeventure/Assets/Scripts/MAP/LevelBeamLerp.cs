using System.Collections;
using UnityEngine;

public class LevelBeamLerp : MonoBehaviour
{
    public Color targetColor = new Color(0, 1, 0, 1);
    public Material materialToChange;
    void Start()
    {
        materialToChange = gameObject.GetComponent<Renderer>().material;
        StartCoroutine(LerpFunction(targetColor, 80));
    }
    IEnumerator LerpFunction(Color endValue, float duration)
    {
        float time = 0;
        Color startValue = materialToChange.color;
        while (time < duration)
        {
            materialToChange.color = Color.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        materialToChange.color = endValue;
    }
}
