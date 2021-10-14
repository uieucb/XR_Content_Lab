

import socket #0110011
import time

import sys
import time
import numpy as np
import random
import pandas as pd

from neo4j import GraphDatabase


data_base_connection = GraphDatabase.driver(uri = "bolt://localhost:7687", auth=("neo4j", "password"))
session = data_base_connection.session()   
ql="MATCH(x) WHERE x.name='Barcelona' return (x) LIMIT 3"



host, port="127.0.0.1", 25001
sock=socket.socket(socket.AF_INET,socket.SOCK_STREAM)
sock.connect((host, port))

startPos = [0,0,0]
while True:

    inicio="buena"
    sock.sendall(inicio.encode("UTF-8"))


    receivedData=sock.recv(1024).decode("UTF-8")
    print(receivedData)


    nodes=session.run(receivedData)

    
    posString=""
    for node in nodes:
         posString+="".join(map(str,node))
         print(posString)

    if (posString!=""):
        sock.sendall(posString.encode("UTF-8"))
        print(posString.encode("UTF-8"))
    else:
        sock.sendall(posString.encode("UTF-8"))
        print(posString.encode("UTF-8"))

    
    

    


