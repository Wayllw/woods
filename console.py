import requests
import json
import ast
import csv

baseurl = "http://localhost:5175/api/blog/"
tok: str = None

def menu():
    print("Escolha:")
    print("[1] LogIn")
    print("[2] Registo")
    x = input()
    if x == "1":
        logIn()
    elif x == "2":
        registo()

def token():
    print("Digite o token:")
    tkn = input()
    rq = requests.get("http://localhost:5175/api/Auth/validate-token?token="+tkn)
    if rq.status_code == 200:
        menu2()
    else:
        print("Ocorreu um erro a validar o token, verifique a existência de espaços,tente novamente.")


def registo():
    print("Registo")
    print("Username:")
    username = input()
    print("Password:")
    password = input()
    if username != None  and password != None and len(username) > 0 and len(password) > 0:
        url = "http://localhost:5175/api/Auth/register"
        json = {"username": username, "password": password}
        response = requests.post(url, json=json)
        if response.status_code == 200:
            print("Registrado com sucesso!")


def logIn():
    print ("Log In")
    print("Username:")
    username = input()
    print("Password:")
    password = input()
    if username != None  and password != None and len(username) > 0 and len(password) > 0:
        global tok
        url = "http://localhost:5175/api/Auth/login"
        json = {"username": username, "password": password}
        response = requests.post(url, json=json)
        if response.status_code == 200:
            tok = response.json().get('token')
            open("token.txt", 'w').write(tok)
            print(tok)
            token()
        elif response.status_code == 401:
            print("Credenciais Erradas")
        else:
            print("Algo inesperado aconteceu!")


def menu2():
    print("Escolha:")
    print("[1] Importar")
    print("[2] Exportar")
    print("[3] Editar")
    print("[4] Eliminar")
    x = input()
    if x == "1":
        print("Caminho para o ficheiro:")
        file = input()
        global tok
        with open(file, "r") as importation:
            data = json.load(importation)
        requests.post(baseurl + "?token=" + tok, json=data)
    elif x == "2":
        print("Escolha:")
        print("[1] Json")
        print("[2] CSV")
        c=input()
        if c == "1":
            print("nome do ficheiro:")
            nome = input()
            print("Caminho para o ficheiro:")
            path = input()
            print("id:")
            id = input()
            response = requests.get(baseurl + id + "?token=" + tok)
            response = str(response.json())
            fw = open(path + "/" + nome + ".json", "w")
            json_dat = json.dumps(ast.literal_eval(response))
            dict_dat = json.loads(json_dat)
            json.dump(dict_dat, fw)
            fw.write("\n")

        elif c == "2":
            print("nome do ficheiro:")
            nome = input()
            print("Caminho para o ficheiro:")
            path = input()
            print("id:")
            id = input()


            response = requests.get(baseurl + "csv/" + id + "?token=" + tok)
            csv_file = path + "/" + nome + ".csv"

            csv_obj = open(csv_file, "w")
            csv_writer = csv.writer(csv_obj)

            data = response.text.splitlines()
            for row in csv.reader(data):
                csv_writer.writerow(row)
            csv_obj.close()

    elif x == "3":
        print("Id:")
        id = input()
        print("Name:")
        name = input()
        print("Venue:")
        venue = input()
        print("Street:")
        street = input()
        print("City:")
        city = input()
        print("State:")
        state = input()
        print("Zip:")
        zip = input()
        print("Country:")
        country = input()

        arestoteles = {"id": id, "name": name, "venue": venue, "street": street, "city": city, "state": state, "zip": zip, "country": country}
        response = requests.put(baseurl + id + "?token=" + tok, json=arestoteles)
        print(response.json())

    elif x == "4":
        print("id:")
        id = input()
        requests.delete(baseurl + id + "?token=" + tok)



if __name__ == '__main__':
    menu()