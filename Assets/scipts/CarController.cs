using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 4;
    [SerializeField] private float acceleration = 10;
    [SerializeField] private Camera texturecamera;
    private RenderTexture texture;
    private Texture2D tex;
    int x = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Physics enginge will not rotate Crab
        rb.freezeRotation = true;
        // remove gravity
        rb.gravityScale = 0;
        texture = texturecamera.targetTexture;
        tex = new Texture2D(256, 256 ,TextureFormat.RGBA32,1,false);
        
        Graphics.CopyTexture(texture, tex);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.drag = 10;
        rb.angularDrag = 10;
        float angleRadians = rb.rotation * Mathf.PI / 180f;
        float xSpeed = Mathf.Cos(angleRadians) * speed;
        float ySpeed = Mathf.Sin(angleRadians) * speed;
  
        if (Input.GetKey(KeyCode.W))
        {
            // walk
            rb.AddForce (new Vector2(xSpeed, ySpeed));
       
        }
        if (Input.GetKey(KeyCode.A))
        {
            // and turn left
            rb.rotation += 2;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // and turn right
            rb.rotation -= 2;
        }
        //texture.GetPixel(0,0);

        Debug.Log(tex.GetPixel(x, x));
        x = x + 10;
    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Road")
        {
            rb.drag = 5;
            rb.angularDrag = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //other.gameObject.GetSpriteRenderer
        if (other.gameObject.name == "Road")
        {
            rb.drag = 1;
            rb.angularDrag = 5;
        }
    }*/

}
