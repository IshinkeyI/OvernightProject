using UnityEngine;
using UnityEngine.SceneManagement;

[AddComponentMenu("Playground/Actions/Destroy Action")]
public class DestroyAction : Action
{
	public Enums.Targets target = Enums.Targets.ObjectThatCollided;
	public GameObject deathEffect;
	public bool isPlayer = false;

	public override bool ExecuteAction(GameObject otherObject)
	{
		if(deathEffect != null)
		{
			GameObject newObject = Instantiate(deathEffect);
			
			Vector3 otherObjectPos = otherObject == null ? transform.position : otherObject.transform.position;
			newObject.transform.position = (target == Enums.Targets.ObjectThatCollided)
				? otherObjectPos : transform.position;
		}

		if(target == Enums.Targets.ObjectThatCollided)
		{
			if(otherObject != null)
			{
				Destroy(otherObject);
			}
		}
		else
		{
			Destroy(gameObject);
			if(isPlayer)
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}

		return true;
	}
}
