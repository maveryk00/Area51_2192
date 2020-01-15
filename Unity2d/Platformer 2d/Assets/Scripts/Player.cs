using UnityEngine;

public class Player : MonoBehaviour {

    static public Player instance;

    static public void SetPosition(Vector3 pos) {
        pos.z = 0;
        instance.transform.position = pos;
    }

    static public Vector3 setPosition {
        set {
            Vector3 pos = value;
            pos.z = 0;
            instance.transform.position = pos;
        }
    }

    static public Transform setPosition2 {
        set {
            Vector3 pos = value.position;
            pos.z = 0;
            instance.transform.position = pos;
        }
    }

    static public HealthBarController HealthBar {
        set {
            instance.healthBarController = value;
        }
    }


    [SerializeField]
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rbody2D;
    private bool onGround = false;
    [SerializeField]
    private HealthBarController healthBarController;

    public float speed = 1f;
    public float jumpForce = 10f;
    public Animator animator;

    public Vector3 startPos;

    public float maxLife = 50;
    public float currentLife;

    public bool grounded {
        get {
            return RoundAbsoluteToZero(rbody2D.velocity.y) == 0f ||
                    onGround;
        }
    }

    void Awake() {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start() {
        startPos = transform.position;

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
            rbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);


        if (Input.GetKeyDown(KeyCode.O))
            TakeDamage(1);

        if (Input.GetKeyDown(KeyCode.P))
            Heal(2);

    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "DeathZone") {
            transform.position = startPos;
        }
        
        if (col.gameObject.tag == "Floor") {
            onGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D col) {
        if (col.gameObject.tag == "Floor") {
            onGround = false;
        }
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

    void TakeDamage(float damage) {
        currentLife -= damage;
        healthBarController.currentLife = currentLife;
    }

    void Heal(float heal) {
        currentLife += heal;
        healthBarController.currentLife = currentLife;
    }
}
