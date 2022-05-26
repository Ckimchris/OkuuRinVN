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

    /*[YarnFunction("Jump_Beef")]
    public void Jump_Beef()
    {
        //This is DX's testing to jump node upon sentence contain specific word
        //Feel free to improve later :D
        if (sentence.Contains("Beef"))
        {
            dR.StartDialogue("Beef");
        }
    }*/


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
