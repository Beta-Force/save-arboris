using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class HoyoTapado : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase nuevoSprite;
    public Collider2D Hoyo;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("piedra");
        if (other.transform.CompareTag("Piedra") && Hoyo.enabled == true)
        {
            Vector3Int tilePosition = tilemap.WorldToCell(transform.position);
            tilemap.SetTile(tilePosition, nuevoSprite);

            Destroy(other.gameObject);
            Hoyo.enabled = false;

        }
    }


}
