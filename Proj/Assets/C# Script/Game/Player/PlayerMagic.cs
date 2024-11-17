using UnityEngine;
using UnityEngine.UI;

public class PlayerMagic : MonoBehaviour
{
    [SerializeField] private GameObject[] fireBallPrefab;
    [SerializeField] private GameObject exploshionPrefab;
    [SerializeField] private Image barMana;
    [SerializeField] private Transform spawnFireBallPos;

    public float amountOfMana = 100;
    private float avaliableMana;
    private Animator animator;

    private float timer = 2f;
    private float timerrollBackFireBall = 0.7f;
    private float timerrollBackExploshion = 2f;
    private bool isFireBollActive = true;
    private bool isExploshionActive = true;

    private void Start()
    {
        avaliableMana = amountOfMana;      
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        ManaRecoveryTimer();

        isFireBollActive = RollBackFireBall();
        isExploshionActive = RollBackExploshion();

        if ((Input.GetKeyDown(KeyCode.Q) || Input.GetMouseButtonDown(1)) && isFireBollActive)
        {
            Firebolls();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Explosion();
        }

        barMana.fillAmount = avaliableMana / amountOfMana;
    }

    private void Firebolls()
    {
        if (WasteOfMana(15))
        {
            animator.SetTrigger("FireBall");
            isFireBollActive = false;
        }
    }

    public void OnMagicFireBoll()
    {
        if (isFireBollActive)
            Firebolls();
    }

    private void Explosion()
    {
        if (WasteOfMana(60))
        {
            animator.SetTrigger("Explosion");
            isExploshionActive = false;
        }
    }

    public void OnMagicExploshion()
    {
        if (isFireBollActive)
            Firebolls();
    }

    private void FireFirebolls()
    {
        int randomFireBoll = Random.Range(0, fireBallPrefab.Length);
        Instantiate(fireBallPrefab[randomFireBoll], spawnFireBallPos.position, Quaternion.identity);
    }
    private void ExploshionsSpwn()
    {
        Instantiate(exploshionPrefab, spawnFireBallPos.position, Quaternion.identity);
    }

    public bool WasteOfMana(int theRightAmountOfMana)
    {
       bool isSpellActivaition = false;

        if (avaliableMana - theRightAmountOfMana >= 0)
        {
            isSpellActivaition = true; 
           
            avaliableMana -= theRightAmountOfMana;
        }
        else
            isSpellActivaition = false;
       
        return isSpellActivaition;
    }

    private void ManaRecoveryTimer()
    {
        if (timer <= 0)
        {
            timer = 2f;

            if (avaliableMana < amountOfMana)
            {
                avaliableMana += 5;
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    private bool RollBackFireBall()
    {
        if (!isFireBollActive) 
        { 
            if (timerrollBackFireBall <= 0)
            {
                timerrollBackFireBall = 0.7f;
                return true;
            }
            else
            {
                timerrollBackFireBall -= Time.deltaTime;
                return false;
            }
        }
        else 
            return true;
    }

    private bool RollBackExploshion()
    {
        if (!isExploshionActive)
        {
            if (timerrollBackExploshion <= 0)
            {
                timerrollBackExploshion = 2f;
                return true;
            }
            else
            {
                timerrollBackExploshion -= Time.deltaTime;
                return false;
            }
        }
        else
            return true;
    }
}

