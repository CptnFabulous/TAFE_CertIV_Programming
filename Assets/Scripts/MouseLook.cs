using UnityEngine;
using System.Collections;
//this script can be found in the Component section under the option Intro PRG/Mouse Look



[AddComponentMenu("Intro PRG/RPG/Player/Mouse Look")]



//Creating an enum out side the script and making it public means it can be asessed anywhere in any script with out reference

public class MouseLook : MonoBehaviour
{
    //Before you write this section please scroll to the bottom of the page
    #region Variables
    //[Header("Rotational Axis")]
    //create a public link to the rotational axis called axis and set a defualt axis

    //[Header("Sensitivity")]
    //public floats for our x and y sensitivity

    //[Header("Y Rotation Clamp")]
    //max and min Y rotation

    //we will have to invert our mouse position later to calculate our mouse look correctly
    //float for rotation Y

    [Header("Rotational Axis")]

    public Axes rotAx;

    [Header("Sensitivity")]

    [Range(0, 20)]
    public float sensitivityX;
    [Range(0, 20)]
    public float sensitivityY;

    [Header("Y rotation Clamp")]
    public float minY;
    public float maxY;

    float rotationY;

    #endregion
    #region Start

    private void Start()
    {
        if (this.GetComponent<Rigidbody>())
        {
            this.GetComponent<Rigidbody>().freezeRotation = true; // 'this.thing' is specified to show that it affect the gameobject this code is attached to. This is unnceccesary and only needed when referencing a different object
        }
    }

    //if our game object has a rigidbody attached to it

    //set the rigidbodys freezRotaion to true

    #endregion
    #region Update
    private void Update()
    {
        //if (GetComponent<Movement>().canMove == true)
        if (Movement.canMove == true) // This was changed to a static variable, use the above line if non-static
        {
            #region Mouse X and Y
            if (rotAx == Axes.mouseXY) //if our axis is set to Mouse X and Y
            {
                float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX; //float rotation x is equal to our y axis plus the mouse input on the Mouse X times our x sensitivity
                rotationY += Input.GetAxis("Mouse Y") * sensitivityY; //our rotation Y is plus equals our mouse input for Mouse Y times Y sensitivity
                rotationY = Mathf.Clamp(rotationY, minY, maxY); //the rotation Y is clamped using Mathf and we are clamping the y rotation to the Y min and Y max
                transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0); //transform our local position to the nex vector3 rotaion - y rotaion on the x axis and x rotation on the y axis
            }
            #endregion

            #region Mouse X
            else if (rotAx == Axes.mouseX) //else if we are rotating on the X
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0); //transform the rotation on our game objects Y by our Mouse input Mouse X times X sensitivity
            }   //x                y                          z
            #endregion

            #region Mouse Y
            else if (rotAx == Axes.mouseY) //else we are only rotation on the Y
            {
                rotationY += Input.GetAxis("Mouse Y") * sensitivityY; //our rotation Y is pulse equals  our mouse input for Mouse Y times Y sensitivity
                rotationY = Mathf.Clamp(rotationY, minY, maxY); //the rotation Y is clamped using Mathf and we are clamping the y rotation to the Y min and Y max
                transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0); //transform our local position to the nex vector3 rotaion - y rotaion on the x axis and local euler angle Y on the y axis

            }
            #endregion
        }

    }
    #endregion

}

#region RotationalAxis
/*
enums are what we call state value variables 
they are comma separated lists of identifiers
we can use them to create Type or Category variables
meaning each heading of the list is a type or category element that this can be
eg weapons in an inventory are a type of inventory item
if the item is a weapon we can equipt it
if it is a consumable we can drink it
it runs different code depending on what that objects enum is set to
you can also have subtypes within those types
eg weapons are an inventory category or type
we can then have ranged, melee weapons
or daggers, short swords, long swords, mace, axe, great axe, war axe and so on
each Type or Category holds different infomation the game needs like 
what animation plays, where the hands sit on the weapon, how many hands sit on the weapon and so on
*/
//Create a public enum called RotationalAxis

public enum Axes
{
    mouseX,
    mouseY,
    mouseXY
}

#endregion











