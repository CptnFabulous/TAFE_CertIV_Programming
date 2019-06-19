using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterData
{
    public string characterName;
    public int skinIndex, eyesIndex, mouthIndex, hairIndex, armourIndex, clothesIndex; //index numbers for our current skin, hair, mouth, eyes textures
    public int[] stats = new int[6];
    public int skillPoints;
    public CharacterClass charClass;
    
    public CharacterData(CustomisationSet player)
    {
        skinIndex = player.skinIndex;
        eyesIndex = player.eyesIndex;
        mouthIndex = player.mouthIndex;
        hairIndex = player.hairIndex;
        armourIndex = player.armourIndex;
        clothesIndex = player.clothesIndex;

        for (int i = 0; i <= player.stats.Length - 1; i++)
        {
            stats[i] = player.stats[i] + player.tempStats[i];
        }

        skillPoints = player.skillPoints;

        charClass = player.charClass;
    }


}