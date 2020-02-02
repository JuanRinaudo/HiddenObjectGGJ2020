using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TMProRandomText : MonoBehaviour
{

    public TextMeshProUGUI[] texts;
    public List<string> names;

    private void Awake()
    {
        for(int textIndex = 0; textIndex < texts.Length; ++textIndex)
        {
            int randomIndex = Random.Range(0, names.Count);
            texts[textIndex].text = names[randomIndex];
            names.RemoveAt(randomIndex);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

}
