using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CurrentSpriteHighlighter : MonoBehaviour
{
    public TextMeshProUGUI characterName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.name == characterName.text)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f);
        }
    }
}
