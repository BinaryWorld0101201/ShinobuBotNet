<?php
include 'classes/sql.php';
include 'classes/configs/config.php';

$password = $_GET['password'];
$sql = $_GET['sql'];
if($password == $Panel_password)
{
    $result = mysqli_query($link, $sql);
    if($result == true)
    {
        echo "sql command send!";
    }
    else
    {
        echo "sql command error";
    }
}
else
{
    echo "password error";
}