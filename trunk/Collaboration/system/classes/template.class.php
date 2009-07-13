<?php

class template {	

	/**
	 * @author [Seb Skuse]
	 * @copyright 2008
	 */	
	
	private $sourceTemplate;
	private $source;
	
	
	public function __construct($sourcefile){
		$file = "presentation/templates/" . $sourcefile . ".html";
		if(file_exists($file) == true){
			$this->sourceTemplate = file_get_contents($file);
			$this->source = $this->sourceTemplate;
		} else {
			throw new Exception("Template source file not found!");
		}
	}
	
	// Replace a variable with content in the template.
	public function replace($var, $fragment){
		if(is_object( $fragment ) == true && get_class($fragment) == get_class($this) ){
			$this->sourceTemplate = str_ireplace("{" . strtolower($var) . "}", $fragment->out(), $this->sourceTemplate);
		} else {
			$this->sourceTemplate = str_ireplace("{" . strtolower($var) . "}", $fragment, $this->sourceTemplate);
		}
	}
	
	// Replace an array of variables with an array of content.
	public function replaceAll(array $data){
		foreach($data as $from => $to){
			$this->replace($from, $to);
		}		
	}
	
	// Replace with HTML content stored in the filesystem.
	public function replaceWithStatic($var, $template, $path = ""){
		if($template == "") $template = "home";
		$fileStr = "templates/" . $path . $template . ".html";
		if(file_exists($fileStr) == true){
			$this->sourceTemplate = str_ireplace("{" . strtolower($var) . "}", file_get_contents($fileStr), $this->sourceTemplate);
		} else {
			throw new Exception("Template file not found!");
		}
	}
	
	// Reset back to the tenplate original.
	public function reset(){
		$this->sourceTemplate = $this->source;
	}
	
	// Return template in current state
	public function out(){
		return $this->sourceTemplate;
	}
}

?>