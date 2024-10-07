using System.Collections;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public Vector2 moveVector;
    [SerializeField] float moveSpeed = 4f;
    [SerializeField] float jumpForce = 4f;
    private bool isGrounded;
    private bool isOnHold;
    [SerializeField] Transform holdPos;
    [SerializeField] Transform groundPos;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask holdLayer;
    [SerializeField] Camera cam;
    public bool onZipLine = false;
    private bool canJump = true;
    private bool isJumping = false;
    [SerializeField] Animator anim;
    float camSize = 20;
    [SerializeField] private AudioClip stepSound1;
    [SerializeField] private AudioClip stepSound2;
    [SerializeField] private AudioClip stepSound3;
    [SerializeField] private AudioClip jumpSound;
    private AudioSource audioSource;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 2f;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded && isOnHold == false) anim.SetInteger("State", 0);
        if (onZipLine == true) anim.SetInteger("State", 2);
        if (!isGrounded && isOnHold == false) anim.SetInteger("State", 3);
        Walk();
        Jump();
        if(camSize > cam.orthographicSize)
        {
            cam.orthographicSize += Time.deltaTime * 2;
        }
        if (camSize < cam.orthographicSize)
        {
            cam.orthographicSize -= Time.deltaTime * 2;
        }
    }

    private void FixedUpdate()
    {
        CheckGround();
        CheckHold();
    }
    void Walk()
    {
        if (onZipLine == true) return;
        moveVector.x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveVector.x * moveSpeed, rb.velocity.y);
        if (moveVector.x < 0) transform.localScale = new Vector3(-1, 1, 1);
        if (moveVector.x > 0) transform.localScale = new Vector3(1, 1, 1);
        if (isGrounded && moveVector.x != 0 && isOnHold == false)
        {
            anim.SetInteger("State", 1);
        }
    }
    void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && (isGrounded == true || isOnHold == true || onZipLine == true) && canJump == true)
        {
            if (onZipLine == true)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                rb.isKinematic = false;
                onZipLine = false;
                transform.parent = null;
            }
            canJump = false;
            StartCoroutine(JumpReload());
            rb.velocity = new Vector3(0, 0, 0);
            rb.AddForce(Vector2.up * jumpForce * 10);
        }
        if(isOnHold == true && isJumping == false)
        {          
            rb.velocity = new Vector3(0,0,0);
        }
        
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("cameraZone"))
        {
           camSize = collision.GetComponent<CameraZones>().size;
        }
    }
    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(groundPos.position, 0.1f, groundLayer);
        isGrounded = collider.Length > 0;
    }
    private void CheckHold()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(holdPos.position, 0.1f, holdLayer);
        isOnHold = collider.Length > 0;
        if(isOnHold == true) anim.SetInteger("State", 2);
    }
    IEnumerator JumpReload()
    {
        isJumping = true;
        yield return new WaitForSeconds(0.1f);
        isJumping = false;
        yield return new WaitForSeconds(0.1f);
        canJump = true;
    }
    public void PlaySoundStep()
    {
        int rnd = Random.Range(1, 4);
        if (rnd == 1)
        {
            audioSource.PlayOneShot(stepSound1, PlayerPrefs.GetFloat("sfxVolume"));
        }
        else if (rnd == 2)
        {
            audioSource.PlayOneShot(stepSound2, PlayerPrefs.GetFloat("sfxVolume"));
        }
        else
        {
            audioSource.PlayOneShot(stepSound3, PlayerPrefs.GetFloat("sfxVolume"));
        }
    }
    public void PlaySoundJump()
    {
        audioSource.PlayOneShot(jumpSound, PlayerPrefs.GetFloat("sfxVolume"));
    }
}

