using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerGrab : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] GameObject fireflyPrefab;
    public Observable<int> heldFireflies = new(0);
    public List<Collider> enteredColliders = new List<Collider>();
    public Animator animator, lanternAnimator;
    public List<GameObject> grabbedFireflies = new List<GameObject>();

#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
    const string interactButton = "Interact_Mac";
#elif UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
    const string interactButton = "Interact_Windows";
#endif

    public bool isOnHub = false;

    void Start()
    {
        gameManager = GameManager.instance;
        if (isOnHub)
        {
            heldFireflies.value = gameManager.heldFirefliesOnHub;
            heldFireflies.Subscribe((heldFireflies) =>
            {
                gameManager.heldFirefliesOnHub = heldFireflies;
            });
        }
    }

    private void Update()
    {
        for (int i = 0; i < 20; i++)
        {
            if (Input.GetKeyDown("joystick 1 button " + i))
            {
                print("joystick 1 button " + i);
            }
        }
        if (Input.GetButtonDown(interactButton))
        {
            Interact();
        }
        if (isGrabbing)
        {
            grabAnimTime += Time.deltaTime;
            if (grabbedFireflies[0] != null)
            {
                lastFirefly.transform.position = Vector3.Lerp(lastFirefly.transform.position, lanternPos.position, grabAnimTime);
                lastFirefly.transform.localScale = Vector3.Lerp(lastFirefly.transform.localScale, Vector3.zero, grabAnimTime);

            }
            if (grabAnimTime > 0.5f)
            {
                isGrabbing = false;
            }
        }
    }

    void Interact()
    {
        if (enteredColliders.Count > 0)
        {
            Collider closestCollider = enteredColliders[0];
            for (int i = 0; i < enteredColliders.Count; i++)
            {
                if (enteredColliders[i].GetComponentInParent<Firefly>())
                {
                    closestCollider = enteredColliders[i];
                    StartCoroutine(GrabFirefly(enteredColliders[i].gameObject.transform.parent.gameObject));
                    closestCollider.GetComponent<IInteractable>().Interact();
                    return;
                }
                if (Vector3.Distance(transform.position, enteredColliders[i].transform.position) < Vector3.Distance(transform.position, closestCollider.transform.position))
                {
                    closestCollider = enteredColliders[i];
                    ReleaseLastFirefly(grabbedFireflies[0]);
                }
            }
            closestCollider.GetComponent<IInteractable>().Interact();
            animator.SetTrigger("Interact");
            lanternAnimator.SetTrigger("Interact");
        }
        UpdateFirefliesInLantern();
    }

    public Transform lanternPos;
    float grabAnimTime = 0f;
    bool isGrabbing;
    GameObject lastFirefly;
    IEnumerator GrabFirefly(GameObject firefly)
    {
        lastFirefly = firefly;
        grabAnimTime = 0f;
        grabbedFireflies.Add(firefly);
        isGrabbing = true;
        grabbedFireflies[0].GetComponent<Rigidbody>().isKinematic = true;
        grabbedFireflies[0].GetComponent<Collider>().enabled = false;
        grabbedFireflies[0].GetComponent<Firefly>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        grabbedFireflies[0].transform.position = lanternPos.position;
        isGrabbing = false;
        UpdateFirefliesInLantern();
    }

    void ReleaseLastFirefly(GameObject firefly)
    {
        grabbedFireflies.Remove(firefly);
        firefly.GetComponent<Rigidbody>().isKinematic = false;
        firefly.GetComponent<Collider>().enabled = true;
        firefly.GetComponent<Firefly>().enabled = true;
        UpdateFirefliesInLantern();
    }

    public List<GameObject> FirefliesInLantern = new();
    public void UpdateFirefliesInLantern()
    {
        for (int i = 0; i < 5; i++)
        {
            FirefliesInLantern[i].SetActive(false);

        }
        for (int i = 0; i < heldFireflies.value; i++)
        {
            FirefliesInLantern[i].SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IInteractable>() != null)
        {
            enteredColliders.Add(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<IInteractable>() != null)
        {
            enteredColliders.Remove(other);
        }
    }

    public void ReleaseFirefly()
    {
        heldFireflies.value--;
        Instantiate(fireflyPrefab, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z + 3), Quaternion.identity);
    }
}
