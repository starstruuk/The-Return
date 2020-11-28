using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locations : MonoBehaviour
{
    public string locationName;

    [TextArea]
    public string description;

    public Directions[] directions;

    public List<Interactable> interactables = new List<Interactable>();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetItems()
    {
        if (interactables.Count == 0)
        {
            return "";
        }
        string result = "You see ";
        bool first = true;

        foreach (Interactable interactable in interactables)
        {   
            if (first)
                result+= interactable.description;
            if (!first)
            {
                result += " and "+interactable.description;
            }
            
            first = false;
        }

        return result;
    }
    public string GetDirections()
    {
        string result = "";
        foreach (Directions direction in directions)
        {
            if (direction.directionsEnabled)
            {
                result+= direction.description + "\n";
            }

        }

        return result;
    }

    public Directions GetDirection(string directionNoun)
    {
        foreach(Directions direction in directions)
        {
            if (direction.directionName.ToLower() == directionNoun.ToLower())
            {
                return direction;
            }
        }
        return null;
    }

    internal bool HasInteractable(Interactable interToCheck)
    {
        foreach(Interactable interactable in interactables)
        {
            if(interactable == interToCheck && interactable.interacatableEnabled)
                return true;

        }

        return false;
    }

}
