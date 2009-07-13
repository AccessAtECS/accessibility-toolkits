var win;

notesGrid = function(){

	var formatTemplate = [
		'URL: <a href="{URL}" target="_blank">{Name}</a><br/>',
		'Who posted this: {User}<br/>',
		'Comments: {comments}<br/>',
		'Added: {Added}'
	];

	var urlTpl = new Ext.Template(formatTemplate);

    var columns = [
        {header: "User", width: 75, sortable: true, dataIndex: 'User'},
        {header: "Name", width: 350, sortable: true, dataIndex: 'Name'},
        {header: "URL", hidden: true, sortable: true, dataIndex: 'URL'},
        {header: "comments", hidden: true, sortable: true, dataIndex: 'comments'},
        {header: "Added", width: 100, sortable: true, dataIndex: 'Added'}
    ];
 

 
	var triggerRefresh = function(button,event){
		notesDataStore.load();
	};    
    
    notesGrid.superclass.constructor.call(this, {
    	store : notesDataStore,
		columns: columns,
		sm: new Ext.grid.RowSelectionModel({singleSelect: true}),
        viewConfig:{forceFit:true},
        height:250,
        renderTo: document.body,
        tbar:[{
            text:'Add URL',
            tooltip:'Add a new URL to list',
            iconCls:'x-icon-newlink',
            handler: function(){

		        if(!win){
		            win = new Ext.Window({
		                layout:'fit',
		                width:400,
		                height:250,
		                closeAction:'hide',
		                plain: true,
		                title: 'Share new link...',
		
		                items: new Ext.FormPanel({
					        labelWidth: 120,
					        id: 'urlSaver',
					        url:'/system/saveUrl.php',
					        bodyStyle:'padding:5px 5px 0',
					        width: 300,
					        defaults: {width: 230},
					        defaultType: 'textfield',
					
					        items: [{
					                fieldLabel: 'Who are you',
					                name: 'username',
					                allowBlank:false
					            },{
					            	fieldLabel: 'Site Name',
					            	name:'name',
					            	allowBlank:false
					            },{
					                fieldLabel: 'URL',
					                name: 'url',
					                allowBlank:false
					            },{
					            	fieldLabel: 'Phrase',
					            	name: 'phrase',
					            	allowBlank:false
					            }, new Ext.form.TextArea({
					                fieldLabel: 'Comments',
					                name: 'comments',
					                allowBlank:false
					            })
					        ],
					
					        buttons: [{
					            text: 'Save',
					            handler: buttonHandler
					        },{
					            text: 'Cancel',
					            handler: function(){
					                win.hide();
					            }            
					        }]
					    })
		            });
		        }
		        win.show(this);


            }
        },{
            text:'Refresh',
            tooltip:'Refresh data',
            iconCls:'x-icon-refresh',
            handler: triggerRefresh        	
        }]      
   });

	this.getSelectionModel().on('rowselect', function(sm, rowIdx, r) {
		var detailPanel = Ext.getCmp('detailPanel');
		urlTpl.overwrite(detailPanel.body, r.data);
	});
	
	 var buttonHandler = function(button, event) {
	 	Ext.getCmp('urlSaver').form.submit({ waitMsg:'Saving Data...', success:formSubmitSuccess, failure:formSubmitFailure });
	 };  
	  
	 var formSubmitSuccess = function(form, action) {
	 	alert("success");
	 }
	 
	 var formSubmitFailure = function(form,action){
	 
	    if (action.failureType === Ext.form.Action.CONNECT_FAILURE) {
	        Ext.Msg.alert('Error',
	            'Status:'+action.response.status+': '+
	            action.response.statusText);
	    }
	    
	    if(action.failureType == Ext.form.Action.CLIENT_INVALID){
	    	Ext.Msg.alert("Error", "Please fill in all the fields in the form.");
	    }
	 
	 	var result = Ext.util.JSON.decode(action.response.responseText);
	 	Ext.Msg.alert("Error", "Error, server responded: " + result.message);
	 	
	 }
	
}

Ext.extend(notesGrid, Ext.grid.GridPanel);
