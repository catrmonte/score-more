using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour {

    public PlayerMovement movement;
    public Text specialTextObject;
    private specialText specTex;

    public delegate void PlayerCollided();
    public static event PlayerCollided OnPlayerCollided;

    void OnCollisionEnter(Collision collisionInfo) // gets info on item colliding into
    {
        if (collisionInfo.collider.tag == "Obstacle") // check to see if it's Obstacle
        {
            GetComponent<PlayerMovement>().enabled = false;
            //pecialText.GetComponent<specialText>
            specTex = specialTextObject.GetComponent<specialText>();
            specTex.collided = true;

            if (OnPlayerCollided != null)
            {
                OnPlayerCollided();
            }

            FindObjectOfType<GameManager>().EndGame();
        }
    }

}
