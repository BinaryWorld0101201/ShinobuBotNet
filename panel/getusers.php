<?php
include 'class/sql.php';
$sql = 'SELECT * FROM `users`';

$result = mysqli_query($link, $sql);

while ($row = mysqli_fetch_array($result)) {
    echo 'ID: '.$row['id'].' , IP: '.$row['ip'].' , User Name: '.$row['PC_user'];
}

?>