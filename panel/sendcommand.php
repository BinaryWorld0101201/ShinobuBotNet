<?php
include 'class/sql.php';
$id_user = $_GET['id'];
$type = $_GET['type'];
$content = $_GET['content'];
$sql = 'INSERT INTO command SET id_user = "'.$id_user.'", commandType = "'.$type.'", commandContent="'.$content.'"';
$result = mysqli_query($link, $sql);

if ($result == True) {
    print("command send!");
}
else
{
    print("error");
}
?>