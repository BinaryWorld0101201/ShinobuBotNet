<?php
include 'class/sql.php';
$sql = 'SELECT * FROM `users`';

$result = mysqli_query($link, $sql);

while ($row = mysqli_fetch_array($result)) {
    print ('"user": "Id: '.$row['id'].' Ip: '.$row['ip'].' UserName: '.$row['PC_user'].'"')
}

?>