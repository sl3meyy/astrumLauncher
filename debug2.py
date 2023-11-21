import os
import zipfile
from tkinter import Tk, Button, Label, mainloop
from pydrive.auth import GoogleAuth
from pydrive.drive import GoogleDrive

def install_astrum():
    # Wechsle in das aktuelle Verzeichnis des Python-Skripts
    os.chdir(os.path.dirname(os.path.abspath(__file__)))

    # Überprüfe und erstelle die benötigten Ordner
    folders = ["C:\\WindScript", "C:\\WindScript\\astrum", "C:\\WindScript\\astrum\\test"]
    for folder in folders:
        if not os.path.exists(folder):
            os.makedirs(folder)

    # Wechsle in das Verzeichnis des Python-Skripts
    os.chdir(os.path.dirname(os.path.abspath(__file__)))

    # Google Authentication
    gauth = GoogleAuth()

    # Versuche, die Einstellungen zu laden
    try:
        gauth.LocalWebserverAuth()
    except KeyError:
        # Falls der 'client_config_file'-Schlüssel nicht gefunden wird, setze die Einstellungen manuell
        gauth.settings['client_config_file'] = 'client_secrets.json'
        gauth.LocalWebserverAuth()

    # Erstelle GoogleDrive-Objekt
    drive = GoogleDrive(gauth)

    # Google Drive-Ordnerlink
    folder_link = "1rJ9zyrmH4fIcEiKbjFClsGpc0l-22uqj"

    # Dateipfad für das Herunterladen
    download_path = "C:\\WindScript\\astrum\\test\\Astrum_package.zip"

    # Extraktionspfad
    extract_path = "C:\\WindScript\\astrum\\test"

    # Download der ZIP-Datei
    file_list = drive.ListFile({'q': f"'{folder_link}' in parents and trashed=false"}).GetList()
    if file_list:
        file_id = file_list[0]['id']
        file = drive.CreateFile({'id': file_id})

        # Informationen zum Downloadstart
        print("Download startet...")
        print(f"Dateiname: {file['title']}")
        print(f"Dateigröße: {file['fileSize']} Bytes")

        # Download und Extraktion der ZIP-Datei
        file.GetContentFile(download_path)

        # Überprüfung der heruntergeladenen Datei
        if os.path.getsize(download_path) == file['fileSize']:
            # Dateigröße stimmt mit der erwarteten Größe überein
            print("\nDownload erfolgreich.")

            # Entpacken der ZIP-Datei
            try:
                with zipfile.ZipFile(download_path, 'r') as zip_ref:
                    zip_ref.extractall(extract_path)
                print("Extraktion abgeschlossen.")
            except zipfile.BadZipFile:
                print("Fehler: Die heruntergeladene Datei ist keine gültige ZIP-Datei.")
        else:
            print("\nFehler beim Download. Die heruntergeladene Datei ist möglicherweise leer.")
            
        # Lösche die heruntergeladene ZIP-Datei
        
    else:
        print("Keine Dateien im angegebenen Google Drive-Ordner gefunden.")

    print("Astrum erfolgreich installiert.")

def launch_astrum():
    # Passe den Pfad entsprechend an
    game_launcher_path = "C:\\WindScript\\astrum\\test\\Astrum_package\\bin\\win_x64\\GameLauncher.exe"

    # Überprüfe, ob die Datei existiert, bevor du sie ausführst
    if os.path.exists(game_launcher_path):
        os.system(f'"{game_launcher_path}"')
    else:
        print("Error: Game not installed.")

# GUI für den Launcher erstellen
root = Tk()
root.title("Astrum Launcher")
root.geometry("750x500")
# Install Button
install_button = Button(root, text="Install", command=install_astrum)
install_button.pack()

# Launch Button
launch_button = Button(root, text="Launch", command=launch_astrum)
launch_button.pack()

# Quit Button
quit_button = Button(root, text="Quit", command=root.destroy)
quit_button.pack()

# GUI starten
mainloop()