using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI depthText;
    public TextMeshProUGUI moneyText;
    public GameObject player;
    public PlayerController playerScript;
    public GameObject enemy;
    public float spawnTime;
    public float lastSpawnTime;

    void Start()
    {
        spawnEnemy();
    }

    // Update is called once per frame
    void Update()
    { if(playerScript.dead) return;
       updateDepth();

       lastSpawnTime-=Time.deltaTime;

       if (lastSpawnTime <=0){
              spawnEnemy();
              lastSpawnTime = spawnTime;
              Debug.Log("hi");
       }
    }

    private void updateDepth()
    {
   depthText.text = "Meters: " + (int)player.transform.position.y;
    }

    private void updateScore()
    {

    }

    private void spawnEnemy(){
        Vector2 playerPosition = new Vector3(player.transform.position.x, player.transform.position.y-10, 0);
        Instantiate(enemy, playerPosition, Quaternion.identity);
    }
}
