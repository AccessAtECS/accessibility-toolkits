// Data store for the notes service.
var notesDataStore = new Ext.data.Store({
    reader: new Ext.data.ArrayReader({}, [
           {name: 'User'},
           {name: 'Name'},
           {name: 'URL'},
           {name: 'comments'},
           {name: 'Added'}
      ]),
   	url: '/system/notesFeed.php',
    autoLoad: true,
});


// Data store for the tasks system.
var tasksDataStore = new Ext.data.Store({
        reader: new Ext.data.ArrayReader({}, [
               {name: 'taskID'},
               {name: 'title'},
               {name: 'deadline'},
               {name: 'project'},
               {name: 'leader'},
               {name: 'completion'}
          ]),
        url: '/system/tasksUpdate.php',
        autoLoad: true
    });