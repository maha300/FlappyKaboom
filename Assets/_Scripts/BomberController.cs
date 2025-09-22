using UnityEngine;

public class BomberController : MonoBehaviour

{
    public float speed = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
