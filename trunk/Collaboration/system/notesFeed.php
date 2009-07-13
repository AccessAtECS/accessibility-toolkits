<?php
require("core.php");
require("../tasks/include/config.php");

$db = new db(TZN_DB_HOST, TZN_DB_USER, TZN_DB_PASS, TZN_DB_BASE);

$result = $db->single( "SELECT user, name, URL, comments, unix_timestamp(time) AS time FROM tasks.lnk_links ORDER BY time DESC LIMIT 0, 25" );

foreach($result as $key => $note){
	$output[$key] = array($note['user'], $note['name'], $note['URL'], $note['comments'], date("M j", $note['time']));
}

echo json_encode($output);

?>