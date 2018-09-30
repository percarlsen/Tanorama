using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class SimpleFSM : MonoBehaviour 
{
	public enum FSMState
	{
		None,
		Patrol,
		Chase,
		Attack,
	}

	// Current state that the NPC is reaching
	public FSMState curState;
	Animator animator;

	protected Transform playerTransform;// Player Transform
	public Vector3 destPos; // Next destination position of the NPC Tank

	// Turret
	public GameObject turret;
	public float turretRotSpeed = 4.0f;


	protected float elapsedTime;


	// Ranges for chase and attack
	public float chaseRange = 35.0f;
	public float attackRange = 20.0f;
	public float attackRangeStop = 10.0f;

	public GameObject[] waypointList;
	public int nextPoint;

	private NavMeshAgent nav;
	GameObject objPlayer;
	bool jasperIsDrinking;

	public GameObject MainCamera;
	public GameObject gameOverSound;
	public GameObject warningPursuit;

	/*
     * Initialize the Finite state machine for the NPC tank
     */
	void Start() {

		//StartCoroutine (num());

		jasperIsDrinking = false; 
		animator = GetComponent<Animator> ();
		animator.SetInteger("animSel", 0);
		curState = FSMState.Patrol;


		elapsedTime = 0.0f;
		nextPoint = 0;
		nav = GetComponent<NavMeshAgent> ();

		// Get the target enemy(Player)
		objPlayer = GameObject.FindGameObjectWithTag("Jasper");
		playerTransform = objPlayer.transform;

		MainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		gameOverSound = GameObject.FindGameObjectWithTag ("game_over_sound");
		warningPursuit = GameObject.FindGameObjectWithTag ("warning_pursuit");

		if(!playerTransform)
			print("Player doesn't exist.. Please add one with Tag named 'Player'");
		destPos = waypointList [0].transform.position;

	}


	// Update each frame
	void Update() {
		switch (curState) {
		case FSMState.Patrol: UpdatePatrolState(); break;
		case FSMState.Chase: UpdateChaseState(); break;
		case FSMState.Attack: UpdateAttackState(); break;
		}

		// Update the time
		elapsedTime += Time.deltaTime;

	}

	/*
     * Patrol state
     */
	protected void UpdatePatrolState() {
		animator.SetInteger ("animSel", 0);//runw walk animation
		// Find another patrol point if the current point is reached

		if (Vector3.Distance(transform.position, destPos) <= 2.0f) {
			FindNextPoint();
		}
		// NavMeshAgent move code goes here
		nav.SetDestination(destPos);

		// Transitions
		// Check the distance with player tank
		// When the distance is near, transition to chase state
		if ((Vector3.Distance(transform.position, playerTransform.position) <= chaseRange)) {
			objPlayer.SendMessage ("GetDrinkStatus", gameObject);
			if (jasperIsDrinking) {
				curState = FSMState.Chase;
			}
		}
	}

	void DrinkStatus(bool stat){
		jasperIsDrinking = stat;
	}


	/*
     * Chase state
	 */
	protected void UpdateChaseState() {

		// NavMeshAgent move code goes here
		animator.SetInteger ("animSel", 1);//run chase animation
		nav.SetDestination(playerTransform.position);

		// Transitions
		// Check the distance with player tank
		// When the distance is near, transition to attack state
		float dist = Vector3.Distance(transform.position, playerTransform.position);
		if (dist <= attackRange) {
			curState = FSMState.Attack;
		}
		// Go back to patrol is it become too far
		else if (dist >= chaseRange) {
			curState = FSMState.Patrol;
		}

	}


	/*
	 * Attack state
	 */
	protected void UpdateAttackState() {

		// Transitions
		// Check the distance with the player tank
		float dist = Vector3.Distance(transform.position, playerTransform.position);
		if (dist > attackRange) {
			curState = FSMState.Chase;
		}
		// Transition to patrol if the tank is too far
		else if (dist >= chaseRange) {
			curState = FSMState.Patrol;
		}

		if (dist <= attackRangeStop) {//stop range
			nav.isStopped = true;
		}else{
			nav.isStopped = false;
		}

		// Always Turn the turret towards the player
		if (turret) {
			Quaternion turretRotation = Quaternion.LookRotation(playerTransform.position - transform.position);
			turret.transform.rotation = Quaternion.Slerp(turret.transform.rotation, turretRotation, Time.deltaTime * turretRotSpeed); 
		}
		animator.SetInteger ("animSel", 2);//run attack animation
		MainCamera.SendMessage ("StopMusic");
		objPlayer.SendMessage ("GameOver", true);

	}
		

	void OnDrawGizmos () {
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, chaseRange);

		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, attackRange);
	}

	// Find the next patrol point
	protected void FindNextPoint() {
		//int rndIndex = Random.Range(0, pointList.Length);

		destPos = waypointList[nextPoint].transform.position;
		if (nextPoint == 3) {
			nextPoint = 0;
		} else {
			nextPoint++;
		}

	}

}
