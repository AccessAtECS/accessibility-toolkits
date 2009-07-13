TaskGrid = function(){

    var columns = [
        {id:'taskID', hidden:true, dataIndex: 'taskID'},
        {header: "Title", width: 280, sortable: true, dataIndex: 'title'},
        {header: "Deadline", width: 75, sortable: true, dataIndex: 'deadline'},
        {header: "Project", width: 75, sortable: true, dataIndex: 'project'},
        {header: "Allocated To", width: 85, sortable: true, dataIndex: 'leader'},
        {header: "% Complete", width: 85, sortable: true, dataIndex: 'completion'}
    ];

	var triggerRefresh = function(button,event){
		tasksDataStore.load();
	};
	


    var tGrid = TaskGrid.superclass.constructor.call(this, {
        store: tasksDataStore,
        columns: columns,
        height:250,
        width:600,
        viewConfig:{forceFit:true},
        tbar:[{
            text:'Add Task',
            tooltip:'Add a new task',
            iconCls:'x-icon-addtask',
            handler: function(){
            	window.location = 'tasks/';
            }
        },
        {
        	text: 'Refresh',
        	tooltip: 'Refresh data',
        	iconCls: 'x-icon-refresh',
        	handler: triggerRefresh
        }],

        renderTo: document.body,
		listeners:{
			'celldblclick': function(grid, rowIdx, columnIdx, evt){
				var dsr = tasksDataStore.getAt(rowIdx).get('taskID');	
				//console.dir(dsr);
				window.location = '/tasks/index.php?rssId=' + dsr + '&tab=desc&elogin=1';
			}
		}
		
    });


}

Ext.extend(TaskGrid, Ext.grid.GridPanel);