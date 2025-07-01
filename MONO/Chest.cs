using UnityEngine;
public class Chest : MonoBehaviour
{
    public Sprite openSprite;
    private Sprite closedSprite;

    private SpriteRenderer spriteRenderer;
    private bool isPlayerNear = false;
    private bool isOpened = false;

    public GameObject lootPrefab;
    public Transform lootSpawnPoint; 


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        closedSprite = spriteRenderer.sprite;
    }

    private void Update()
    {
        if (isPlayerNear && !isOpened && Input.GetKeyDown(KeyCode.E)) OpenChest();
    }

    void OpenChest()
    {
        isOpened = true;
        spriteRenderer.sprite = openSprite;

        Debug.Log("Chest opened!");

        if (lootPrefab != null)
        {
            Vector3 spawnPosition = lootSpawnPoint != null ? lootSpawnPoint.position : transform.position + new Vector3(0, 0.5f, 0);
            Instantiate(lootPrefab, spawnPosition, Quaternion.identity);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isPlayerNear = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isPlayerNear = false;
    }
}