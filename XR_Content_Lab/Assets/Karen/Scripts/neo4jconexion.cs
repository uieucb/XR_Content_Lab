using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Neo4jClient;
using Neo4j.Driver;
using Neo4j;
using System;
using System.Linq;
using UnityEngine.UI;

public class neo4jconexion : MonoBehaviour
{
    public InputField nombreField;
    public InputField edadField;  
    public InputField sexoField;
    public InputField ciField;
    public InputField dptoField;
    public InputField textoBusqueda;
    public Text busco;

    public string resultado="";



    // Start is called before the first frame update
    void Start()
    {

        
    }
    public void inicio(){
        string unombre=nombreField.text;
        string uedad=edadField.text;
        string usexo=sexoField.text;
        string uci=ciField.text;
        string udpto=dptoField.text;
        bool bandera=sinblancos(unombre,uedad,usexo,uci,udpto);
        if(bandera==false){
            ingresandatos(unombre,uedad,usexo,uci,udpto);
        }else{
            print("Todos los espacios deben ser llenados");
        }
        
    }
    


    void Update()
    {
        
    }
    
    void ingresandatos(string unombre,string uedad,string usexo,string uci,string udpto){
       /*Comenzando la conexion para pasar los datos al Neo4j*/ 
        var conexion = new HelloWorldExample("bolt://localhost:7687", "neo4j", "password");
        /*enviando los datos a la funcion senddata*/
        conexion.SendData(unombre,uedad,usexo,uci,udpto);



    }


    /*--------Evitando que se ingresen celdas que no contienen valores*/
    public bool sinblancos(string unombre,string uedad,string usexo,string uci,string udpto){
        bool bandera=false;
        if(unombre=="" || uedad=="" || usexo=="" || uci=="" || udpto==""){
            bandera=true;
        }else{
            bandera=false;
        }
        return bandera;

    }


public class HelloWorldExample : IDisposable
{
    private bool _disposed = false;
    
    private readonly IDriver _driver;

    ~HelloWorldExample() => Dispose(false);

    public HelloWorldExample(string uri, string user, string password)
    {
        _driver = GraphDatabase.Driver(uri, AuthTokens.Basic(user, password));
    }


    public void SendData(string unombre,string uedad,string usexo,string uci,string udpto)
    {
        string message=unombre+"h"+uedad+"o"+usexo;
        using (var session = _driver.AsyncSession())
        {
            var greeting = session.WriteTransactionAsync(tx =>
            {
            
                var result = tx.RunAsync("CREATE (a:Greeting) " +
                                    "SET a.message = $message " +
                                    "RETURN a.message + ', from node ' + id(a)",
                    new {message});
        
                return result;
            });
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        if (disposing)
        {
            _driver?.Dispose();
        }

        _disposed = true;
    }
}
}
