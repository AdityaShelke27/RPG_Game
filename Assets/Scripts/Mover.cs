using UnityEngine;
using UnityEngine.AI;
using RPG.Combat;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour
    {
        NavMeshAgent agent;
        Animator anim;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            anim = GetComponent<Animator>();
        }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            anim.SetFloat("Speed", agent.velocity.magnitude);
        }

        public void MoveTo(Vector3 pos)
        {
            agent.SetDestination(pos);
            agent.isStopped = false;
        }

        public void Stop()
        {
            agent.isStopped = true;
        }
    }
}