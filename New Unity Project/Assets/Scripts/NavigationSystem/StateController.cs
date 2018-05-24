using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.AI;
//using Complete;

public class StateController : MonoBehaviour {

    public State currentState;
	public EnemyStats enemyStats;
	public Transform eyes;
    public State remainState;
    //For Debug 
    public int SpawnPointIndex;
    public int LaneIndex;
    public string enemyName;
    public string tempName;

    [HideInInspector]
    public NavMeshAgent navMeshAgent;
    private Text UILog;
	//[HideInInspector] public Complete.TankShooting tankShooting;
	[HideInInspector]
    public Transform[] wayPointList;
    [HideInInspector]
    public int nextWayPoint;
    [HideInInspector] 
    public Transform chaseTarget;
    [HideInInspector]
    public float stateTimeElapsed;

    private bool aiActive;
    float minionSpeed;

    private int targetPosition;
    CastleHealth casteHealth;
    private UnityAction bornListener;
    private UnityAction lifeListener;
    private UnityAction deathListener;
    bool isDieing;
    m_Enemy enemyModel;

    void Awake () 
	{
        UILog = GameObject.FindGameObjectWithTag("Canvas").GetComponentInChildren<Text>(true);
        //tankShooting = GetComponent<Complete.TankShooting> ();
        navMeshAgent = GetComponent<NavMeshAgent> ();
        targetPosition = 0;
        enemyModel = GetComponent<m_Enemy>();
        bornListener = new UnityAction(MinionSpawned);
        lifeListener = new UnityAction(MinionMovement);
        deathListener = new UnityAction(MinionDied);
        isDieing = false;
        navMeshAgent = GetComponent<NavMeshAgent>();
        aiActive = !isDieing;
    }

	public void SetupAI(bool aiActivationFromTankManager, List<Transform> wayPointsFromTankManager)
	{
		//wayPointList = wayPointsFromTankManager;
		//aiActive = aiActivationFromTankManager;
		//if (aiActive) 
		//{
		//	navMeshAgent.enabled = true;
		//} else 
		//{
		//	navMeshAgent.enabled = false;
		//}
	}
    private void OnEnable()
    {
        EventManager.StartListening(enemyName + "born", bornListener);
        EventManager.StartListening(enemyName + "movement", MinionMovement);
        EventManager.StartListening(enemyName + "death", deathListener);

    }

    private void OnDisable()
    {
        EventManager.StopListening(enemyName + "born", bornListener);
        EventManager.StopListening(enemyName + "movement", MinionMovement);
        EventManager.StopListening(enemyName + "death", deathListener);
    }

    private void Update()
    {
        if (!aiActive)
            return;
        if(nextWayPoint < (wayPointList.Length) - 1)
        {
            Debug.Log(nextWayPoint); 
        }
        else if(!isDieing)
        {
            EndOfPath();
        }
        currentState.UpdateState(this);
    }

    private void Start()
    {
        minionSpeed = enemyModel.movementSpeed;
        casteHealth = GameObject.FindGameObjectWithTag("Castle").GetComponent<CastleHealth>();
        
        EventManager.TriggerEvent(enemyName + "born");
    }

    private void OnDrawGizmos()
    {
        if(currentState != null && eyes != null)
        {
            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawWireSphere(eyes.position, enemyStats.lookSphereCastRadius);
        }
    }

    public void EndOfPath()
    {
        EventManager.TriggerEvent(enemyName + "death");
        if (casteHealth.currentHealth > 0)
        {
            casteHealth.TakeDamage(enemyModel.attackDamage);
        }
        gameObject.GetComponent<EnemyHealth>().Death();
        isDieing = true;
        aiActive = !isDieing;
        navMeshAgent.enabled = false;
    }

    void MinionSpawned()
    {

        UILog.text += enemyName + " spawned at lane " + LaneIndex + "\n";
        //Debug.Log(enemyName + " spawned at lane " + LaneIndex);
    }

    void MinionDied()
    {
        UILog.text += enemyName + " Died" + "\n";
        //Debug.Log(enemyName + " Died");
    }

    void MinionMovement()
    {
        //UILog.text += enemyName + "is at point " + targetPosition + " of Lane" + LaneIndex + "\n";
        //Debug.Log(enemyName + "is at point " + targetPosition + " of Lane" + LaneIndex);
    }


    public void TransitionToState(State nextState)
    {
        if(nextState != remainState)
        {
            currentState = nextState;
            OnExitState();
        }
    }

    public bool CheckIfCountDownElapsed(float duration)
    {
        stateTimeElapsed += Time.deltaTime;
       return (stateTimeElapsed >= duration);
    }

    private void OnExitState()
    {
        stateTimeElapsed = 0;
    }
}