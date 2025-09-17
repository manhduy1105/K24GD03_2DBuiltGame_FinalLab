using UnityEngine;


public class CrossPlatformInput : MonoBehaviour
{
    public float speed = 5.0f;
    public Rigidbody2D rb;
    public GameObject CanvasMB;
    public GameObject Canvas;
    private Vector2 moveInput;
    public GameObject bullet;
    public float bulletSpeed;
    private int direction = 1;
    public GameObject Blockmb;
    private Vector2 LastMoveInput;
    [SerializeField] public Joystick mobileJoystick;
    public GameObject Lose;
    void Start()
    {
        Blockmb.SetActive(false);
        CanvasMB.SetActive(false);
        Canvas.SetActive(false);
        Lose.SetActive(false);
    }
    void Update()
    {
        moveInput = Vector2.zero;

        // --- PC & WebGL (Keyboard) ---
#if UNITY_STANDALONE || UNITY_WEBGL
        CanvasMB.SetActive(false);
        Canvas.SetActive(true);
        
        
        float h = Input.GetAxisRaw("Horizontal"); // A/D hoặc ← →
        float v = Input.GetAxisRaw("Vertical");   // W/S hoặc ↑ ↓
        moveInput = new Vector2(h, v);

        if (Input.GetMouseButtonDown(0)) {
         
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 huong = (mouseWorldPos - transform.position).normalized;
         var RealBullet = Instantiate(bullet, transform.position, Quaternion.identity);
         RealBullet.GetComponent<Rigidbody2D>().linearVelocity = huong * bulletSpeed;
          Destroy ( RealBullet ,3f);
        }
#endif

        // --- Mobile (Touch) ---
#if UNITY_ANDROID || UNITY_IOS
        
        CanvasMB.SetActive(true);
        Canvas.SetActive(false);
        if (SystemInfo.supportsGyroscope)
        {
            
            Vector3 tilt = Input.gyro.gravity;
            
            moveInput = new Vector2(tilt.x, tilt.y);
        }
        if (mobileJoystick != null)
        {
            moveInput = new Vector2(mobileJoystick.Horizontal, mobileJoystick.Vertical);
        }
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
                Debug.Log("Tap at: " + t.position);

            if (t.phase == TouchPhase.Moved)
                moveInput = t.deltaPosition.normalized; 
        }
        

        if (moveInput != Vector2.zero)
        {
            LastMoveInput = moveInput;
        }

#endif
    }

    void FixedUpdate()
    {

        rb.linearVelocity = moveInput.normalized * speed;
        Move();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Death();
        }
    }

    void Death()
    {
        Time.timeScale = 0f;
        Lose.SetActive(true);

    }
    void Move()
    {
        Vector3 currentLocal = transform.localScale;
        if (moveInput.x > 0)
        {
            direction = 1;
            transform.localScale = new Vector3(Mathf.Abs(currentLocal.x), currentLocal.y, currentLocal.z);
        }
        if (moveInput.x < 0)
        {
            direction = -1;
            transform.localScale = new Vector3(-Mathf.Abs(currentLocal.x), currentLocal.y, currentLocal.z);
        }
    }
    public void Shot() {
        var RealBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        Vector2 huong = moveInput.normalized;
        if (huong == Vector2.zero)
            huong = LastMoveInput.normalized;
        RealBullet.GetComponent<Rigidbody2D>().linearVelocity = huong * bulletSpeed ;
        Destroy ( RealBullet ,3f);
    }
    public void XoayTuDong()
    {
        Screen.orientation = ScreenOrientation.AutoRotation;
        Screen.autorotateToPortrait = true;
        Screen.autorotateToPortraitUpsideDown = false; 
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
        transform.position = Vector2.zero;
    }
    public void XoayNgang()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        Blockmb.SetActive(false);
        transform.position = Vector2.zero;
    }
    public void XoayDoc()
    {
        Screen.orientation=ScreenOrientation.Portrait;
        Blockmb.SetActive(true);
        transform.position = Vector2.zero;
    }

}


