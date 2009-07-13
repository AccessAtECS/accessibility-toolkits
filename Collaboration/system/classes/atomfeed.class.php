<?php
class atomfeed {

	private $xmlData;
	private $out;

	public function __construct($uri){
		$this->xmlData = new SimpleXmlElement($uri, NULL, true);
		//echo "<p>" . file_get_contents($uri) . "</p>";
	}
	
	public function returnFeed($format){
		$i = 0;
		foreach($this->xmlData->entry as $feedItem){
			$uri = (string) $feedItem->link['href'];		
			$title = (string) $feedItem->title;
			$author = (string) $feedItem->author->name;
			$content = (string) $feedItem->content;
			$updated = (string) $feedItem->updated;
			
			
			$output[$i] = array($content, $author, date("M j", strtotime($updated) ) );
			$i++;
		}
		
		$this->out = $output;
		return $this->returnOut();
	}
	
	public function returnOut(){
		return $this->out;
	}

}

class format {
	public function updates(){
	
	}

}
?>