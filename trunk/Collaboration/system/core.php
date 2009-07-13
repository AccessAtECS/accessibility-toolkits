<?php
error_reporting(E_ALL);

define('SVN_UPDATES_FEED', "http://code.google.com/feeds/p/accessibility-toolkits/updates/basic");

define('TASKS_DB', 'tasks');

function __autoload($class_name) {
	$path = dirname(__FILE__) . "/classes/" . $class_name . ".class.php";
    if(file_exists($path) == true) require_once($path);
}

function secureInclude(){
	if( isset($_GET['page']) == false ) $_GET['page'] = "home";
	
	$filtered = filter_input(INPUT_GET, 'page', FILTER_VALIDATE_REGEXP, array('options'=>array("regexp"=>'/^[a-zA-Z]+$/')));
	
	$filename = "presentation/templates/" . $filtered . ".html";
	
	if( file_exists($filename) && is_readable($filename) ) {
		return $filtered;
	} else {
		return "error";
	}
}


?>