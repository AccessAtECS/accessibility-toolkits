svnUpdates = function(){

    var columns = [
        {header: "Title", width: 280, sortable: true, dataIndex: 'Title'},
        {header: "User", width: 75, sortable: true, dataIndex: 'User'},
        {header: "Updated", width: 85, sortable: true, dataIndex: 'Updated'}
    ];
    
    
    svnUpdates.superclass.constructor.call(this, {
    	store : new Ext.data.Store({
	        reader: new Ext.data.ArrayReader({}, [
                   {name: 'Title'},
                   {name: 'User'},
                   {name: 'Updated'}
              ]),
           	url: '/system/svnFeed.php',
	        autoLoad: true,
	    }),
		columns: columns,
		viewConfig:{forceFit:true},
        height:250,
        width:600,
        renderTo: document.body,
        tbar:[{
            text:'Browse',
            tooltip:'Browse Repository',
            iconCls:'x-icon-svndetails',
            handler: function(){
            	window.location = 'http://code.google.com/p/accessibility-toolkits/source/browse/';
            }
        },
        {
        	text: 'Issues',
        	tooltip: 'Browse Issues',
        	iconCls: 'x-icon-exclamation',
        	handler: function(){
            	window.location = 'http://code.google.com/p/accessibility-toolkits/issues/list';
            }
        },
        {
        	text: 'Wiki',
        	tooltip: 'Browse Wiki',
        	iconCls: 'x-icon-wiki',
        	handler: function(){
        		window.location = 'http://code.google.com/p/accessibility-toolkits/w/list';
        	}
        }],
   
   });

}

Ext.extend(svnUpdates, Ext.grid.GridPanel);