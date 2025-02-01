using RPG.Movement;
using UnityEngine;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        Transform m_Target;
        Mover m_Mover;
        [SerializeField] float m_AttackRange = 10;
        bool m_HasReachedTarget;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            m_Mover = GetComponent<Mover>();
        }

        // Update is called once per frame
        void Update()
        {
            if(m_Target)
            {
                if(Vector3.Distance(transform.position, m_Target.position) > m_AttackRange)
                {
                    m_Mover.MoveTo(m_Target.position);
                }
                else
                {
                    m_Mover.Stop();
                }
            }
        }

        public void Attack(CombatTarget combatTarget)
        {
            m_Target = combatTarget.transform;
            Debug.Log("Take that you ugly peasant");
        }

        public void Cancel()
        {
            m_Target = null;
        }
    }
}