using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    public enum BodyPartType { Legs, Head, GrappelArm, GunArm, JetPack, Wing }
    [SerializeField] BodyPartType bodyPartType;

    public BodyPartType GetBodyPartType()
    {
        return bodyPartType;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player;
        collision.TryGetComponent<Player>(out player);
        player.RestoreBodyPart(this);
        gameObject.SetActive(false);
    }
}
