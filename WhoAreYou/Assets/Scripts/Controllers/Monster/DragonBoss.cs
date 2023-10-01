using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class DragonBoss : MonoBehaviour
{

    private enum BossState
    {
        IDLE,
        CHARGING_BREATH,
        BREATH_ATTACK,
        CHASING_PLAYER,
        MELEE_ATTACK,
        SUMMON_MINIONS,
    }
    #region Variables
    private NavMeshAgent nav;
    private Animator anim;
    private Stat stat;
    public GameObject breathPrefab;   // �극�� ��ų ������
    public Transform breathSpawnPoint; // �극�� ��ų �߻� ����
    public float breathCooldown = 7f; // �극�� ��ų ��Ÿ��
    public float ClawCooldwon = 10f; // Claw ��ų ��Ÿ��
    public Slider bosshpSlider;
    [SerializeField]
    private float currentBreathCooldown = 0f;
    [SerializeField]
    private float currentClawCooldown = 0f; 

    public float meleeAttackRange = 2f; // ���� ���� ����

    public Transform[] summonSpawnPoint; // ��ȯ ����
    public GameObject dragonMinionPrefab; // �巡�� �̴Ͼ� ������
    [SerializeField]
    private bool isMoving = false; // ������ ����
    [SerializeField]
    private bool isBreathing = false; // �극�� ����
    [SerializeField]
    BoxCollider MeleeAttackWeapon; // �������� Colider
    [SerializeField]
    BoxCollider ClawAttackWeapon; // Claw��ų Colider
    [SerializeField]
    int attackCount = 0; // ����Ƚ��
    [SerializeField]
    bool awakeningState = false; // �������¿���
    [SerializeField]
    bool isSummoning = false; // ��ȯ ����
    [SerializeField]
    bool isDie = false;

    private Transform playerTransform; // �÷��̾� ��ġ

    [Header("Sight Settings")]
    public float viewRadius = 5f; // �þ߰�

    [SerializeField]
    private BossState currentState; // ���� ���� ����
    #endregion Variables


    private void Start()
    {
        stat = GetComponent<Stat>();
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        nav.speed = 5f;
        currentState = BossState.IDLE;
        isBreathing = true;
        isSummoning = true;
        currentBreathCooldown = breathCooldown;
        currentClawCooldown = ClawCooldwon;
        stat.Hp = stat.MaxHp;
    }
    private void Update()
    {
        bosshpSlider.value = (float)stat.Hp / (float)stat.MaxHp;
        if (stat.Hp <= 0)
        {
            isDie = true;
            anim.SetBool("isDie", true);
        }
        if (isDie)
        { 
            return;
        }
        if (!PlayerDetected())
        {
            currentState = BossState.IDLE; 
        }
        bosshpSlider.gameObject.SetActive(true);
        if (stat.Hp <= 30)
        {
            awakeningState = true;
            if (isSummoning)
            {
                currentState = BossState.SUMMON_MINIONS;
            }
        }
        CheckState();
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject player = GameObject.Find("Player");
        if (other.CompareTag("Weapon"))
        {
            stat.OnAttacked(player.GetComponent<Stat>());    
        }
    }

    #region Methods


    private void CheckState() //���� üũ�Լ�
    {
        switch (currentState)
        {
            case BossState.IDLE:
                anim.SetBool("isIdle", true);
                if (PlayerDetected())
                {
                    if (isBreathing)
                    {
                        currentState = BossState.CHARGING_BREATH;
                    }
                    else
                    {
                        currentState = BossState.CHASING_PLAYER;
                    }
                }
                break;
            case BossState.CHARGING_BREATH:
                currentBreathCooldown -= Time.deltaTime;
                if (currentBreathCooldown <= 0)
                {
                    currentState = BossState.BREATH_ATTACK;
                }
                break;
            case BossState.BREATH_ATTACK:
                anim.SetBool("isIdle", false);
                UseBreathSkill();
                break;
            case BossState.CHASING_PLAYER:
                anim.SetBool("isIdle", false);
                isMoving = true;
                nav.isStopped = false;
                anim.SetBool("isMove", true);
                if (isMoving)
                {
                    ChasePlayer();
                }
                break;

            case BossState.MELEE_ATTACK:
                if (awakeningState)
                {
                    currentClawCooldown -= Time.deltaTime;
                    if (currentClawCooldown <= 0)
                    {
                        anim.SetTrigger("MeleeAttackTrigger2");
                        currentClawCooldown = ClawCooldwon;
                    }
                }
                anim.SetBool("isIdle", false);
                if (attackCount >= 10)
                {
                    attackCount = 0;
                    currentState = BossState.IDLE;
                    anim.SetBool("isIdle", true);
                    isBreathing = true;
                }
                anim.SetBool("isMove", false);
                isMoving = false;
                anim.SetTrigger("MeleeAttackTrigger1");
                if (Vector3.Distance(playerTransform.position, transform.position) > meleeAttackRange)
                {
                    currentState = BossState.CHASING_PLAYER;
                }
                break;
            case BossState.SUMMON_MINIONS:
                anim.SetTrigger("screamTrigger");
                isMoving = false;
                nav.isStopped = true;
                break;
        }
    }

    private bool PlayerDetected() // �÷��̾� �����Լ�
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, viewRadius);
        foreach (Collider collider in targets)
        {
            if (collider.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }


    private void ChasePlayer() // �÷��̾� �߰� �Լ�
    {
        if (attackCount >= 10)
        {
            attackCount = 0;
            currentState = BossState.IDLE;
            anim.SetBool("isIdle", true);
            isBreathing = true;
        }
        Collider[] coliders = Physics.OverlapSphere(transform.position, viewRadius);
        foreach (Collider target in coliders)
        {
            if (target.CompareTag("Player"))
            {
                playerTransform = target.transform;
            }
        }
        anim.SetBool("isMove", true);
        isMoving = true;
        nav.SetDestination(playerTransform.position);
        nav.stoppingDistance = 9f;
        if (Vector3.Distance(playerTransform.position, transform.position) < meleeAttackRange)
        {
            anim.SetBool("isMove", false);
            currentState = BossState.MELEE_ATTACK;
        }
    }

    private void UseBreathSkill() // �극����ų 
    {
        transform.LookAt(playerTransform);
        anim.SetTrigger("breathTrigger");
        if (breathPrefab != null && breathSpawnPoint != null )
        {
            StartCoroutine("CreateFireBall");
        }
        currentBreathCooldown = breathCooldown;
        isBreathing = false;
    }

    IEnumerator CreateFireBall()
    {
        yield return new WaitForSeconds(0.2f);
        Instantiate(breathPrefab, breathSpawnPoint.position, breathSpawnPoint.rotation);
        StopCoroutine("CreateFireBall");
    }

    private void ChangeStateIdle() // Idle���·� �ٲٱ�
    {
        currentState = BossState.IDLE;
        DisableTrigger();
    }

    private void WeaponOn() // ����Colider On
    {
        MeleeAttackWeapon.enabled = true;
        attackCount++;
    }
    private void WeaponOff() // ���� Colider Off
    {
        MeleeAttackWeapon.enabled = false;
    }

    private void ClawWeaponOn() // ��ų���� Colider On
    {
        ClawAttackWeapon.enabled = true;
    }

    private void ClawWeaponOff() // ��ų���� Colider Off
    {
        ClawAttackWeapon.enabled = false;
    }

    private void DisableTrigger() // Trigger ����
    {
        anim.ResetTrigger("breathTrigger");
        anim.ResetTrigger("screamTrigger");
    }

    private void DestoryDragon() // Dragon ����
    {
        Destroy(gameObject);
    }


    private void SummonDragonMinions() // �巡�� ���� 
    {

        if (dragonMinionPrefab != null && summonSpawnPoint != null)
        {
            for (int i = 0; i < 4; i++)
            {
                Instantiate(dragonMinionPrefab, summonSpawnPoint[i].position, Quaternion.identity);
            }
        }
        isSummoning = false;
    }

    #endregion Methods
}
