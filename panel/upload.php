<?php
include 'class/sql.php';

//достаём id и папку 

$id = $_GET['id'];
$uploads_dir = './files/'.$id.'/';
//отправка файла
if ($_FILES["file"]["error"] == UPLOAD_ERR_OK) {
    $tmp_name = $_FILES["file"]["tmp_name"];
    $name = $_FILES["file"]["name"];
    move_uploaded_file($tmp_name, $uploads_dir);
}
?>
