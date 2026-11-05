using UnityEngine;

public class SpawnCoins : MonoBehaviour
{
    public GameObject GoldCoinPrefab,SilverCoinPrefab,BrownCoinPrefab;

    public Player player;
    public float minX = -8f;
    public float maxX = 8f;
    public float miny = -4f;
    public float maxY = 4f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spwanCoins();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.currCoins == 0)
        {
            spwanCoins();
        }
    }

    private void spwanCoins()
    {
        for (int i = 0; i < 5; i++)
        {
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(miny, maxY);
            Vector2 randomPosition = new Vector2(randomX, randomY);
            
            int coinType = Random.Range(0,3);
            if (coinType == 0)
            {
                GameObject coin = Instantiate(BrownCoinPrefab,randomPosition,Quaternion.identity); 
            }
            if (coinType == 1)
            {
                GameObject coin = Instantiate(SilverCoinPrefab,randomPosition,Quaternion.identity); 
            }
            if (coinType == 2)
            {
                GameObject coin = Instantiate(GoldCoinPrefab,randomPosition,Quaternion.identity); 
            }
                 
        }
        Player.currCoins = 5;
    }
}
