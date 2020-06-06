using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _coinsField;
    [SerializeField]
    private Text _livesField;
    [SerializeField]
    private Player _player;

    void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    public void UpdateCoinsDisplay()
    {
        _coinsField.text = _coinsField.text + _player._coins;
    }

    public void UpdateLivesDisplay()
    {
        _livesField.text = _livesField.text + _player._lives;
    }
}
