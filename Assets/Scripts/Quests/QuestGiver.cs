using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class QuestUI
{
    public PlayerQuest player;
    public GameObject questWindow;

    public Text nameText;
    public Text descriptionText;
    public Text xpText;
    public Text currencyText;
    public Button accept;
    public Button decline;


}

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public QuestUI uI;

    public void OpenQuestWindow()
    {
        uI.questWindow.SetActive(true);
        uI.nameText.text = quest.name;
        uI.descriptionText.text = quest.description;
        uI.xpText.text = quest.xpReward.ToString();
        uI.currencyText.text = quest.currencyReward.ToString();
        //uI.accept.onClick.AddListener(AcceptQuest);
        //uI.decline.onClick.AddListener(DeclineQuest);

    }

    public void AcceptQuest()
    {
        uI.questWindow.SetActive(false);
        if (quest.state == QuestState.undiscovered)
        {
            quest.state = QuestState.accepted;
            uI.player.quests.Add(quest);
        }
    }

    public void DeclineQuest()
    {
        uI.questWindow.SetActive(false);
    }
}
