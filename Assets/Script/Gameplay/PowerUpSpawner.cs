using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private  So_PowerUpConfig powerUpConfig;
    
    [Header("Current Progress")]
    [SerializeField] private bool canSpawn;
    [SerializeField] float currentTimer;
    [SerializeField] float spawnedItemLifetime;
    

    PowerUp spawnedItem;
    Vector2 screenBounds;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void Update()
    {
        currentTimer += Time.deltaTime;
        if(!canSpawn)
        {
            if(currentTimer > spawnedItemLifetime)
            {
                DestroySpawnedItem();
            }
        }
        else
        {
            if(currentTimer > powerUpConfig.SpawnInterval)
            {
                SpawnRandomPowerUp();
                canSpawn = false;
                currentTimer = 0;
                spawnedItemLifetime = Random.Range(powerUpConfig.MinDuration, powerUpConfig.MaxDuration);
            }
        }

       
    }

    private void SpawnRandomPowerUp()
    {
        PowerUp selectedPowerUpPrefab = powerUpConfig.GetRandomPowerUp() ;
        Vector3 randomPosition = GetRandomSpawnPosition();
        spawnedItem = Instantiate(selectedPowerUpPrefab, randomPosition, Quaternion.identity);
        spawnedItem.OnDestroyEvent += OnItemDestroyed;
    }

    private Vector3 GetRandomSpawnPosition()
    {
        // Calculate a random spawn position within the game area.
        float x = Random.Range(-screenBounds.x, screenBounds.x); 
        float y = Random.Range(-screenBounds.y, screenBounds.y); 
        return new Vector3(x, y, 0f);
    }


    void DestroySpawnedItem()
    {
        if (spawnedItem != null)
            Destroy(spawnedItem);
        
        OnItemDestroyed();
    }

    void OnItemDestroyed()
    {
        canSpawn = true;
        currentTimer = 0;

    }
}
