<?php
include 'classes/sql.php';
$id = $_GET['id'];
$comand = 'UPDATE `users` SET `online`= "Online" WHERE id ="'.$id.'"';
mysqli_query($link, $comand);