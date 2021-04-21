using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GestorPersistencia : MonoBehaviour
{
    public static GestorPersistencia instancia;
    public DataPersistencia data;
    string archivoDatos = "save.dat";

    private void Awake()
    {
        if (instancia == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instancia = this;
        }
        else if (instancia != this)
            Destroy(this.gameObject);

        CargarDataPersistencia();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) GuardarDataPersistencia();
    }

    public void GuardarDataPersistencia()
    {
        string filePath = Application.persistentDataPath + "/" + archivoDatos;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(filePath);
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Datos guardados");
    }

    public void CargarDataPersistencia()
    {
        string filePath = Application.persistentDataPath + "/" + archivoDatos;
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(filePath))
        {
            FileStream file = File.Open(filePath, FileMode.Open);
            DataPersistencia cargado = (DataPersistencia)bf.Deserialize(file);
            data = cargado;
            file.Close();
            Debug.Log("Datos cargados");
        }
    }
}
[System.Serializable]
public class DataPersistencia
{
    public float highscore = 0;
    public DataPersistencia()
    {
        highscore = 0;
    }
}


