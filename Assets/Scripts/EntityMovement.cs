using System.Collections;
using UnityEngine;
using System;

public class EntityMovement : MonoBehaviour
{
    private Camera camera;
    [SerializeField]
    private float movementSpeed = 1;
    [SerializeField]
    private float dashSpeed = 5;
    [SerializeField]
    private float dashCooldownTime = .3f;
    private float currDashCooldownTime;

    private Rigidbody2D rb;
    private IsMergeable mergeScript;

    private Action<Vector3, float> applyTranslation;

    private readonly WaitForFixedUpdate _fixedUpdate = new WaitForFixedUpdate();

    private Coroutine _dashCoolDown;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        mergeScript = GetComponent<IsMergeable>();
    }

    void Start()
    {
        if (rb != null) {
            applyTranslation = (Vector3 dest, float speed) => {
                rb.velocity = -new Vector2(transform.position.x - dest.x, transform.position.y - dest.y).normalized * speed;
            };
        } else {
            applyTranslation = (Vector3 dest, float speed) => {
                StartCoroutine(MoveEnitity(dest * speed));
            };
        }
    }

    public void Dash(Vector2 clickPos, float speed)
    {

        if (applyTranslation != null)
            applyTranslation(clickPos, dashSpeed);
        mergeScript.CanMerge = true;

        if (rb != null)
        {
            if (_dashCoolDown != null) _dashCoolDown = null;
            print(_dashCoolDown);
            _dashCoolDown = StartCoroutine(DashCoolDown());
        }

    }

    public void MoveTo(Vector3 clickPos)
    {
        //if (mergeScript.CanMerge == false || currDashCooldownTime <= 0) {
        if (Vector2.Distance(transform.position, clickPos) > .2)
            applyTranslation(clickPos, movementSpeed);
        //}
    }

    IEnumerator DashCoolDown()
    {
        currDashCooldownTime = dashCooldownTime;
        while (rb.velocity.x > 1 || rb.velocity.x < 1 || rb.velocity.y < -1 || rb.velocity.y > 1) {
            currDashCooldownTime -= Time.deltaTime;

            if (mergeScript.CanMerge == false) break;
            yield return _fixedUpdate;
        }

        mergeScript.CanMerge = false;
        _dashCoolDown = null;
    }

    IEnumerator MoveEnitity (Vector3 dest)
    {
        while (transform.position != dest)
        {
            transform.Translate(dest / movementSpeed);
            yield return _fixedUpdate;
        }
    }

    public void PlayerMerged(IsMergeable mergeScript)
    {
        CancleDash();
        Bounce(mergeScript);
    }

    void CancleDash()
    {
        mergeScript.CanMerge = false;
    }

    void Bounce(IsMergeable mergeScript)
    {
        Vector3 mergepos = mergeScript.gameObject.transform.position;
        Vector3 distance = new Vector3(mergepos.x - transform.position.x, mergepos.y - transform.position.y, 0).normalized;
        transform.position = mergepos + distance;
    }

}
