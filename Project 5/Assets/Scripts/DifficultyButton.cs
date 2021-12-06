using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    // Variables
    private Button button;
    private GameManager gameManger;
    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        // Instatiates variables
        button = GetComponent<Button>();
        gameManger = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Sets difficulty
    private void SetDifficulty()
    {
        gameManger.StartGame(difficulty);
    }
}
