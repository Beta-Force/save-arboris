using UnityEngine;
using UnityEngine.Events;

public class TriggerPlate : MonoBehaviour
{
    public UnityEvent Activated; 
    public UnityEvent Deactivated;

    [SerializeField] private SpriteRenderer visualSprite;
    [SerializeField] private Sprite spriteDeactivated, spriteActivated;
    [SerializeField] private LayerMask layersToCompare;
    [SerializeField] private float distanceToActivate;

    private bool colliding = false;
    private GameObject collidingObj;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(((1 << collision.gameObject.layer) & layersToCompare) != 0)
        {
            print(Vector3.Distance(transform.position, collision.transform.position));
            if (Vector3.Distance(transform.position, collision.transform.position) < distanceToActivate && !colliding)
            {
                // Setup some visuals when activated (sprites or animation or particles) 
                visualSprite.sprite = spriteActivated;

                colliding = true;

                collidingObj = collision.gameObject;
                //print(collidingObj);
                Activated?.Invoke();
            }         
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(((1 << collision.gameObject.layer) & layersToCompare) != 0)
        {
            if (collidingObj != null && Vector3.Distance(transform.position, collidingObj.transform.position) > distanceToActivate)
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
