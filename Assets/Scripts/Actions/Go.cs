using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Go")]
public class Go : Actions
{
     public override void RespondToInput(GameController controller, string action)
    {
        if (controller.player.ChangeLocation(controller,action))
        {
            controller.DisplayLocation();
        }
        else{
            controller.currentText.text = "You can't go that way.";
        }
    }
}
