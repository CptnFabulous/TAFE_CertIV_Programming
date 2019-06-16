using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static List<Item> inv = new List<Item>();
    public static bool showInventory;
    public Item selectedItem;
    public static int money;

    public Vector2 screen;
    public Vector2 scrollPosition; // Scroll bar

    public string[] sortType = new string[7];
    public int index;
    public string sortingType = "All"; // for sorting stuff, could be done as an enum

    public Transform dropLocation;
    public Transform[] equippedLocation;

    public GameObject currentWeapon;
    public GameObject currentHelmet;

    sliderDelayHealthMeter healthMeter;
    
    // Start is called before the first frame update
    void Start()
    {
        sortType = new string[] { "All", "Food", "Weapons", "Apparel", "Crafting", "Quest", "Ingredients", "Potion", "Scroll" };
        
        // Spawns items into your inventory
        inv.Add(ItemData.CreateItem(0));
        inv.Add(ItemData.CreateItem(1));
        inv.Add(ItemData.CreateItem(2));
        inv.Add(ItemData.CreateItem(100));
        inv.Add(ItemData.CreateItem(101));
        inv.Add(ItemData.CreateItem(102));
        inv.Add(ItemData.CreateItem(200));
        inv.Add(ItemData.CreateItem(201));
        inv.Add(ItemData.CreateItem(202));
        inv.Add(ItemData.CreateItem(300));
        inv.Add(ItemData.CreateItem(301));
        inv.Add(ItemData.CreateItem(302));
        for (int i = 0; i < inv.Count; i++)
        {
            Debug.Log(inv[i].Name);
        }

        healthMeter = GetComponent<sliderDelayHealthMeter>();
    }

    public bool ToggleInventory()
    {
        if (showInventory)
        {
            showInventory = false;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Movement.canMove = true;
            return false;
        }
        else
        {
            if (screen.x != Screen.width / 16 || screen.y != Screen.height / 9) // Substitute 16 and 9 for actual aspect ratio data
            {
                screen.x = Screen.width / 16;
                screen.y = Screen.height / 9;
            }

            showInventory = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Movement.canMove = false;
            return true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // add separate code into the if statement if the game is paused
            ToggleInventory();

        }
    }

    void DisplayItem(Item selectedItem)
    {
        switch (selectedItem.Type)
        {
            case ItemType.Food:
                GUI.Box(new Rect(8 * screen.x, 5 * screen.y, 8 * screen.x, 4 * screen.y), selectedItem.Name + "\n" + selectedItem.Description + "\nValue: " + selectedItem.Value + "\nHeal: " + selectedItem.Heal + "\nAmount: " + selectedItem.Amount);
                if (healthMeter.healthCurrent < healthMeter.healthMax)
                {
                    if (GUI.Button(new Rect(15 * screen.x, 8.75f * screen.y, screen.x, 0.25f * screen.y), "Eat"))
                    {
                        healthMeter.healthCurrent += selectedItem.Heal;
                        DepleteItem(selectedItem, 1);
                    }
                }
                if (GUI.Button(new Rect(14 * screen.x, 8.75f * screen.y, screen.x, 0.25f * screen.y), "Discard"))
                {
                    Discard(selectedItem, 1);
                }
                break;
            case ItemType.Weapon:
                GUI.Box(new Rect(8 * screen.x, 5 * screen.y, 8 * screen.x, 4 * screen.y), selectedItem.Name + "\n" + selectedItem.Description + "\nValue: " + selectedItem.Value + "\nDamage: " + selectedItem.Damage + "\nAmount: " + selectedItem.Amount);
                if (currentWeapon == null || selectedItem.Mesh.name != currentWeapon.name)
                {
                    if (GUI.Button(new Rect(15 * screen.x, 8.75f * screen.y, screen.x, 0.25f * screen.y), "Equip"))
                    {
                        if (currentWeapon != null)
                        {
                            Destroy(currentWeapon);
                        }
                        currentWeapon = Instantiate(selectedItem.Mesh, equippedLocation[0]);
                        currentWeapon.GetComponent<ItemHandler>().enabled = false;
                        currentWeapon.name = selectedItem.Mesh.name;
                    }
                }
                if (GUI.Button(new Rect(14 * screen.x, 8.75f * screen.y, screen.x, 0.25f * screen.y), "Discard"))
                {
                    if (currentWeapon != null && selectedItem.Mesh.name == currentWeapon.name)
                    {
                        Destroy(currentWeapon);
                    }
                    Discard(selectedItem, 1);
                }
                break;
            case ItemType.Apparel:
                GUI.Box(new Rect(8 * screen.x, 5 * screen.y, 8 * screen.x, 4 * screen.y), selectedItem.Name + "\n" + selectedItem.Description + "\nValue: " + selectedItem.Value + "\nArmour: " + selectedItem.Armour + "\nAmount: " + selectedItem.Amount);
                if (currentHelmet == null || selectedItem.Mesh.name != currentHelmet.name)
                {
                    if (GUI.Button(new Rect(15 * screen.x, 8.75f * screen.y, screen.x, 0.25f * screen.y), "Equip"))
                    {
                        if (currentHelmet != null)
                        {
                            Destroy(currentHelmet);
                        }
                        currentHelmet = Instantiate(selectedItem.Mesh, equippedLocation[1]);
                        currentHelmet.GetComponent<ItemHandler>().enabled = false;
                        currentHelmet.name = selectedItem.Mesh.name;
                    }
                }
                if (GUI.Button(new Rect(14 * screen.x, 8.75f * screen.y, screen.x, 0.25f * screen.y), "Discard"))
                {
                    if (currentHelmet != null && selectedItem.Mesh.name == currentHelmet.name)
                    {
                        Destroy(currentHelmet);
                    }
                    Discard(selectedItem, 1);
                }
                break;
            case ItemType.Crafting:
                GUI.Box(new Rect(8 * screen.x, 5 * screen.y, 8 * screen.x, 4 * screen.y), selectedItem.Name + "\n" + selectedItem.Description + "\nValue: " + selectedItem.Value + "\nAmount: " + selectedItem.Amount);

                if (GUI.Button(new Rect(14 * screen.x, 8.75f * screen.y, screen.x, 0.25f * screen.y), "Discard"))
                {
                    Discard(selectedItem, 1);
                }
                break;
            case ItemType.Quest:
                GUI.Box(new Rect(8 * screen.x, 5 * screen.y, 8 * screen.x, 4 * screen.y), selectedItem.Name + "\n" + selectedItem.Description + "\nValue: " + selectedItem.Value + "\nAmount: " + selectedItem.Amount);

                if (GUI.Button(new Rect(14 * screen.x, 8.75f * screen.y, screen.x, 0.25f * screen.y), "Discard"))
                {
                    Discard(selectedItem, 1);
                }
                break;
            case ItemType.Ingredients:
                GUI.Box(new Rect(8 * screen.x, 5 * screen.y, 8 * screen.x, 4 * screen.y), selectedItem.Name + "\n" + selectedItem.Description + "\nValue: " + selectedItem.Value + "\nAmount: " + selectedItem.Amount);

                if (GUI.Button(new Rect(14 * screen.x, 8.75f * screen.y, screen.x, 0.25f * screen.y), "Discard"))
                {
                    Discard(selectedItem, 1);
                }
                break;
            case ItemType.Potions:
                GUI.Box(new Rect(8 * screen.x, 5 * screen.y, 8 * screen.x, 4 * screen.y), selectedItem.Name + "\n" + selectedItem.Description + "\nValue: " + selectedItem.Value + "\nAmount: " + selectedItem.Amount);

                if (GUI.Button(new Rect(14 * screen.x, 8.75f * screen.y, screen.x, 0.25f * screen.y), "Discard"))
                {
                    Discard(selectedItem, 1);
                }
                break;
            case ItemType.Scrolls:
                GUI.Box(new Rect(8 * screen.x, 5 * screen.y, 8 * screen.x, 4 * screen.y), selectedItem.Name + "\n" + selectedItem.Description + "\nValue: " + selectedItem.Value + "\nAmount: " + selectedItem.Amount);
                
                if (GUI.Button(new Rect(14 * screen.x, 8.75f * screen.y, screen.x, 0.25f * screen.y), "Discard"))
                {
                    Discard(selectedItem, 1);
                }
                break;

        }
    }

    void DepleteItem(Item item, int amountDepleted)
    {
        if (item.Amount > amountDepleted)
        {
            item.Amount -= amountDepleted;
        }
        else
        {
            inv.Remove(item);
            item = null;
        }
    }

    void Discard(Item itemToDiscard, int amountDiscarded)
    {
        GameObject clone = Instantiate(selectedItem.Mesh, dropLocation.position, Quaternion.identity);
        clone.AddComponent<Rigidbody>().useGravity = true;
        DepleteItem(itemToDiscard, amountDiscarded);
    }

    void DisplayInventory(string sortType)
    {
        if (!(sortType == "All" || sortType == ""))
        {
            #region Types
            ItemType type = (ItemType)System.Enum.Parse(typeof(ItemType), sortType);
            int amount = 0; //a, refers to amount of a certain item in the inventory
            int slot = 0; //s, refers to slot location in inventory
            for (int i = 0; i < inv.Count; i++)
            {
                if (inv[i].Type == type)
                {
                    amount++;
                }
            }

            if (amount <= 35) // The value 35 could be changed to a public integer in the inspector for changing the amount of slots. Or would it be better to have an array of slot gameobjects and 35 refers to array.count?
            {
                for (int i = 0; i < inv.Count; i++)
                {
                    if (inv[i].Type == type)
                    {
                        if (GUI.Button(new Rect(0.5f * screen.x, 0.25f * screen.y + slot * (0.25f * screen.y), 3 * screen.x, 0.25f * screen.y), inv[i].Name))
                        {
                            selectedItem = inv[i];
                            Debug.Log(selectedItem.Name);
                        }
                        slot++;
                    }
                }
            }
            else
            {
                scrollPosition = GUI.BeginScrollView(new Rect(0.5f * screen.x, 0.25f * screen.y, 3.5f * screen.x, 8.5f * screen.y), scrollPosition, new Rect(0, 0, 0, 8.5f * screen.y + ((amount - 34) * (0.25f * screen.y))), false, true);
                for (int i = 0; i < inv.Count; i++)
                {
                    if (inv[i].Type == type)
                    {
                        if (GUI.Button(new Rect(0 * screen.x, 0 * screen.y + slot * (0.25f * screen.y), 3 * screen.x, 0.25f * screen.y), inv[i].Name))
                        {
                            selectedItem = inv[i];
                            Debug.Log(selectedItem.Name);
                        }
                        slot++;
                    }
                }
                GUI.EndScrollView();
            }
            #endregion
        }
        else
        {
            if (inv.Count <= 34)
            {
                for (int i = 0; i < inv.Count; i++)
                {
                    if (GUI.Button(new Rect(0.5f * screen.x, 0.25f * screen.y + i * (0.25f * screen.y), 3 * screen.x, 0.25f * screen.y), inv[i].Name))
                    {
                        selectedItem = inv[i];
                        Debug.Log(selectedItem.Name);
                    }
                }
            }
            else
            {
                scrollPosition = GUI.BeginScrollView(new Rect(0.5f * screen.x, 0.25f * screen.y, 3.5f * screen.x, 8.5f * screen.y), scrollPosition, new Rect(0, 0, 0, 8.5f * screen.y + ((inv.Count - 34) * (0.25f * screen.y))), false, true);
                for (int i = 0; i < inv.Count; i++)
                {
                    if (GUI.Button(new Rect(0 * screen.x, 0 * screen.y + i * (0.25f * screen.y), 3 * screen.x, 0.25f * screen.y), inv[i].Name))
                    {
                        selectedItem = inv[i];
                        Debug.Log(selectedItem.Name);
                    }
                }
                GUI.EndScrollView();
            }
        }
    }
    

    private void OnGUI()
    {
        if (showInventory)
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Inventory");
            for (int i = 0; i < sortType.Length; i++)
            {
                if (GUI.Button(new Rect(5.5f * screen.x + i * (screen.x), 0.25f * screen.y, screen.x, 0.25f * screen.y), sortType[i]))
                {
                    sortingType = sortType[i];
                }
            }
            DisplayInventory(sortingType);

            if (selectedItem != null)
            {
                GUI.DrawTexture(new Rect(11 * screen.x, 1.5f * screen.y, 2 * screen.x, 2 * screen.y), selectedItem.Icon);
                DisplayItem(selectedItem);
            }
        }
    }
}
