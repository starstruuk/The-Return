using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Locations playerLocation;
    public List<Interactable> inventory = new List<Interactable>();

    public bool ChangeLocation(GameController controller, string directionNoun)
    {
        Directions direction = playerLocation.GetDirection(directionNoun);
        if (direction!=null)
        {   if (direction.directionsEnabled)
            {
                playerLocation = direction.location;
                return true;
            }
        }
        return false;
    }

    public void Teleport(GameController controller, Locations destination)
    {
        playerLocation = destination;
    }

    internal bool CanUseInteractable(GameController controller, Interactable inter) 
    {
        if(inter.targetInteractable == null)
            return true;
        if(HasInteractable(inter.targetInteractable))
            return true;
        if (playerLocation.HasInteractable(inter.targetInteractable))
            return true;
        return false;
    
    }

    private bool HasInteractable(Interactable interToCheck)
    {
        foreach(Interactable interactable in inventory)
        {
            if(interactable == interToCheck && interactable.interacatableEnabled)
                return true;

        }

        return false;
    }

    internal bool CanTalkToInteractable(GameController controller, Interactable inter) {
        return inter.playerCanTalkTo;
    }

    internal bool CanReadInteractable(GameController controller, Interactable inter){
        return inter.playerCanRead;
    }
    internal bool CanGiveToInteractable(GameController controller, Interactable inter) {
        return inter.playerCanGiveTo;
    }

    public bool HasItemByName (string intr) {
        {
            foreach (Interactable interactable in inventory)
            {
                if(interactable.interactableName.ToLower() == intr.ToLower())
                    return true;
                
            }
            return false;
        }
    }
}
