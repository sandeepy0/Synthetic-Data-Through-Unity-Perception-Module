 using UnityEngine;
 using System.Collections;
 using System;
 using System.IO;
//  using Debug;
 public class CamRotation: MonoBehaviour {
 
    //  public float rotationSpeed = 10;
        // public string[] lines = File.ReadAllLines("textFile");  
    public AssambleScene AssambleScene;
    // public string path = "Assets/Resources/camera_positions.txt";
    public string[] lines;
    // public ArraySegment<string> arrSegment;
    public string[] arr;
    public int count=11;
    public float width;
    public float length;
    public float height;
    void Start()
    {
                // Read a text file line by line.  
        // string cwd = System.AppContext.BaseDirectory;
        // Console.WriteLine(cwd);
        // Debug.Log("Hello");

        lines = File.ReadAllLines(AssambleScene.camera_positions_file_path);
        // arr = new ArraySegment<string>(lines, 10, lines.Length);
        // Debug.Log("lines Length:");
        // Debug.Log(lines.Length);
        // string arrSegment = new ArraySegment<string>( lines, 10, lines.Length );
        // Debug.Log("Hello");
       

        string[] vars = lines[6].Split('\t');
       
        // width = int.Parse(vars[0]);
        // length = float.Parse(vars[1]);
        // height = float.Parse(vars[2]);

        // Debug.Log("width:" + width + "|");
        // Debug.Log("length:" + length + "|");
        // Debug.Log("height:" + height + "|");



        // Debug.Log(lines);

        // foreach (var el in lines)
        //     Debug.Log(el);
        // Debug.Log(arrSegment);
        // arr = arrSegment.ToArray();

        // Debug.Log(typeof(arr));
    }
 
    void Update() 
    {   

        var rotationVector = transform.rotation.eulerAngles;


        //if you put this in a coroutine and yielding for some amount of time 
        //you can have something like a rotating loading icon

        // foreach (var line in lines)
            // Debug.Log(line);
        // var line = lines[count].Trim();
        string[] vars = lines[count].Split(' ');
        // Debug.Log("Count " + count);
        // Debug.Log("vars.Length " + vars.Length);


        // foreach (var line in vars)
        //     Debug.Log(line);

        int index = int.Parse(vars[0]);
        float x = float.Parse(vars[1]);
        float y = float.Parse(vars[2]);
        float z = float.Parse(vars[3]);


        // Debug.Log("index:" + index + "|");
        // Debug.Log("x:" + x + "|");
        // Debug.Log("y:" + y + "|");
        // Debug.Log("z:" + z + "|");

        count += 1;

        rotationVector.x = x;  //this number is the degree of rotation around x Axis
        rotationVector.y = y;  //this number is the degree of rotation around y Axis
        rotationVector.z = z;  //this number is the degree of rotation around z Axis
        transform.rotation = Quaternion.Euler(rotationVector);
        // transform.position.x = transform.position.x * x;
        // transform.position.y = transform.position.y * y;
        // transform.position.z = transform.position.z * z;

        // public static transform.position Multiply (x,y,z); // * new Vector3(x, y, z);
        
        // transform.position = Vector3.Scale( transform.position, new Vector3(x, y, z));

    }
 }