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
    int skinIndex, eyesIndex, mouthIndex, hairIndex, armourIndex, clothesIndex; //index numbers for our current skin, hair, mouth, eyes textures

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
        SetTexture("Skin", skinIndex = 0);
        SetTexture("Eyes", eyesIndex  = 0);
        SetTexture("Mouth", mouthIndex = 0);
        SetTexture("Hair", hairIndex = 0);
        SetTexture("Armour", armourIndex = 0);
        SetTexture("Clothes", clothesIndex = 0);
        ChooseClass(0);

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

    void SetTexture(string type, int dir)
    {
        int index = 0, max = 0, matIndex = 0;
        Texture2D[] textures = new Texture2D[0];

        #region Switch Material

        switch(type)
        {
            case "Skin":
                index = skinIndex;
                max = skinMax;
                textures = skin.ToArray();
                matIndex = 1;
                break;
            case "Eyes":
                index = eyesIndex;
                max = eyesMax;
                textures = eyes.ToArray();
                matIndex = 2;
                break;
            case "Mouth":
                index = mouthIndex;
                max = mouthMax;
                textures = mouth.ToArray();
                matIndex = 3;
                break;
            case "Hair":
                index = hairIndex;
                max = hairMax;
                textures = hair.ToArray();
                matIndex = 4;
                break;
            case "Armour":
                index = armourIndex;
                max = armourMax;
                textures = armour.ToArray();
                matIndex = 5;
                break;
            case "Clothes":
                index = clothesIndex;
                max = clothesMax;
                textures = clothes.ToArray();
                matIndex = 6;
                break;
        }
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
        index += dir;
        if (index < 0)
        {
            index = max - 1;
        }
        if (index > max - 1)
        {
            index = 0;
        }
        Material[] mat = character.materials;
        mat[matIndex].mainTexture = textures[index];
        character.materials = mat;

        //outside our switch statement
        //index plus equals our direction
        //cap our index to loop back around if is is below 0 or above max take one
        //Material array is equal to our characters material list
        //our material arrays current material index's main texture is equal to our texture arrays current index
        //our characters materials are equal to the material array
        //create another switch that is goverened by the same string name of our material
        #endregion

        #region Set Material Switch

        switch (type)
        {
            case "Skin":
                skinIndex = index;
                break;
            case "Eyes":
                eyesIndex = index;
                break;
            case "Mouth":
                mouthIndex = index;
                break;
            case "Hair":
                hairIndex = index;
                break;
            case "Armour":
                armourIndex = index;
                break;
            case "Clothes":
                clothesIndex = index;
                break;
        }
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
    }
    #endregion

    #region Save
    void Save()
    {

    }
    //Function called Save this will allow us to save our indexes 
    //SetInt for SkinIndex, HairIndex, MouthIndex, EyesIndex
    //SetString CharacterName
    #endregion

    #region OnGUI
    private void OnGUI() //Function for our GUI elements
    {
        //create the floats scrW and scrH that govern our 16:9 ratio
        float screenW = Screen.width / 16;
        float screenH = Screen.height / 9;
        int i = 0; //create an int that will help with shuffling your GUI elements under eachother

        #region Set Skin
        if (GUI.Button(new Rect(0.25f * screenW, screenH + i * (0.5f * screenH), 0.5f * screenW, 0.5f * screenH), "<"))
        {
            SetTexture("Skin", -1);

        }

        GUI.Box(new Rect(0.75f * screenW, screenH + i * (0.5f * screenH), 1f * screenW, 0.5f * screenH), "Skin");

        if (GUI.Button(new Rect(1.75f * screenW, screenH + i * (0.5f * screenH), 0.5f * screenW, 0.5f * screenH), ">"))
        {
            SetTexture("Skin", 1);

        }
        #endregion
        i++;
        #region Set Eyes
        if (GUI.Button(new Rect(0.25f * screenW, screenH + i * (0.5f * screenH), 0.5f * screenW, 0.5f * screenH), "<"))
        {
            SetTexture("Eyes", -1);

        }

        GUI.Box(new Rect(0.75f * screenW, screenH + i * (0.5f * screenH), 1f * screenW, 0.5f * screenH), "Eyes");

        if (GUI.Button(new Rect(1.75f * screenW, screenH + i * (0.5f * screenH), 0.5f * screenW, 0.5f * screenH), ">"))
        {
            SetTexture("Eyes", 1);

        }
        #endregion
        i++;
        #region Set Mouth
        if (GUI.Button(new Rect(0.25f * screenW, screenH + i * (0.5f * screenH), 0.5f * screenW, 0.5f * screenH), "<"))
        {
            SetTexture("Mouth", -1);

        }

        GUI.Box(new Rect(0.75f * screenW, screenH + i * (0.5f * screenH), 1f * screenW, 0.5f * screenH), "Mouth");

        if (GUI.Button(new Rect(1.75f * screenW, screenH + i * (0.5f * screenH), 0.5f * screenW, 0.5f * screenH), ">"))
        {
            SetTexture("Mouth", 1);

        }
        #endregion
        i++;
        #region Set Hair
        if (GUI.Button(new Rect(0.25f * screenW, screenH + i * (0.5f * screenH), 0.5f * screenW, 0.5f * screenH), "<"))
        {
            SetTexture("Hair", -1);

        }

        GUI.Box(new Rect(0.75f * screenW, screenH + i * (0.5f * screenH), 1f * screenW, 0.5f * screenH), "Hair");

        if (GUI.Button(new Rect(1.75f * screenW, screenH + i * (0.5f * screenH), 0.5f * screenW, 0.5f * screenH), ">"))
        {
            SetTexture("Hair", 1);

        }
        #endregion
        i++;
        #region Set Armour
        if (GUI.Button(new Rect(0.25f * screenW, screenH + i * (0.5f * screenH), 0.5f * screenW, 0.5f * screenH), "<"))
        {
            SetTexture("Armour", -1);

        }

        GUI.Box(new Rect(0.75f * screenW, screenH + i * (0.5f * screenH), 1f * screenW, 0.5f * screenH), "Armour");

        if (GUI.Button(new Rect(1.75f * screenW, screenH + i * (0.5f * screenH), 0.5f * screenW, 0.5f * screenH), ">"))
        {
            SetTexture("Armour", 1);

        }
        #endregion
        i++;
        #region Set Clothes
        if (GUI.Button(new Rect(0.25f * screenW, screenH + i * (0.5f * screenH), 0.5f * screenW, 0.5f * screenH), "<"))
        {
            SetTexture("Clothes", -1);

        }

        GUI.Box(new Rect(0.75f * screenW, screenH + i * (0.5f * screenH), 1f * screenW, 0.5f * screenH), "Clothes");

        if (GUI.Button(new Rect(1.75f * screenW, screenH + i * (0.5f * screenH), 0.5f * screenW, 0.5f * screenH), ">"))
        {
            SetTexture("Clothes", 1);

        }
        #endregion
        i++;
        #region Random and Reset
        //create 2 buttons one Random and one Reset
        if (GUI.Button(new Rect(0.25f * screenW, screenH + i * (0.5f * screenH), screenW, 0.5f * screenH), "Random"))
        {
            //Random will feed a random amount to the direction
            SetTexture("Skin", skinIndex = Random.Range(0, skinMax - 1));
            SetTexture("Eyes", eyesIndex = Random.Range(0, eyesMax - 1));
            SetTexture("Mouth", mouthIndex = Random.Range(0, mouthMax - 1));
            SetTexture("Hair", hairIndex = Random.Range(0, hairMax - 1));
            SetTexture("Armour", armourIndex = Random.Range(0, armourMax - 1));
            SetTexture("Clothes", clothesIndex = Random.Range(0, clothesMax - 1));
        }

        if (GUI.Button(new Rect(1.25f * screenW, screenH + i * (0.5f * screenH), screenW, 0.5f * screenH), "Reset"))
        {
            //reset will set all to 0 both use SetTexture
            SetTexture("Skin", skinIndex = 0);
            SetTexture("Eyes", eyesIndex = 0);
            SetTexture("Mouth", mouthIndex = 0);
            SetTexture("Hair", hairIndex = 0);
            SetTexture("Armour", armourIndex = 0);
            SetTexture("Clothes", clothesIndex = 0);
        }
        #endregion
        i++;
        #region Name
        characterName = GUI.TextField(new Rect(0.25f * screenW, screenH + i * (0.5f * screenH), 2f * screenW, 0.5f * screenH), characterName, 16);
        #endregion
        i++;
        #region Save Character
        if (GUI.Button(new Rect(0.25f * screenW, screenH + i * (0.5f * screenH), 2f * screenW, 0.5f * screenH), "Save and Play"))
        {
            Save();
            SceneManager.LoadScene(2);
        }
        #endregion
        i = 0;

        GUI.Box(new Rect(3.75f * screenW, screenH + i * (0.5f * screenH), 3f * screenW, 0.5f * screenH), "Character Class");
        i++;
        //GUI.Box(new Rect(3.75f * screenW, screenH + i * (0.5f * screenH), 2f * screenW, 0.5f * screenH), selectedClass[selectedIndex]);

        if (GUI.Button(new Rect(3.75f * screenW, screenH + i * (0.5f * screenH), 0.5f * screenW, 0.5f * screenH), "<"))
        {
            selectedIndex--;
            if (selectedIndex < 0)
            {
                selectedIndex = selectedClass.Length - 1;
            }
            ChooseClass(selectedIndex);
        }

        GUI.Box(new Rect(4.25f * screenW, screenH + i * (0.5f * screenH), 2f * screenW, 0.5f * screenH), selectedClass[selectedIndex]);

        if (GUI.Button(new Rect(6.25f * screenW, screenH + i * (0.5f * screenH), 0.5f * screenW, 0.5f * screenH), ">"))
        {
            selectedIndex++;
            if (selectedIndex > selectedClass.Length - 1)
            {
                selectedIndex = 0;
            }
            ChooseClass(selectedIndex);
        }

        GUI.Box(new Rect(3.75f * screenW, 2f * screenH, 2f * screenW, 0.5f * screenH), "Points: " + skillPoints);

        for (int s = 0; s < 6; s++)
        {
            if (skillPoints > 0)
            {
                if (GUI.Button(new Rect(), "+"))
                {
                    skillPoints--;
                    tempStats[s]++;
                }
            }
            GUI.Box(new Rect(3.75f * screenW, 2.5f * screenH + s * (0.5f * screenH), 2f * screenW, 0.5f * screenH), statArray[s] + ": " + tempStats[s] + stats[s]);
        }


        //i++;

        





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



        //move down the screen with the int using ++ each grouping of GUI elements are moved using this
        #endregion
    }

    void ChooseClass(int className)
    {
        switch(className)
        {
            case 0:
                stats[0] = 15;
                stats[1] = 10;
                stats[2] = 10;
                stats[3] = 10;
                stats[4] = 10;
                stats[5] = 5;
                charClass = CharacterClass.Barbarian;
                break;
            case 1:
                stats[0] = 5;
                stats[1] = 10;
                stats[2] = 10;
                stats[3] = 10;
                stats[4] = 10;
                stats[5] = 9999999;
                charClass = CharacterClass.Bard;
                break;
            case 2:
                stats[0] = 15;
                stats[1] = 10;
                stats[2] = 10;
                stats[3] = 10;
                stats[4] = 4325;
                stats[5] = 5;
                charClass = CharacterClass.Druid;
                break;
            case 3:
                stats[0] = 15;
                stats[1] = 435435435;
                stats[2] = 10;
                stats[3] = 5647385;
                stats[4] = 10;
                stats[5] = 5;
                charClass = CharacterClass.Monk;
                break;
            case 4:
                stats[0] = 15;
                stats[1] = 15;
                stats[2] = 15;
                stats[3] = 15;
                stats[4] = 15;
                stats[5] = 15;
                charClass = CharacterClass.Paladin;
                break;
            case 5:
                stats[0] = 1234576890;
                stats[1] = 10;
                stats[2] = 10;
                stats[3] = 10;
                stats[4] = 10;
                stats[5] = 5;
                charClass = CharacterClass.Ranger;
                break;
            case 6:
                stats[0] = 15;
                stats[1] = 10;
                stats[2] = 234567;
                stats[3] = 32;
                stats[4] = 10;
                stats[5] = 5;
                charClass = CharacterClass.Sorcerer;
                break;
            case 7:
                stats[0] = 99999999;
                stats[1] = 99999999;
                stats[2] = 99999999;
                stats[3] = 99999999;
                stats[4] = 99999999;
                stats[5] = 99999999;
                charClass = CharacterClass.Warlock;
                break;
        }
    }





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
