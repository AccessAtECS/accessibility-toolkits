<?php
require_once("core.php");

$svnData = new atomfeed(SVN_UPDATES_FEED);
	
echo json_encode( $svnData->returnFeed( format::updates() ) );
	

?>