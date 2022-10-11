using UnityEngine;
using Platformer.Mechanics;

public class PlatformerJumpPad : MonoBehaviour
{
    public float verticalVelocity;

    void OnTriggerEnter2D(Collider2D other)
    {
        var rb = other.attachedRigidbody;
        if (rb == null) return;
        var player = rb.GetComponent<PlayerControllerBackup>();
        if (player == null) return;
        AddVelocity(player);
    }

    void AddVelocity(PlayerControllerBackup player)
    {
        player.velocity.y = verticalVelocity;
    }
}
