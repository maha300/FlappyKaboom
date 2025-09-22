using UnityEngine;
using TMPro;

public class BirdController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 0.5f;
    private Vector2 initPos;
    public TMP_Text scoreText;
    void Start()
    {
        initPos = gameObject.transform.position;
        Debug.Log("Bird has been loaded");
    }

    // Update is called once per frame
    void Update()
    {
        //Create a new vector where we modify x position
        //of our game object
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector2 pos = new Vector2(
                gameObject.transform.position.x + speed,
                gameObject.transform.position.y);
            //Assign new position vector to game object
            gameObject.transform.position = pos;

        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector2 pos = new Vector2(
                gameObject.transform.position.x - speed,
                gameObject.transform.position.y);
            //Assign new position vector to game object
            gameObject.transform.position = pos;

        }

        else if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector2 pos = new Vector2(
                gameObject.transform.position.x,
                gameObject.transform.position.y + speed);
            //Assign new position vector to game object
            gameObject.transform.position = pos;

        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector2 pos = new Vector2(
                gameObject.transform.position.x,
                gameObject.transform.position.y - speed);
            //Assign new position vector to game object
            gameObject.transform.position = pos;

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            //Play the death sound
            //gameObject.GetComponent<AudioSource>().Play();

            //Move bird back to initial position
            //gameObject.transform.position = initPos;
            //Destroy(gameObject);
            //On collision, subtract 25 points
            int score = int.Parse(scoreText.text);
            score = score - 25;
            scoreText.text = score.ToString();

        }

    }
    private void Die()
    {
        //Play Death sound
        gameObject.GetComponent<AudioSource>().Play();

        //Make bird flip
        gameObject.GetComponent<SpriteRenderer>().flipY = true;

        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;

    }
}
