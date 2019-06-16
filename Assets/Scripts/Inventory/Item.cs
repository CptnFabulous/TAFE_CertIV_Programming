//in this script  you will only need using UnityEngine as we just need the script to connect to unity
using UnityEngine;
//this public class doent inherit from MonoBehaviour
//this script is also referenced by other scripts but never attached to anything
public class Item
{
    //basic variables for items that we need are 
    #region Private Variables

    private int _id; //Identification Number
    private string _name; //Object Name
    private int _value; //Value of the Object
    private string _description; //Description of what the Object is
    private Texture2D _icon; //Icon that displays when that Object is in an Inventory
    private GameObject _mesh; //Mesh of that object when it is equipt or in the world
    private ItemType _type; //Enum ItemType which is the Type of object so we can classify them

    // Individual values for different item types. In a proper game you would make new inherited scripts for different item types e.g. itemWeapon, itemFood, etc., and add these variables to those scripts.
    private int _heal;
    private int _damage;
    private int _armour;
    private int _amount;

    #endregion

    #region Constructors
    public void ItemCon(int itemID, string itemName, Texture2D itemIcon, ItemType itemType)
    {
        _id = itemID;
        _name = itemName;
        _icon = itemIcon;
        _type = itemType;
    }
    //A constructor is a bit of code that allows you to create objects from a class. You call the constructor by using the keyword new 
    //followed by the name of the class, followed by any necessary parameters.
    //the Item needs Identification Number, Object Name, Icon and Type
    //here we connect the parameters with the item variables
    #endregion
    #region Public Variables
    //here we are creating the public versions or our private variables that we can reference and connect to when interacting with items

    public int ID //public Identification Number
    {
        get
        {
            return _id; //get the private Identification Number
        }
        set
        {
            _id = value; //and set it to the value of our public Identification Number
        }
    }

    public string Name //public Name
    {
        get
        {
            return _name; //get the private Name
        }
        set
        {
            _name = value; //and set it to the value of our public Name
        }
    }

    public int Value //public Value
    {
        get
        {
            return _value; //get the private Value
        }
        set
        {
            _value = value; //and set it to the value of our public Value
        }
    }

    public string Description //public Description
    {
        get
        {
            return _description; //get the private Description
        }
        set
        {
            _description = value; //and set it to the value of our public Description
        }
    }

    public Texture2D Icon //public Icon
    {
        get
        {
            return _icon; //get the private Icon
        }
        set
        {
            _icon = value; //and set it to the value of our public Icon
        }
    }

    public GameObject Mesh //public Mesh
    {
        get
        {
            return _mesh; //get the private Mesh
        }
        set
        {
            _mesh = value; //and set it to the value of our public Mesh
        }
    }

    public ItemType Type //public Type
    {
        get
        {
            return _type; //get the private Type
        }
        set
        {
            _type = value; //and set it to the value of our public Type
        }
    }

    // Individual values for different item types. In a proper game you would make new inherited scripts for different item types e.g. itemWeapon, itemFood, etc., and add these variables to those scripts.

    public int Heal
    {
        get
        {
            return _heal;
        }
        set
        {
            _heal = value;
        }
    }

    public int Damage
    {
        get
        {
            return _damage;
        }
        set
        {
            _damage = value;
        }
    }

    public int Armour
    {
        get
        {
            return _armour;
        }
        set
        {
            _armour = value;
        }
    }

    public int Amount
    {
        get
        {
            return _amount;
        }
        set
        {
            _amount = value;
        }
    }


    #endregion
}
#region Enums
public enum ItemType //The Global Enum ItemType that we have created categories in
{
    Food,
    Weapon,
    Apparel,
    Crafting,
    Quest,
    Money,
    Ingredients,
    Potions,
    Scrolls
}
#endregion
