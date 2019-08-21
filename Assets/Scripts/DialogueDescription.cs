using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This allows us to the make the scriptable objects in the project hierarchy through right clicking
[CreateAssetMenu(fileName ="New DialogueDescription", menuName = "Dialogue Description")]
public class DialogueDescription : ScriptableObject {

    //We need a blank sprite so we can clearly show who is talking by 
    //turning the non talking character 'Off'
    public Sprite blankSprite;

    [Header("Dialogue")]
    //We take the dialogue struct (collection of data) and stick '[]' at the end
    //to turn it into an array (an array is like a shoping list)
    public Dialogue[] dialogue;
}

public enum CharacterType
{
    //Enums allow us to store data and assign it a value
    Player = 0,
    NPC = 1,
}

public enum CharacterList
{
    //Enums allow us to store data and assign it a value but in this case
    //we dont need it to as we are going to retrieve the character names
    Pheonix,
    Gumshoe
}

[System.Serializable]
public struct Dialogue
{
    //This struct will allow us to collect a load of data so that out dialogue system 
    //can give us the performance we need
    public Sprite characterSprite;
    public CharacterType characterType;
    public CharacterList name;
    [TextArea(0, 800)]
    public string dialogue;
}