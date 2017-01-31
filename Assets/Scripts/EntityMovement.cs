using System.Collections;
using UnityEngine;
using System;

public class EntityMovement : MonoBehaviour
{

    private Camera camera;
    [SerializeField]
    private float movementSpeed = 1;

    [SerializeField]
    private bool doMove = true;

    private Rigidbody2D rb;
    private IsMergeable mergeScript;

    private Action<Vector3, float> applyTranslation;

    private readonly WaitForFixedUpdate _fixedUpdate = new WaitForFixedUpdate();

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        mergeScript = GetComponent<IsMergeable>();
    }

    void Start()
    {
        if (rb != null)
        {
            applyTranslation = (Vector3 dest, float speed) =>
            {
                if (doMove == true)
                {
                    rb.velocity =
                        -new Vector2(transform.position.x - dest.x, transform.position.y - dest.y).normalized * speed;
                    /*if (Vector3.Distance(transform.position, dest) > 1f) {
                        mergeScript.CanMerge = true;
                    } else {
                        mergeScript.CanMerge = false;
                    }*/
                }
            };
        }
        else
        {
            applyTranslation = (Vector3 dest, float speed) => {
                StartCoroutine(MoveEnitity(dest * speed));
            };
        }
    }

    public void MoveTo(Vector3 clickPos)
    {
        applyTranslation(clickPos, movementSpeed);
    }

    public void resetVelocity()
    {
        rb.velocity = Vector2.zero;
    }

    IEnumerator BounceCooldown()
    {
            doMove = false;
            yield return new WaitForSeconds(.5f);
            doMove = true;
     
    }

    IEnumerator MoveEnitity(Vector3 dest)
    {
        while (transform.position != dest)
        {
            transform.Translate(dest / movementSpeed);
            yield return _fixedUpdate;
        }
    }

    public void PlayerMerged(PlayerMerge pMerge, IsMergeable mergeScript)
    { 
        Bounce(mergeScript);
    }


    void Bounce(IsMergeable mergeScript)
    {
        Vector2 mergepos = (Vector2)mergeScript.gameObject.transform.position;
        Vector2 distance = (mergepos - (Vector2)transform.position);
        applyTranslation((Vector2) (mergepos + distance), -2);
        StartCoroutine(BounceCooldown());
    }

}
