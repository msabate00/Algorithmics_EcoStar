using UnityEngine;

public class Enemigocomplicado : MonoBehaviour
{
    [Header("Referencias")]
    public Transform[] patrolPoints;
    public Transform player;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public EnemyHealth health;
    public Transform groundCheck;
    [Header("Movimiento")]
    public float patrolSpeed = 2f;
    public float chaseSpeed = 3.5f;
    public float returnSpeed = 2.5f;
    public float pointReachedDistance = 0.15f;
    public bool canJump = true;
    public float jumpForce = 8f;
    public float jumpCooldown = 0.35f;
    public bool allowDropFromPlatforms = false;
    public float playerHigherJumpThreshold = 0.75f;
    [Header("Checks")]
    public LayerMask groundLayer;
    public LayerMask playerLayer;
    public float groundCheckRadius = 0.15f;
    public float wallCheckDistance = 0.35f;
    public float edgeCheckDistance = 0.8f;
    [Header("Distancias")]
    public float detectionDistance = 5f;
    public float loseDistance = 7f;
    public float attackDistance = 1.2f;
    [Header("Ataque")]
    public int damage = 1;
    public float attackCooldown = 1f;
    public Vector2 attackOffset = new Vector2(0.6f, 0f);
    public float attackRadius = 0.4f;
    public string playerTag = "Player";
    [Header("Hurt")]
    public float hurtTime = 0.2f;
    public Vector2 hurtKnockback = new Vector2(4f, 4f);
    [HideInInspector] public EnemyPatrolState PatrolState;
    [HideInInspector] public EnemyChaseState ChaseState;
    [HideInInspector] public EnemyReturnState ReturnState;
    [HideInInspector] public EnemyAttackState AttackState;
    [HideInInspector] public EnemyHurtState HurtState;
    [HideInInspector] public EnemyDeadState DeadState;
    public EnemyStateBase CurrentState { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public bool IsDead { get; private set; }
    public bool FacingRight { get; private set; } = true;
    public int PatrolIndex { get; set; }
    public int ReturnIndex { get; set; }
    public float AttackTimer { get; set; }
    public float StateTimer { get; set; }
    public bool SuspendAutoMovement { get; set; }
    public bool HasPatrolPoints => patrolPoints != null &&
   patrolPoints.Length > 0;
    public bool HasPlayer => player != null;
    public Vector3 PlayerPosition => player != null ?
   player.position : transform.position;
    private float desiredVelocityX;
    private float nextJumpTime;

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        if (health == null)
            health = GetComponent<EnemyHealth>();
        if (spriteRenderer == null)
            spriteRenderer =
           GetComponentInChildren<SpriteRenderer>();
        if (animator == null)
            animator = GetComponent<Animator>();
        PatrolState = new EnemyPatrolState(this);
        ChaseState = new EnemyChaseState(this);
        ReturnState = new EnemyReturnState(this);
        AttackState = new EnemyAttackState(this);
        HurtState = new EnemyHurtState(this);
        DeadState = new EnemyDeadState(this);
    }
    private void Start()
    {
        TryFindPlayer();
        ChangeState(PatrolState);
    }

    private void Update()
    {
        if (AttackTimer > 0f)
            AttackTimer -= Time.deltaTime;
        if (player == null)
            TryFindPlayer();
        CurrentState?.LogicUpdate();
        UpdateAnimator();
    }
    private void FixedUpdate()
    {
        CurrentState?.PhysicsUpdate();
        ApplyHorizontalMovement();
    }

    public abstract class EnemyStateBase
    {
        protected readonly EnemyStateMachine enemy;
        protected EnemyStateBase(EnemyStateMachine enemy)
        {
            this.enemy = enemy;
        }
        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void LogicUpdate() { }
        public virtual void PhysicsUpdate() { }
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame

}
