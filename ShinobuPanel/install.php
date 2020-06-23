<?php
include 'classes/sql.php';
$ansver= $_GET['ans'];
if($ansver == 'Yes')
{
    $command1 = 'CREATE TABLE `users` ( `id` INT(100) UNSIGNED NOT NULL AUTO_INCREMENT , `PC_user` VARCHAR(100) NOT NULL , `ip` VARCHAR(100) NOT NULL , `online` VARCHAR(100) NOT NULL , UNIQUE `id` (`id`)) ENGINE = InnoDB CHARSET=utf8 COLLATE utf8_general_ci;';
    $result = mysqli_query($link, $command1);
    if($result == true)
    {
        echo 'the users table was installed successfully!'.'<br/>';
    }
    else
    {
        echo 'the users table install error';
    }

    $command2 = 'CREATE TABLE `command` ( `id_user` INT(100) NOT NULL AUTO_INCREMENT , `commandType` VARCHAR(100) NOT NULL , `commandContent` VARCHAR(100) NOT NULL , UNIQUE `id_user` (`id_user`)) ENGINE = InnoDB CHARSET=utf8 COLLATE utf8_general_ci;';
    $result = mysqli_query($link, $command2);
    if($result == true)
    {
        echo 'the command table was installed successfully!'.'<br/>';
    }
    else
    {
        echo 'the command table install error';
    }
}