<?php
include 'classes/configs/config.php';
include_once 'classes/Utils.php';
include_once 'classes/blackupload/Upload.php';

$password = $_GET['password'];
if($password == $Panel_password)
{
    #get files list
    if(isset($_GET['id']))
    {
        #set id
        $id = $_GET['id'];

        $path = "upload/".$id;
        $filelist = array();

        if($handle = opendir($path)){
            while($entry = readdir($handle)){
                echo $entry."<br>";
            }

        closedir($handle);
        }
    }
    
    #upload files
    if(isset($_GET['upload']))
    {
        $utils = new Utils;

        $folder = "files/";
        $upload = new BlackUpload\Upload($_FILES['file'], realpath($folder), "classes/blackupload/");

        $upload->setINI(
            [
                "file_uploads" => 1,
                "memory_limit" => "2048MB",
                "upload_max_filesize" => "2048MB",
                "post_max_size" => "2048MB",
            ]
        );

        $upload->enableProtection();

        try {
            if (
                $upload->checkForbidden() &&
                $upload->checkExtension() &&
                $upload->checkMime()
            ) {
                $upload->upload();
            }
        } catch (Throwable $th) {
        }

    #end
    }

    if(isset($_GET['my_files']))
    {
        $path = "files/";
        $filelist = array();

        if($handle = opendir($path)){
            while($entry = readdir($handle)){
                echo $entry."<br>";
            }

        closedir($handle);
        }
    }

}
else
{
    echo "password error";
}