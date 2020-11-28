using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Help")]
public class Help : Actions
{
    public override void RespondToInput(GameController controller, string action)
    {
        controller.currentText.text = "Type an action followed by a noun (for example, \"go north\")";
        controller.currentText.text = "\nAllowed actions:\ngo, examine, get, use, inventory, say, help, talkto, read";
    }
}
