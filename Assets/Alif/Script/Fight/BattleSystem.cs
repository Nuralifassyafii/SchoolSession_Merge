using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { Start, PlayerTurn, EnemyTurn, Win, Lose}
public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefabs;
    public GameObject enemyPrefabs;

    public Transform playerBoard;
    public Transform enemyBoard;

    public BattleState battleState;

    private Unit player;
    private Unit enemy;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public Text turntext;

    public KeyCode attackInput;
    public KeyCode skillInput;
    // Start is called before the first frame update
    void Start()
    {
        battleState = BattleState.Start;
        StartCoroutine(SetupBattle()) ;
        
        
        
    }

    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefabs, playerBoard);
        player = playerGO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemyPrefabs, enemyBoard);
        enemy = enemyGO.GetComponent<Unit>();

        Debug.Log("Start system");

        yield return new WaitForSeconds(.5f);

        Debug.Log(enemy.unitName + player.unitName);

        playerHUD.UnitInfo(player);
        enemyHUD.UnitInfo(enemy);

        battleState = BattleState.PlayerTurn;
        StartCoroutine(Turn());

        yield return new WaitForSeconds(1f);

        
        
        
        
    }

    public void OnplayerTurnAttack()
    {
        if(battleState == BattleState.PlayerTurn)
        {
            StartCoroutine(OnAttackPlayer());

        } else {
            return;
        }
    }

    IEnumerator Turn()
    {
        if (battleState == BattleState.PlayerTurn)
        {
            turntext.text = "Player Turn";
            yield return new WaitForSeconds(2f);
            turntext.text = " ";
        }
        else if (battleState == BattleState.EnemyTurn)
        {
            turntext.text = "Enemy Turn";
            yield return new WaitForSeconds(2f);
            turntext.text = " ";
            ReadInput(attackInput);
        }
    }

    IEnumerator OnAttackEnemy()
    {
        bool isdead = player.TakeDamage(enemy.damage);

        playerHUD.Hp(player.currentHp);
        Debug.Log("attack Musuh Sukses");

        yield return new WaitForSeconds(1f);
       
        if(isdead == true)
        {
            battleState = BattleState.Lose;
            StartCoroutine(EndBattle());
        } else if (isdead == false)
        {
            battleState = BattleState.PlayerTurn;
            
        }
    }

    IEnumerator EndBattle()
    {
        if(battleState == BattleState.Win)
        {
            yield return new WaitForSeconds(.5f);
            turntext.text = "menang";
            Debug.Log("win");
            yield return new WaitForSeconds(2f);
            turntext.text = " ";
        } else if (battleState == BattleState.Lose)
        {
            yield return new WaitForSeconds(.5f);
            turntext.text = "Kau Kalah";
            yield return new WaitForSeconds(2f);
            turntext.text = " ";
        }
    }

    IEnumerator OnAttackPlayer()
    {
            bool isdead = enemy.TakeDamage(player.damage);

            enemyHUD.Hp(enemy.currentHp);
            Debug.Log("attack success");

            yield return new WaitForSeconds(1f);

            if(isdead == true)
            {
                battleState = BattleState.Win;
                StartCoroutine(EndBattle());
            }
            else if (isdead == false)
            {
                battleState = BattleState.EnemyTurn;
                StartCoroutine(OnAttackEnemy());
            }
    }

    public void ReadInput(KeyCode key)
    {
        if(battleState == BattleState.PlayerTurn) {
        if (Input.GetKeyDown(key))
        {
            OnplayerTurnAttack();
        }
            else
            {
                return;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput(attackInput);
    }
}
