<?php 
include 'class/sql.php';
$ip = $_SERVER['REMOTE_ADDR'];
$sql = 'SELECT id FROM users WHERE ip = "'.$ip.'"';
$result = mysqli_query($link, $sql);
while ($row = mysqli_fetch_array($result)) {
    print($row['id']);
}
?>