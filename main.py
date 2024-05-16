import tkinter as tk
from tkinter import font, filedialog
import requests
import json
import csv
import ast

baseurl = "http://localhost:5175/api/blog/"


def exportarInfo(id, path):
    response = requests.get(baseurl+id)
    response = str(response.json())
    fw = open(path+".json", "w")
    json_dat = json.dumps(ast.literal_eval(response))
    dict_dat = json.loads(json_dat)
    json.dump(dict_dat, fw)
    fw.write("\n")
    print(response)


def exportarCsv(id, path):
    response = requests.get(baseurl+"csv/"+id)
    print(response.text)
    csv_file = path+".csv"

    csv_obj = open(csv_file, "w")
    csv_writer = csv.writer(csv_obj)

    data = response.text.splitlines()
    for row in csv.reader(data):
        csv_writer.writerow(row)
    csv_obj.close()

    print(response)



def addInfo(id, title, content):
    json = {"id": id, "title": title, "content": content}
    requests.post(baseurl, json=json)
    print(json)


def importInfo(file):
    with open(file, "r") as importation:
        data = json.load(importation)
    requests.post(baseurl, json=data)
    print(data)


def editInfo(id, title, content):
    json = {"id": id, "title": title, "content": content}
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

    def confirm2():
        def importat():
            path = file_path.cget("text")
            importInfo(path)
            win.destroy()

        def browse():
            file = filedialog.askopenfilename()
            file_path.config(text=file)
        janela.destroy()

        win = tk.Tk()
        win.title("Choose file:")
        file_path_label = tk.Label(win, text="Choose your file:")
        file_path_label.grid(row=0, column=0)
        file_path = tk.Label(win)
        file_path.grid(row=1, column=0, columnspan=3)
        btn = tk.Button(win, text="browse", command=browse)
        btn.grid(row=0, column=1)

        but = tk.Button(win, text="Confirmar", command=importat)
        but.grid(row=2, column=0, columnspan=3)

        win.configure(bg="#49cc90")
        file_path.configure(bg="#49cc90", fg="white", font=bold)
        file_path_label.configure(bg="#49cc90", fg="white", font=bold)
        but.configure(bg="#49cc90", fg="white", font=bold)
        btn.configure(bg="#49cc90", fg="white", font=bold)

    janela = tk.Tk()
    janela.title("Introduzir dados")

    label_id = tk.Label(janela, text="ID:")
    label_id.grid(row=0, column=0)
    entry_id = tk.Entry(janela)
    entry_id.grid(row=0, column=1)

    label_title = tk.Label(janela, text="Title:")
    label_title.grid(row=1, column=0)
    entry_title = tk.Entry(janela)
    entry_title.grid(row=1, column=1)

    label_content = tk.Label(janela, text="Content:")
    label_content.grid(row=2, column=0)
    entry_content = tk.Entry(janela)
    entry_content.grid(row=2, column=1)

    button = tk.Button(janela, text="Confirmar", command=confirm)
    button.grid(row=3, column=1)
    buttons = tk.Button(janela, text="Importar", command=confirm2)
    buttons.grid(row=3, column=0)

    janela.configure(bg="#49cc90")
    label_id.configure(bg="#49cc90", fg="white", font=bold)
    label_title.configure(bg="#49cc90", fg="white", font=bold)
    label_content.configure(bg="#49cc90", fg="white", font=bold)
    button.configure(bg="#49cc90", fg="white", font=bold)
    buttons.configure(bg="#49cc90", fg="white", font=bold)

    janela.mainloop()


def buildPut():
    window.destroy()

    def confirm():
        id = entry_id.get()
        title = entry_title.get()
        content = entry_content.get()
        editInfo(id, title, content)
        jenelo.destroy()

    jenelo = tk.Tk()
    jenelo.title("Introduzir dados")
    label_id = tk.Label(jenelo, text="ID:")
    label_id.grid(row=0, column=0)
    entry_id = tk.Entry(jenelo)
    entry_id.grid(row=0, column=1)
    label_title = tk.Label(jenelo, text="Title:")
    label_title.grid(row=1, column=0)
    entry_title = tk.Entry(jenelo)
    entry_title.grid(row=1, column=1)
    label_content = tk.Label(jenelo, text="Content:")
    label_content.grid(row=2, column=0)
    entry_content = tk.Entry(jenelo)
    entry_content.grid(row=2, column=1)
    button = tk.Button(jenelo, text="Confirmar", command=confirm)
    button.grid(row=3, column=1)

    jenelo.configure(bg="#fca130")
    label_id.configure(bg="#fca130", fg="white", font=bold)
    label_title.configure(bg="#fca130", fg="white", font=bold)
    label_content.configure(bg="#fca130", fg="white", font=bold)
    button.configure(bg="#fca130", fg="white", font=bold)

    jenelo.mainloop()


def buildGet():
    window.destroy()

    def confirm():
        file_path = filedialog.asksaveasfilename()
        file_path_label.config(text=file_path)

    def confirm2():
        id = entry_id.get()
        path = file_path_label.cget("text")
        exportarInfo(id, path)
        jnl.destroy()


    def confirm3():
        id = entry_id.get()
        path = file_path_label.cget("text")
        exportarCsv(id, path)
        jnl.destroy()

    jnl = tk.Tk()
    jnl.title("Introduzir dados")
    label_id = tk.Label(jnl, text="ID:")
    label_id.grid(row=0, column=0)
    entry_id = tk.Entry(jnl)
    entry_id.grid(row=0, column=1)
    button_s = tk.Button(jnl, text="Browse", command=confirm)
    file_path_label = tk.Label(jnl)
    file_path_label.grid(row=1, column=0, columnspan=3)
    button_s.grid(row=2, column=1)
    button_d = tk.Button(jnl, text="Exportar", command=confirm2)
    button_d.grid(row=3, column=1)
    button_c = tk.Button(jnl, text="CSV", command=confirm3)
    button_c.grid(row=4, column=1)
    jnl.configure(bg="#61affe")
    label_id.configure(bg="#61affe", fg="white", font=bold)
    file_path_label.configure(bg="#61affe", fg="white", font=bold)
    button_s.configure(bg="#61affe", fg="white", font=bold)
    button_d.configure(bg="#61affe", fg="white", font=bold)
    button_c.configure(bg="#61affe", fg="white", font=bold)


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
    button_s = tk.Button(jnl, text="Confirmar", command=confirm)
    button_s.grid(row=1, column=1)
    jnl.configure(bg="#f93e3e")
    label_id.configure(bg="#f93e3e", fg="white", font=bold)
    button_s.configure(bg="#f93e3e", fg="white", font=bold)


window = tk.Tk()
bold = font.Font(weight="bold")

window.title("Select what u want to do:")
window.eval('tk::PlaceWindow . center')
get_entry = tk.Button(window, text="Get", command=buildGet, width=20, height=5, font=bold)
get_entry.grid(row=0, column=0, sticky='EWNS')
post_entry = tk.Button(window, text="Post", command=buildPost, width=20, height=5, font=bold)
post_entry.grid(row=0, column=1, sticky='EWNS')
put_entry = tk.Button(window, text="Put", command=buildPut, width=20, height=5, font=bold)
put_entry.grid(row=1, column=0, sticky='EWNS')
delete_entry = tk.Button(window, text="Delete", command=buildDel, width=20, height=5, font=bold)
delete_entry.grid(row=1, column=1, sticky='EWNS')

get_entry.configure(bg="#61affe", fg="white",)
post_entry.configure(bg="#49cc90", fg="white")
put_entry.configure(bg="#fca130", fg="white")
delete_entry.configure(bg="#f93e3e", fg="white")
window.mainloop()
