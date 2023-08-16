using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// from https://www.youtube.com/watch?v=1nFNOyCalzo

public class MerchantDialogue : MonoBehaviour
{
    public GameObject dialogue_panel;
    public Text dialogue_text;
    public string[] dialogue;
    private int index;

    public float word_speed;
    public bool player_is_close;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && player_is_close)
        {
            if(dialogue_panel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                dialogue_panel.SetActive(true);
                StartCoroutine(Typing());
            }
        }
    }
    
    public void zeroText()
    {
        dialogue_text.text = "";
        index = 0;
        dialogue_panel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogue_text.text += letter;
            yield return new WaitForSeconds(word_speed);
        }
    }

    public void NextLine()
    {
        if(index < dialogue.Length - 1)
        {
            index++;
            dialogue_text.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            player_is_close = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player_is_close = false;
            zeroText();
        }
    }
}
