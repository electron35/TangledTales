using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsLadder : MonoBehaviour
{
    public PlayerController pc;
    // Ce blueprint sert de tag suppl�mentaire
    public bool LadderActive = true;

    public void pcEject()
    {
        if (pc != null)
        {
            pc.stopClimb();
        }
        
    }
}
