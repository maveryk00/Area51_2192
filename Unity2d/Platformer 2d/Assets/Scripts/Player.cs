using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rbody2D;

    public float speed = 1f;
    public Animator animator;

    public bool grounded {
        get {
            return RoundAbsoluteToZero(rbody2D.velocity.y) == 0f;
        }
    }

    // Start is called before the first frame update
    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        float h = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        animator.SetBool("walk", (h != 0));
        animator.SetBool("jump", !grounded);
        animator.SetFloat("vertical", Mathf.Sign(rbody2D.velocity.y));

        if (h != 0) { spriteRenderer.flipX = (h < 0); }

        //transform.Translate(Vector3.right * h * speed);
        MyTranslate(Vector3.right * h * speed);

        if (grounded && Input.GetKeyDown(KeyCode.Space))
            rbody2D.AddForce(Vector2.up * 5, ForceMode2D.Impulse);

    }

    void MyTranslate(Vector3 translateVector) {
        transform.localPosition += translateVector;
    }

    float RoundAbsoluteToZero(float decimalValue) {
        decimalValue = Mathf.Abs(decimalValue);
        if (decimalValue <= 0.01f) {
            decimalValue = 0f;
        }
        return decimalValue;
    }
}
