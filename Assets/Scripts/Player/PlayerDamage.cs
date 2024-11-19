using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public void DamagePlayer()
    {
        System.Random random = new System.Random();
        int sortedValue = random.Next(0, 2);
        int directionX = sortedValue == 0 ? -1000 : 1000;
        PlayerManager.playerAnimation.PlayDamage();
        PlayerManager.instance.ResetPhysicsVelociy();
        PlayerManager.instance.ThrowPlayer(directionX,1000);

        CanvasManager.instance.DecrementPlayerLife();
    }
}
