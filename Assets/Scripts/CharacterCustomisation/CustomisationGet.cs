using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //you will need to change Scenes

public class CustomisationGet : MonoBehaviour {

    [Header("Character")]
    public Renderer character; //public variable for the Skinned Mesh Renderer which is our character reference


    #region Start
    private void Start()
    {
        character = GameObject.FindGameObjectWithTag("PlayerMesh").GetComponent<SkinnedMeshRenderer>(); //our character reference connected to the Skinned Mesh Renderer via finding the Mesh
        LoadTexture(); //Run the function LoadTexture
    }
    #endregion

    #region LoadTexture Function
    void LoadTexture()
    {
        if (CharacterSave.LoadData() != null) //check to see if our save file for this character
        {
            CharacterData dataToLoad = CharacterSave.LoadData();
            print(dataToLoad);

            //if it does have a save file then load and SetTexture Skin, Hair, Mouth and Eyes from PlayerPrefs

            SetTexture("Skin", dataToLoad.skinIndex);
            SetTexture("Eyes", dataToLoad.mouthIndex);
            SetTexture("Mouth", dataToLoad.eyesIndex);
            SetTexture("Hair", dataToLoad.hairIndex);
            SetTexture("Armour", dataToLoad.armourIndex);
            SetTexture("Clothes", dataToLoad.clothesIndex);

            character.gameObject.GetComponentInParent<GameObject>().name = dataToLoad.characterName; //grab the gameObject in scene that is our character and set its Object name to the Characters name
        }
        else
        {
            SceneManager.LoadScene("CharacterCustomisation"); //if it doesnt then load the CustomSet level
        }
    }
    #endregion

    #region SetTexture


    //Create a function that is called SetTexture it should contain a string and int
    //the string is the name of the material we are editing, the int is the direction we are changing
    void SetTexture(string type, int index)
    {

        Texture2D tempTexture = null; //we need variables that exist only within this function
        int matIndex = 0; //these are int material index and Texture2D array of textures

        switch(type) //inside a switch statement that is swapped by the string name of our material
        {
            case "Skin": //case skin      
                tempTexture = Resources.Load("Character/Skin_" + index) as Texture2D; //textures is our Resource.Load Character Skin save index we loaded in set as our Texture2D
                matIndex = 1; //material index element number is 1
            break; //break
            case "Eyes": //case eyes
                tempTexture = Resources.Load("Character/Eyes_" + index) as Texture2D; //textures is our Resource.Load Character Skin save index we loaded in set as our Texture2D
                matIndex = 2; //material index element number is 1
                break; //break
            case "Mouth": //case mouth
                tempTexture = Resources.Load("Character/Mouth_" + index) as Texture2D; //textures is our Resource.Load Character Skin save index we loaded in set as our Texture2D
                matIndex = 3; //material index element number is 1
            break; //break
            case "Hair": //case hair
                tempTexture = Resources.Load("Character/Hair_" + index) as Texture2D; //textures is our Resource.Load Character Skin save index we loaded in set as our Texture2D
                matIndex = 4; //material index element number is 1
            break; //break
            case "Armour": //case armour 
                tempTexture = Resources.Load("Character/Armour_" + index) as Texture2D; //textures is our Resource.Load Character Skin save index we loaded in set as our Texture2D
                matIndex = 5; //material index element number is 1
            break; //break
            case "Clothes": //case skin
                tempTexture = Resources.Load("Character/Clothes_" + index) as Texture2D; //textures is our Resource.Load Character Skin save index we loaded in set as our Texture2D
                matIndex = 6; //material index element number is 1
            break; //break
        }

        
        //now repeat for each material 
        //hair is 2
        //mouth is 3
        //eyes are 4





        //Material array is equal to our characters material list
        //our material arrays current material index's main texture is equal to our texture arrays current index
        //our characters materials are equal to the material array

    }

    #endregion
}
