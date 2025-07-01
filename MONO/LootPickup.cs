using UnityEngine;

public class LootPickup : MonoBehaviour
{
    public float floatSpeed = 1f;
    public float floatHeight = 2f;

    private Vector3 startPosition;
    private bool pickedUp = false;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        if (!pickedUp)
        {
            if (transform.position.y < startPosition.y = floatHeight)
            {
                transform.position += Vector3.up * floatSpeed * Time.deltaTime;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pickedUp = true;
            Debug.Log("Loot picked up!");
            // TODO: Add to inventory, score, etc.
            Destroy(gameObject);
        }
    }
}