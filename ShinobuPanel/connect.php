<?php
//connect to sql
include 'classes/sql.php';
//get ip
$ip = $_SERVER['REMOTE_ADDR'];
//get username
$PC_user = $_GET['user'];
//connct user to db
$sql = 'INSERT INTO `users`(`PC_user`, `ip`, `online`) VALUES ("'.$PC_user.'","'.$ip.'","Online")';
//querty
$result = mysqli_query($link, $sql);
if($result == true)
{
    echo 'db write'.'<br/>';
}
else
{
	echo "ERROR".'<br/>';
}
//get id command
$GetIdCommand = 'SELECT id FROM users WHERE ip = "'.$ip.'"';
//querty result
$idquery = mysqli_query($link, $GetIdCommand);
//get info about result
while ($id = mysqli_fetch_array($idquery)) {
    $nullcommand = 'INSERT INTO `command`(`id_user`, `commandType`, `commandContent`) VALUES ("'.$id['id'].'","null","")';
    $result = mysqli_query($link, $nullcommand);
    print 'connected'.'<br/>';
}
