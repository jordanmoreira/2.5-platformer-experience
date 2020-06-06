using System.Collections;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField]
    private GameObject _respawnPoint;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = GameObject.FindWithTag("Player").AddComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }

            CharacterController cc = other.GetComponent<CharacterController>();

            cc.enabled = false;
            other.transform.position = _respawnPoint.transform.position;
            StartCoroutine(CCEnableRoutine(cc));
        }
    }

    IEnumerator CCEnableRoutine(CharacterController controller)
    {
        yield return new WaitForSeconds(0.5f);
        controller.enabled = true;
    }
}
