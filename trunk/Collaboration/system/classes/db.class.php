<?php
//////////////////////////////////////////////////////
// (c) Seb Skuse (seb@skuse-consulting.co.uk)       //
//                ss1706@ecs.soton.ac.uk			//
// A Class for abstracting MySQLi database          //
// functions to allow queueing and other functions. //
// Secures input from all user input.				//
// CV: 1.20.2 								        //
//////////////////////////////////////////////////////


class db extends mysqli {
	
	public $queries = array();
	protected $numQueries = 0;
	public $database;
	

	public function __construct($db_host, $db_username, $db_password, $db_database){
		$this->database = $db_database;
		parent::__construct($db_host, $db_username, $db_password, $db_database);
		parent::select_db($this->database);
	}

	public function __destruct(){
		parent::close();
	}

	public function queryCount(){
		return $this->numQueries;
	}

	public function scrub($input){
		return $this->real_escape_string($input);
	}


	// These functions are all custom implementations.
	// This allows us to build a query using arrays, rather than sending it SQL directly.

	/**
	 * Example: select(array("fURL", "feed_title"), "feeds", array(array("", "fID", $id)));
	 * select fURL and feed_title from feeds where fID is $id.
	 * @ $fields = array list of fields that you want to select.
	 * @ $table = string of the table you want to select in the current database.
	 * @ $conditions = 2d array. Second level arrays contain three items - argument, column and data. Argument is ignored for the first item (obviously). Can be for example AND, OR, etc. Column is the string for the column name and data is the data that you want to match.
	 * @ $additionals = not required. Any additional bits of SQL you wish to have after the common bit.
	*/

	public function select($fields = array(), $table, $conditions = array(), $additionals = ""){
		// Start with the SELECT statement.
		$out = "SELECT ";
		// For each of the fields add them in here after the SELECT statement.
		foreach($fields as $field){
			$out .= $this->real_escape_string($field) . " ,";
		}

		// Remove trailing comma, then add the source database to the SQL statement.
		$out = rtrim($out, ",") . "FROM `" . $this->database . "`.`" . $table . "` WHERE ";

		// For each of the conditions write them into the SQL variable.
		$i = 0;
		foreach($conditions as $value){
			if($i != 0){
				$out .= $value[0] . " ";
			}
			$out .=  $value[1] . " ='" . $this->real_escape_string($value[2]) . "' ";
			$i++;
		}
		// Trim trailing space, add any additionals.
		$out = rtrim($out, " ") . " " . $additionals . ";";
		// Push the query to the class array queries.
		array_push($this->queries, $out);
		return $out;
	}


	/**
	 * Example: insert(array("fID"=> "NULL", "uID" => $uID, "fURL"=>$feedURL, "feed_title"=>$image_title, "feed_description"=>$feed_description, "last_refreshed"=>date('l dS F Y h:i A')), "feeds");
	 * insert a new record into feeds where fID is null, uID is $uID, fURL is $feedURL, feed_title is $image_title, feed_description is $feed_description and last_refreshed is date('l dS F Y h:i A');
	 * @ $dataArr = array list with keys of fields that you want to put in with their data.
	 * @ $table = string of the table you want to select in the current database.
	 * @ $additionals = not required. Any additional bits of SQL you wish to have after the common bit.
	*/

	public function insert($dataArr = array(), $table, $additionals = ""){
		// Start with the INSERT INTO statement, with the database stored in the class variable and then the table that the user has passed to us.
		$out = "INSERT INTO `" . $this->database . "`.`" . $table . "` (";
		// For each of the keys in the dataArr output them here, seperated by commas into the $out variable.
		foreach(array_keys($dataArr) as $key){
			$out .= "`" . $this->real_escape_string($key) . "`,";
		}

		// Remove the trailing comma, close the bracket and start the VALUES section.
		$out = rtrim($out, ",") . ") VALUES(";
		// For each of the array values output in the same order that we did with the keys so that they match up.
		// Note, if it is a number or NULL then we shouldnt really have quotes around it.
		foreach(array_values($dataArr) as $value){
			if(is_string($value) == true){
				if(strtoupper($value) != "NULL"){
					$out .= "'" . $this->real_escape_string($value) . "',";
				} else {
					$out .= $this->real_escape_string($value) . ",";
				}
			} else {
				$out .= $this->real_escape_string($value) . ",";
			}
		}
		// Trim the trailing comma off, close the brackets then add the additionals.
		$out = rtrim($out, ",") . ")" . $additionals . ";";
		// Push the query to the class array queries.
		array_push($this->queries, $out);
		return $out;
	}


	/**
	 * Example: update(array("last_refreshed" => date('l dS F Y h:i A')), "feeds", array(array("", "fURL", $_POST['fURL']), array("AND", "uID", $_SESSION['uID'])));
	 * update a record's last_refreshed field with date('l dS F Y h:i A') in the table feeds where fURL is $_POST['fURL'] and uUD is the same as $_SESSION['uID']
	 * @ $updateFLDS = array list with keys of fields that you want to update in with their data.
	 * @ $table = string of the table you want to select in the current database.
	 * @ $fields = 2d array. Second level arrays contain three items - argument, column and data. Argument is ignored for the first item (obviously). Can be for example AND, OR, etc. Column is the string for the column name and data is the data that you want to match.
	 * @ $additionals = not required. Any additional bits of SQL you wish to have after the common bit.
	*/

	public function update($updateFLDS = array(), $table, $fields = array(), $additionals = ""){
		// Start with the UPDATE statement, with the database that we are connected to and the table at the end.
		$out = "UPDATE `" . $this->database . "`.`" . $table . "` SET ";

		// For each update field output to the string in the format $key = '$data',. This will allow multiple fields to be updated.
		foreach($updateFLDS as $key => $value){
			$out .= $key . " ='" . $this->real_escape_string($value) . "', ";
		}

		// Remove trailing comma and space and append the WHERE clause.
		$out = rtrim($out, ", ") . " WHERE ";

		// Append all of the conditional fields to the end of the statement that the user has added.
		$i = 0;
		foreach($fields as $value){
			if($i != 0){
				$out .= $value[0] . " ";
			}
			$out .= $value[1] . " ='" . $this->real_escape_string($value[2]) . "' ";
			$i++;
		}
		// Remove trailing spaces and add the additionals variable to the end of the statement.
		$out = rtrim($out, " ") . " " . $additionals . ";";
		// Push the query to the class array queries.
		array_push($this->queries, $out);
		return $out;
	}


	/**
	 * Example: delete("feeds", array(array("", "fID", $_POST['feedid'])));
	 * delete a record from feeds where fID is the same as $_POST['feedid']
	 * @ $table = string of the table you want to select in the current database.
	 * @ $fields = 2d array. Second level arrays contain three items - argument, column and data. Argument is ignored for the first item (obviously). Can be for example AND, OR, etc. Column is the string for the column name and data is the data that you want to match.
	 * @ $additionals = not required. Any additional bits of SQL you wish to have after the common bit.
	*/

	public function delete($table, $fields = array(), $additionals = ""){
		// Start with the DELETE FROM statement, with the database and table appended afterwards. Follow with the WHERE clause...
		$out = "DELETE FROM `" . $this->database . "`.`" . $table . "` WHERE ";
		$i = 0;

		// For each of the conditional fields that the user has entered append them to the SQL string.
		foreach($fields as $value){
			if($i != 0){
				$out .= $value[0] . " ";
			}
			$out .= $value[1] . " ='" . $this->real_escape_string($value[2]) . "' ";
			$i++;
		}
		// Remove trailing whitespace and add the additionals variable to the end of the SQL.
		$out = rtrim($out, " ") . " " . $additionals . ";";
		// Push the query to the class array queries.
		array_push($this->queries, $out);
	}
		
	
	public function single($query){
		$res = parent::query($query);
		if(mysqli_error($this)){ 
  			throw new exception( mysqli_error($this), mysqli_errno($this) ); 
		} 
			
		$out = array();
		$x = 0;
		if(is_bool($res) == true) {
				$out[$i] = "";
		} else {
        	while ( $row = $res->fetch_assoc() ) {
				$out[$x] = $row;
				$x++;
			}	
		}
		return $out;
	}
	
	public function queuedQuery($query){
		array_push($this->queries, $query);
		return $query;
	}	
	
	
	public function runBatch(){
		// Create a new array for the output.
		$this->numQueries += count($this->queries);
		$out = array();
		$i = 0;
		// Ping the server and re-establish the connection if it has been dropped.
		parent::ping();
		// For each query...
		foreach($this->queries as $query){
			// Run the query.
			//echo $query;
			$res = parent::query($query, MYSQLI_USE_RESULT);
			if(mysqli_error($this)){ 
      			throw new exception(mysqli_error($this), mysqli_errno($this)); 
    		}

			$x = 0;
			// Append the results into a 3d array in $out.
			//echo $res;
			if(is_bool($res) == true) {
				$out[$i] = "";
			} else {
            	while ( $row = $res->fetch_assoc() ) {
					$out[$i][$x] = $row;
					$x++;
				}
			}
			$i++;
		}
		$this->queries = array();
		// Return the output to the caller.
		return $out;
	}	
	
}

?>