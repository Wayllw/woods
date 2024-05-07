import tkinter as tk
import os
import requests

baseurl = "http://localhost:5175/api/blog/"



def obterInfo(id):
    response = requests.get(baseurl + id)
    print(response.json())


def addInfo(id, title, content):
    json={"id": id, "title": title, "content": content}
    response = requests.post(baseurl, json=json)
    print(response.json())


def editInfo(id, title, content):
    json={"id": id, "title": title, "content": content}
    response = requests.put(baseurl + id, json=json)
    print(response.json())

def deleteInfo(id):
    requests.delete(baseurl+id)


def buildPost():
    window.destroy()
    def confirm():
        id = entry_id.get()
        title = entry_title.get()
        content = entry_content.get()
        addInfo(id, title, content)
        janela.destroy()

    janela=tk.Tk()
    janela.title("Introduzir dados")

    label_id = tk.Label(janela, text="ID:")
    label_id.grid(row=0, column=0)
    entry_id = tk.Entry(janela)
    entry_id.grid(row=0, column=1)

    label_title = tk.Label(janela, text="Title:")
    label_title.grid(row=1, column=0)
    entry_title = tk.Entry(janela)
    entry_title.grid(row=1,column=1)

    label_content = tk.Label(janela, text="Context:")
    label_content.grid(row=2, column=0)
    entry_content = tk.Entry(janela)
    entry_content.grid(row=2,column=1)

    button = tk.Button(janela, text="Confirmar", command=confirm)
    button.grid(row=3, column=1)
    janela.mainloop()

def buildPut():
    window.destroy()
    def confirm():
        id = entry_id.get()
        title = entry_title.get()
        content = entry_content.get()
        editInfo(id, title, content)
        jenelo.destroy()

    jenelo=tk.Tk()
    jenelo.title("Introduzir dados")

    label_id = tk.Label(jenelo, text="ID:")
    label_id.grid(row=0, column=0)
    entry_id = tk.Entry(jenelo)
    entry_id.grid(row=0, column=1)

    label_title = tk.Label(jenelo, text="Title:")
    label_title.grid(row=1, column=0)
    entry_title = tk.Entry(jenelo)
    entry_title.grid(row=1,column=1)

    label_content = tk.Label(jenelo, text="Context:")
    label_content.grid(row=2, column=0)
    entry_content = tk.Entry(jenelo)
    entry_content.grid(row=2,column=1)

    button = tk.Button(jenelo, text="Confirmar", command=confirm)
    button.grid(row=3, column=1)
    jenelo.mainloop()

def buildGet():
    window.destroy()
    def confirm():
        id = entry_id.get()
        obterInfo(id)
        jnl.destroy()
    jnl = tk.Tk()
    jnl.title("Introduzir dados")
    label_id = tk.Label(jnl, text="ID:")
    label_id.grid(row=0, column=0)
    entry_id = tk.Entry(jnl)
    entry_id.grid(row=0, column=1)
    button_s=tk.Button(jnl, text="Confirmar", command=confirm)
    button_s.grid(row=1, column=1)


def buildDel():
    window.destroy()
    def confirm():
        id = entry_id.get()
        deleteInfo(id)
        jnl.destroy()
    jnl = tk.Tk()
    jnl.title("Introduzir dados")
    label_id = tk.Label(jnl, text="ID:")
    label_id.grid(row=0, column=0)
    entry_id = tk.Entry(jnl)
    entry_id.grid(row=0, column=1)
    button_s=tk.Button(jnl, text="Confirmar", command=confirm)
    button_s.grid(row=1, column=1)


window = tk.Tk()
window.title("Lattttttt")
get_entry = tk.Button(window, text="Get", command=buildGet)
get_entry.grid(row=0, column=0)
post_entry = tk.Button(window, text="Post", command=buildPost)
post_entry.grid(row=0, column=1)
put_entry = tk.Button(window, text="Put", command=buildPut)
put_entry.grid(row=0, column=2)
delete_entry = tk.Button(window, text="Delete", command=buildDel)
delete_entry.grid(row=0, column=3)
window.mainloop()