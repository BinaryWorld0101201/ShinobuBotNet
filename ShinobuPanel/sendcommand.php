<?php
include 'classes/sql.php';
$id_user = $_GET['id'];
$type = $_GET['type'];
$content = $_GET['content'];
if($content == null)
{
    $deletecommand = 'DELETE FROM command WHERE id_user = "'.$id_user.'"';
    $deletresult = mysqli_query($link, $deletecommand);

    if($deletresult == true)
    {
        echo 'old command delet'.'<br/>';
        $sql = 'INSERT INTO `command`(`id_user`, `commandType`, `commandContent`) VALUES ("'.$id_user.'","'.$type.'","")';
        $result = mysqli_query($link, $sql);

        if ($result == true) {
            echo 'command send!'.'<br/>';
        }

        else
        {
            echo 'ERROR!'.'<br/>';
        }
    }

    else
    {
        echo 'old command not delete!'.'<br/>';
        echo 'ERROR!';
    }

}

else
{
    $deletecommand = 'DELETE FROM command WHERE id_user = "'.$id_user.'"';
    $deletresult = mysqli_query($link, $deletecommand);
    if($deletresult == true)
    {
        echo 'old command delet';
    }
    

    $sql = 'INSERT INTO command SET id_user = "'.$id_user.'", commandType = "'.$type.'", commandContent="'.$content.'"';
    $result = mysqli_query($link, $sql);

    if ($result == True) {
        print("command send!");
    }
    else
    {
        print("error");
    }
}

?>