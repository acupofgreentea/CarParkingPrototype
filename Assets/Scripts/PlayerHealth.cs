using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float Health = 10f;

    [SerializeField] private float damage = 1f;

    [SerializeField] private float currentHealth;

    private Collider lastCollidedWith;

    public static event UnityAction OnPlayerDie;

    void Awake()
    {
        currentHealth = Health;
    }

    void OnCollisionEnter(Collision other)
    {
        if(lastCollidedWith != null)
        {
            if(other.gameObject.GetInstanceID() == lastCollidedWith.gameObject.GetInstanceID())
                return;
        }
        
        lastCollidedWith = other.collider;

        currentHealth -= damage;

        Debug.LogError("damaged", other.gameObject);

        if(currentHealth <= 0f)
        {
            OnPlayerDie?.Invoke();
            Debug.LogError("level failed");
        }
    }
}
