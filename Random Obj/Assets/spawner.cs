using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
public class spawner : MonoBehaviour
{
	public GameObject cube,sphere;
	string [] coords;
	List<string> gcube_coords = new List<string>();
	List<string> rcube_coords = new List<string>();
	List<string> gsphere_coords = new List<string>();
	string myFilePath, fileName;
	void Start()
	{
		fileName = "Assets/coords.txt";
		//myFilePath = Application.dataPath + "/" + fileName; 
		myFilePath = fileName;
		ReadFromTheFile ();

		for (int i = 0; i < gcube_coords.Count; i++) {
			
			var sStrings = gcube_coords[i].Split(","[0]);
			float x = float.Parse(sStrings[0]);
			float y = float.Parse(sStrings[1]);
			float z = float.Parse(sStrings[2]);

			GameObject my_cube = Instantiate (cube, new Vector3 (x, y, z), cube.transform.rotation);

			var cubeRenderer = my_cube.GetComponent<Renderer>();

			//Call SetColor using the shader property name "_Color" and setting the color to red
			cubeRenderer.material.SetColor("_Color", Color.green);
		}

		for (int i = 0; i < gsphere_coords.Count; i++) {

			var sStrings = gsphere_coords[i].Split(","[0]);
			float x = float.Parse(sStrings[0]);
			float y = float.Parse(sStrings[1]);
			float z = float.Parse(sStrings[2]);

			GameObject my_cube = Instantiate (sphere, new Vector3 (x, y, z), sphere.transform.rotation);

			var cubeRenderer = my_cube.GetComponent<Renderer>();

			//Call SetColor using the shader property name "_Color" and setting the color to red
			cubeRenderer.material.SetColor("_Color", Color.green);
		}

		for (int i = 0; i < rcube_coords.Count; i++) {

			var sStrings = rcube_coords[i].Split(","[0]);
			float x = float.Parse(sStrings[0]);
			float y = float.Parse(sStrings[1]);
			float z = float.Parse(sStrings[2]);

			GameObject my_cube = Instantiate (cube, new Vector3 (x, y, z), cube.transform.rotation);

			var cubeRenderer = my_cube.GetComponent<Renderer>();

			//Call SetColor using the shader property name "_Color" and setting the color to red
			cubeRenderer.material.SetColor("_Color", Color.red);
		}
	}

	void Update()
	{
		if (Input.anyKey)
		{	Application.Quit();	}
	}

	public void ReadFromTheFile(){
		int flag = 0;

		coords = File.ReadAllLines(myFilePath);
		foreach (string coord in coords)
		{
			//print (coord);
			if (coord.Equals("Green cubes") & flag == 0) {
				flag = 1;
				continue;
			}
			else if (coord.Equals("Green spheres") & flag == 0) {
				flag = 2;
				continue;
			}
			else if (coord.Equals("Red cubes") & flag == 0) {
				flag = 3;
				continue;
			}
			else if (coord == "") 
			{
				flag = 0;
				continue;
			}

			if (flag == 1)
			{	gcube_coords.Add (coord);	}
			else if (flag == 2)
			{	gsphere_coords.Add (coord);	}
			else if (flag == 3)
			{	rcube_coords.Add (coord);	}
		}
	}
}
