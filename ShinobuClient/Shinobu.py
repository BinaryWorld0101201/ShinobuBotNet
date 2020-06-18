import requests
import os
import json
from colorama import Fore, Back, init
init(autoreset=True)
print(Fore.MAGENTA + '''
░██████╗██╗░░██╗██╗███╗░░██╗░█████╗░██████╗░██╗░░░██╗██████╗░░█████╗░████████╗███╗░░██╗███████╗████████╗
██╔════╝██║░░██║██║████╗░██║██╔══██╗██╔══██╗██║░░░██║██╔══██╗██╔══██╗╚══██╔══╝████╗░██║██╔════╝╚══██╔══╝
╚█████╗░███████║██║██╔██╗██║██║░░██║██████╦╝██║░░░██║██████╦╝██║░░██║░░░██║░░░██╔██╗██║█████╗░░░░░██║░░░
░╚═══██╗██╔══██║██║██║╚████║██║░░██║██╔══██╗██║░░░██║██╔══██╗██║░░██║░░░██║░░░██║╚████║██╔══╝░░░░░██║░░░
██████╔╝██║░░██║██║██║░╚███║╚█████╔╝██████╦╝╚██████╔╝██████╦╝╚█████╔╝░░░██║░░░██║░╚███║███████╗░░░██║░░░
╚═════╝░╚═╝░░╚═╝╚═╝╚═╝░░╚══╝░╚════╝░╚═════╝░░╚═════╝░╚═════╝░░╚════╝░░░░╚═╝░░░╚═╝░░╚══╝╚══════╝░░░╚═╝░░░
''')

if(os.path.isfile('URL.txt') == False):
	file = open('URL.txt', 'w')
	URL = input(Fore.YELLOW + '[?] - Enter URL: ')
	file.write(URL)
	file.close()
	print(Fore.GREEN + '[!] - url ' + URL + ' set')

print(Fore.GREEN + '[!] - Get URL')
file = open('URL.txt')
url = file.read()
print(Fore.GREEN + '[!] - URL set')
response = requests.get(url + 'GetUsers.php')
userslist = json.load(response.text)

