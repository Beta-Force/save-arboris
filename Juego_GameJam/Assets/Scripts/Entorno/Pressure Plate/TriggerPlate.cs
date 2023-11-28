using UnityEngine;
using UnityEngine.Events;

public class TriggerPlate : MonoBehaviour
{
    public UnityEvent Activated; 
    public UnityEvent Deactivated;

    [SerializeField] private SpriteRenderer visualSprite;
    [SerializeField] private Sprite spriteDeactivated, spriteActivated;
    [SerializeField] private LayerMask layersToCompare;

    private bool colliding = false;
    private GameObject collidingObj;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(((1 << collision.gameObject.layer) & layersToCompare) != 0)
        {
            if (Vector3.Distance(transform.position, collision.transform.position) < 0.2f && !colliding)
            {
                // Setup some visuals when activated (sprites or animation or particles) 
                visualSprite.sprite = spriteActivated;

                colliding = true;

                collidingObj = collision.gameObject;

                Activated?.Invoke();
            }         
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(((1 << collision.gameObject.layer) & layersToCompare) != 0)
        {
            if (Vector3.Distance(transform.position, collidingObj.transform.position) > 0.2f)
            {
                // Setup some visuals when activated (sprites or animation or particles)
                visualSprite.sprite = spriteDeactivated;
                colliding = false;

                collidingObj = null;
                Deactivated?.Invoke();
            }
        }
    }
}
