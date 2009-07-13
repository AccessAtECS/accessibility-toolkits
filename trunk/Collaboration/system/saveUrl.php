<?php
require("core.php");
require("../tasks/include/config.php");

$username 	= $_POST['username'];
$name 		= $_POST['name'];
$url 		= $_POST['url'];
$phrase 	= $_POST['phrase'];
$comments	= $_POST['comments'];


if($phrase != "duck"){
	echo "{success: false, message: 'The phrase was incorrect.'}";
	exit;
} else {
	$db = new db(TZN_DB_HOST, TZN_DB_USER, TZN_DB_PASS, TZN_DB_BASE);
	
	$query = $db->prepare("INSERT INTO `tasks`.`lnk_links` (user, name, URL, comments, time) VALUES(?,?,?,?, NOW())");
	$query->bind_param('ssss', $username, $name, $url, $comments);
	$query->execute();
	echo "{success: true, message: 'Data saved successfully.'}";
	exit;
}

echo "{success: false, message: 'Something went wrong.'}";
?>