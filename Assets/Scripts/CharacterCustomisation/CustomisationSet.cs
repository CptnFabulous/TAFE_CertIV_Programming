using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//you will need to change Scenes
public class CustomisationSet : MonoBehaviour {

    #region Variables
    [Header("Texture List")]
    public List<Texture2D> skin = new List<Texture2D>(); //Texture2D List for skin,hair, mouth, eyes
    public List<Texture2D> hair = new List<Texture2D>();
    public List<Texture2D> mouth = new List<Texture2D>();
    public List<Texture2D> eyes = new List<Texture2D>();
    public List<Texture2D> armour = new List<Texture2D>();
    public List<Texture2D> clothes = new List<Texture2D>();
    [Header("Index")]
    int skinIndex, eyesIndex, mouthIndex, hairIndex, armourindex, clothesIndex; //index numbers for our current skin, hair, mouth, eyes textures

    [Header("Renderer")]
    //renderer for our character mesh so we can reference a material list
    public Renderer character;

    [Header("Max Index")]
    public int skinMax;
    public int eyesMax, mouthMax, hairMax, armourMax, clothesMax; //max amount of skin, hair, mouth, eyes textures that our lists are filling with
    [Header("Character Name")]
    public string characterName = "Adventurer"; //name of our character that the user is making

    [Header("Stats")]

    /*
    public CharacterClass characterClass;
    public string[] statNames;
    public int[] statData;
    */

    public string[] statArray = new string[6];
    public int[] stats = new int[6];
    public int[] tempStats = new int[6];
    public int skillPoints = 10;
    public CharacterClass charClass = CharacterClass.Barbarian;
    public string[] selectedClass = new string[8];
    public int selectedIndex = 0;


    #endregion

    #region Start
    //in start we need to set up the following

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        statArray = new string[] { "Strength", "Dexterity", "Constitution", "Wisdom", "Intelligence", "Charisma" };
        selectedClass = new string[] { "Barbarian", "Bard", "Druid", "Monk", "Paladin", "Ranger", "Sorceror", "Warlock" };
        
        #region for loop to pull textures from file


        for (int i = 0; i < skinMax; i++) //for loop looping from 0 to less than the max amount of skin textures we need
        {
            Texture2D temp = Resources.Load("Character/Skin_" + i) as Texture2D; //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Skin_#
            skin.Add(temp); //add our temp texture that we just found to the skin List
        }
        for (int i = 0; i < hairMax; i++) //for loop looping from 0 to less than the max amount of hair textures we need
        {
            Texture2D temp = Resources.Load("Character/Hair_" + i.ToString()) as Texture2D; //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Hair_#
            hair.Add(temp); //add our temp texture that we just found to the hair List
        }
        for (int i = 0; i < mouthMax; i++) //for loop looping from 0 to less than the max amount of mouth textures we need
        {
            Texture2D temp = Resources.Load("Character/Mouth_" + i.ToString()) as Texture2D; //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Mouth_#
            mouth.Add(temp); //add our temp texture that we just found to the mouth List
        }
        for (int i = 0; i < eyesMax; i++) //for loop looping from 0 to less than the max amount of eyes textures we need
        {
            Texture2D temp = Resources.Load("Character/Eyes_" + i.ToString()) as Texture2D; //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Eyes_#
            eyes.Add(temp); //add our temp texture that we just found to the eyes List
        }
        for (int i = 0; i < armourMax; i++) //for loop looping from 0 to less than the max amount of armour textures we need
        {
            Texture2D temp = Resources.Load("Character/Armour_" + i.ToString()) as Texture2D; //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Armour_#
            armour.Add(temp); //add our temp texture that we just found to the armour List
        }
        for (int i = 0; i < clothesMax; i++) //for loop looping from 0 to less than the max amount of clothes textures we need
        {
            Texture2D temp = Resources.Load("Character/Clothes_" + i.ToString()) as Texture2D; //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Clothes_#
            clothes.Add(temp); //add our temp texture that we just found to the clothes List
        }
        #endregion

        character = GameObject.Find("Mesh").GetComponent<SkinnedMeshRenderer>(); //connect and find the SkinnedMeshRenderer thats in the scene to the variable we made for Renderer

        #region do this after making the function SetTexture
        //SetTexture skin, hair, mouth, eyes to the first texture 0
        #endregion


    }

    
    #endregion

    #region SetTexture
    //Create a function that is called SetTexture it should contain a string and int
    //the string is the name of the material we are editing, the int is the direction we are changing
    //we need variables that exist only within this function
    //these are ints index numbers, max numbers, material index and Texture2D array of textures
    //inside a switch statement that is swapped by the string name of our material
    #region Switch Material
    //case skin
    //index is the same as our skin index
    //max is the same as our skin max
    //textures is our skin list .ToArray()
    //material index element number is 1
    //break
    //now repeat for each material 
    //hair is 2
    //index is the same as our index
    //max is the same as our max
    //textures is our list .ToArray()
    //material index element number is 2
    //break
    //mouth is 3
    //index is the same as our index
    //max is the same as our max
    //textures is our list .ToArray()
    //material index element number is 3
    //break
    //eyes are 4
    //index is the same as our index
    //max is the same as our max
    //textures is our list .ToArray()
    //material index element number is 4
    //break
    #endregion
    #region OutSide Switch
    //outside our switch statement
    //index plus equals our direction
    //cap our index to loop back around if is is below 0 or above max take one
    //Material array is equal to our characters material list
    //our material arrays current material index's main texture is equal to our texture arrays current index
    //our characters materials are equal to the material array
    //create another switch that is goverened by the same string name of our material
    #endregion
    #region Set Material Switch
    //case skin
    //skin index equals our index
    //break
    //case hair
    //index equals our index
    //break
    //case mouth
    //index equals our index
    //break
    //case eyes
    //index equals our index
    //break
    #endregion
    #endregion

    #region Save
    //Function called Save this will allow us to save our indexes 
    //SetInt for SkinIndex, HairIndex, MouthIndex, EyesIndex
    //SetString CharacterName
    #endregion

    #region OnGUI
    //Function for our GUI elements
    //create the floats scrW and scrH that govern our 16:9 ratio
    //create an int that will help with shuffling your GUI elements under eachother
    #region Skin
    //GUI button on the left of the screen with the contence <
    //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  -1
    //GUI Box or Lable on the left of the screen with the contence Skin
    //GUI button on the left of the screen with the contence >
    //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  1
    //move down the screen with the int using ++ each grouping of GUI elements are moved using this
    #endregion
    //set up same things for Hair, Mouth and Eyes
    #region Hair
    //GUI button on the left of the screen with the contence <
    //when pressed the button will run SetTexture and grab the Material and move the texture index in the direction  -1
    //GUI Box or Lable on the left of the screen with the contence material Name
    //GUI button on the left of the screen with the contence >
    //when pressed the button will run SetTexture and grab the  Material and move the texture index in the direction  1
    //move down the screen with the int using ++ each grouping of GUI elements are moved using this
    #endregion
    #region Mouth
    //GUI button on the left of the screen with the contence <
    //when pressed the button will run SetTexture and grab the Material and move the texture index in the direction  -1
    //GUI Box or Lable on the left of the screen with the contence material Name
    //GUI button on the left of the screen with the contence >
    //when pressed the button will run SetTexture and grab the  Material and move the texture index in the direction  1
    //move down the screen with the int using ++ each grouping of GUI elements are moved using this
    #endregion
    #region Eyes
    //GUI button on the left of the screen with the contence <
    //when pressed the button will run SetTexture and grab the Material and move the texture index in the direction  -1
    //GUI Box or Lable on the left of the screen with the contence material Name
    //GUI button on the left of the screen with the contence >
    //when pressed the button will run SetTexture and grab the  Material and move the texture index in the direction  1
    //move down the screen with the int using ++ each grouping of GUI elements are moved using this
    #endregion
    #region Random Reset
    //create 2 buttons one Random and one Reset
    //Random will feed a random amount to the direction 
    //reset will set all to 0 both use SetTexture
    //move down the screen with the int using ++ each grouping of GUI elements are moved using this
    #endregion
    #region Character Name and Save & Play
    //name of our character equals a GUI TextField that holds our character name and limit of characters
    //move down the screen with the int using ++ each grouping of GUI elements are moved using this

    //GUI Button called Save and Play
    //this button will run the save function and also load into the game level
    #endregion
    #endregion
}

public enum CharacterClass
{
    Barbarian,
    Bard,
    Druid,
    Monk,
    Paladin,
    Ranger,
    Sorcerer,
    Warlock
}

/*
public enum CharacterClass
{
    Barbarian,
    Bard,
    Cleric,
    Druid,
    Fighter,
    Monk,
    Paladin,
    Ranger,
    Rogue,
    Sorcerer,
    Warlock,
    Wizard
}
*/
