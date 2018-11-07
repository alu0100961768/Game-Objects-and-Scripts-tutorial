using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fractal : MonoBehaviour {

	public Mesh[] meshes;
	public Material material;

	private Material[,] materials;

	public int maxDepth;
	private int depth;
	public float childScale;

	private void Start() {
		if (materials == null) {
			InitializeMaterials ();
		}

		gameObject.AddComponent<MeshFilter> ().mesh= meshes[Random.Range(0, meshes.Length)];
		gameObject.AddComponent<MeshRenderer> ().material= materials[depth, Random.Range(0, 2)];
		//GetComponent<MeshRenderer> ().material.color = Color.Lerp (Color.white, Color.yellow, (float)depth / maxDepth);
		if (depth < maxDepth) {
			StartCoroutine (CreateChildren ());
		}
	}

	private static Vector3[] childDirections= {
		Vector3.up, Vector3.right, Vector3.left, Vector3.forward, Vector3.back
	};

	private static Quaternion[] childOrientations= {
		Quaternion.identity,  Quaternion.Euler (0f, 0f, -90f), Quaternion.Euler (0f, 0f, 90f), Quaternion.Euler (90f, 0f, 0f), Quaternion.Euler (-90f, 0f, 0f)
	};

	private void InitializeMaterials() {
	
		materials = new Material[maxDepth + 1, 2];
		for (int i = 0; i <= maxDepth; i++) {
			float t = i / (maxDepth / 1f);
			t *= t;
			materials[i, 0] = new Material (material);
			materials[i, 0].color= Color.Lerp (Color.white, Color.yellow, (float)i / maxDepth);
			materials[i, 1] = new Material (material);
			materials[i, 1].color= Color.Lerp (Color.white, Color.cyan, (float)i / maxDepth);
		}
		materials[maxDepth, 0].color = Color.magenta;
		materials[maxDepth, 1].color = Color.red;
	
	}


	private IEnumerator CreateChildren(){

		for (int i = 0; i < childDirections.Length; i++) {
			yield return new WaitForSeconds (Random.Range(0.1f, 0.5f));
			new GameObject ("Fractal Child").AddComponent<Fractal> ().Initialize (this, i);
		}




		/*yield return new WaitForSeconds (0.5f);
		new GameObject ("Fractal Child").AddComponent<Fractal> ().Initialize(this, Vector3.up, Quaternion.identity);
		yield return new WaitForSeconds (0.5f);
		new GameObject ("Fractal Child").AddComponent<Fractal> ().Initialize(this, Vector3.right, Quaternion.Euler(0f, 0f, -90f));
		yield return new WaitForSeconds (0.5f);
		new GameObject ("Fractal Child").AddComponent<Fractal> ().Initialize(this, Vector3.left, Quaternion.Euler(0f, 0f, 90f));*/
	  }

	private void Initialize(Fractal parent, int childIndex){
		meshes= parent.meshes;
		materials= parent.materials;
		maxDepth= parent.maxDepth;
		depth= parent.depth+ 1;
		childScale= parent.childScale;

		transform.parent = parent.transform;
		transform.localRotation = childOrientations [childIndex];
		transform.localScale= Vector3.one * childScale;
		transform.localPosition = childDirections[childIndex] * (0.5f + 0.5f * childScale);

	}









}
