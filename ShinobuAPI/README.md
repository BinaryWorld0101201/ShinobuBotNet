#  ShinobuBotNet API
>before using the API, configure config.cs
*  Bots
	* [Create bot](#create-bot)
    * [Get ID](#get-id)
    * [Cheak Connect](#cheak-connect)
    * [Create Cheak File](#create-cheak-file)
    * [Get Command](#get-command)
* Client
    * [Get Users List](#get-users-list)
    * [Send Command](#send-command)
###### Create Bot:
```API.connect();```

###### Get ID:
```string id = API.Get_ID();```
>return id
###### Cheak Connect:
```string cheak = API.cheak_connect();```
>return yes or no

###### Create Cheak File:
```API.create_cheak_File();```

###### Get Command:
```string command = API.GetCommand(your id);```
>it can return null on the first run

###### Get Users List:
```string userslist = API.GetUsers();```

###### Get Users List:
```string userslist = API.GetUsers();```

###### Get Users List:
```string result = API.SendCommand(id,type,content);```
>you don't have to write" content"