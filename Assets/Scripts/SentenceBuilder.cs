using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class SentenceBuilder : MonoBehaviour
{
    public DialogueRunner dR;
    public SlotHandler[] slots;
    private static string sentence;
    public GameObject canvasObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateAnswer()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            var word = slots[i].currentText;
            sentence += " " + word;
        }
        HideBuilder();
    }

    [YarnFunction("Output")]
    public static string Output()
    {
        return sentence;
    }


    [YarnCommand("SentenceBuilder")]
    public void ShowBuilder()
    {
        canvasObj.SetActive(true);
    }

    [YarnCommand("HideSentenceBuilder")]
    public void HideBuilder()
    {
        canvasObj.SetActive(false);
    }
}
