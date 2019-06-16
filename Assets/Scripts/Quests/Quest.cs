[System.Serializable]

public enum QuestState
{
    undiscovered,
    accepted,
    completed,
    failed,
    claimed
}
[System.Serializable]

public class Quest
{
    // state of quest
    public QuestState state = QuestState.undiscovered;
    public string name; // name
    public string description; // description

    public int xpReward; // xpReward
    public int currencyReward; // currencyReward

    //public QuestGoal[] goals;
    public QuestGoal goal;
    // goal
    // complete

    public void Complete()
    {
        state = QuestState.completed;
    }



   
}
