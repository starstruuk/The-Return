using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string interactableName;
    [TextArea]
    public string description;
    public bool playerPickUp;
    public bool interacatableEnabled = true;

    public bool playerCanTalkTo = false;
    public bool playerCanGiveTo = false;

    public bool playerCanRead = false;
    public Interactable targetInteractable = null;
    
    public Interactions[] interactions;

    public bool InteractionWith(GameController controller, string actionKeyword, string intr = "")
    {
        foreach (Interactions interaction in interactions)
        {
            if(interaction.action.keyword == actionKeyword)
            {
                if(intr!="" && intr.ToLower()!= interaction.textToReply.ToLower())
                    continue;

                foreach(Interactable disableInteractable in interaction.interactablesToDisable)
                    disableInteractable.interacatableEnabled = false;

                foreach(Interactable enableInteractable in interaction.interactablesToEnable)
                    enableInteractable.interacatableEnabled = true;
                
                foreach(Directions disableDirection in interaction.directionsToDisable)
                    disableDirection.directionsEnabled = false;

                foreach(Directions enableDirection in interaction.directionsToEnable)
                    enableDirection.directionsEnabled = true;

                if (interaction.locationToTeleport!=null)
                    controller.player.Teleport(controller, interaction.locationToTeleport);
                    
                controller.currentText.text = interaction.response;
                controller.DisplayLocation(true);
                return true;
                
            }
        }

        return false;
    }
}
