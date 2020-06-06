using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private Player _player;

    void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            _player.AddCoins(1);
        }
    }
}
