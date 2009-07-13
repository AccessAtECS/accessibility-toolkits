Ext.onReady(function() {
	Ext.QuickTips.init();
    
    var Google_html = "<form id=\"g_search\" action=\"http://www.google.co.uk/search\" method=\"GET\" name=\"gs\"> <input type=\"text\" title=\"Search\" maxlength=\"2048\" size=\"41\" id=\"q\" name=\"q\"/> <input type=\"submit\" value=\"Google Search\" style=\"margin: 0pt 2px 0pt 5px;\" name=\"btnG\"/></form>";
    
    // create some portlet tools using built in Ext tool ids
    var tools = [{
        id:'gear',
        handler: function(){
            Ext.Msg.alert('Message', 'The Settings tool was clicked.');
        }
    },{
        id:'close',
        handler: function(e, target, panel){
            panel.ownerCt.remove(panel, true);
        }
    }];

    var viewport = new Ext.Viewport({
        layout:'fit',
        items:[{
            xtype: 'grouptabpanel',
    		tabWidth: 130,
    		activeGroup: 0,
    		items: [{
    			mainItem: 1,
    			items: [{
    				title: 'Task List',
                    layout: 'fit',
                    iconCls: 'x-icon-tasks',
                    tabTip: 'Tasks',
                    style: 'padding: 10px;',
    				items: [new TaskGrid()]
    			}, 
                {
                    xtype: 'portal',
                    title: 'Dashboard',
                    tabTip: 'Dashboard tabtip',
                    items:[{
                    	columnWidth:1,
                    	style:'padding:10px 10px 0',
                    	items:[{
                    		title:'Google Search',
                    		layout:'fit',
                    		html:Google_html
                    	}]
                    },
                    {
                        columnWidth:.70,
                        style:'padding:0 0 10px 10px',
                        items:[{
                            title: 'Tasks',
                            layout:'fit',
                            items: new TaskGrid()
                        }]
                    },{
                        columnWidth:.30,
                        style:'padding:0 10px',
                        items:[{
                            title: 'SVN Updates',
                            layout: 'fit',
                            items: new svnUpdates()
                        }]
                    },{
                        columnWidth:1,
                        style:'padding:0 10px',
                        items:[{
                            title: 'Recent Shared Links',
                            items:[
                            	new notesGrid(),
                            	{
									id: 'detailPanel',
									region: 'center',
									bodyStyle: {
										padding: '7px',
										height: '60px',
									},
									html: 'Please select a link to see additional details.'
								}]
                        }]
                    }]                    
                }, {
    				title: 'Shared Links',
                    iconCls: 'x-icon-links',
                    tabTip: 'Shared Links',
                    style: 'padding: 10px;',
					layout: 'fit',
    				items:[
                    	new notesGrid(),
                    	{
							id: 'detailPanelBig',
							region: 'center',
							bodyStyle: {
								padding: '7px',
								height: '60px',
							},
							html: 'Please select a link to see additional details.'
						
					}]	
    			}, {
    				title: 'SVN Detail',
                    iconCls: 'x-icon-svndetails',
                    tabTip: 'Users tabtip',
                    style: 'padding: 10px;',
    				html: ''		
    			}]
            }, {
            	expanded: true,
            	items: [{
            		title: 'Projects',
            		iconCls: 'x-icon-projects',
            		tabTip: 'Projects',
            		style: 'padding: 10px;',
            		html: ''
            	}]
            },
            {
                expanded: true,
                items: [{
                    title: 'Resources',
                    iconCls: 'x-icon-configuration',
                    tabTip: 'Configuration tabtip',
                    style: 'padding: 10px;',
                    html: '' 
                }, {
                    title: 'Google Code',
                    iconCls: 'x-icon-gcode',
                    tabTip: 'Templates tabtip',
                    style: 'padding: 10px;'
                },
                {
                    title: 'TaskFreak',
                    iconCls: 'x-icon-taskfreak',
                    tabTip: 'Templates tabtip',
                    style: 'padding: 10px;',
                    html: ''
                },
                {
    				title: 'Shared Files',
                    iconCls: 'x-icon-shared',
                    tabTip: 'Subscriptions tabtip',
                    style: 'padding: 10px;',
					layout: 'fit',
    				items: [{
						xtype: 'tabpanel',
						activeTab: 1,
						items: [{
							title: 'Nested Tabs',
							html: ''
						}]	
					}]	
    			},
                {
                    title: 'Google Search',
                    iconCls: 'x-icon-search',
                    tabTip: 'Templates tabtip',
                    style: 'padding: 10px;',
                    html: ''
                }]
            }]
		}]
    });
    
    Ext.get("q").focus();
    
});
