using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueSystem : MonoBehaviour {

    [Header("Dialogue Description")]
    //Here is where we are going to slot in our dialogue descriptions
    public DialogueDescription description;

    [Header("UI Components")]
    //Here we want to gather all the UI Components so we are able
    //to manipulate them via code
    public Text dialogueName;
    public Text dialogueText;
    public Image pcImage;
    public Image npcImage;

    //These 'private' functions allow us to pass data between functions with in the script
    //setting them to private stop the functions from being manipulated externaly either by 
    //editing the values in the Unity Inspector or by another script 
    private int dialogueIndex = -1;
    private bool isFinished = false;

    private void Start()
    {
        StartEndDialogue();
    }

    private void LateUpdate()
    {
        //Check if the player is has pressed the space key and that the dialogue index number is less than
        //the length of the array
        if (Input.GetKeyDown(KeyCode.Space) && dialogueIndex < description.dialogue.Length)
        {
            CycleDialogue();
        }

        if (isFinished)
        {
            StartEndDialogue();
        }     
    }

    void CycleDialogue()
    {
        //This line of code allows us to add '1' to its self (basicly: dialogueIndex + 1) 
        dialogueIndex++;

        if (dialogueIndex < description.dialogue.Length)
        {
            //Here we are taking the names of the characters and what the dialogue from 
            //the enums in the scriptable object & converting it to a string (text) 
            dialogueName.text = description.dialogue[dialogueIndex].name.ToString();
            dialogueText.text = description.dialogue[dialogueIndex].dialogue.ToString();

            //Here we are taking the character sprites from the scriptable object and passing them
            //the UI 
            pcImage.sprite = description.dialogue[dialogueIndex].characterSprite;
            npcImage.sprite = description.dialogue[dialogueIndex].characterSprite;

            SetBlankSprite();
        }
        else
        {
            //Here we are changing the isFinished bool to make the dialogue system 
            //stop cycling through the dialogue
            isFinished = true;
        }        
    }

    void SetBlankSprite()
    {
        //Toggle between player and npc sprite while talking 
        if (description.dialogue[dialogueIndex].characterType != 0)
        {
            pcImage.sprite = description.blankSprite;
        }
        else
        {
            npcImage.sprite = description.blankSprite;
        }
    }

    void StartEndDialogue()
    {
        //Set both player and npc sprites blank
        pcImage.sprite = description.blankSprite;
        npcImage.sprite = description.blankSprite;

        //Check to see if dialogue index is not the same value as the length of dialogue
        // and also is the story finished
        if (dialogueIndex != description.dialogue.Length -1 && isFinished == false)
        {
            dialogueName.text = "";
            dialogueText.text = "Press Space to start";
        }
        else
        {
            dialogueName.text = "";
            dialogueText.text = "The End";
        }
    }
}
