<?php
include 'classes/sql.php';
$id = $_GET['id'];
mysqli_query($link, 'UPDATE `users` SET `online`= "Offline" WHERE id = "'.$id.'"');
$deletecommand = 'DELETE FROM command WHERE id_user = "'.$id_user.'"';
$deletresult = mysqli_query($link, $deletecommand);

if($deletresult == true)
{
    $sql = 'INSERT INTO `command`(`id_user`, `commandType`, `commandContent`) VALUES ("'.$id.'","ping","")';
    $result = mysqli_query($link, $sql);

    if ($result == true) {
        echo 'command send!'.'<br/>';
    }

    else
    {
        echo 'ERROR!'.'<br/>';
    }
}