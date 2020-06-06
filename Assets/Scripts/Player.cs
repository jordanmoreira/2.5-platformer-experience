using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private CharacterController _characterController;

    [SerializeField]
    private UIManager _uiManager;

    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _gravity = 1.3f;
    [SerializeField]
    private float _jumpHeight = 30.0f;
    [SerializeField]
    public int _lives = 3;

    private float _cachedYVelocity;
    private bool _canDoubleJump = false;
    public int _coins = 0;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (_uiManager == null)
        {
            Debug.LogError("The UI Manager is NULL.");
        }
        _uiManager.UpdateLivesDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        Vector3 velocity = direction * _speed;

        if (_characterController.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _cachedYVelocity = _jumpHeight;
                _canDoubleJump = true;
            }
        }
        else
        {
            if (_canDoubleJump == true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _cachedYVelocity += _jumpHeight;
                    _canDoubleJump = false;
                }
            }
            _cachedYVelocity -= _gravity;
        }

        velocity.y = _cachedYVelocity;
        _characterController.Move(velocity * Time.deltaTime);
    }

    public void AddCoins(int coins)
    {
        _coins += coins;
        _uiManager.UpdateCoinsDisplay();
    }

    public void Damage()
    {
        _lives--;
        _uiManager.UpdateLivesDisplay();

        if (_lives < 1)
        {
            //restart the game
            SceneManager.LoadSceneAsync(0);
        }
    }
}
