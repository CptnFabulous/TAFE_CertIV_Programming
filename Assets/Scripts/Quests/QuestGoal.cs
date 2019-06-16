[System.Serializable]

public enum GoalType
{
    defeatEnemy,
    collectItem,
    travelToLocation,
    talkToPerson,
    interactWithObject
}
[System.Serializable]

public class QuestGoal
{
    public GoalType type;

    public int requiredAmount;
    public int currentAmount;

    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }

    public void EnemyKilled()
    {
        if (type == GoalType.defeatEnemy)
        {
            currentAmount++;
        }
    }

    public void ObjectCollected()
    {
        if (type == GoalType.collectItem)
        {
            currentAmount++;
        }
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
