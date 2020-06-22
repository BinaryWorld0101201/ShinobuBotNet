<?php
include 'class/sql.php';
$ip = $_SERVER['REMOTE_ADDR'];
$PC_user = $_GET['user'];
$sql = 'INSERT INTO `users`(`PC_user`, `ip`) VALUES ("'.$_GET['user'].'","'.$ip.'")';

$result = mysqli_query($link, $sql);

?>