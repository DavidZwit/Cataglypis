using UnityEngine;
using System.Collections;
/// <summary>
/// This class is responsible for the dashing movement and setting it off if the object hits a collider.
/// Object must have a rigidbody2d to work.
/// </summary>
public class Dash : MonoBehaviour {

    //Variables that can be edited in the editor.
    [SerializeField]
    private float dashingSpeed;
    [SerializeField]
    private float friction = 1;


    //Variables needed for the calculations.
    private Rigidbody2D rigidBody;

    void Start()
    {
        //rigidbody is declared.
        rigidBody = GetComponent<Rigidbody2D>();
    }

    //REMOVE THIS FUNCTION, ONLY FOR TESTING!
    /*
    void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
            Dashing(new Vector2(Random.Range(-10, 10), Random.Range(-10, 10)));
    }
    */
    
    //function called from the swipe control script. parameter is the direction the swipe is headed.
    public void Dashing(Vector2 direction)
    {   
        //normalise the direction vector.
        direction.Normalize();
        //Multiplies it with the speed.
        direction *= dashingSpeed;

        //drag is declared (friction to slow down the object).
        rigidBody.drag = friction;
        //velocity is declared direction.        
        rigidBody.velocity = direction;
    }
}
