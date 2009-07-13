<?php
require("core.php");
require("../tasks/include/config.php");

$query = "SELECT i.itemId, itemStatusId, i.priority, i.title, i.description, unix_timestamp(i.deadlineDate) AS deadlineDate, m.firstName AS firstName, p.name AS pName, max((s.statusKey/5)*100) AS status
FROM tasks.frk_item as i
LEFT JOIN frk_member AS m ON (i.memberId = m.memberId) 
LEFT JOIN frk_project AS p ON (i.projectId = p.projectId)
LEFT JOIN (
	SELECT max(statusKey) AS statusKey, itemStatusId, itemId
	FROM frk_itemStatus 
	GROUP BY itemId
	) AS s ON (i.itemId = s.itemId)
WHERE i.deadlineDate >= CURDATE() AND s.statusKey != 5 OR s.statusKey < 5 AND i.deadlineDate <= CURDATE()
GROUP BY s.itemId
ORDER BY deadlineDate ASC, s.itemStatusId DESC
LIMIT 0, 40";

$db = new db(TZN_DB_HOST, TZN_DB_USER, TZN_DB_PASS, TZN_DB_BASE);

$result = $db->single( $query );

foreach($result as $key => $task){
	//echo date("Ymd", $task['deadlineDate']) . ":";
	//echo date("Ymd") . "<br />";
	//echo $task['deadlineDate'];
	if(date("Ymd", $task['deadlineDate']) == (date("Ymd")+1) ){
		$task['deadlineDate'] = "<b>Today</b>";
	} elseif(date("Ymd", $task['deadlineDate']) < date("Ymd")){
		$task['deadlineDate'] = "<span style=\"color:red; font-weight:bold\">".date("M j", $task['deadlineDate'])."</span>";
	} else {
		$task['deadlineDate'] = date("M j", $task['deadlineDate']);
	}
	$output[$key] = array($task['itemId'], $task['title'], $task['deadlineDate'], $task['pName'], $task['firstName'], floor($task['status']));
}

echo json_encode($output);

?>

