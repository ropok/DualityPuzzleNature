using UnityEngine;

namespace ChoosingVacation
{
    public class ClickInteract : MonoBehaviour
    {
        [SerializeField]
        private GameObject greenMark;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hitInfo = Physics2D.Raycast(ray.origin, Vector2.zero);

                if (hitInfo && hitInfo.collider != null)
                {
                    DestroyDifference(hitInfo);
                    GreenMarkAppears(greenMark, new Vector3(ray.origin.x, ray.origin.y, 1));
                    ObjectsCount(1);
                }
            }

        }

        void DestroyDifference(RaycastHit2D raycastHit2D)
        {
            Debug.Log("Object Name: " + raycastHit2D.collider.gameObject.name);
            raycastHit2D.collider.enabled = false;
        }

        void GreenMarkAppears(GameObject greenMark, Vector3 greenMarkPosition)
        {
            Instantiate(greenMark, greenMarkPosition, Quaternion.identity);
        }

        void ObjectsCount(int count)
        {
            ObjectsFound.objectsFound += count;
        }
    }
}
