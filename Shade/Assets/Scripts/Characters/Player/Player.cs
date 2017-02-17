using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MovingObject
{
    // Player variables
    public float restartLevelDelay = 1f; // Delay time in seconds to restart level.
    public float visionTime = 4.0f; // Time in seconds
    public float eyeTime = 1.0f; 

    private float currentVisionTime = 0; // Approaches the total allowed vision ti me
    private bool _visionActivated = false;
    private GameObject eyeOpening; // Image for eye opening

    // Cache variables
    private Animator animator; // Used to store a reference to the Player's animator component.

    // HUD for Vision
    private Vector2 visionBarPos = new Vector2(40, 40);
    private Vector2 visionBarSize = new Vector2(200, 60);
    private GUIStyle visionBarStyle = null;
    private Texture2D progressBarEmpty;
    private Texture2D progressBarFull;

    // By duck (http://answers.unity3d.com/users/82/duck.html)
    // From http://answers.unity3d.com/answers/11898/view.html
    void OnGUI()
    {
        if (GameManager.Instance.enabled && GameManager.Instance.doingSetup == false)
        {
            // draw the background:
            InitStyles();
            OnDispositionChange();
            GUI.BeginGroup(new Rect(visionBarPos.x, visionBarPos.y, visionBarSize.x, visionBarSize.y));
            GUI.Box(new Rect(0, 0, visionBarSize.x, visionBarSize.y), progressBarEmpty, visionBarStyle);

            // draw the filled-in part:
            GUI.BeginGroup(new Rect(0, 0, visionBarSize.x * (visionTime - currentVisionTime), visionBarSize.y));
            GUI.Box(new Rect(0, 0, visionBarSize.x, visionBarSize.y), progressBarFull);
            GUI.EndGroup();

            GUI.EndGroup();
        }
    }

    private void InitStyles()
    {
        if (visionBarStyle == null)
        {
            visionBarStyle = new GUIStyle(GUI.skin.box);
        }
    }
    
    protected override void Start()
    {
        animator = GetComponent<Animator>();

        // Get the current disposition point total stored in GameManager between levels.
        disposition = GameManager.Instance.playerDisposition;

        // Get reference for eye opening
        eyeOpening = GameObject.Find("EyeOpening");

        // Set eye opening as false to start
        eyeOpening.GetComponent<Image>().enabled = false;

        // Call the Start function of the MovingObject base class.
        base.Start();
    }
    
    protected override void OnDispositionChange()
    {
        if (visionBarStyle != null)
        {
            visionBarStyle.normal.background = MakeTex(2, 2, disposition.getColor());
        }
    }

    // Code by Benderlab
    // https://forum.unity3d.com/members/benderlab.133282/
    // https://forum.unity3d.com/threads/change-gui-box-color.174609/#post-1194616
    private Texture2D MakeTex(int width, int height, Color col)
    {
        Color[] pix = new Color[width * height];
        for (int i = 0; i < pix.Length; ++i)
        {
            pix[i] = col;
        }
        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pix);
        result.Apply();
        return result;
    }

    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    private void OnDisable()
    {
        // Store the local disposition back into the GameManager for future re-load
        GameManager.Instance.playerDisposition = disposition;
    }

    private void Update()
    {
        while (GameManager.Instance.doingSetup) { return; }
        HandleMovement();
        HandleVision();
        HandleDispositionUpdate();
    }

    private void HandleDispositionUpdate()
    {
        OnDispositionChange();
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (vertical == 0 && horizontal == 0)
        {
            animator.enabled = false;
        }
        else
        {
            animator.enabled = true;

            if (vertical > 0)
            {
                animator.SetInteger("Direction", Direction.Up);
            }
            else if (vertical < 0)
            {
                animator.SetInteger("Direction", Direction.Down);
            }
            else if (horizontal > 0)
            {
                animator.SetInteger("Direction", Direction.Right);
            }
            else if (horizontal < 0)
            {
                animator.SetInteger("Direction", Direction.Left);
            }
        }

        //Check if we have a non-zero value for horizontal or vertical
        if (horizontal != 0 || vertical != 0)
        {
            Move(horizontal, vertical);
        }
    }

    private void HandleVision()
    {
        bool visionToggled = Input.GetButtonUp("Vision");

        if (visionToggled)
        {
            bool currentVisionState = _visionActivated;

            if (currentVisionTime >= 0)
            {
                if (currentVisionState == true) // already activated?
                    _visionActivated = false; // deactivate
                else // not yet activated? 
                    _visionActivated = true; // activate
            }
            else
            {
                _visionActivated = false;
            }

            if (currentVisionState != _visionActivated)
            {
                GameManager.Instance.ToggleEnemyDispositions(_visionActivated);
                GameManager.Instance.setState(_visionActivated);
                eyeOpening.GetComponent<Image>().enabled = true;
            }

        }

        if (_visionActivated)
        {
            currentVisionTime += Time.deltaTime;
        }
        else if (currentVisionTime > 0)
        {
            currentVisionTime -= Time.deltaTime;
            currentVisionTime = Mathf.Clamp(currentVisionTime, 0, visionTime);
        }

        if (currentVisionTime >= (visionTime - 1.0f))
        {
            eyeOpening.GetComponent<Image>().enabled = false;
        }

        if (currentVisionTime >= visionTime)
        {
            _visionActivated = false;
            GameManager.Instance.ToggleEnemyDispositions(false);
            GameManager.Instance.setState(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the tag of the trigger collided with is Exit.
        if (other.tag == "Exit")
        {
            // Invoke the Restart function to start the next level with a delay of restartLevelDelay (default 1 second).
            Invoke("Restart", restartLevelDelay);

            // Disable the player object since level is over.
            enabled = false;
        }
        else
        {
            Enemy enemy = other.gameObject.GetComponent<EnemyPatrol>();
            if(enemy != null && enemy.disposition.isSimilar(disposition) == false)
            {
                GameManager.Instance.GameOver();
            }
        }
    }

    /// <summary>
    /// Reload the scene.
    /// </summary>
    private void Restart()
    {
        // Load the last scene loaded, in this case Main, the only scene in the game.
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Called when an enemy attacks the player.
    /// </summary>
    /// <param name="loss">The amount of health to subtract from the player.</param>
    public void LoseHealth(int loss)
    {
        // Set the trigger for the player animator to transition to the playerHit animation.
        animator.SetTrigger("playerHit");

        health -= loss;

        // Check to see if game has ended.
        CheckIfGameOver();
    }

    /// <summary>
    /// Checks if the player is dead and if so, call the GameManager GameOver sequence.
    /// </summary>
    private void CheckIfGameOver()
    {
        if (health <= 0)
        {
            // Call the GameOver function of GameManager.
            GameManager.Instance.GameOver();
        }
    }

}