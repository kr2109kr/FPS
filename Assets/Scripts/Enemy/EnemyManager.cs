using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }

    private int enemyCount;
    [SerializeField] private Text enemyCountDisplay;
    
    private AudioSource audioSource;
    [SerializeField] private AudioClip enemyDeadAudioClip;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }

        else
        {
            Instance = this;
        }

        audioSource = GetComponent<AudioSource>();
    }


    private void Start()
    {
        foreach (Transform child in transform)
        {
            enemyCount += child.childCount;
        }

        enemyCountDisplay.text = enemyCount.ToString();
    }


    public void EnemyCountDecrease()
    {
        enemyCount -= 1;
        enemyCountDisplay.text = enemyCount.ToString();
        EnemyCountCheck();

        audioSource.PlayOneShot(enemyDeadAudioClip);
    }


    private void EnemyCountCheck()
    {
        if (enemyCount == 0)
        {
            GameManager.Instance.GameWin();
        }
    }
}
