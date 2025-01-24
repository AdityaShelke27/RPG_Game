using RPG.Combat;
using RPG.Movement;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        Mover m_Mover;
        Fighter m_Fighter;

        private void Awake()
        {
            m_Mover = GetComponent<Mover>();
            m_Fighter = GetComponent<Fighter>();
        }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (ImplementWithCombat()) return;
            if (ImplementWithMovement()) return;

            Debug.Log("Do Nothng");
        }
        bool ImplementWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.TryGetComponent(out CombatTarget target))
                {
                    if (Input.GetButtonDown("Fire1"))
                        m_Fighter.Attack(target);

                    return true;
                }
            }

            return false;
        }
        bool ImplementWithMovement()
        {
            RaycastHit hit;
            if (Physics.Raycast(GetMouseRay(), out hit))
            {
                if (Input.GetButton("Fire1"))
                    m_Mover.MoveTo(hit.point);

                return true;
            }
            else
                return false;
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}